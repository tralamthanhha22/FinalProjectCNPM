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
    public partial class frmDoiTacVanChuyen : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        public frmDoiTacVanChuyen()
        {
            InitializeComponent();
        }

        private void frmDoiTacVanChuyen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            LoadData();


        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            String sSQL = "select DELIVERYNOTE_ID as \"ID Vận chuyển \", DELIVERYNAME as \"Tên đối tác\", DELIVERYFEE  as \"Phí ship\" from DELIVERY;";
            String dliName4Return = "";



            SqlCommand cmd = new SqlCommand(sSQL, conn);
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

            conn.Close();
        }

        private void LoadDataTextBox()
        {

            DataGridViewCellCollection row = dataGridView1.SelectedRows[0].Cells;
            tbDeliveryID.Text = row[0].Value.ToString();
            tbDeliverName.Text = row[1].Value.ToString();
            tbDeliveryFee.Text = row[2].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                LoadDataTextBox();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String sSQL = "update DELIVERY set DELIVERYNAME = @Deliver_name, DELIVERYFEE = @Deliver_fee where DELIVERYNOTE_ID = @Deliver_ID" ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@Deliver_name", tbDeliverName.Text));
            cmd.Parameters.Add(new SqlParameter("@Deliver_ID", tbDeliveryID.Text));
            cmd.Parameters.Add(new SqlParameter("@Deliver_fee", tbDeliveryFee.Text));

            try
            {
                cmd.ExecuteNonQuery();
                LoadData();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }

        
            
        }
    }

}