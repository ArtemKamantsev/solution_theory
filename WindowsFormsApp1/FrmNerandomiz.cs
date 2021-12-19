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
            indexesOptimal = new List<string>();
            resIndexes = new List<string>();
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
        List<string> indexesOptimal;
        List<string> resIndexes;
        double rightLoss;
        double loss;

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
        public void GetResultFromPythonMM()
        {
            var json = JsonConvert.SerializeObject(listMaxMin);
            dataJson.Clear();
            result.Clear();
            dataJson.Append("{\"matrix\": " + json + "}");
            result.Append(ReadPyhonFile("min-max", dataJson));

            dynamic stuff = JsonConvert.DeserializeObject(result.ToString());

            if (stuff.data == null)
                MessageBox.Show(stuff.error.ToString(), "Error:");
            else
            {
                stuff = JsonConvert.DeserializeObject(stuff.data.ToString());
                listMaxMin = JsonConvert.DeserializeObject<List<List<double>>>(stuff.matrix_loss.ToString());
                indexesOptimal = JsonConvert.DeserializeObject<List<string>>(stuff.indexes_optimal.ToString());
                rightLoss = Convert.ToDouble(JsonConvert.DeserializeObject(stuff.loss.ToString()));
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
                    MakeMatrixAnswerMM();
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
            bool isEqualList = false;
            resIndexes = txtBXMM.Text.Split().ToList();
            if (indexesOptimal.Count == resIndexes.Count)
            {
                for (int i = 0; i < resIndexes.Count; i++)
                {
                    if (indexesOptimal[i] != resIndexes[i])
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
                txtBXMM.BackColor = Color.Red;
            }
            else
            {
                txtBXMM.BackColor = Color.Green;
            }

            loss = Convert.ToDouble(numVMM.Value);
            _ = EqualDoubleForResult(numVMM, loss, rightLoss);

        }
        private void numVMM_ValueChanged(object sender, EventArgs e)
        {
            numVMM.BackColor = Color.White;
        }
        private void btnClearMM_Click(object sender, EventArgs e)
        {
            ClearAllObjectsMM();
        }
        private void MakeMatrixAnswerMM()
        {
            for (int i = 0; i < m; i++)
            {
                dtAnswerMM.Columns.Add("B" + (i + 1), "b" + (i + 1));
            }
            dtAnswerMM.RowCount = n;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dtAnswerMM.Rows[i].Cells[j].Value = listMaxMin[i][j];
                }
            }
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
            }
        }
        bool isInfCheck = false;
        bool isNoAnswCheck = false;
        private void checkInfNP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkInfNP.Checked == true)
            {
                txtXNP.Enabled = false;
                isInfCheck = true;
                isNoAnswCheck = false;
                if (checkNoAnsNP.Checked)
                    checkNoAnsNP.Checked = false;
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
        private void checkNoAnsNP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNoAnsNP.Checked == true)
            {
                txtXNP.Enabled = false;
                isNoAnswCheck = true;
                isInfCheck = false;
                if (checkInfNP.Checked)
                    checkInfNP.Checked = false;
            }
            else
            {
                isNoAnswCheck = false;
                if (!isInfCheck && !isNoAnswCheck)
                {
                    txtXNP.Enabled = true;
                }
            }

        }
        private void btnNextNP_Click(object sender, EventArgs e)
        {
            groupExitNP.Visible = true;
            groupPerevirNP.Visible = false;
        }
        private void btnCheckNP_Click(object sender, EventArgs e)
        {

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
            numVNP.Value = 0;

            txtXNP.Enabled = true;

            dtNeimanPirs.Rows.Clear();
            dtNeimanPirs.Columns.Clear();

            dtNeimanPirs.Columns.Add("B1", "b1");
            dtNeimanPirs.Columns.Add("B2", "b2");
            dtNeimanPirs.RowCount = n;

            listNeimPirs.Clear();
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
                //numericUpDown.Enabled = false;
                return true;
            }
        }
        private void FrmNerandomiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
        }


    }
}
