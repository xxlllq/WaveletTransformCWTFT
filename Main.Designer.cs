namespace WaveletTransformCWTFT
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scottPlotUC1 = new ScottPlot.ScottPlotUC();
            this.button1 = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scottPlotUC2 = new ScottPlot.ScottPlotUC();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sampleRateSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.octaveSelect = new System.Windows.Forms.ComboBox();
            this.scottPlotUC3 = new ScottPlot.ScottPlotUC();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.yaxisPictureBox = new System.Windows.Forms.PictureBox();
            this.xaxisPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yaxisPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xaxisPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // scottPlotUC1
            // 
            this.scottPlotUC1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scottPlotUC1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.scottPlotUC1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scottPlotUC1.Location = new System.Drawing.Point(-11, 177);
            this.scottPlotUC1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scottPlotUC1.Name = "scottPlotUC1";
            this.scottPlotUC1.Size = new System.Drawing.Size(652, 315);
            this.scottPlotUC1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "txt文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openFile);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(98, 48);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(391, 28);
            this.filePath.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(1, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1307, 13);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // scottPlotUC2
            // 
            this.scottPlotUC2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scottPlotUC2.Location = new System.Drawing.Point(687, 177);
            this.scottPlotUC2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scottPlotUC2.Name = "scottPlotUC2";
            this.scottPlotUC2.Size = new System.Drawing.Size(652, 315);
            this.scottPlotUC2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.filePath);
            this.groupBox2.Location = new System.Drawing.Point(23, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信号源";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sampleRateSelect);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.octaveSelect);
            this.groupBox3.Location = new System.Drawing.Point(625, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(548, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数";
            // 
            // sampleRateSelect
            // 
            this.sampleRateSelect.FormattingEnabled = true;
            this.sampleRateSelect.Items.AddRange(new object[] {
            "51200"});
            this.sampleRateSelect.Location = new System.Drawing.Point(93, 46);
            this.sampleRateSelect.Name = "sampleRateSelect";
            this.sampleRateSelect.Size = new System.Drawing.Size(121, 26);
            this.sampleRateSelect.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "倍频程";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "采样频率";
            // 
            // octaveSelect
            // 
            this.octaveSelect.FormattingEnabled = true;
            this.octaveSelect.Items.AddRange(new object[] {
            "4",
            "12",
            "24"});
            this.octaveSelect.Location = new System.Drawing.Point(380, 46);
            this.octaveSelect.Name = "octaveSelect";
            this.octaveSelect.Size = new System.Drawing.Size(121, 26);
            this.octaveSelect.TabIndex = 0;
            this.octaveSelect.SelectedIndexChanged += new System.EventHandler(this.octaveSelect_SelectedValueChanged);
            // 
            // scottPlotUC3
            // 
            this.scottPlotUC3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scottPlotUC3.Location = new System.Drawing.Point(-10, 500);
            this.scottPlotUC3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scottPlotUC3.Name = "scottPlotUC3";
            this.scottPlotUC3.Size = new System.Drawing.Size(653, 421);
            this.scottPlotUC3.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Location = new System.Drawing.Point(711, 519);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(631, 433);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // yaxisPictureBox
            // 
            this.yaxisPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yaxisPictureBox.Location = new System.Drawing.Point(649, 519);
            this.yaxisPictureBox.Name = "yaxisPictureBox";
            this.yaxisPictureBox.Size = new System.Drawing.Size(65, 432);
            this.yaxisPictureBox.TabIndex = 0;
            this.yaxisPictureBox.TabStop = false;
            // 
            // xaxisPictureBox
            // 
            this.xaxisPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.xaxisPictureBox.Location = new System.Drawing.Point(711, 958);
            this.xaxisPictureBox.Name = "xaxisPictureBox";
            this.xaxisPictureBox.Size = new System.Drawing.Size(631, 43);
            this.xaxisPictureBox.TabIndex = 0;
            this.xaxisPictureBox.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Location = new System.Drawing.Point(1359, 519);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(126, 435);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1506, 1050);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.xaxisPictureBox);
            this.Controls.Add(this.yaxisPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.scottPlotUC3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.scottPlotUC2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scottPlotUC1);
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小波分析";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yaxisPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xaxisPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ScottPlot.ScottPlotUC scottPlotUC1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private ScottPlot.ScottPlotUC scottPlotUC2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox octaveSelect;
        private System.Windows.Forms.ComboBox sampleRateSelect;
        private ScottPlot.ScottPlotUC scottPlotUC3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox yaxisPictureBox;
        private System.Windows.Forms.PictureBox xaxisPictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}