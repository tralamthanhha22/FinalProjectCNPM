using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SEFinalProject_Winform
{
    public partial class frmNhapHang : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        String AccountID = "";
        String proImage = "";
        int proQuantityNow = 0;
        Boolean importCreatedCheck = false;
        DataTable table4Report = null;
        private string documentContents = "";
        private string stringToPrint = "";

        public frmNhapHang()
        {
            InitializeComponent();
        }

        public frmNhapHang(String accountID)
        {
            InitializeComponent();
            AccountID = accountID;
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

        private void btnChooseImage_Clicked(object sender, EventArgs e)
        {
            // open file dialog   
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

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            LoadData();
            btnUpdate.Enabled = false;
            btnAddNew.Enabled = true;
            btnChooseImage.Enabled = true;
            this.WindowState = FormWindowState.Maximized;

            //tbImportID.Text =  createImportID();
            tbImportID.Text = "I0005";
            tbImportDate.Text = DateTime.Now.ToString();
            LoadImportData("I0005");



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
                proQuantityNow = int.Parse(row[4].Value.ToString());

                String imagePath = "D:\\Homework\\SoftwareEngineering\\CloneSE\\FinalProjectCNPM\\Image\\" + row[10].Value.ToString();
               // String imagePath = "C:\\Users\\ACER\\source\\repos\\FinalProjectCNPM\\Image\\" + row[10].Value.ToString();

                picturePro.ImageLocation = imagePath;
                picturePro.SizeMode = PictureBoxSizeMode.StretchImage;


                btnAddNew.Enabled = false;
                btnUpdate.Enabled = true;
                btnChooseImage.Enabled = false;

                tbProductID.Enabled = false;
                tbProductName.Enabled = false;
                tbProBrand.Enabled = false;
                tbProOrigin.Enabled = false;
                tbProPrice.Enabled = false;
                tbProType.Enabled = false;
                tbProUseDate.Enabled = false;
                rtbProDes.Enabled = false;

            }
        }

        private void btnClear_clicked(object sender, EventArgs e)
        {
            clearFormData();
        }

        private void clearFormData()
        {
            btnAddNew.Enabled = true;
            btnChooseImage.Enabled = true;
            btnUpdate.Enabled = false;

            tbProductID.Text = "";
            tbProductName.Text = "";
            tbProBrand.Text = "";
            tbProOrigin.Text = "";
            tbProPrice.Text = "";
            tbProType.Text = "";
            tbProUseDate.Text = "";
            rtbProDes.Text = "";
            picturePro.ImageLocation = "";

            tbProductID.Enabled = true;
            tbProductName.Enabled = true;
            tbProBrand.Enabled = true;
            tbProOrigin.Enabled = true;
            tbProPrice.Enabled = true;
            tbProType.Enabled = true;
            tbProUseDate.Enabled = true;
            rtbProDes.Enabled = true;
        }

        private void addNewProduct(object sender, EventArgs e)
        {
            //String location = "C:\\Users\\ACER\\source\\repos\\FinalProjectCNPM\\FinalWeb\\FinalWeb\\Uploads\\products";
            String proID = tbProductID.Text.ToString();
            String proName = tbProductName.Text.ToString();
            String proOrigin = tbProOrigin.Text.ToString();
            String proType = tbProType.Text;
            String proBrand = tbProBrand.Text;
            String proDes = rtbProDes.Text;
            float proPrice = 0;
            int proQuantity = 0;
            DateTime useDate = tbProUseDate.Value;
            Image a = picturePro.Image;
            String[] ele = proImage.Split('\\');
            //a.Save(Path.Combine(location, ele[ele.Length - 1]));
            //MessageBox.Show(Path.Combine(location, ele[ele.Length - 1]));
            //MessageBox.Show(ele[ele.Length - 1]);
            try
            {
                proQuantity = int.Parse(numberProductQuantity.Value.ToString());
                proPrice = float.Parse(tbProPrice.Text.ToString());
                //useDate = DateTime.ParseExact(tbProUseDate.Text.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
            } catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình thêm sản phẩm");
            }

            //insert into PRODUCT values ('P0000',N'Tên sản phẩm', 0, N'Xuất xứ', 0, N'Type', N'Brand', N'Des', '2024-12-23',0);

            String sSQL = "INSERT INTO PRODUCT (PRODUCTID, PRONAME, PROPRICE, PROORIGIN, PROQUANTITY, PROTYPE ,PROBRAND, PRODESCRIPTION, USEDATE, HASSOLD, PROIMAGE)" +
                "VALUES (@ProID, @ProName, @ProPrice, @ProOrigin, @ProQuantity, @ProType, @ProBrand, @ProDes, @UseDate, @HasSold, @ProImage)";
            SqlConnection conn = new SqlConnection(strConn);
           
            conn.Open();
            SqlCommand cmd = new SqlCommand(sSQL, conn);

            cmd.Parameters.Add(new SqlParameter("@ProID", proID));
            cmd.Parameters.Add(new SqlParameter("@ProName",proName));
            cmd.Parameters.Add(new SqlParameter("@ProPrice", proPrice));
            cmd.Parameters.Add(new SqlParameter("@ProOrigin", proOrigin));
            cmd.Parameters.Add(new SqlParameter("@ProType", proType));
            cmd.Parameters.Add(new SqlParameter("@ProQuantity", proQuantity));
            cmd.Parameters.Add(new SqlParameter("@ProBrand", proBrand));
            cmd.Parameters.Add(new SqlParameter("@ProDes", proDes));
            cmd.Parameters.Add(new SqlParameter("@UseDate", useDate));
            cmd.Parameters.Add(new SqlParameter("@HasSold", 1));
            cmd.Parameters.Add(new SqlParameter("@ProImage", ele[ele.Length - 1]));
            //cmd.Parameters.Add(new SqlParameter("@ProImage", proImage));
            try
            {

                cmd.ExecuteNonQuery();
                if (!importCreatedCheck)
                {
                    importCreatedCheck = true;
                    createNewImport();
                }
                createImportDetail(tbImportID.Text);
                clearFormData();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            MessageBox.Show("Save successfully!");
            LoadData();

        }

        private void updateProduct(object sender, EventArgs e)
        {
            String proID = tbProductID.Text.ToString();

            int proQuantity = 0;
            try
            {
                proQuantity = int.Parse(numberProductQuantity.Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình thêm sản phẩm");
            }

            proQuantity = proQuantity + proQuantityNow;

            
            String sSQL = "UPDATE PRODUCT SET PROQUANTITY = @ProQuantity WHERE PRODUCTID = @ProID";
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@ProID", proID));
            cmd.Parameters.Add(new SqlParameter("@ProQuantity", proQuantity));

            try
            {

                cmd.ExecuteNonQuery();
                if (!importCreatedCheck)
                {
                    importCreatedCheck = true;
                    createNewImport();
                }

                createImportDetail(tbImportID.Text);
                clearFormData();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            MessageBox.Show("Save successfully!");
            LoadData();
        }

        private String createImportID()
        {
            String importID = "";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT Max(IMPORTID) FROM IMPORT";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                String temp = Regex.Replace (dt.Rows[0][0].ToString(), "I", string.Empty);
                int id = int.Parse(temp) + 1;
                String idsinh = String.Format("{0:0000.#}", id);
                importID = "I" + idsinh;
                
            }
            else
            {
                //MessageBox.Show("No data");
            }

            
            conn.Close();
           
            return importID;
        }

        private void createNewImport()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "INSERT INTO IMPORT values (@ImportID, @AcountID, @ImportDate);";
            SqlCommand cmd2 = new SqlCommand(sSQL, conn);

            cmd2.Parameters.Add(new SqlParameter("@ImportID", tbImportID.Text));
            cmd2.Parameters.Add(new SqlParameter("@AcountID", AccountID));
            cmd2.Parameters.Add(new SqlParameter("@ImportDate", DateTime.Now.ToString()));
            try
            {

                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            conn.Close();
        }
       
        private void createImportDetail(String importID)
        {
            String importDetailID = "";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "select Max(IDETAIL_ID) from IMPORT_DETAIL;";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                String temp = Regex.Replace(dt.Rows[0][0].ToString(), "ID", string.Empty);
                int id = int.Parse(temp) + 1;
                String idsinh = String.Format("{0:000.#}", id);
                importDetailID = "ID" +  idsinh;

            }
            else
            {
                //MessageBox.Show("No data");
            }

            //add new import detail 
            
            String importQuantity = numberProductQuantity.Value.ToString();
            

            sSQL = "INSERT INTO IMPORT_DETAIL values (@IDETAIL_ID, @ProID, @IMPORTID, @ImportQUuantity);";
            SqlCommand cmd2 = new SqlCommand(sSQL, conn);

            cmd2.Parameters.Add(new SqlParameter("@IDETAIL_ID", importDetailID));
            cmd2.Parameters.Add(new SqlParameter("@ProID", tbProductID.Text));
            cmd2.Parameters.Add(new SqlParameter("@IMPORTID", tbImportID.Text));
            cmd2.Parameters.Add(new SqlParameter("@ImportQUuantity", importQuantity));
            try
            {

                cmd2.ExecuteNonQuery();
                LoadImportData(importID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
                MessageBox.Show("Có lỗi khi nhập hàng");
            }
            
            

            conn.Close();
        }

        private void LoadImportData(String importID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT IDETAIL_ID as \"Mã chi tiết\", PRODUCTID as \"Mã sản phẩm\", IMPORTID as \"Mã đơn nhập\", IMPORTQUANTITY as \"Số lượng nhập\"  FROM IMPORT_DETAIL where IMPORTID = @importID";

            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@importID", importID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            table4Report = new DataTable();
            da.Fill(table4Report);
            if (table4Report.Rows.Count > 0)
            {
                dataGridView2.DataSource = table4Report;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            else
            {
                //MessageBox.Show("No data");
            }

            conn.Close();
        }


        private void createPDFReport(object sender, EventArgs e)
        {
            frmPreviewReportPrint frmImportPrint = new frmPreviewReportPrint("Import", tbImportID.Text);
            frmImportPrint.ShowDialog();

        }

      
    }
}
