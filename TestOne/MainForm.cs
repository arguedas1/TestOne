using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace TestOne
{
    public partial class MainForm : Form
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter memCounter;
        private PerformanceCounter diskBytesPerSecCounter;

        private long prevNetworkBytes = 0;
        private DateTime prevNetworkTime;

        // per-interface prev bytes
        private Dictionary<string, long> prevBytesByInterface = new Dictionary<string, long>();

        // history buffers
        private Queue<double> cpuHistory = new Queue<double>();
        private Queue<double> memHistory = new Queue<double>();
        private Queue<double> netHistory = new Queue<double>();
        private const int HISTORY_MAX = 60;

        public MainForm()
        {
            InitializeComponent();
            InitializeCounters();

            prevNetworkTime = DateTime.UtcNow;
            prevNetworkBytes = GetTotalNetworkBytes();

            timerUpdate.Interval = 1000;
            timerUpdate.Tick += TimerUpdate_Tick;
            timerUpdate.Start();
        }

        private void InitializeCounters()
        {
            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                _ = cpuCounter.NextValue();
            }
            catch { cpuCounter = null; }

            try
            {
                memCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
                _ = memCounter.NextValue();
            }
            catch { memCounter = null; }

            try
            {
                diskBytesPerSecCounter = new PerformanceCounter("PhysicalDisk", "Disk Bytes/sec", "_Total");
                _ = diskBytesPerSecCounter.NextValue();
            }
            catch { diskBytesPerSecCounter = null; }
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            UpdateCpu();
            UpdateMemory();
            UpdateDisk();
            UpdateNetwork();
            UpdateCharts();
            lblLast.Text = $"Última actualización: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        }

        private void UpdateCpu()
        {
            float cpuPct = 0f;
            if (cpuCounter != null)
            {
                try { cpuPct = cpuCounter.NextValue(); }
                catch { cpuPct = 0f; }
            }
            progressCpu.Value = Clamp((int)Math.Round(cpuPct));
            lblCpu.Text = $"CPU: {cpuPct:0.0}%";
            EnqueueHistory(cpuHistory, cpuPct);
        }

        private void UpdateMemory()
        {
            float memPct = 0f;
            string memText = "-";
            try
            {
                if (memCounter != null) memPct = memCounter.NextValue();
                var ci = new ComputerInfo();
                ulong total = ci.TotalPhysicalMemory;
                ulong avail = ci.AvailablePhysicalMemory;
                double totalMb = total / 1024.0 / 1024.0;
                double availMb = avail / 1024.0 / 1024.0;
                double usedMb = totalMb - availMb;
                memText = $"RAM: {memPct:0.0}% — {usedMb:0} MB usados / {totalMb:0} MB";
            }
            catch { }
            progressRam.Value = Clamp((int)Math.Round(memPct));
            lblRam.Text = memText;
            EnqueueHistory(memHistory, memPct);
        }

        private void UpdateDisk()
        {
            try
            {
                var allDrives = DriveInfo.GetDrives().Where(d => d.IsReady).ToArray();
                listDrives.Items.Clear();
                double totalSize = 0;
                double totalFree = 0;
                foreach (var d in allDrives)
                {
                    long size = d.TotalSize;
                    long free = d.TotalFreeSpace;
                    totalSize += size;
                    totalFree += free;
                    double usedPct = (size - free) / size * 100.0;
                    listDrives.Items.Add($"{d.Name}  {usedPct:0.0}%  {BytesToReadable(size - free)} usados / {BytesToReadable(size)}");
                }
                double usedAllPct = 0;
                if (totalSize > 0) usedAllPct = (totalSize - totalFree) / totalSize * 100.0;
                progressDisk.Value = Clamp((int)Math.Round((float)usedAllPct));
                lblDisk.Text = $"DISCO (todos): {usedAllPct:0.0}% usados";

                if (diskBytesPerSecCounter != null)
                {
                    float bps = diskBytesPerSecCounter.NextValue();
                    lblDiskActivity.Text = $"Actividad disco: {BytesToReadable((long)bps)}/s";
                }
                else lblDiskActivity.Text = "Actividad disco: no disponible";
            }
            catch { lblDisk.Text = "DISCO: no disponible"; }
        }

        private void UpdateNetwork()
        {
            try
            {
                var now = DateTime.UtcNow;
                long totalBytes = GetTotalNetworkBytes();
                double seconds = (now - prevNetworkTime).TotalSeconds;
                double bytesPerSec = 0;
                if (seconds > 0) bytesPerSec = (totalBytes - prevNetworkBytes) / seconds;
                prevNetworkBytes = totalBytes;
                prevNetworkTime = now;

                lblNetTotal.Text = $"Red total: {BytesToReadable((long)bytesPerSec)}/s";
                EnqueueHistory(netHistory, Math.Round(bytesPerSec / 1024.0, 2)); // store KB/s for chart

                // per-interface speeds
                listNet.Items.Clear();
                var ifaces = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback);
                foreach (var ni in ifaces)
                {
                    try
                    {
                        var stats = ni.GetIPv4Statistics();
                        long cur = stats.BytesReceived + stats.BytesSent;
                        long prev = 0;
                        prevBytesByInterface.TryGetValue(ni.Id, out prev);
                        long delta = cur - prev;
                        double speedSec = delta / 1.0; // timer interval 1s
                        prevBytesByInterface[ni.Id] = cur;
                        listNet.Items.Add($"{ni.Name}  {(speedSec / 1024.0):0.0} KB/s");
                    }
                    catch { }
                }
            }
            catch { lblNetTotal.Text = "Red: no disponible"; }
        }

        private void UpdateCharts()
        {
            // CPU
            chartCpu.Series["CPU"].Points.Clear();
            foreach (var v in cpuHistory) chartCpu.Series["CPU"].Points.AddY(v);
            // MEM
            chartRam.Series["RAM"].Points.Clear();
            foreach (var v in memHistory) chartRam.Series["RAM"].Points.AddY(v);
            // NET
            chartNet.Series["NET"].Points.Clear();
            foreach (var v in netHistory) chartNet.Series["NET"].Points.AddY(v);
        }

        private void EnqueueHistory(Queue<double> q, double value)
        {
            q.Enqueue(value);
            if (q.Count > HISTORY_MAX) q.Dequeue();
        }

        private int Clamp(int v)
        {
            if (v < 0) return 0;
            if (v > 100) return 100;
            return v;
        }

        private long GetTotalNetworkBytes()
        {
            long total = 0;
            var nics = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback);
            foreach (var ni in nics)
            {
                try
                {
                    var s = ni.GetIPv4Statistics();
                    total += s.BytesReceived + s.BytesSent;
                }
                catch { }
            }
            return total;
        }

        private string BytesToReadable(long bytes)
        {
            if (bytes < 1024) return bytes + " B";
            double kb = bytes / 1024.0;
            if (kb < 1024) return $"{kb:0.0} KB";
            double mb = kb / 1024.0;
            if (mb < 1024) return $"{mb:0.0} MB";
            double gb = mb / 1024.0;
            return $"{gb:0.00} GB";
        }

        protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timerUpdate?.Stop();
            cpuCounter?.Dispose();
            memCounter?.Dispose();
            diskBytesPerSecCounter?.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
