using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            lgForm.LoginEvent += LgForm_LoginEvent;

            lgForm.ShowDialog();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LgForm_LoginEvent(string accountantID)
        {

            
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "SELECT * FROM ACCOUNTANT WHERE ACCOUNTID = @AccountID;";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@AccountID", accountantID));
            try
            { 
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error:" + ex.Message);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tbmãNhânViênToolStripMenuItem.Text = "Mã nhân viên: " + accountantID;
                tbtênNhânViênToolStripMenuItem.Text = "Tên nhân viên: " + dt.Rows[0][1].ToString();
                tbsốĐiệnThoạiToolStripMenuItem.Text ="Số điện thoại: " +  dt.Rows[0][2].ToString();
                tbđịaChỉToolStripMenuItem.Text = "Địa chỉ: " + dt.Rows[0][3].ToString();

            }
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

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCustomerManagement frmCus = new frmCustomerManagement();
            //frmCus.MdiParent = this;
            //frmCus.Show();
        }

        private void quảnLýĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderManager frmOrder = new frmOrderManager();
            frmOrder.MdiParent = this;
            frmOrder.Show();
        }

        private void đốiTácVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiTacVanChuyen frmVanChuyen = new frmDoiTacVanChuyen();
            frmVanChuyen.MdiParent = this;
            frmVanChuyen.Show();
                
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCustomerManager frmCustomerManager1 = new frmCustomerManager();
            frmCustomerManager1.MdiParent = this;
            frmCustomerManager1.Show();
        }

        private void thốngKêHàngBánChạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeBestSeller frmBestSell = new frmThongKeBestSeller();
            frmBestSell.MdiParent = this;
            frmBestSell.Show();
        }
    }
}
