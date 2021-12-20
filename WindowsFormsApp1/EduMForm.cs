using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EduMForm : Form
    {
        public EduMForm()
        {
            InitializeComponent();
        }

        private void EduMForm_Shown(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            string path = curDir + @"\data\ТПР_теория.htm";
            webBrowser1.Url = new Uri(String.Format("file:///{0}", path));
        }

        private void EduMForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
