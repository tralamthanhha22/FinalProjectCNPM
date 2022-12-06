using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEFinalProject_Winform
{
    public partial class frmMainForm : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private String AccountID = "";
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void thốngKêThángToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            frmLoginAccountant lgForm = new frmLoginAccountant(AccountID);
            
            lgForm.ShowDialog();
            this.WindowState = FormWindowState.Maximized;
        }

        private void nhậpHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNhapHang phieuNhap = new frmNhapHang();
            phieuNhap.MdiParent =  this;
            phieuNhap.Show();
        }

        private void lượngHàngTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductManager frmproduct = new frmProductManager();
            frmproduct.MdiParent = this;
            frmproduct.Show();

        }
    }
}
