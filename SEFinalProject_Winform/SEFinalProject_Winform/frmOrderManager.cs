using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEFinalProject_Winform
{
    public partial class frmOrderManager : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        float totalPrice = 0;
        String[] TrangThaiThanhToanSource = { "Đã thanh toán", "Chưa thanh toán" };
        String[] HinhThucThanhToanSource = { "Thanh toán khi nhận hàng", "Thanh toán bằng ví điện tử", "Thanh toán chuyển khoản" };
        String[] TinhTrangDonHangSource = { "Chưa xử lý", "Đang chuẩn bị hàng", "Đang giao hàng", "Đã nhận được hàng" };

        public frmOrderManager()
        {
            InitializeComponent();
        }


        private void frmOrderManager_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadDataBegining();
        }

        private void LoadDataBegining()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "Select * from " + '"' + "ORDER" + '"' + " where  ORDERSTATUS != N'Đã nhận được hàng';";
            tbOrderDate.Enabled = false;

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cbOrdID.DataSource = dt.Copy();
                cbOrdID.DisplayMember = "ORDERID";
                cbOrdID.ValueMember = "ORDERID";

            }
            else
            {
                //MessageBox.Show("No data");
            }

           
            cbTinhTrangThanhToan.DataSource = TrangThaiThanhToanSource;         
            cbHinhThucThanhToan.DataSource = HinhThucThanhToanSource;           
            cbTinhTrangDonHang.DataSource = TinhTrangDonHangSource;
   

            String sSQL2 = "Select * from DELIVERY;";

            SqlCommand cmd2 = new SqlCommand(sSQL2, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                cbDonViVanChuyen.DataSource = dt2.Copy();
                cbDonViVanChuyen.DisplayMember = "DELIVERYNAME";
                cbDonViVanChuyen.ValueMember = "DELIVERYNAME";
            }
            else
            {
                //MessageBox.Show("No data");
            }



            conn.Close();
        }

        private void LoadDataGridView(String OrdID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "Select ORDER_DETAIL.PRODUCTID as \"Mã sản phẩm\", PRODUCT.PRONAME as \"Tên sản phẩm\", PRODUCT.PROPRICE as \"Đơn giá\", ORDER_DETAIL.BUYQUANTITY as \"Số lượng\"  from" + 
                " ORDER_DETAIL, PRODUCT where ORDER_DETAIL.PRODUCTID = PRODUCT.PRODUCTID and ORDER_DETAIL.ORDERID = @OrdID;";
            
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            cmd.Parameters.Add(new SqlParameter("@OrdID",OrdID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
               // MessageBox.Show("No data");
            }
     
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String productID = dt.Rows[i][0].ToString();
                String proQuantity = dt.Rows[i][3].ToString();
                
                String sSQL2 = "Select PROPRICE from PRODUCT where PRODUCTID = @ProID;";

                SqlCommand cmd2 = new SqlCommand(sSQL2, conn);

                cmd2.Parameters.Add(new SqlParameter("@ProID", productID));
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {

                    totalPrice += float.Parse(dt2.Rows[0][0].ToString()) * int.Parse(proQuantity);

                    
                }
            }

            tbTongTien.Text = String.Format("{0:0,0 vnđ}", totalPrice);


            // Xử lý các combo box: 
            String sSQL3 = "Select * from \"ORDER\" where ORDERID = @OrdID;";

            cmd = new SqlCommand(sSQL3, conn);

            cmd.Parameters.Add(new SqlParameter("@OrdID", OrdID));
            SqlDataAdapter da3 = new SqlDataAdapter(cmd);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                cbDonViVanChuyen.Text = getDonViVanChuyen(null, dt3.Rows[0][2].ToString());
                tbOrderDate.Text = dt3.Rows[0][3].ToString();
                cbTinhTrangDonHang.Text = dt3.Rows[0][4].ToString();
                cbTinhTrangThanhToan.Text = dt3.Rows[0][5].ToString();
                cbHinhThucThanhToan.Text = dt3.Rows[0][6].ToString();
            }


                conn.Close();
        }

        private void cbOrdID_choose(object sender, EventArgs e)
        {
            String OrdID_choosed = cbOrdID.Text.ToString();
            tbOrderID.Text = OrdID_choosed;
            totalPrice = 0;
            LoadDataGridView(OrdID_choosed);
            LoadDataAgent(OrdID_choosed);
          
            
        }

        private void LoadDataAgent(String OrdID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select * from Agent, \"ORDER\" where \"ORDER\".AGENTID =  AGENT.AGENTID and \"ORDER\".ORDERID = @OrdID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@OrdID", OrdID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                tbAgentName.Text = dt.Rows[0][1].ToString();
                tbAgentAddress.Text = dt.Rows[0][2].ToString();
                tbAgentEmail.Text = dt.Rows[0][3].ToString();
                tbAgentPhone.Text = dt.Rows[0][4].ToString();

            }
            else
            {
                // MessageBox.Show("No data");
            }

            conn.Close();


        }

        private void cbDonViVanChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Deliver_name = cbDonViVanChuyen.Text;
            getDonViVanChuyen(Deliver_name, null);

 

        }

        private String getDonViVanChuyen(String Deliver_name, String Deliver_ID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "";
            String dliName4Return = "";


            if (Deliver_ID == null)
            {
                sSQL = "select * from DELIVERY where DELIVERYNAME = @DeliName ";
               
                
            }
            else
            {
                sSQL = "select * from DELIVERY where DELIVERYNOTE_ID = @DeliName ";
                Deliver_name = Deliver_ID;
              
            }
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@DeliName", Deliver_name));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                float shipfee = float.Parse(dt.Rows[0][2].ToString());
                float totalPriceWithShip = totalPrice + shipfee;
                if (Deliver_ID != null)
                    dliName4Return = dt.Rows[0][1].ToString();
                else
                    dliName4Return = dt.Rows[0][0].ToString();

                tbPhiShip.Text = String.Format("{0:0,0 vnđ}", shipfee);
                tbTongTien.Text = String.Format("{0:0,0 vnđ}", totalPriceWithShip);

            }
            else
            {
                // MessageBox.Show("No data");
            }

            conn.Close();

            return dliName4Return;
        }

        private void btnUpdate_clicked(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "UPDATE  \"ORDER\" set ORDERSTATUS = @OrdStatus , PAYMENTMETHOD = @PayMethod, PAYMENTSTATUS = @PayStatus, DELIVERYNOTE_ID = @Deli_ID where ORDERID = @OrdID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@OrdStatus", cbTinhTrangDonHang.Text));
            cmd.Parameters.Add(new SqlParameter("@PayStatus", cbTinhTrangThanhToan.Text));
            cmd.Parameters.Add(new SqlParameter("@PayMethod", cbHinhThucThanhToan.Text));
            cmd.Parameters.Add(new SqlParameter("@Deli_ID", getDonViVanChuyen(cbDonViVanChuyen.Text, null)));
            cmd.Parameters.Add(new SqlParameter("@OrdID", cbOrdID.Text));
            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");

            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            
        }

        private void btnPrintOrder_clicked(object sender, EventArgs e)
        {
            frmPreviewReportPrint frmOrderPrint = new frmPreviewReportPrint("Order", tbOrderID.Text);
            frmOrderPrint.ShowDialog();
        }
    }
}
