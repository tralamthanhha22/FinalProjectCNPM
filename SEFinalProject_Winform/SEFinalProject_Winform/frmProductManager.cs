using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEFinalProject_Winform
{
    public partial class frmProductManager : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        String proImage = "";
        public frmProductManager()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT * FROM PRODUCT";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No data");
            }

            conn.Close();
        }

        private void btnChooseImage_clicked(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                picturePro.Image = new Bitmap(open.FileName);
                picturePro.SizeMode = PictureBoxSizeMode.StretchImage;
                // image file path  
                String image_path = open.FileName;
                proImage = image_path;
            }
        }

        private void frmProductManager_Load(object sender, EventArgs e)
        {
            LoadData();
            this.WindowState = FormWindowState.Maximized;
        }


        private void clearFormData()
        {

            tbProductID.Text = "";
            tbProductName.Text = "";
            tbProBrand.Text = "";
            tbProOrigin.Text = "";
            tbProPrice.Text = "";
            tbProType.Text = "";
            tbProUseDate.Text = "";
            rtbProDes.Text = "";
            picturePro.ImageLocation = "D:\\Homework\\SoftwareEngineering\\CloneSE\\FinalProjectCNPM\\Image\\icon_noimage.png";
            //picturePro.ImageLocation = "C:\\Users\\ACER\\source\\repos\\FinalProjectCNPM\\Image\\icon_noimage.png";


        }

        private void loadCellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewCellCollection row = dataGridView1.SelectedRows[0].Cells;
                tbProductID.Text = row[0].Value.ToString();
                tbProductName.Text = row[1].Value.ToString();
                tbProPrice.Text = row[2].Value.ToString();
                tbProOrigin.Text = row[3].Value.ToString();
                tbProType.Text = row[5].Value.ToString();
                tbProBrand.Text = row[6].Value.ToString();
                rtbProDes.Text = row[7].Value.ToString();
                tbProUseDate.Text = row[8].Value.ToString();
                numberProductQuantity.Value = int.Parse(row[4].Value.ToString());
                proImage = row[10].Value.ToString();
                

                String imagePath = "D:\\Homework\\SoftwareEngineering\\CloneSE\\FinalProjectCNPM\\Image\\" + proImage;
                //String imagePath = "C:\\Users\\ACER\\source\\repos\\FinalProjectCNPM\\Image\\" + row[10].Value.ToString();

                picturePro.ImageLocation = imagePath;
                picturePro.SizeMode = PictureBoxSizeMode.StretchImage;

                btnUpdate.Enabled = true;
                btnChooseImage.Enabled = true;

            }
        }

        private void btnUpdate_clicked(object sender, EventArgs e)
        {
            String proID = tbProductID.Text.ToString();
            String proName = tbProductName.Text.ToString();
            String proOrigin = tbProOrigin.Text.ToString();
            String proType = tbProType.Text;
            String proBrand = tbProBrand.Text;
            String proDes = rtbProDes.Text;
            
            float proPrice = 0;
            int proQuantity = 0;
            DateTime useDate = tbProUseDate.Value;
            String[] ele = proImage.Split('\\');
            //MessageBox.Show(ele[ele.Length - 1]);
            try
            {
                proQuantity = int.Parse(numberProductQuantity.Value.ToString());
                proPrice = float.Parse(tbProPrice.Text.ToString());
                //useDate = DateTime.ParseExact(tbProUseDate.Text.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình thêm sản phẩm");
            }


        
            String sSQL = "UPDATE PRODUCT SET PRONAME = @ProName, PROPRICE = @ProPrice, PROORIGIN = @ProOrigin, PROQUANTITY = @ProQuantity, PROTYPE = @ProType, " +
                "PROBRAND = @ProBrand, PRODESCRIPTION = @ProDes, USEDATE = @UseDate, PROIMG = @ProImage WHERE PRODUCTID = @ProID";
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@ProID", proID));
            cmd.Parameters.Add(new SqlParameter("@ProName", proName));
            cmd.Parameters.Add(new SqlParameter("@ProPrice", proPrice));
            cmd.Parameters.Add(new SqlParameter("@ProOrigin", proOrigin));
            cmd.Parameters.Add(new SqlParameter("@ProType", proType));
            cmd.Parameters.Add(new SqlParameter("@ProQuantity", proQuantity));
            cmd.Parameters.Add(new SqlParameter("@ProBrand", proBrand));
            cmd.Parameters.Add(new SqlParameter("@ProDes", proDes));
            cmd.Parameters.Add(new SqlParameter("@UseDate", useDate));
            cmd.Parameters.Add(new SqlParameter("@ProImage", ele[ele.Length - 1]));
            try
            {

                cmd.ExecuteNonQuery();
                clearFormData();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            MessageBox.Show("Save successfully!");
            LoadData();
        }

        private void deleteProduct(object sender, EventArgs e)
        {
            String proID = tbProductID.Text.ToString();
            String proName = tbProductName.Text.ToString();
            String message = "Bạn có chắc muốn xóa sản phẩm " + proName + "?";
            String title = "Xóa sản phẩm" + proID;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                //check if product is in other table 
                String sSQLCHECK = "SELECT * FROM ORDER_DETAIL WHERE PRODUCTID = @ProID";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                SqlCommand cmd = new SqlCommand(sSQLCHECK, conn);
                cmd.Parameters.Add(new SqlParameter("@ProID", proID));

                try
                {

                    cmd.ExecuteNonQuery();
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // Nếu sản phẩm đã từng được bán -> không được xóa
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Bạn không được xóa sản phẩm đã từng được mua bán");
                    } 
                    //Không thì xóa bình thường
                    else
                    {
                        String sSQL = "DELETE FROM PRODUCT WHERE PRODUCTID = @ProID";
                        cmd = new SqlCommand(sSQL, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete successfully!");
                        LoadData();
                    }
                    clearFormData();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error:" + ex.Message);
                }
                
            }
            else
            {
                //Chẳng làm gì cả
            }
        }
    }
}
