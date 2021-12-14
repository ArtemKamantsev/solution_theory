namespace WindowsFormsApp1
{
    partial class FrmNerandomiz
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGridMinMax = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.numGameCount = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNextNP = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numPorogZn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numContrlSt = new System.Windows.Forms.NumericUpDown();
            this.dtNeimanPirs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numGameCountNP = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMinMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorogZn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrlSt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNeimanPirs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCountNP)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(983, 674);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(975, 639);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Мінімаксний критерій";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(9, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(958, 89);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Для запуску калькулятору введіть кількість ігор(рядків матриці виграшу). Після ві" +
    "дображення таблиці внесіть в неї відповідні дані для подальших розрахунків. ";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(485, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 496);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вихідні дані";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(337, 442);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(139, 48);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Далі";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGridMinMax);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numGameCount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(9, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 496);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вхідні дані";
            // 
            // dtGridMinMax
            // 
            this.dtGridMinMax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridMinMax.Location = new System.Drawing.Point(38, 93);
            this.dtGridMinMax.Name = "dtGridMinMax";
            this.dtGridMinMax.RowHeadersWidth = 51;
            this.dtGridMinMax.RowTemplate.Height = 24;
            this.dtGridMinMax.Size = new System.Drawing.Size(375, 368);
            this.dtGridMinMax.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(51, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введіть кількість ігор: ";
            // 
            // numGameCount
            // 
            this.numGameCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numGameCount.Location = new System.Drawing.Point(268, 38);
            this.numGameCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGameCount.Name = "numGameCount";
            this.numGameCount.Size = new System.Drawing.Size(120, 27);
            this.numGameCount.TabIndex = 2;
            this.numGameCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGameCount.ValueChanged += new System.EventHandler(this.numGameCount_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(975, 639);
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
            this.textBox2.Location = new System.Drawing.Point(9, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(952, 89);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Для запуску калькулятору введіть кількість ігор(рядків матриці виграшу), контроль" +
    "ований стан і порогове значення. Після відображення таблиці внесіть в неї відпов" +
    "ідні дані для подальших розрахунків. ";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNextNP);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(482, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 526);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вихідні дані";
            // 
            // btnNextNP
            // 
            this.btnNextNP.Location = new System.Drawing.Point(340, 471);
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
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.numContrlSt);
            this.groupBox4.Controls.Add(this.dtNeimanPirs);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.numGameCountNP);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(7, 107);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(459, 524);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вхідні дані";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(50, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Порогове значення: ";
            // 
            // numPorogZn
            // 
            this.numPorogZn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPorogZn.Location = new System.Drawing.Point(267, 98);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(50, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Контрольванний стан: ";
            // 
            // numContrlSt
            // 
            this.numContrlSt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numContrlSt.Location = new System.Drawing.Point(267, 62);
            this.numContrlSt.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numContrlSt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numContrlSt.Name = "numContrlSt";
            this.numContrlSt.Size = new System.Drawing.Size(120, 27);
            this.numContrlSt.TabIndex = 5;
            this.numContrlSt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtNeimanPirs
            // 
            this.dtNeimanPirs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtNeimanPirs.Location = new System.Drawing.Point(33, 133);
            this.dtNeimanPirs.Name = "dtNeimanPirs";
            this.dtNeimanPirs.RowHeadersWidth = 51;
            this.dtNeimanPirs.RowTemplate.Height = 24;
            this.dtNeimanPirs.Size = new System.Drawing.Size(375, 368);
            this.dtNeimanPirs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введіть кількість ігор: ";
            // 
            // numGameCountNP
            // 
            this.numGameCountNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numGameCountNP.Location = new System.Drawing.Point(267, 26);
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
            // FrmNerandomiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 673);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmNerandomiz";
            this.Text = "Калькулятор нерандомізованних прикладів";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNerandomiz_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMinMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorogZn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrlSt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNeimanPirs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCountNP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridView dtGridMinMax;
        private System.Windows.Forms.NumericUpDown numGameCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNextNP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPorogZn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numContrlSt;
        private System.Windows.Forms.DataGridView dtNeimanPirs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numGameCountNP;
    }
}