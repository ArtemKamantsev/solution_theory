using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class FrmRandomiz : Form
    {
        public FrmRandomiz()
        {
            InitializeComponent();

            listMaxMin = new List<List<double>>();
            listNeimPirs = new List<List<double>>();
            dataJson = new StringBuilder();
            result = new StringBuilder();
            solutionCounts = new StringBuilder();
        }

        int n;
        readonly int m = 2;
        List<List<double>> listMaxMin;
        List<List<double>> listNeimPirs;
        bool isNull = true;
        int porogZnach;
        StringBuilder dataJson;
        StringBuilder result;
        StringBuilder solutionCounts;

        double resFirstElem;
        double resLastElem;
        List<int> indexesConvexHull;
        List<double> X;

        List<string> resIndexes;
        double rightLoss;
        string isRightLossNull;
        double loss;
        List<double> indexesExcluded;

        #region Критерий МиниМакс
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dtGridMinMax.AllowUserToAddRows = false;
            n = (int)numGameCount.Value;

           ClearAllObjectsMM();
        }

        private void numGameCount_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numGameCount.Value;

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

                GetResultFromPythonMM();
            }
        }
        private void GetResultFromPythonMM()
        {
            var json = JsonConvert.SerializeObject(listMaxMin);
            dataJson.Clear();
            solutionCounts.Clear();
            result.Clear();
            dataJson.Append("{\"matrix\": " + json + "}");
            result.Append(PythonInteractor.ReadPyhonFile("min-max-randomized", dataJson));

            dynamic stuff = JsonConvert.DeserializeObject(result.ToString());

            if (stuff.data == null)
                MessageBox.Show(stuff.error.ToString(), "Error:");
            else
            {
                stuff = JsonConvert.DeserializeObject(stuff.data.ToString());
                listMaxMin = JsonConvert.DeserializeObject<List<List<double>>>(stuff.matrix_loss.ToString());
                indexesConvexHull = JsonConvert.DeserializeObject<List<int>>(stuff.indexes_convex_hull.ToString());
                solutionCounts.Append(stuff.solution_counts);
                if(!String.IsNullOrEmpty(stuff.X.ToString()))
                {
                    X = JsonConvert.DeserializeObject<List<double>>(stuff.X.ToString());
                }
                rightLoss = Convert.ToDouble(stuff.loss.ToString());
            }
        }

        bool isClicked = false;
        private void btnNext_Click(object sender, EventArgs e)
        {
            bool isRigth1, isRigth2;
            List<List<double>> listForChart;
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
                listForChart = MakeMatrixForChart(listMaxMin);
                DrawPlot(chart1, listForChart);
            }
        }
        private void numFirstElemMM_ValueChanged(object sender, EventArgs e)
        {
            numFirstElemMM.BackColor = Color.White;
        }
        private void numLastElemMM_ValueChanged(object sender, EventArgs e)
        {
            numLastElemMM.BackColor = Color.White;
        }

        private void btnCheckMM_Click(object sender, EventArgs e)
        {
            if (solutionCounts.ToString() == "SINGLE")
            {
                if(checkInfMM.Checked)
                {
                    checkInfMM.BackColor = Color.Red;
                }
                else
                {
                    EqualListIndexes(txtBXMM, X);
                }
            }
            else
            {
                if (checkInfMM.Checked)
                {
                    checkInfMM.BackColor = Color.Green;
                }
                else
                {
                    checkInfMM.BackColor = Color.Red;
                }
            }

            loss = Convert.ToDouble(numVMM.Value);
            _ = EqualDoubleForResult(numVMM, loss, rightLoss);

        }
        private void checkInfMM_CheckedChanged(object sender, EventArgs e)
        {
            txtBXMM.Enabled = !checkInfMM.Checked;   
            txtBXMM.BackColor = Color.White;
            checkInfMM.BackColor = Color.White;
        }
        private void txtBXMM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && ch != 8 && ch != 44 && ch != 32)
            {
                e.Handled = true;
            }

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
            checkInfMM.Checked = false;

            txtBXMM.Enabled = true;

            numFirstElemMM.BackColor = Color.White;
            numLastElemMM.BackColor = Color.White;
            txtBXMM.BackColor = Color.White;
            numVMM.BackColor = Color.White;
            checkInfMM.BackColor = Color.White;

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

           ClearAllObjectsNP();
        }
        private void numGameCountNP_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numGameCountNP.Value;

            ClearObjectsNP();
        }
        private void btnToCalcNP_Click(object sender, EventArgs e)
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
                GetResultFromPythonNP();
            }
        }
       
        public void GetResultFromPythonNP()
        {
            var json = JsonConvert.SerializeObject(listNeimPirs);
            dataJson.Clear();
            result.Clear();
            dataJson.Append("{\"matrix\": " + json + ", \"critical_value\": " + porogZnach + "}");
            result.Append(PythonInteractor.ReadPyhonFile("neyman-pirson-randomized", dataJson));

            dynamic stuff = JsonConvert.DeserializeObject(result.ToString());

            if (stuff.data == null)
            {
                groupPerevirNP.Visible = false;
                MessageBox.Show(stuff.exeption.ToString(), "Error:");
            }
            else
            {
                stuff = JsonConvert.DeserializeObject(stuff.data.ToString());
                listNeimPirs = JsonConvert.DeserializeObject<List<List<double>>>(stuff.matrix_loss.ToString());
                indexesConvexHull = JsonConvert.DeserializeObject<List<int>>(stuff.indexes_convex_hull.ToString());
                solutionCounts.Append(stuff.solution_counts);
                if (!String.IsNullOrEmpty(stuff.X.ToString()))
                {
                    X = JsonConvert.DeserializeObject<List<double>>(stuff.X.ToString());
                }
                if (!String.IsNullOrEmpty(stuff.loss.ToString()))
                {
                    isRightLossNull = "no";
                    rightLoss = Convert.ToDouble(stuff.loss.ToString());
                }
                else
                {
                    isRightLossNull = null;
                }
            }
        }
        private void btnNextNP_Click(object sender, EventArgs e)
        {
            bool isRigth1, isRigth2;
            List<List<double>> listForChart;
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
                listForChart = MakeMatrixForChart(listNeimPirs);
                DrawPlot(chart2, listForChart);
            }
        }
        private void txtXNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBXMM_KeyPress(sender, e);
        }
        private void btnCheckNP_Click(object sender, EventArgs e)
        {
            if (solutionCounts.ToString() == "SINGLE")
            {
                if (checkInfNP.Checked)
                {
                    checkInfNP.BackColor = Color.Red;
                }
                else if(checkNoAnswersNP.Checked)
                {
                    checkNoAnswersNP.BackColor = Color.Red;
                }
                else
                {
                    EqualListIndexes(txtXNP, X);
                }
            }
            else if (solutionCounts.ToString() == "NONE")
            {
                if (checkInfNP.Checked)
                {
                    checkInfNP.BackColor = Color.Red;
                    numVNP.BackColor = Color.Red;
                }
                else if (checkNoAnswersNP.Checked)
                {
                    checkNoAnswersNP.BackColor = Color.Green;
                }
                else
                {
                    checkInfNP.BackColor = Color.Red;
                    checkNoAnswersNP.BackColor = Color.Red;
                    txtXNP.BackColor = Color.Red;
                    numVNP.BackColor = Color.Red;
                }
            }
            else
            {
                if (checkInfNP.Checked)
                {
                    checkInfNP.BackColor = Color.Green;
                    txtXNP.BackColor = Color.White;
                }
                else if(checkNoAnswersNP.Checked)
                {
                    checkNoAnswersNP.BackColor = Color.Red;
                }
                else
                {
                    //checkInfNP.BackColor = Color.Red;
                    txtXNP.BackColor = Color.Red;
                }
            }

            if (numVNP.Enabled && !String.IsNullOrEmpty(isRightLossNull))
            {
                loss = Convert.ToDouble(numVNP.Value);
                _ = EqualDoubleForResult(numVNP, loss, rightLoss);
            }
           
        }

        private void btnClearNP_Click(object sender, EventArgs e)
        {
            ClearAllObjectsNP();
        }

        bool isInfCheck = false;
        bool isNoAnswCheck = false;
        private void checkInfNP_CheckedChanged(object sender, EventArgs e)
        {
            checkInfNP.BackColor = Color.White;
            txtXNP.BackColor = Color.White;
            numVNP.BackColor = Color.White;
            checkNoAnswersNP.BackColor = Color.White;
            if (checkInfNP.Checked == true)
            {
                txtXNP.Enabled = false;
                isInfCheck = true;
                isNoAnswCheck = false;
                if (checkNoAnswersNP.Checked)
                    checkNoAnswersNP.Checked = false;
            }
            else
            {
                isInfCheck = false;
                if (!isNoAnswCheck && !isInfCheck)
                {
                    txtXNP.Enabled = true;
                }
            }
        }

        private void checkNoAnswersNP_CheckedChanged(object sender, EventArgs e)
        {
            checkInfNP.BackColor = Color.White;
            txtXNP.BackColor = Color.White;
            checkNoAnswersNP.BackColor = Color.White;
            numVNP.BackColor = Color.White;
            if (checkNoAnswersNP.Checked == true)
            {
                txtXNP.Enabled = false;
                numVNP.Enabled = false;
                isNoAnswCheck = true;
                isInfCheck = false;
                if (checkInfNP.Checked)
                    checkInfNP.Checked = false;
            }
            else
            {
                numVNP.Enabled = true;
                isNoAnswCheck = false;
                if (!isInfCheck && !isNoAnswCheck)
                {
                    txtXNP.Enabled = true;
                }
            }
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
            numVNP.Value = 0;
            checkNoAnswersNP.Checked = false;
            checkInfNP.Checked = false;

            txtXNP.Enabled = true;

            numFirstElemNP.BackColor = Color.White;
            numLastElemNP.BackColor = Color.White;
            txtXNP.BackColor = Color.White;
            numVNP.BackColor = Color.White;
            checkNoAnswersNP.BackColor = Color.White;
            checkInfNP.BackColor = Color.White;


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
            if (res != matr)
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
                    if (listFromServ[i] != Convert.ToDouble(resIndexes[i]))
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

        private double getMax(List<List<double>> data)
        {
            double max = Double.MinValue;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i][0] > max)
                {
                    max = data[i][0];
                }

                if (data[i][1] > max)
                {
                    max = data[i][1];
                }
            }

            return max;
        }
        
        private void DrawPlot(object sender, List<List<double>> chartData)
        {
            double max = getMax(chartData);
            Chart chart = sender as Chart;

            chart.Series.Clear();
            chart.Series.Add("Бісектриса");
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].BorderWidth = 3;

            chart.Series[0].Points.AddXY(0, 0);
            chart.Series[0].Points.AddXY(max, max);
            
            chart.Series.Add("Опукла множина");

            chart.Series[1].ChartType = SeriesChartType.Line;
            chart.Series[1].BorderWidth = 3;

            for (int i = 0; i < chartData.Count; i++)
            {
                chart.Series[1].Points.AddXY(chartData[i][0], chartData[i][1]);
            }

            chart.Series[1].Points.AddXY(chartData[0][0], chartData[0][1]);
        }

        private List<List<double>> MakeMatrixForChart(List<List<double>> listToConvert)
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0;i < indexesConvexHull.Count; i++)
            {
                result.Add(listToConvert[indexesConvexHull[i]]);
            }

            return result;
        }

        private void CheckCheckbox(object sender)
        {
            CheckBox checkBox = sender as CheckBox;
            if (solutionCounts.ToString() == "SINGLE")
            {
                if (checkBox.Checked)
                {
                    checkInfMM.BackColor = Color.Red;
                }
                else
                {
                    checkBox.BackColor = Color.Green;
                }
            }
            else
            {
                if (checkBox.Checked)
                {
                    checkBox.BackColor = Color.Green;
                }
                else
                {
                    checkBox.BackColor = Color.Red;
                }
            }
        }
        private void FrmRandomiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
        }

      
    }
}
