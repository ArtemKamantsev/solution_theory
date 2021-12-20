using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Text.Json;

namespace WindowsFormsApp1
{
    public partial class FrmNerandomiz : Form
    {
        public FrmNerandomiz()
        {
            InitializeComponent();

            listMaxMin = new List<List<double>>();
            listNeimPirs = new List<List<double>>();
            dataJson = new StringBuilder();
            result = new StringBuilder();
            indexesOptimal = new List<double>();
            resIndexes = new List<string>();
            indexesExcluded = new List<double>();
        }

        int n;
        int m = 2;
        List<List<double>> listMaxMin;
        List<List<double>> listNeimPirs;
        int porogZnach;
        bool isNull = true;
        StringBuilder dataJson;
        StringBuilder result;
        double resFirstElem;
        double resLastElem;
        List<double> indexesOptimal;
        List<string> resIndexes;
        double rightLoss;
        double loss;
        List<double> indexesExcluded;

        #region Критерий МиниМакс
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dtGridMinMax.AllowUserToAddRows = false;
            n = (int)numRow.Value;
            m = (int)numColumn.Value;

            ClearAllObjectsMM();
        }

        private void numRow_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numRow.Value;
            m = (int)numColumn.Value;

            ClearObjectsMM();
        }

        private void numColumn_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numRow.Value;
            m = (int)numColumn.Value;

            ClearObjectsMM();
        }
        private void btnToCalcMM_Click(object sender, EventArgs e)
        {
            isNull = false;
            foreach (DataGridViewRow row in dtGridMinMax.Rows)
            {
                IEnumerable<DataGridViewCell> cellsWithValusInRows = from DataGridViewCell cell in row.Cells
                                                                     where string.IsNullOrEmpty((string)cell.Value)
                                                                     select cell;

                if (cellsWithValusInRows != null && cellsWithValusInRows.Any())
                {
                    isNull = true;
                    MessageBox.Show("Заповніть матрицю!", "Warning!");
                    break;
                }
            }

            if (!isNull)
            {
                groupPerevirMM.Visible = true;
                groupEnterMM.Enabled = false;

                for (int i = 0; i < n; i++)
                {
                    listMaxMin.Add(new List<double>());
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        listMaxMin[i].Add(Convert.ToDouble(dtGridMinMax.Rows[i].Cells[j].Value));
                    }
                }

                GetResultFromPython("min-max", ref listMaxMin);
            }
        }

        bool isClicked = false;
        private void btnNext_Click(object sender, EventArgs e)
        {
            bool isRigth1, isRigth2;
            resFirstElem = (double)numFirstElemMM.Value;
            resLastElem = (double)numLastElemMM.Value;
            if (!isClicked)
            {
                isRigth1 = EqualDoubleForResult(numFirstElemMM, resFirstElem, listMaxMin[0][0]);
                isRigth2 = EqualDoubleForResult(numLastElemMM, resLastElem, listMaxMin[n - 1][m - 1]);
                if (isRigth1 && isRigth2)
                {
                    isClicked = true;
                    btnNext.Text = "Далі";
                    MakeMatrixAnswer(dtAnswerMM, n, m, listMaxMin);
                }
            }
            else
            {
                isClicked = false;
                btnNext.Text = "Перевірити";
                numFirstElemMM.BackColor = Color.White;
                numLastElemMM.BackColor = Color.White;
                groupExitMM.Visible = true;
                groupPerevirMM.Visible = false;

                MakeMatrixAnswer(dtGridMinMax, n, m, listMaxMin);
            }
        }
        private void numFirstElemMM_ValueChanged(object sender, EventArgs e)
        {
            numFirstElemMM.BackColor= Color.White;
        }
        private void numLastElemMM_ValueChanged(object sender, EventArgs e)
        {
            numLastElemMM.BackColor = Color.White;
        }
        private void btnCheckMM_Click(object sender, EventArgs e)
        {
            EqualListIndexes(txtBXMM, indexesOptimal);

            loss = Convert.ToDouble(numVMM.Value);
            _ = EqualDoubleForResult(numVMM, loss, rightLoss);

        }
        private void txtBXMM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && ch != 8 && ch != 44 && ch != 32)
            {
                e.Handled = true;
            }
        }
        private void numVMM_ValueChanged(object sender, EventArgs e)
        {
            numVMM.BackColor = Color.White;
        }
        private void btnClearMM_Click(object sender, EventArgs e)
        {
            ClearAllObjectsMM();
        }
       
        private void ClearObjectsMM()
        {
            dtGridMinMax.Rows.Clear();
            dtGridMinMax.Columns.Clear();

            for (int i = 0; i < m; i++)
            {
                dtGridMinMax.Columns.Add("B" + (i + 1), "b" + (i + 1));
            }
            dtGridMinMax.RowCount = n;
        }
        private void ClearAllObjectsMM()
        {
            groupPerevirMM.Visible = false;
            groupExitMM.Visible = false;
            groupEnterMM.Enabled = true;

            numFirstElemMM.Value = 0;
            numLastElemMM.Value = 0;
            txtBXMM.Text = "";
            numVMM.Value = 0;

            txtBXMM.Enabled = true;

            numFirstElemMM.BackColor = Color.White;
            numLastElemMM.BackColor = Color.White;
            txtBXMM.BackColor = Color.White;
            numVMM.BackColor = Color.White;

            dtGridMinMax.Rows.Clear();
            dtGridMinMax.Columns.Clear();
            dtAnswerMM.Rows.Clear();
            dtAnswerMM.Columns.Clear();

            for (int i = 0; i < m; i++)
            {
                dtGridMinMax.Columns.Add("B" + (i + 1), "b" + (i + 1));
            }
            dtGridMinMax.RowCount = n;

            listMaxMin.Clear();
        }
        #endregion

        #region Критерий Неймана-Пирса
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            dtNeimanPirs.AllowUserToAddRows = false;
            n = (int)numGameCountNP.Value;
            m = 2;

            ClearObjectsNP();
        }
        private void numGameCountNP_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numGameCountNP.Value;

            ClearObjectsNP();
        }
        private void btnToCalcNP_Click(object sender, EventArgs e)
        {
            isNull = false;
            foreach (DataGridViewRow row in dtNeimanPirs.Rows)
            {
                IEnumerable<DataGridViewCell> cellsWithValusInRows = from DataGridViewCell cell in row.Cells
                                                                     where string.IsNullOrEmpty((string)cell.Value)
                                                                     select cell;

                if (cellsWithValusInRows != null && cellsWithValusInRows.Any())
                {
                    isNull = true;
                    MessageBox.Show("Заповніть матрицю!", "Warning!");
                    break;
                }
            }

            if (!isNull)
            {
                groupPerevirNP.Visible = true;
                groupEnterNP.Enabled = false;

                porogZnach = (int)numPorogZn.Value;
                for (int i = 0; i < n; i++)
                {
                    listNeimPirs.Add(new List<double>());
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        listNeimPirs[i].Add(Convert.ToInt32(dtNeimanPirs.Rows[i].Cells[j].Value));
                    }
                }
                GetResultFromPython("neyman-pirson", ref listNeimPirs);
            }
        }
        private void numFirstElemNP_ValueChanged(object sender, EventArgs e)
        {
            numFirstElemNP.BackColor = Color.White;
        }
        private void numLastElemNP_ValueChanged(object sender, EventArgs e)
        {
            numLastElemNP.BackColor = Color.White;
        }
        private void btnNextNP_Click(object sender, EventArgs e)
        {
            bool isRigth1, isRigth2;
            resFirstElem = (double)numFirstElemNP.Value;
            resLastElem = (double)numLastElemNP.Value;
            if (!isClicked)
            {
                isRigth1 = EqualDoubleForResult(numFirstElemNP, resFirstElem, listNeimPirs[0][0]);
                isRigth2 = EqualDoubleForResult(numLastElemNP, resLastElem, listNeimPirs[n - 1][m - 1]);
                if (isRigth1 && isRigth2)
                {
                    isClicked = true;
                    btnNextNP.Text = "Далі";
                    MakeMatrixAnswer(dtAnswerNP, n, m, listNeimPirs);
                }
            }
            else
            {
                isClicked = false;
                btnNextNP.Text = "Перевірити";
                numFirstElemNP.BackColor = Color.White;
                numLastElemNP.BackColor = Color.White;
                groupExitNP.Visible = true;
                groupPerevirNP.Visible = false;

                MakeMatrixAnswer(dtNeimanPirs, n, m, listNeimPirs);
            }
        }
        private void btnCheckNP_Click(object sender, EventArgs e)
        {
            EqualListIndexes(txtXNP,indexesOptimal);
            EqualListIndexes(txtResExcluded, indexesExcluded);

            loss = Convert.ToDouble(numVNP.Value);
            _ = EqualDoubleForResult(numVNP, loss, rightLoss);
        }
        private void txtXNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBXMM_KeyPress(sender, e);
        }
        private void txtResExcluded_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 32 && ch != 8)
            {
                e.Handled = true;
            }
        }
        private void btnClearNP_Click(object sender, EventArgs e)
        {
            ClearAllObjectsNP();
        }
        private void ClearObjectsNP()
        {
            dtNeimanPirs.Rows.Clear();
            dtNeimanPirs.Columns.Clear();

            dtNeimanPirs.Columns.Add("B1", "b1");
            dtNeimanPirs.Columns.Add("B2", "b2");
            dtNeimanPirs.RowCount = n;

            listNeimPirs.Clear();
        }
        private void ClearAllObjectsNP()
        {
            groupPerevirNP.Visible = false;
            groupExitNP.Visible = false;
            groupEnterNP.Enabled = true;

            numFirstElemNP.Value = 0;
            numLastElemNP.Value = 0;
            txtXNP.Text = "";
            txtResExcluded.Text = "";
            numVNP.Value = 0;

            txtXNP.Enabled = true;

            numFirstElemNP.BackColor = Color.White;
            numLastElemNP.BackColor = Color.White;
            txtXNP.BackColor = Color.White;
            numVNP.BackColor = Color.White;
            txtResExcluded.BackColor = Color.White;

            dtNeimanPirs.Rows.Clear();
            dtNeimanPirs.Columns.Clear();
            dtAnswerNP.Rows.Clear();
            dtAnswerNP.Columns.Clear();

            dtNeimanPirs.Columns.Add("B1", "b1");
            dtNeimanPirs.Columns.Add("B2", "b2");
            dtNeimanPirs.RowCount = n;

            listNeimPirs.Clear();
        }
        #endregion
        public void GetResultFromPython(string method, ref List<List<double>> listToJson)
        {
            var json = JsonConvert.SerializeObject(listToJson);
            dataJson.Clear();
            result.Clear();
            if (method == "min-max")
            {
                dataJson.Append("{\"matrix\": " + json + "}");
            }
            else
            {
                dataJson.Append("{\"matrix\": " + json + ", \"critical_value\": " + porogZnach + "}");
            }

            result.Append(PythonInteractor.ReadPyhonFile(method, dataJson));

            dynamic stuff = JsonConvert.DeserializeObject(result.ToString());

            if (stuff.data == null)
                MessageBox.Show(stuff.exeption.ToString(), "Error:");
            else
            {
                stuff = JsonConvert.DeserializeObject(stuff.data.ToString());
                listToJson = JsonConvert.DeserializeObject<List<List<double>>>(stuff.matrix_loss.ToString());
                indexesOptimal = JsonConvert.DeserializeObject<List<double>>(stuff.indexes_optimal.ToString());
                for (int i = 0; i < indexesOptimal.Count; i++)
                {
                    indexesOptimal[i] += 1;
                }
                rightLoss = Convert.ToDouble(stuff.loss.ToString());

                if (method == "neyman-pirson")
                {
                    indexesExcluded = JsonConvert.DeserializeObject<List<double>>(stuff.indexes_excluded.ToString());
                    for (int i = 0; i < indexesExcluded.Count; i++)
                    {
                        indexesExcluded[i] += 1;
                    }
                }
            }
        }
        
        private void MakeMatrixAnswer(object sender, int n, int m, List<List<double>> list)
        {
            DataGridView dataGridView = sender as DataGridView;
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            for (int i = 0; i < m; i++)
            {
                dataGridView.Columns.Add("B" + (i + 1), "b" + (i + 1));
            }
            dataGridView.RowCount = n;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = list[i][j];
                }
            }
        }
        private bool EqualDoubleForResult(object sender, double res, double matr)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            if (Math.Abs(res-matr)>0.00000001)
            {
                numericUpDown.BackColor = Color.Red;
                return false;
            }
            else
            {
                numericUpDown.BackColor = Color.Green;
                return true;
            }
        }
        private void EqualListIndexes(object sender, List<double> listFromServ)
        {
            TextBox textBox = sender as TextBox;
            bool isEqualList = false;
            resIndexes = textBox.Text.Trim().Split().ToList();
            if (listFromServ.Count == resIndexes.Count)
            {
                for (int i = 0; i < resIndexes.Count; i++)
                {
                    if (Math.Abs(listFromServ[i]- Convert.ToDouble(resIndexes[i]))> 0.00000001)
                    {
                        isEqualList = false;
                    }
                    else
                    {
                        isEqualList = true;
                    }
                }
            }
            if (!isEqualList)
            {
                textBox.BackColor = Color.Red;
            }
            else
            {
                textBox.BackColor = Color.Green;
            }
        }
        private void FrmNerandomiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
        }

       
    }
}
