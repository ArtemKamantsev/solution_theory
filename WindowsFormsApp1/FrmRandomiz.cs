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

            listMaxMin = new List<List<int>>();
            listNeimPirs = new List<List<int>>();   
        }

        int n;
        int m = 2;
        List<List<int>> listMaxMin;
        List<List<int>> listNeimPirs;
        int controlStan;
        int porogZnach;

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                listMaxMin.Add(new List<int>());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    listMaxMin[i].Add(Convert.ToInt32(dtGridMinMax.Rows[i].Cells[j].Value));
                }
            }

            List<List<double>> data = new List<List<double>>();
            List<double> list = new List<double>();
            list.Add(0);
            list.Add(1);
            data.Add(list);

            List<double> list1 = new List<double>();
            list1.Add(3);
            list1.Add(5);
            data.Add(list1);

            List<double> list2 = new List<double>();
            list2.Add(2);
            list2.Add(7);
            data.Add(list2);

            List<double> list3 = new List<double>();
            list3.Add(-1);
            list3.Add(3);
            data.Add(list3);

            DrawPlot(data);
        }

        private void DrawPlot(List<List<double>> chartData)
        {
            double max = -9999;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

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
                listNeimPirs.Add(new List<int>());
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

        private string ReadPyhonFile(string methodName, string inputRow)
        {
            ProcessStartInfo start = new ProcessStartInfo();

            string curDir = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = Directory.GetParent(curDir);
            DirectoryInfo directoryInfo2 = Directory.GetParent(directoryInfo.FullName);
            start.FileName = directoryInfo2.FullName + @"\core\venv\Scripts\python.exe";
            string path = directoryInfo2.FullName + @"\core\api.py";

            start.Arguments = string.Format(path);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardInput = true;
            using (Process process = Process.Start(start))
            {
                StreamWriter writer = process.StandardInput;
                writer.WriteLine(methodName);
                writer.WriteLine(inputRow);

                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        private void FrmRandomiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
