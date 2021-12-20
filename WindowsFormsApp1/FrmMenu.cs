using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnRand_Click(object sender, EventArgs e)
        {
            FrmRandomiz frmRandomiz = new FrmRandomiz(); 
            frmRandomiz.Show();
            Hide();
        }

        private void btnNerand_Click(object sender, EventArgs e)
        {
            FrmNerandomiz frmNerandomiz = new FrmNerandomiz();
            frmNerandomiz.Show();
            Hide();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Hide();
        }
    }
}
