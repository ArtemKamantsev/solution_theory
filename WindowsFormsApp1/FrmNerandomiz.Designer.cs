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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNextNP = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numPorogZn = new System.Windows.Forms.NumericUpDown();
            this.dtNeimanPirs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numGameCountNP = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numColumn = new System.Windows.Forms.NumericUpDown();
            this.dtGridMinMax = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.numRow = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorogZn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNeimanPirs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCountNP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMinMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).BeginInit();
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
            this.groupBox2.Size = new System.Drawing.Size(482, 513);
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
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtGridMinMax);
            this.groupBox1.Controls.Add(this.numColumn);
            this.groupBox1.Controls.Add(this.numRow);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(9, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 513);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вхідні дані";
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
            this.label4.Location = new System.Drawing.Point(50, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Порогове значення: ";
            // 
            // numPorogZn
            // 
            this.numPorogZn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPorogZn.Location = new System.Drawing.Point(283, 80);
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
            this.dtNeimanPirs.Location = new System.Drawing.Point(36, 134);
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
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введіть кількість рядків: ";
            // 
            // numGameCountNP
            // 
            this.numGameCountNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numGameCountNP.Location = new System.Drawing.Point(283, 26);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Введіть кількість стовпців: ";
            // 
            // numColumn
            // 
            this.numColumn.Location = new System.Drawing.Point(288, 75);
            this.numColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numColumn.Name = "numColumn";
            this.numColumn.Size = new System.Drawing.Size(120, 27);
            this.numColumn.TabIndex = 10;
            this.numColumn.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numColumn.ValueChanged += new System.EventHandler(this.numColumn_ValueChanged);
            // 
            // dtGridMinMax
            // 
            this.dtGridMinMax.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtGridMinMax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridMinMax.Location = new System.Drawing.Point(41, 122);
            this.dtGridMinMax.Name = "dtGridMinMax";
            this.dtGridMinMax.RowHeadersWidth = 51;
            this.dtGridMinMax.RowTemplate.Height = 24;
            this.dtGridMinMax.Size = new System.Drawing.Size(367, 368);
            this.dtGridMinMax.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Введіть кількість рядків: ";
            // 
            // numRow
            // 
            this.numRow.Location = new System.Drawing.Point(288, 28);
            this.numRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRow.Name = "numRow";
            this.numRow.Size = new System.Drawing.Size(120, 27);
            this.numRow.TabIndex = 7;
            this.numRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRow.ValueChanged += new System.EventHandler(this.numRow_ValueChanged);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorogZn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNeimanPirs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGameCountNP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMinMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNext;
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
        private System.Windows.Forms.DataGridView dtNeimanPirs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numGameCountNP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numColumn;
        private System.Windows.Forms.DataGridView dtGridMinMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numRow;
    }
}