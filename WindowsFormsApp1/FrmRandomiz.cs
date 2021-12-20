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
        }

        int n;
        readonly int m = 2;
        List<List<double>> listMaxMin;
        List<List<double>> listNeimPirs;
        bool isNull = true;
        int porogZnach;
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

        private void btnNext_Click_1(object sender, EventArgs e)
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
                indexesOptimal = JsonConvert.DeserializeObject<List<double>>(stuff.indexes_optimal.ToString());
                for (int i = 0; i < indexesOptimal.Count; i++)
                {
                    indexesOptimal[i] += 1;
                }
            }

            List<List<double>> data = new List<List<double>>();

            for (int i = 0; i < n; i++)
            {
                data.Add(new List<double>());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    data[i].Add(Convert.ToDouble(dtGridMinMax.Rows[i].Cells[j].Value));
                }
            }

            DrawPlot(data);
        }

        private void DrawPlot(List<List<double>> chartData)
        {
            double max = -9999;

            chart1.Series.Clear();
            chart1.Series.Add("Series1");

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 5;

            for (int i=0; i < chartData.Count; i++)
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
        private void btnNextNP_Click(object sender, EventArgs e)
        {
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
                    //MessageBox.Show(result);
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

        private void FrmRandomiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
        }

        
    }
}
