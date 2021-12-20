namespace WindowsFormsApp1
{
    partial class FrmRandomiz
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupPerevirMM = new System.Windows.Forms.GroupBox();
            this.dtAnswerMM = new System.Windows.Forms.DataGridView();
            this.numLastElemMM = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numFirstElemMM = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupExitMM = new System.Windows.Forms.GroupBox();
            this.checkInfMM = new System.Windows.Forms.CheckBox();
            this.numVMM = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtBXMM = new System.Windows.Forms.TextBox();
            this.btnClearMM = new System.Windows.Forms.Button();
            this.btnCheckMM = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupEnterMM = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnToCalcMM = new System.Windows.Forms.Button();
            this.dtGridMinMax = new System.Windows.Forms.DataGridView();
            this.numGameCount = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnNextNP = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numPorogZn = new System.Windows.Forms.NumericUpDown();
            this.dtNeimanPirs = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.numGameCountNP = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupPerevirMM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAnswerMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLastElemMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstElemMM)).BeginInit();
            this.groupExitMM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupEnterMM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMinMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorogZn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNeimanPirs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCountNP)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 796);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupPerevirMM);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.groupExitMM);
            this.tabPage1.Controls.Add(this.groupEnterMM);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1016, 761);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Мінімаксний критерій";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // groupPerevirMM
            // 
            this.groupPerevirMM.Controls.Add(this.dtAnswerMM);
            this.groupPerevirMM.Controls.Add(this.numLastElemMM);
            this.groupPerevirMM.Controls.Add(this.label3);
            this.groupPerevirMM.Controls.Add(this.numFirstElemMM);
            this.groupPerevirMM.Controls.Add(this.label1);
            this.groupPerevirMM.Controls.Add(this.btnNext);
            this.groupPerevirMM.Location = new System.Drawing.Point(445, 112);
            this.groupPerevirMM.Name = "groupPerevirMM";
            this.groupPerevirMM.Size = new System.Drawing.Size(567, 574);
            this.groupPerevirMM.TabIndex = 9;
            this.groupPerevirMM.TabStop = false;
            this.groupPerevirMM.Text = "Параметри для перевірки";
            this.groupPerevirMM.Visible = false;
            // 
            // dtAnswerMM
            // 
            this.dtAnswerMM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtAnswerMM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAnswerMM.Location = new System.Drawing.Point(98, 128);
            this.dtAnswerMM.Name = "dtAnswerMM";
            this.dtAnswerMM.RowHeadersWidth = 51;
            this.dtAnswerMM.RowTemplate.Height = 24;
            this.dtAnswerMM.Size = new System.Drawing.Size(367, 368);
            this.dtAnswerMM.TabIndex = 11;
            // 
            // numLastElemMM
            // 
            this.numLastElemMM.DecimalPlaces = 2;
            this.numLastElemMM.Location = new System.Drawing.Point(379, 85);
            this.numLastElemMM.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numLastElemMM.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numLastElemMM.Name = "numLastElemMM";
            this.numLastElemMM.Size = new System.Drawing.Size(120, 27);
            this.numLastElemMM.TabIndex = 9;
            this.numLastElemMM.ValueChanged += new System.EventHandler(this.numLastElemMM_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Введіть останній елемент матриці";
            // 
            // numFirstElemMM
            // 
            this.numFirstElemMM.DecimalPlaces = 2;
            this.numFirstElemMM.Location = new System.Drawing.Point(379, 42);
            this.numFirstElemMM.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numFirstElemMM.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numFirstElemMM.Name = "numFirstElemMM";
            this.numFirstElemMM.Size = new System.Drawing.Size(120, 27);
            this.numFirstElemMM.TabIndex = 7;
            this.numFirstElemMM.ValueChanged += new System.EventHandler(this.numFirstElemMM_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введіть перший елемент матриці";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(420, 512);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(139, 48);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Перевірити";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(7, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(958, 89);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Для запуску калькулятору введіть кількість рядків та стовпців матриці виграшу 1го" +
    " гравця. Після відображення таблиці внесіть в неї відповідні дані для подальших " +
    "розрахунків. ";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupExitMM
            // 
            this.groupExitMM.Controls.Add(this.checkInfMM);
            this.groupExitMM.Controls.Add(this.numVMM);
            this.groupExitMM.Controls.Add(this.label8);
            this.groupExitMM.Controls.Add(this.textBox3);
            this.groupExitMM.Controls.Add(this.label7);
            this.groupExitMM.Controls.Add(this.textBox4);
            this.groupExitMM.Controls.Add(this.txtBXMM);
            this.groupExitMM.Controls.Add(this.btnClearMM);
            this.groupExitMM.Controls.Add(this.btnCheckMM);
            this.groupExitMM.Controls.Add(this.chart1);
            this.groupExitMM.Location = new System.Drawing.Point(445, 112);
            this.groupExitMM.Name = "groupExitMM";
            this.groupExitMM.Size = new System.Drawing.Size(565, 642);
            this.groupExitMM.TabIndex = 6;
            this.groupExitMM.TabStop = false;
            this.groupExitMM.Text = "Вихідні дані";
            this.groupExitMM.Visible = false;
            // 
            // checkInfMM
            // 
            this.checkInfMM.AutoSize = true;
            this.checkInfMM.Location = new System.Drawing.Point(17, 448);
            this.checkInfMM.Name = "checkInfMM";
            this.checkInfMM.Size = new System.Drawing.Size(166, 24);
            this.checkInfMM.TabIndex = 27;
            this.checkInfMM.Text = "безліч роз`язків";
            this.checkInfMM.UseVisualStyleBackColor = true;
            // 
            // numVMM
            // 
            this.numVMM.DecimalPlaces = 2;
            this.numVMM.Location = new System.Drawing.Point(63, 539);
            this.numVMM.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numVMM.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.numVMM.Name = "numVMM";
            this.numVMM.Size = new System.Drawing.Size(120, 27);
            this.numVMM.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(18, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 27);
            this.label8.TabIndex = 25;
            this.label8.Text = "v =";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(11, 488);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(543, 33);
            this.textBox3.TabIndex = 24;
            this.textBox3.Text = "Введіть ціну гри:";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(13, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "X =";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(6, 337);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(548, 49);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "Введіть оптимальний вектор Х (компоненти вводити з двома знаками після коми та че" +
    "рез пробіл)";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBXMM
            // 
            this.txtBXMM.Location = new System.Drawing.Point(62, 403);
            this.txtBXMM.Name = "txtBXMM";
            this.txtBXMM.Size = new System.Drawing.Size(492, 27);
            this.txtBXMM.TabIndex = 23;
            // 
            // btnClearMM
            // 
            this.btnClearMM.Location = new System.Drawing.Point(344, 586);
            this.btnClearMM.Name = "btnClearMM";
            this.btnClearMM.Size = new System.Drawing.Size(215, 46);
            this.btnClearMM.TabIndex = 22;
            this.btnClearMM.Text = "Закінчити перевірку";
            this.btnClearMM.UseVisualStyleBackColor = true;
            // 
            // btnCheckMM
            // 
            this.btnCheckMM.Location = new System.Drawing.Point(6, 584);
            this.btnCheckMM.Name = "btnCheckMM";
            this.btnCheckMM.Size = new System.Drawing.Size(215, 48);
            this.btnCheckMM.TabIndex = 21;
            this.btnCheckMM.Text = "Перевірити себе";
            this.btnCheckMM.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(11, 26);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(548, 308);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupEnterMM
            // 
            this.groupEnterMM.Controls.Add(this.label2);
            this.groupEnterMM.Controls.Add(this.btnToCalcMM);
            this.groupEnterMM.Controls.Add(this.dtGridMinMax);
            this.groupEnterMM.Controls.Add(this.numGameCount);
            this.groupEnterMM.Location = new System.Drawing.Point(7, 112);
            this.groupEnterMM.Name = "groupEnterMM";
            this.groupEnterMM.Size = new System.Drawing.Size(432, 544);
            this.groupEnterMM.TabIndex = 5;
            this.groupEnterMM.TabStop = false;
            this.groupEnterMM.Text = "Вхідні дані";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Введіть кількість рядків:";
            // 
            // btnToCalcMM
            // 
            this.btnToCalcMM.Location = new System.Drawing.Point(287, 490);
            this.btnToCalcMM.Name = "btnToCalcMM";
            this.btnToCalcMM.Size = new System.Drawing.Size(139, 48);
            this.btnToCalcMM.TabIndex = 12;
            this.btnToCalcMM.Text = "Далі";
            this.btnToCalcMM.UseVisualStyleBackColor = true;
            this.btnToCalcMM.Click += new System.EventHandler(this.btnToCalcMM_Click);
            // 
            // dtGridMinMax
            // 
            this.dtGridMinMax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridMinMax.Location = new System.Drawing.Point(29, 93);
            this.dtGridMinMax.Name = "dtGridMinMax";
            this.dtGridMinMax.RowHeadersWidth = 51;
            this.dtGridMinMax.RowTemplate.Height = 24;
            this.dtGridMinMax.Size = new System.Drawing.Size(375, 368);
            this.dtGridMinMax.TabIndex = 6;
            // 
            // numGameCount
            // 
            this.numGameCount.Location = new System.Drawing.Point(270, 49);
            this.numGameCount.Name = "numGameCount";
            this.numGameCount.Size = new System.Drawing.Size(120, 27);
            this.numGameCount.TabIndex = 14;
            this.numGameCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1016, 761);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Критерій Неймана-Пірса";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.Gray;
            this.textBox2.Location = new System.Drawing.Point(8, 10);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(952, 89);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Для запуску калькулятору введіть кількість ігор(рядків матриці виграшу), контроль" +
    "ований стан і порогове значення. Після відображення таблиці внесіть в неї відпов" +
    "ідні дані для подальших розрахунків. ";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chart2);
            this.groupBox3.Controls.Add(this.btnNextNP);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(444, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 526);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вихідні дані";
            // 
            // chart2
            // 
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(18, 28);
            this.chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(498, 353);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            // 
            // btnNextNP
            // 
            this.btnNextNP.Location = new System.Drawing.Point(377, 471);
            this.btnNextNP.Name = "btnNextNP";
            this.btnNextNP.Size = new System.Drawing.Size(139, 49);
            this.btnNextNP.TabIndex = 4;
            this.btnNextNP.Text = "Далі";
            this.btnNextNP.UseVisualStyleBackColor = true;
            this.btnNextNP.Click += new System.EventHandler(this.btnNextNP_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.numPorogZn);
            this.groupBox4.Controls.Add(this.dtNeimanPirs);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.numGameCountNP);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(6, 105);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(432, 524);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вхідні дані";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(34, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Порогове значення: ";
            // 
            // numPorogZn
            // 
            this.numPorogZn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPorogZn.Location = new System.Drawing.Point(251, 83);
            this.numPorogZn.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numPorogZn.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.numPorogZn.Name = "numPorogZn";
            this.numPorogZn.Size = new System.Drawing.Size(120, 27);
            this.numPorogZn.TabIndex = 7;
            this.numPorogZn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtNeimanPirs
            // 
            this.dtNeimanPirs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtNeimanPirs.Location = new System.Drawing.Point(19, 140);
            this.dtNeimanPirs.Name = "dtNeimanPirs";
            this.dtNeimanPirs.RowHeadersWidth = 51;
            this.dtNeimanPirs.RowTemplate.Height = 24;
            this.dtNeimanPirs.Size = new System.Drawing.Size(375, 368);
            this.dtNeimanPirs.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(34, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Введіть кількість ігор: ";
            // 
            // numGameCountNP
            // 
            this.numGameCountNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numGameCountNP.Location = new System.Drawing.Point(251, 26);
            this.numGameCountNP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGameCountNP.Name = "numGameCountNP";
            this.numGameCountNP.Size = new System.Drawing.Size(120, 27);
            this.numGameCountNP.TabIndex = 2;
            this.numGameCountNP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGameCountNP.ValueChanged += new System.EventHandler(this.numGameCountNP_ValueChanged);
            // 
            // FrmRandomiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 794);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmRandomiz";
            this.Text = "Калькулятор рандомізованних прикладів";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRandomiz_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupPerevirMM.ResumeLayout(false);
            this.groupPerevirMM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAnswerMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLastElemMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstElemMM)).EndInit();
            this.groupExitMM.ResumeLayout(false);
            this.groupExitMM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupEnterMM.ResumeLayout(false);
            this.groupEnterMM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMinMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorogZn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNeimanPirs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCountNP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupExitMM;
        private System.Windows.Forms.GroupBox groupEnterMM;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNextNP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPorogZn;
        private System.Windows.Forms.DataGridView dtNeimanPirs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numGameCountNP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataGridView dtGridMinMax;
        private System.Windows.Forms.NumericUpDown numGameCount;
        private System.Windows.Forms.GroupBox groupPerevirMM;
        private System.Windows.Forms.DataGridView dtAnswerMM;
        private System.Windows.Forms.NumericUpDown numLastElemMM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numFirstElemMM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnToCalcMM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkInfMM;
        private System.Windows.Forms.NumericUpDown numVMM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtBXMM;
        private System.Windows.Forms.Button btnClearMM;
        private System.Windows.Forms.Button btnCheckMM;
    }
}