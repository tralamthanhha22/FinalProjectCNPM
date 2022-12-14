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
using System.Windows.Forms.DataVisualization.Charting;

namespace SEFinalProject_Winform
{
    public partial class frmThongKeBestSeller : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        public frmThongKeBestSeller()
        {
            InitializeComponent();
        }

        private void frmThongKeBestSeller_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            chart1.Titles.Add("Bảng thống kê");
            LoadData();
            LoadComboBox();
            
            
        }

        private void LoadComboBox()
        {
            String[] monthSource = { "Tất cả", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "Cả năm" };
            cbMonth.DataSource = monthSource;
            cbMonth.DisplayMember = monthSource[0];

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "Select DISTINCT year(ORDERDATE) as \"YEAR\", month(ORDERDATE) as \"MONTH\" from \"ORDER\";";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            { 
                cbYear.DataSource = dt.Copy();
                cbYear.DisplayMember = "YEAR";
                cbYear.ValueMember = "YEAR";

                
            }
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "Select PRODUCTID as \"Mã sản phẩm\", PRONAME as \"Tên sản phẩm\", HASSOLD as \"Đã bán\" from PRODUCT order by  HASSOLD Desc ;";
            

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0 )
            {
                fillChart(ds, "Tổng quá số lượng đã bán");

                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            else
            {
                MessageBox.Show("No data");
            }
        }

        private void fillChart(DataSet ds, String time)
        {
            chart1.DataSource = ds;
            if (time == "Tổng quá số lượng đã bán")
            {
                chart1.Series["HasSold"].XValueMember = "Mã sản phẩm";
                chart1.Series["HasSold"].YValueMembers = "Đã bán";
            } else
            {
                chart1.Series["HasSold"].XValueMember = "PRODUCTID";
                chart1.Series["HasSold"].YValueMembers = "BUYQUANTITY";
               
            }

            chart1.Titles[0].Text = time;
            
            
            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkboxChange_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxChange.Checked == true)
            {
                //Chuyển kiểu biểu đồ hình tròn
                chart1.Series[0].ChartType = SeriesChartType.Pie;
            } else
            {
                //Chuyển sang biểu đồ cột
                chart1.Series[0].ChartType = SeriesChartType.Column;
            }

        }

        private void combox_change(object sender, EventArgs e)
        {
            String month = cbMonth.Text;
            String year = cbYear.Text;

           

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "";


            if (month == "Tất cả")
            {
                LoadData();
                cbYear.Enabled = false;
            }
            else
            {
                if (month == "Cả năm")
                {
                    cbYear.Enabled = true;
                    sSQL = "Select ORDER_DETAIL.ORDERID, ORDER_DETAIL.PRODUCTID, ORDER_DETAIL.BUYQUANTITY from ORDER_DETAIL, \"ORDER\" where \"ORDER\".ORDERID = ORDER_DETAIL.ORDERID and year(\"ORDER\".ORDERDATE) = @year"
                         + " order by ORDER_DETAIL.PRODUCTID";

                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.Add(new SqlParameter("@year", cbYear.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(dt);
                    da.Fill(ds);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        fillChart(ds, "Danh sách bán chạy năm " + cbYear.Text);
                        
                    }
                } else
                {
                    cbYear.Enabled = true;
                    int monthint = int.Parse(month);

                    sSQL = "Select ORDER_DETAIL.ORDERID, ORDER_DETAIL.PRODUCTID, ORDER_DETAIL.BUYQUANTITY from ORDER_DETAIL, \"ORDER\" where \"ORDER\".ORDERID = ORDER_DETAIL.ORDERID and year(\"ORDER\".ORDERDATE) = @year and month(\"ORDER\".ORDERDATE) = @month"
                         + " order by ORDER_DETAIL.PRODUCTID";

                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.Add(new SqlParameter("@year", cbYear.Text));
                    cmd.Parameters.Add(new SqlParameter("@month", cbMonth.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        fillChart(ds, "Danh sách bán chạy tháng " + cbMonth.Text + " năm " + cbYear.Text);

                    }
                    else
                    {
                        MessageBox.Show("Tháng này bạn không có đơn hàng nào!");
                    }
                }

                
            } 
                
        }
    }
}
