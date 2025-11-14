namespace TestOne
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.ProgressBar progressCpu;
        private System.Windows.Forms.ProgressBar progressRam;
        private System.Windows.Forms.ProgressBar progressDisk;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.Label lblDisk;
        private System.Windows.Forms.Label lblDiskActivity;
        private System.Windows.Forms.ListBox listDrives;
        private System.Windows.Forms.ListBox listNet;
        private System.Windows.Forms.Label lblNetTotal;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCpu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNet;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            progressCpu = new ProgressBar();
            progressRam = new ProgressBar();
            progressDisk = new ProgressBar();
            lblCpu = new Label();
            lblRam = new Label();
            lblDisk = new Label();
            lblDiskActivity = new Label();
            listDrives = new ListBox();
            listNet = new ListBox();
            lblNetTotal = new Label();
            lblLast = new Label();
            timerUpdate = new System.Windows.Forms.Timer(components);
            chartCpu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartRam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartNet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)chartCpu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartRam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartNet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // progressCpu
            // 
            progressCpu.Location = new Point(12, 29);
            progressCpu.Name = "progressCpu";
            progressCpu.Size = new Size(360, 23);
            progressCpu.TabIndex = 0;
            // 
            // progressRam
            // 
            progressRam.Location = new Point(12, 82);
            progressRam.Name = "progressRam";
            progressRam.Size = new Size(360, 23);
            progressRam.TabIndex = 1;
            // 
            // progressDisk
            // 
            progressDisk.Location = new Point(12, 135);
            progressDisk.Name = "progressDisk";
            progressDisk.Size = new Size(360, 23);
            progressDisk.TabIndex = 2;
            // 
            // lblCpu
            // 
            lblCpu.AutoSize = true;
            lblCpu.Location = new Point(12, 9);
            lblCpu.Name = "lblCpu";
            lblCpu.Size = new Size(41, 15);
            lblCpu.TabIndex = 3;
            lblCpu.Text = "CPU: -";
            // 
            // lblRam
            // 
            lblRam.AutoSize = true;
            lblRam.Location = new Point(12, 62);
            lblRam.Name = "lblRam";
            lblRam.Size = new Size(44, 15);
            lblRam.TabIndex = 4;
            lblRam.Text = "RAM: -";
            // 
            // lblDisk
            // 
            lblDisk.AutoSize = true;
            lblDisk.Location = new Point(12, 115);
            lblDisk.Name = "lblDisk";
            lblDisk.Size = new Size(52, 15);
            lblDisk.TabIndex = 5;
            lblDisk.Text = "DISCO: -";
            // 
            // lblDiskActivity
            // 
            lblDiskActivity.AutoSize = true;
            lblDiskActivity.Location = new Point(12, 161);
            lblDiskActivity.Name = "lblDiskActivity";
            lblDiskActivity.Size = new Size(99, 15);
            lblDiskActivity.TabIndex = 6;
            lblDiskActivity.Text = "Actividad disco: -";
            // 
            // listDrives
            // 
            listDrives.FormattingEnabled = true;
            listDrives.ItemHeight = 15;
            listDrives.Location = new Point(12, 180);
            listDrives.Name = "listDrives";
            listDrives.Size = new Size(360, 154);
            listDrives.TabIndex = 7;
            // 
            // listNet
            // 
            listNet.FormattingEnabled = true;
            listNet.ItemHeight = 15;
            listNet.Location = new Point(392, 180);
            listNet.Name = "listNet";
            listNet.Size = new Size(380, 154);
            listNet.TabIndex = 8;
            // 
            // lblNetTotal
            // 
            lblNetTotal.AutoSize = true;
            lblNetTotal.Location = new Point(392, 161);
            lblNetTotal.Name = "lblNetTotal";
            lblNetTotal.Size = new Size(38, 15);
            lblNetTotal.TabIndex = 9;
            lblNetTotal.Text = "Red: -";
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(12, 352);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(125, 15);
            lblLast.TabIndex = 10;
            lblLast.Text = "Última actualización: -";
            // 
            // chartCpu
            // 
            chartArea1.Name = "ChartArea1";
            chartCpu.ChartAreas.Add(chartArea1);
            chartCpu.Location = new Point(12, 375);
            chartCpu.Name = "chartCpu";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "CPU";
            chartCpu.Series.Add(series1);
            chartCpu.Size = new Size(250, 150);
            chartCpu.TabIndex = 2;
            // 
            // chartRam
            // 
            chartArea2.Name = "ChartArea1";
            chartRam.ChartAreas.Add(chartArea2);
            chartRam.Location = new Point(272, 375);
            chartRam.Name = "chartRam";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "RAM";
            chartRam.Series.Add(series2);
            chartRam.Size = new Size(250, 150);
            chartRam.TabIndex = 1;
            // 
            // chartNet
            // 
            chartArea3.Name = "ChartArea1";
            chartNet.ChartAreas.Add(chartArea3);
            chartNet.Location = new Point(532, 375);
            chartNet.Name = "chartNet";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "NET";
            chartNet.Series.Add(series3);
            chartNet.Size = new Size(240, 150);
            chartNet.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.arguedasonesplash;
            pictureBox1.Location = new Point(650, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(122, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            ClientSize = new Size(784, 541);
            Controls.Add(pictureBox1);
            Controls.Add(chartNet);
            Controls.Add(chartRam);
            Controls.Add(chartCpu);
            Controls.Add(lblLast);
            Controls.Add(lblNetTotal);
            Controls.Add(listNet);
            Controls.Add(listDrives);
            Controls.Add(lblDiskActivity);
            Controls.Add(lblDisk);
            Controls.Add(lblRam);
            Controls.Add(lblCpu);
            Controls.Add(progressDisk);
            Controls.Add(progressRam);
            Controls.Add(progressCpu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Monitor CPU / RAM / Disco / Red - TestOne  ArguedasOne";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)chartCpu).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartRam).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartNet).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
    }
}
