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
        int m;
        List<List<int>> listMaxMin;
        List<List<int>> listNeimPirs;
        int controlStan;
        int porogZnach;

        #region Критерий МиниМакс
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dtGridMinMax.AllowUserToAddRows = false;
            dtGridMinMax.Rows.Clear();
            dtGridMinMax.Columns.Clear();
            n = (int)numRow.Value;
            m = (int)numColumn.Value;

            for (int i = 0; i < m; i++)
            {
                dtGridMinMax.Columns.Add("B"+(i+1), "b" + (i + 1));
            }
            dtGridMinMax.Rows.Add(n);
            listMaxMin.Clear();
        }

        private void numRow_ValueChanged(object sender, EventArgs e)
        {
            dtGridMinMax.Rows.Clear();
            dtGridMinMax.Columns.Clear();
            n = (int)numRow.Value;

            for (int i = 0; i < m; i++)
            {
                dtGridMinMax.Columns.Add("B" + (i + 1), "b" + (i + 1));
            }
            dtGridMinMax.RowCount = n;
            listMaxMin.Clear();
        }

        private void numColumn_ValueChanged(object sender, EventArgs e)
        {
            dtGridMinMax.Rows.Clear();
            dtGridMinMax.Columns.Clear();
            m = (int)numColumn.Value;

            for (int i = 0; i < m; i++)
            {
                dtGridMinMax.Columns.Add("B" + (i + 1), "b" + (i + 1));
            }
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
            controlStan = (int)numContrlSt.Value;
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

        private void ReadPyhonFile()
        {
            ProcessStartInfo start = new ProcessStartInfo();

            string curDir = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = Directory.GetParent(curDir);
            DirectoryInfo directoryInfo2 = Directory.GetParent(directoryInfo.FullName);
            start.FileName = directoryInfo2.FullName + @"\core\venv\Scripts\python.exe";
            string path = directoryInfo2.FullName + @"\core\api.py";

            start.Arguments = string.Format("{0} -c {1}", path, "worst app!");
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result);
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
