using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.Hide();
        }

        private void btnNerand_Click(object sender, EventArgs e)
        {
            FrmNerandomiz frmNerandomiz = new FrmNerandomiz();
            frmNerandomiz.Show();
            this.Hide();
        }
    }
}
