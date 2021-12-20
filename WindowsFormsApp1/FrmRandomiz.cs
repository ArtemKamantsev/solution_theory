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
        double loss;
        List<double> indexesExcluded;

        #region Критерий МиниМакс
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dtGridMinMax.AllowUserToAddRows = false;
            dtGridMinMax.Rows.Clear();
            n = (int)numGameCount.Value;

            dtGridMinMax.Columns.Add("B1", "b1");
            dtGridMinMax.Columns.Add("B2", "b2");
            dtGridMinMax.Rows.Add(n);
            listMaxMin.Clear();
        }

        private void numGameCount_ValueChanged_1(object sender, EventArgs e)
        {
            dtGridMinMax.Rows.Clear();
            n = (int)numGameCount.Value;

            dtGridMinMax.RowCount = n;
            listMaxMin.Clear();
        }
        private void btnToCalcMM_Click(object sender, EventArgs e)
        {
            isNull = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (dtGridMinMax.Rows[i].Cells[j].Value == null)
                    {
                        isNull = true;
                        MessageBox.Show("Заповніть матрицю!", "Warning!");
                        break;
                    }
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
            result.Append(ReadPyhonFile("min-max-randomized", dataJson));

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

                listForChart = MakeMatrixForChart(listMaxMin);
                DrawPlot(listForChart);
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
                    checkInfMM.BackColor = Color.Green;
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
            dtNeimanPirs.Rows.Clear();
            dtNeimanPirs.Columns.Clear();
            n = (int)numGameCountNP.Value;

            dtNeimanPirs.Columns.Add("B1", "b1");
            dtNeimanPirs.Columns.Add("B2", "b2");
            dtNeimanPirs.RowCount = n;
            listNeimPirs.Clear();
        }
        private void numGameCountNP_ValueChanged(object sender, EventArgs e)
        {
            dtNeimanPirs.Rows.Clear();
            n = (int)numGameCountNP.Value;

            dtNeimanPirs.RowCount = n;
            listNeimPirs.Clear();
        }
        private void btnToCalcNP_Click(object sender, EventArgs e)
        {
            isNull = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (dtNeimanPirs.Rows[i].Cells[j].Value == null)
                    {
                        isNull = true;
                        MessageBox.Show("Заповніть матрицю!", "Warning!");
                        break;
                    }
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
            result.Append(ReadPyhonFile("neyman-pirson-randomized", dataJson));

            dynamic stuff = JsonConvert.DeserializeObject(result.ToString());

            if (stuff.data == null)
                MessageBox.Show(stuff.exeption.ToString(), "Error:");
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
                rightLoss = Convert.ToDouble(stuff.loss.ToString());
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

                listForChart = MakeMatrixForChart(listMaxMin);
                DrawPlot(listForChart);
            }
        }
        private void btnCheckNP_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private string ReadPyhonFile(string methodName, StringBuilder data)
        {
            ProcessStartInfo start = new ProcessStartInfo();

            string curDir = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = Directory.GetParent(curDir);
            DirectoryInfo directoryInfo2 = Directory.GetParent(directoryInfo.FullName);
            start.FileName = directoryInfo2.FullName + @"\core\venv\Scripts\python.exe";
            string path = directoryInfo2.FullName + @"\core\api.py";

            start.Arguments = string.Format("{0}", path);
            start.UseShellExecute = false;
            start.RedirectStandardInput = true;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                StreamWriter writer = process.StandardInput;
                writer.WriteLine(methodName);
                writer.WriteLine(data);
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result);
                    return result;
                }
            }
        }
        private void MakeMatrixAnswer(object sender, int n, int m, List<List<double>> list)
        {
            DataGridView dataGridView = sender as DataGridView;
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
        private void DrawPlot(List<List<double>> chartData)
        {
            double max = -9999;

            chart1.Series.Clear();
            chart1.Series.Add("Series1");

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 5;

            for (int i = 0; i < chartData.Count; i++)
            {
                if (chartData[i][0] > max)
                {
                    max = chartData[i][0];
                }

                if (chartData[i][1] > max)
                {
                    max = chartData[i][1];
                }

                chart1.Series[0].Points.AddXY(chartData[i][0], chartData[i][1]);
            }

            chart1.Series[0].Points.AddXY(chartData[0][0], chartData[0][1]);

            chart1.Series.Add("Series2");
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].BorderWidth = 5;

            chart1.Series[1].Points.AddXY(0, 0);
            chart1.Series[1].Points.AddXY(max, max);
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
        private void FrmRandomiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
        }

       
    }
}
