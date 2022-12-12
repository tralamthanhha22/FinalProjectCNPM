using System;
using System.Collections;
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
using Microsoft.Reporting.WinForms;

namespace SEFinalProject_Winform
{
    public partial class frmPreviewReportPrint : Form
    {
        String reportType = "";
        String ID = "";
        String strConn = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        public frmPreviewReportPrint(string reportType, String ID)
        {
            InitializeComponent();
            this.reportType = reportType;
            this.ID = ID;
        }

        private DataTable LoadData(String importID)
        {
           

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT IMPORT.IMPORTID, IMPORT.ACCOUNTID, IMPORT.IMPORTDATE, " +
                        "IMPORT_DETAIL.IDETAIL_ID, IMPORT_DETAIL.PRODUCTID, IMPORT_DETAIL.IMPORTID AS Expr1, IMPORT_DETAIL.IMPORTQUANTITY, " +
                        " ACCOUNTANT.ACCOUNTID AS Expr2, ACCOUNTANT.AGENTNAME, " +
                        "PRODUCT.PRODUCTID AS Expr3, PRODUCT.PRONAME, PRODUCT.PROPRICE " +
                        "FROM IMPORT CROSS JOIN IMPORT_DETAIL CROSS JOIN  ACCOUNTANT CROSS JOIN PRODUCT " +
                        "where IMPORT.IMPORTID = @importID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@importID", importID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            return dt;
        }

        private void frmPreviewImportPrint_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            if (reportType == "Import")
            {
                LoadReportImport(ID);

            } else
            {
                LoadReportOrder(ID);
            }
        }

        private void LoadReportImport(String importID)
        {
            reportViewer1.LocalReport.ReportPath = "ReportImport.rdlc";
            var source = new ReportDataSource();
            source.Name = "DataSetImport";
            source.Value = LoadData(importID);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
           
            
        }

        private void LoadReportOrder(String orderID)
        {

        }
    }
}
