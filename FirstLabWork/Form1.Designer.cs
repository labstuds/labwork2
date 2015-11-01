namespace FirstLabWork
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpNums = new System.Windows.Forms.TabPage();
            this.gbCounting = new System.Windows.Forms.GroupBox();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.showGraphicsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGraphKind = new System.Windows.Forms.ComboBox();
            this.intervalsCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.seriesType = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.UITable = new System.Windows.Forms.DataGridView();
            this.tpSampleMean = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.SampleMeanTB = new System.Windows.Forms.TextBox();
            this.tpDispersion = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.DispersionTB = new System.Windows.Forms.TextBox();
            this.tpSampleMeanSquare = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.SampleMeanSquareTB = new System.Windows.Forms.TextBox();
            this.tpSamplingPoints = new System.Windows.Forms.TabPage();
            this.nudR = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CentralSamplingPointTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.InitialSamplingPointTB = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdLoadDataInput = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.работаСГотовымРядомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tpNums.SuspendLayout();
            this.gbCounting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalsCountUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UITable)).BeginInit();
            this.tpSampleMean.SuspendLayout();
            this.tpDispersion.SuspendLayout();
            this.tpSampleMeanSquare.SuspendLayout();
            this.tpSamplingPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpNums);
            this.tabControl1.Controls.Add(this.tpSampleMean);
            this.tabControl1.Controls.Add(this.tpDispersion);
            this.tabControl1.Controls.Add(this.tpSampleMeanSquare);
            this.tabControl1.Controls.Add(this.tpSamplingPoints);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 408);
            this.tabControl1.TabIndex = 0;
            // 
            // tpNums
            // 
            this.tpNums.Controls.Add(this.gbCounting);
            this.tpNums.Controls.Add(this.showGraphicsButton);
            this.tpNums.Controls.Add(this.label1);
            this.tpNums.Controls.Add(this.cbGraphKind);
            this.tpNums.Controls.Add(this.intervalsCountUpDown);
            this.tpNums.Controls.Add(this.label8);
            this.tpNums.Controls.Add(this.seriesType);
            this.tpNums.Controls.Add(this.statusLabel);
            this.tpNums.Controls.Add(this.button1);
            this.tpNums.Controls.Add(this.UITable);
            this.tpNums.Location = new System.Drawing.Point(4, 22);
            this.tpNums.Name = "tpNums";
            this.tpNums.Padding = new System.Windows.Forms.Padding(3);
            this.tpNums.Size = new System.Drawing.Size(707, 382);
            this.tpNums.TabIndex = 0;
            this.tpNums.Text = "Ряды и числовые характеристики";
            this.tpNums.UseVisualStyleBackColor = true;
            this.tpNums.Click += new System.EventHandler(this.tpNums_Click);
            // 
            // gbCounting
            // 
            this.gbCounting.Controls.Add(this.rtbLogs);
            this.gbCounting.Location = new System.Drawing.Point(9, 243);
            this.gbCounting.Name = "gbCounting";
            this.gbCounting.Size = new System.Drawing.Size(691, 133);
            this.gbCounting.TabIndex = 21;
            this.gbCounting.TabStop = false;
            this.gbCounting.Text = "Ход вычислений";
            // 
            // rtbLogs
            // 
            this.rtbLogs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogs.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rtbLogs.Location = new System.Drawing.Point(3, 16);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(685, 114);
            this.rtbLogs.TabIndex = 0;
            this.rtbLogs.Text = "";
            // 
            // showGraphicsButton
            // 
            this.showGraphicsButton.Location = new System.Drawing.Point(253, 200);
            this.showGraphicsButton.Name = "showGraphicsButton";
            this.showGraphicsButton.Size = new System.Drawing.Size(171, 23);
            this.showGraphicsButton.TabIndex = 20;
            this.showGraphicsButton.Text = "Построить";
            this.showGraphicsButton.UseVisualStyleBackColor = true;
            this.showGraphicsButton.Click += new System.EventHandler(this.showGraphicsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Вид графика";
            // 
            // cbGraphKind
            // 
            this.cbGraphKind.AutoCompleteCustomSource.AddRange(new string[] {
            "Гистограмма",
            "Полигон"});
            this.cbGraphKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGraphKind.FormattingEnabled = true;
            this.cbGraphKind.Items.AddRange(new object[] {
            "Полигон",
            "Гистограмма",
            "Функция распределения"});
            this.cbGraphKind.Location = new System.Drawing.Point(84, 202);
            this.cbGraphKind.Name = "cbGraphKind";
            this.cbGraphKind.Size = new System.Drawing.Size(163, 21);
            this.cbGraphKind.TabIndex = 18;
            // 
            // intervalsCountUpDown
            // 
            this.intervalsCountUpDown.Location = new System.Drawing.Point(197, 173);
            this.intervalsCountUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.intervalsCountUpDown.Name = "intervalsCountUpDown";
            this.intervalsCountUpDown.Size = new System.Drawing.Size(227, 20);
            this.intervalsCountUpDown.TabIndex = 17;
            this.intervalsCountUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Количество интервалов разбиения";
            // 
            // seriesType
            // 
            this.seriesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seriesType.FormattingEnabled = true;
            this.seriesType.Items.AddRange(new object[] {
            "Статистический ряд",
            "Статистический ряд относительных частот",
            "Интервальный статистический ряд частот",
            "Группированный ряд относительных частот"});
            this.seriesType.Location = new System.Drawing.Point(436, 173);
            this.seriesType.Name = "seriesType";
            this.seriesType.Size = new System.Drawing.Size(265, 21);
            this.seriesType.TabIndex = 15;
            this.seriesType.SelectedIndexChanged += new System.EventHandler(this.seriesType_SelectedIndexChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(6, 226);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(492, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Здесь будет отображаться статус. Необходимо загрузить новую выборку. Нажмите Откр" +
    "ыть...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(435, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Рассчитать ряды";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UITable
            // 
            this.UITable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UITable.Location = new System.Drawing.Point(6, 0);
            this.UITable.Name = "UITable";
            this.UITable.ReadOnly = true;
            this.UITable.Size = new System.Drawing.Size(695, 150);
            this.UITable.TabIndex = 0;
            // 
            // tpSampleMean
            // 
            this.tpSampleMean.Controls.Add(this.pictureBox1);
            this.tpSampleMean.Controls.Add(this.label3);
            this.tpSampleMean.Controls.Add(this.SampleMeanTB);
            this.tpSampleMean.Location = new System.Drawing.Point(4, 22);
            this.tpSampleMean.Name = "tpSampleMean";
            this.tpSampleMean.Padding = new System.Windows.Forms.Padding(3);
            this.tpSampleMean.Size = new System.Drawing.Size(707, 382);
            this.tpSampleMean.TabIndex = 1;
            this.tpSampleMean.Text = "Среднее выборочное";
            this.tpSampleMean.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Среднее выборочное";
            // 
            // SampleMeanTB
            // 
            this.SampleMeanTB.BackColor = System.Drawing.SystemColors.Window;
            this.SampleMeanTB.Location = new System.Drawing.Point(310, 19);
            this.SampleMeanTB.Name = "SampleMeanTB";
            this.SampleMeanTB.ReadOnly = true;
            this.SampleMeanTB.Size = new System.Drawing.Size(163, 20);
            this.SampleMeanTB.TabIndex = 7;
            // 
            // tpDispersion
            // 
            this.tpDispersion.Controls.Add(this.pictureBox2);
            this.tpDispersion.Controls.Add(this.label4);
            this.tpDispersion.Controls.Add(this.DispersionTB);
            this.tpDispersion.Location = new System.Drawing.Point(4, 22);
            this.tpDispersion.Name = "tpDispersion";
            this.tpDispersion.Padding = new System.Windows.Forms.Padding(3);
            this.tpDispersion.Size = new System.Drawing.Size(707, 382);
            this.tpDispersion.TabIndex = 2;
            this.tpDispersion.Text = "Выборочная дисперсия";
            this.tpDispersion.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Выборочная дисперсия";
            // 
            // DispersionTB
            // 
            this.DispersionTB.BackColor = System.Drawing.SystemColors.Window;
            this.DispersionTB.Location = new System.Drawing.Point(338, 60);
            this.DispersionTB.Name = "DispersionTB";
            this.DispersionTB.ReadOnly = true;
            this.DispersionTB.Size = new System.Drawing.Size(163, 20);
            this.DispersionTB.TabIndex = 9;
            // 
            // tpSampleMeanSquare
            // 
            this.tpSampleMeanSquare.Controls.Add(this.pictureBox3);
            this.tpSampleMeanSquare.Controls.Add(this.label5);
            this.tpSampleMeanSquare.Controls.Add(this.SampleMeanSquareTB);
            this.tpSampleMeanSquare.Location = new System.Drawing.Point(4, 22);
            this.tpSampleMeanSquare.Name = "tpSampleMeanSquare";
            this.tpSampleMeanSquare.Padding = new System.Windows.Forms.Padding(3);
            this.tpSampleMeanSquare.Size = new System.Drawing.Size(707, 382);
            this.tpSampleMeanSquare.TabIndex = 3;
            this.tpSampleMeanSquare.Text = "Выборочное среднее квадратическое";
            this.tpSampleMeanSquare.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Выборочное среднее квадратическое";
            // 
            // SampleMeanSquareTB
            // 
            this.SampleMeanSquareTB.BackColor = System.Drawing.SystemColors.Window;
            this.SampleMeanSquareTB.Location = new System.Drawing.Point(211, 11);
            this.SampleMeanSquareTB.Name = "SampleMeanSquareTB";
            this.SampleMeanSquareTB.ReadOnly = true;
            this.SampleMeanSquareTB.Size = new System.Drawing.Size(163, 20);
            this.SampleMeanSquareTB.TabIndex = 11;
            // 
            // tpSamplingPoints
            // 
            this.tpSamplingPoints.Controls.Add(this.nudR);
            this.tpSamplingPoints.Controls.Add(this.label9);
            this.tpSamplingPoints.Controls.Add(this.label7);
            this.tpSamplingPoints.Controls.Add(this.CentralSamplingPointTB);
            this.tpSamplingPoints.Controls.Add(this.label6);
            this.tpSamplingPoints.Controls.Add(this.InitialSamplingPointTB);
            this.tpSamplingPoints.Location = new System.Drawing.Point(4, 22);
            this.tpSamplingPoints.Name = "tpSamplingPoints";
            this.tpSamplingPoints.Padding = new System.Windows.Forms.Padding(3);
            this.tpSamplingPoints.Size = new System.Drawing.Size(707, 382);
            this.tpSamplingPoints.TabIndex = 4;
            this.tpSamplingPoints.Text = "Выборочные моменты";
            this.tpSamplingPoints.UseVisualStyleBackColor = true;
            // 
            // nudR
            // 
            this.nudR.Location = new System.Drawing.Point(624, 12);
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(77, 20);
            this.nudR.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Порядок r";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Центральный выборочный момент порядка r";
            // 
            // CentralSamplingPointTB
            // 
            this.CentralSamplingPointTB.BackColor = System.Drawing.SystemColors.Window;
            this.CentralSamplingPointTB.Location = new System.Drawing.Point(247, 39);
            this.CentralSamplingPointTB.Name = "CentralSamplingPointTB";
            this.CentralSamplingPointTB.ReadOnly = true;
            this.CentralSamplingPointTB.Size = new System.Drawing.Size(163, 20);
            this.CentralSamplingPointTB.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Начальный выборочный момент порядка r";
            // 
            // InitialSamplingPointTB
            // 
            this.InitialSamplingPointTB.BackColor = System.Drawing.SystemColors.Window;
            this.InitialSamplingPointTB.Location = new System.Drawing.Point(247, 12);
            this.InitialSamplingPointTB.Name = "InitialSamplingPointTB";
            this.InitialSamplingPointTB.ReadOnly = true;
            this.InitialSamplingPointTB.Size = new System.Drawing.Size(163, 20);
            this.InitialSamplingPointTB.TabIndex = 23;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.работаСГотовымРядомToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(733, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(175, 20);
            this.открытьToolStripMenuItem.Text = "Открыть файл с выборкой...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // ofdLoadDataInput
            // 
            this.ofdLoadDataInput.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdLoadDataInput_FileOk);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FirstLabWork.Properties.Resources.ср_выборочное;
            this.pictureBox1.Location = new System.Drawing.Point(150, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FirstLabWork.Properties.Resources.disp;
            this.pictureBox2.Location = new System.Drawing.Point(43, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(613, 204);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FirstLabWork.Properties.Resources.отклонение;
            this.pictureBox3.Location = new System.Drawing.Point(6, 66);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(698, 221);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // работаСГотовымРядомToolStripMenuItem
            // 
            this.работаСГотовымРядомToolStripMenuItem.Name = "работаСГотовымРядомToolStripMenuItem";
            this.работаСГотовымРядомToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.работаСГотовымРядомToolStripMenuItem.Text = "Работа с готовым рядом";
            this.работаСГотовымРядомToolStripMenuItem.Click += new System.EventHandler(this.работаСГотовымРядомToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 436);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(749, 475);
            this.MinimumSize = new System.Drawing.Size(749, 475);
            this.Name = "Form1";
            this.Text = "Статистика";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpNums.ResumeLayout(false);
            this.tpNums.PerformLayout();
            this.gbCounting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.intervalsCountUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UITable)).EndInit();
            this.tpSampleMean.ResumeLayout(false);
            this.tpSampleMean.PerformLayout();
            this.tpDispersion.ResumeLayout(false);
            this.tpDispersion.PerformLayout();
            this.tpSampleMeanSquare.ResumeLayout(false);
            this.tpSampleMeanSquare.PerformLayout();
            this.tpSamplingPoints.ResumeLayout(false);
            this.tpSamplingPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpNums;
        private System.Windows.Forms.DataGridView UITable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdLoadDataInput;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox seriesType;
        private System.Windows.Forms.NumericUpDown intervalsCountUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button showGraphicsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGraphKind;
        private System.Windows.Forms.TabPage tpSampleMean;
        private System.Windows.Forms.TabPage tpDispersion;
        private System.Windows.Forms.TabPage tpSampleMeanSquare;
        private System.Windows.Forms.TabPage tpSamplingPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SampleMeanTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DispersionTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SampleMeanSquareTB;
        private System.Windows.Forms.NumericUpDown nudR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CentralSamplingPointTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox InitialSamplingPointTB;
        private System.Windows.Forms.GroupBox gbCounting;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolStripMenuItem работаСГотовымРядомToolStripMenuItem;
    }
}

