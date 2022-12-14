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
            this.reportViewer1.RefreshReport();
        
        }

        private void LoadReportImport(String importID)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "SEFinalProject_Winform.ReportImport.rdlc";
            var source = new ReportDataSource();
            source.Name = "DataSetImport";
            source.Value = LoadDataImport(importID);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
           
            
        }

        private DataTable LoadDataImport(String importID)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT IMPORT.IMPORTID, IMPORT.ACCOUNTID, IMPORT.IMPORTDATE, " +
                        "IMPORT_DETAIL.IDETAIL_ID, IMPORT_DETAIL.PRODUCTID, IMPORT_DETAIL.IMPORTID AS Expr1, IMPORT_DETAIL.IMPORTQUANTITY, " +
                        " ACCOUNTANT.ACCOUNTID AS Expr2, ACCOUNTANT.AGENTNAME, " +
                        "PRODUCT.PRODUCTID AS Expr3, PRODUCT.PRONAME, PRODUCT.PROPRICE " +
                        "FROM IMPORT CROSS JOIN IMPORT_DETAIL CROSS JOIN  ACCOUNTANT CROSS JOIN PRODUCT " +
                        "WHERE  IMPORT_DETAIL.IMPORTID = IMPORT.IMPORTID and IMPORT.ACCOUNTID = ACCOUNTANT.ACCOUNTID and IMPORT_DETAIL.PRODUCTID = PRODUCT.PRODUCTID and  IMPORT.IMPORTID = @importID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@importID", importID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        private void LoadReportOrder(String orderID)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "SEFinalProject_Winform.ReportOrder.rdlc";
            var source = new ReportDataSource();
            source.Name = "DataSetOrder";
            source.Value = LoadDataOrder(orderID);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }

        private DataTable LoadDataOrder(String orderID)
        {

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            String sSQL = "SELECT \"ORDER\".ORDERID, \"ORDER\".AGENTID, \"ORDER\".DELIVERYNOTE_ID, \"ORDER\".ORDERDATE, \"ORDER\".ORDERSTATUS, " +
                "\"ORDER\".PAYMENTSTATUS, \"ORDER\".PAYMENTMETHOD, ORDER_DETAIL.ODETAIL_ID,   ORDER_DETAIL.ORDERID AS Expr1, ORDER_DETAIL.PRODUCTID, ORDER_DETAIL.BUYQUANTITY," +
                " AGENT.AGENTID AS Expr2, AGENT.AGENTNAME, AGENT.AGENTADDRESS, AGENT.AGENTPHONE, PRODUCT.PRODUCTID AS Expr3, PRODUCT.PRONAME, PRODUCT.PROPRICE, " +
                "DELIVERY.DELIVERYNOTE_ID AS Expr4, DELIVERY.DELIVERYNAME, DELIVERY.DELIVERYFEE " +
                "FROM     \"ORDER\" CROSS JOIN  ORDER_DETAIL CROSS JOIN  AGENT CROSS JOIN PRODUCT CROSS JOIN  DELIVERY " +
                     "WHERE \"ORDER\".ORDERID = ORDER_DETAIL.ORDERID and ORDER_DETAIL.PRODUCTID = PRODUCT.PRODUCTID and AGENT.AGENTID = \"ORDER\".AGENTID and \"ORDER\".DELIVERYNOTE_ID = DELIVERY.DELIVERYNOTE_ID and ORDER_DETAIL.ORDERID = @orderID";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            cmd.Parameters.Add(new SqlParameter("@orderID", orderID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
