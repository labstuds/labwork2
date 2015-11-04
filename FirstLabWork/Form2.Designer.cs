namespace FirstLabWork
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetIntervalSeriesTable = new System.Windows.Forms.Button();
            this.calculateGroupedSeries = new System.Windows.Forms.Button();
            this.calculateChars = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.characteristicsLabel = new System.Windows.Forms.Label();
            this.rNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.showGraphicsButton = new System.Windows.Forms.Button();
            this.cbGraphKind = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нормальныйЗаконToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показательныйЗаконToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdLaplas = new System.Windows.Forms.OpenFileDialog();
            this.ofdHi = new System.Windows.Forms.OpenFileDialog();
            this.dgvHi = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tbK = new System.Windows.Forms.TextBox();
            this.tbHiObs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvIntervals = new System.Windows.Forms.DataGridView();
            this.LeftBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveInterval = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvGroupedSeries = new System.Windows.Forms.DataGridView();
            this.X_star = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_i_star = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.cbAlphaValues = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.rNumber)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupedSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Таблица с интервальным рядом распределения частот\r\n";
            // 
            // btnGetIntervalSeriesTable
            // 
            this.btnGetIntervalSeriesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetIntervalSeriesTable.Location = new System.Drawing.Point(218, 297);
            this.btnGetIntervalSeriesTable.Name = "btnGetIntervalSeriesTable";
            this.btnGetIntervalSeriesTable.Size = new System.Drawing.Size(338, 23);
            this.btnGetIntervalSeriesTable.TabIndex = 5;
            this.btnGetIntervalSeriesTable.Text = "Извлечь интервальный ряд распределения частот";
            this.btnGetIntervalSeriesTable.UseVisualStyleBackColor = true;
            this.btnGetIntervalSeriesTable.Click += new System.EventHandler(this.button1_Click);
            // 
            // calculateGroupedSeries
            // 
            this.calculateGroupedSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calculateGroupedSeries.Location = new System.Drawing.Point(218, 326);
            this.calculateGroupedSeries.Name = "calculateGroupedSeries";
            this.calculateGroupedSeries.Size = new System.Drawing.Size(338, 23);
            this.calculateGroupedSeries.TabIndex = 6;
            this.calculateGroupedSeries.Text = "Рассчитать группированный ряд относительных частот";
            this.calculateGroupedSeries.UseVisualStyleBackColor = true;
            this.calculateGroupedSeries.Click += new System.EventHandler(this.calculateGroupedSeries_Click);
            // 
            // calculateChars
            // 
            this.calculateChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calculateChars.Location = new System.Drawing.Point(218, 355);
            this.calculateChars.Name = "calculateChars";
            this.calculateChars.Size = new System.Drawing.Size(338, 23);
            this.calculateChars.TabIndex = 7;
            this.calculateChars.Text = "Рассчитать числовые характерстики";
            this.calculateChars.UseVisualStyleBackColor = true;
            this.calculateChars.Click += new System.EventHandler(this.calculateChars_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Группированный ряд относительных частот";
            // 
            // characteristicsLabel
            // 
            this.characteristicsLabel.AutoSize = true;
            this.characteristicsLabel.Location = new System.Drawing.Point(227, 56);
            this.characteristicsLabel.Name = "characteristicsLabel";
            this.characteristicsLabel.Size = new System.Drawing.Size(309, 13);
            this.characteristicsLabel.TabIndex = 10;
            this.characteristicsLabel.Text = "Здесь будут отображены значения характеристик выборки";
            // 
            // rNumber
            // 
            this.rNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rNumber.Location = new System.Drawing.Point(12, 358);
            this.rNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rNumber.Name = "rNumber";
            this.rNumber.Size = new System.Drawing.Size(136, 20);
            this.rNumber.TabIndex = 11;
            this.rNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "R";
            // 
            // showGraphicsButton
            // 
            this.showGraphicsButton.Location = new System.Drawing.Point(385, 171);
            this.showGraphicsButton.Name = "showGraphicsButton";
            this.showGraphicsButton.Size = new System.Drawing.Size(171, 23);
            this.showGraphicsButton.TabIndex = 22;
            this.showGraphicsButton.Text = "Построить";
            this.showGraphicsButton.UseVisualStyleBackColor = true;
            this.showGraphicsButton.Click += new System.EventHandler(this.showGraphicsButton_Click);
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
            this.cbGraphKind.Location = new System.Drawing.Point(216, 171);
            this.cbGraphKind.Name = "cbGraphKind";
            this.cbGraphKind.Size = new System.Drawing.Size(163, 21);
            this.cbGraphKind.TabIndex = 21;            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Построение графиков и эмпирической функции распределения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Работа с рядами и их характеристиками";
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.helpButton.Location = new System.Drawing.Point(175, 355);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(37, 23);
            this.helpButton.TabIndex = 25;
            this.helpButton.Text = "?";
            this.helpButton.UseVisualStyleBackColor = true;            
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem,
            this.проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem
            // 
            this.загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem.Name = "загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem";
            this.загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem.Size = new System.Drawing.Size(170, 20);
            this.загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem.Text = "Загрузить таблицу Лапласа";
            this.загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem.Click += new System.EventHandler(this.загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem_Click);
            // 
            // проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem
            // 
            this.проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нормальныйЗаконToolStripMenuItem,
            this.показательныйЗаконToolStripMenuItem,
            this.загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem});
            this.проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem.Name = "проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem";
            this.проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem.Text = "Проверка гипотез";
            // 
            // нормальныйЗаконToolStripMenuItem
            // 
            this.нормальныйЗаконToolStripMenuItem.Name = "нормальныйЗаконToolStripMenuItem";
            this.нормальныйЗаконToolStripMenuItem.Size = new System.Drawing.Size(536, 22);
            this.нормальныйЗаконToolStripMenuItem.Text = "Проверить гипотезу о нормальном законе распределения по критерию Пирсона";
            this.нормальныйЗаконToolStripMenuItem.Click += new System.EventHandler(this.нормальныйЗаконToolStripMenuItem_Click);
            // 
            // показательныйЗаконToolStripMenuItem
            // 
            this.показательныйЗаконToolStripMenuItem.Name = "показательныйЗаконToolStripMenuItem";
            this.показательныйЗаконToolStripMenuItem.Size = new System.Drawing.Size(536, 22);
            this.показательныйЗаконToolStripMenuItem.Text = "Проверить гипотезу о показательном законе распределения по критерию Пирсона";
            this.показательныйЗаконToolStripMenuItem.Click += new System.EventHandler(this.показательныйЗаконToolStripMenuItem_Click);
            // 
            // загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem
            // 
            this.загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem.Name = "загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem";
            this.загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem.Size = new System.Drawing.Size(536, 22);
            this.загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem.Text = "Загрузить критические точки распределения Хи квадрат";
            this.загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem.Click += new System.EventHandler(this.загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem_Click);
            // 
            // dgvHi
            // 
            this.dgvHi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHi.Location = new System.Drawing.Point(753, 56);
            this.dgvHi.Name = "dgvHi";
            this.dgvHi.ReadOnly = true;
            this.dgvHi.Size = new System.Drawing.Size(345, 322);
            this.dgvHi.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(789, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Критические точки распределения Хи квадрат";
            // 
            // tbK
            // 
            this.tbK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbK.Location = new System.Drawing.Point(398, 212);
            this.tbK.Name = "tbK";
            this.tbK.ReadOnly = true;
            this.tbK.Size = new System.Drawing.Size(158, 20);
            this.tbK.TabIndex = 29;
            // 
            // tbHiObs
            // 
            this.tbHiObs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbHiObs.Location = new System.Drawing.Point(398, 238);
            this.tbHiObs.Name = "tbHiObs";
            this.tbHiObs.ReadOnly = true;
            this.tbHiObs.Size = new System.Drawing.Size(158, 20);
            this.tbHiObs.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Число степеней свободы k";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Критерий Пирсона наблюдаемый";
            // 
            // dgvIntervals
            // 
            this.dgvIntervals.AllowUserToAddRows = false;
            this.dgvIntervals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntervals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LeftBorder,
            this.RightBorder,
            this.N});
            this.dgvIntervals.Location = new System.Drawing.Point(12, 57);
            this.dgvIntervals.MultiSelect = false;
            this.dgvIntervals.Name = "dgvIntervals";
            this.dgvIntervals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIntervals.Size = new System.Drawing.Size(198, 263);
            this.dgvIntervals.TabIndex = 33;
            // 
            // LeftBorder
            // 
            this.LeftBorder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LeftBorder.HeaderText = "X_i";
            this.LeftBorder.Name = "LeftBorder";
            this.LeftBorder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RightBorder
            // 
            this.RightBorder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RightBorder.HeaderText = "X_i+1";
            this.RightBorder.Name = "RightBorder";
            this.RightBorder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // N
            // 
            this.N.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.N.HeaderText = "n";
            this.N.Name = "N";
            this.N.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnRemoveInterval
            // 
            this.btnRemoveInterval.Enabled = false;
            this.btnRemoveInterval.Location = new System.Drawing.Point(130, 325);
            this.btnRemoveInterval.Name = "btnRemoveInterval";
            this.btnRemoveInterval.Size = new System.Drawing.Size(80, 23);
            this.btnRemoveInterval.TabIndex = 35;
            this.btnRemoveInterval.Text = "Удалить ряд";
            this.btnRemoveInterval.UseVisualStyleBackColor = true;
            this.btnRemoveInterval.Click += new System.EventHandler(this.btnRemoveInterval_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 325);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 23);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "Добавить ряд";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvGroupedSeries
            // 
            this.dgvGroupedSeries.AllowUserToAddRows = false;
            this.dgvGroupedSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupedSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X_star,
            this.m_i_star});
            this.dgvGroupedSeries.Location = new System.Drawing.Point(562, 56);
            this.dgvGroupedSeries.Name = "dgvGroupedSeries";
            this.dgvGroupedSeries.ReadOnly = true;
            this.dgvGroupedSeries.Size = new System.Drawing.Size(185, 322);
            this.dgvGroupedSeries.TabIndex = 37;
            // 
            // X_star
            // 
            this.X_star.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.X_star.HeaderText = "x*";
            this.X_star.Name = "X_star";
            this.X_star.ReadOnly = true;
            // 
            // m_i_star
            // 
            this.m_i_star.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.m_i_star.HeaderText = "m*";
            this.m_i_star.Name = "m_i_star";
            this.m_i_star.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Уровень значимости alpha";
            // 
            // cbAlphaValues
            // 
            this.cbAlphaValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlphaValues.Enabled = false;
            this.cbAlphaValues.FormattingEnabled = true;
            this.cbAlphaValues.Location = new System.Drawing.Point(398, 267);
            this.cbAlphaValues.Name = "cbAlphaValues";
            this.cbAlphaValues.Size = new System.Drawing.Size(158, 21);
            this.cbAlphaValues.TabIndex = 39;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 390);
            this.Controls.Add(this.cbAlphaValues);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvGroupedSeries);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemoveInterval);
            this.Controls.Add(this.dgvIntervals);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbHiObs);
            this.Controls.Add(this.tbK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvHi);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.showGraphicsButton);
            this.Controls.Add(this.cbGraphKind);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rNumber);
            this.Controls.Add(this.characteristicsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calculateChars);
            this.Controls.Add(this.calculateGroupedSeries);
            this.Controls.Add(this.btnGetIntervalSeriesTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1126, 429);
            this.MinimumSize = new System.Drawing.Size(1126, 429);
            this.Name = "Form2";
            this.Text = "Обработка интервального ряда частот";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rNumber)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupedSeries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetIntervalSeriesTable;
        private System.Windows.Forms.Button calculateGroupedSeries;
        private System.Windows.Forms.Button calculateChars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label characteristicsLabel;
        private System.Windows.Forms.NumericUpDown rNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button showGraphicsButton;
        private System.Windows.Forms.ComboBox cbGraphKind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdLaplas;
        private System.Windows.Forms.ToolStripMenuItem проверитьГипотезуОЗаконеРаспределенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нормальныйЗаконToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показательныйЗаконToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdHi;
        private System.Windows.Forms.DataGridView dgvHi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbK;
        private System.Windows.Forms.TextBox tbHiObs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvIntervals;
        private System.Windows.Forms.Button btnRemoveInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvGroupedSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_star;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_i_star;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbAlphaValues;

    }
}