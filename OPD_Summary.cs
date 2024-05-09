using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.IO;

namespace Ruby_Hospital
{
    
    public partial class OPD_Summary : Form
    {
        DataTable dt;
        public OPD_Summary()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void OPD_Summary_Load(object sender, EventArgs e)
        {
              
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "By Between Dates")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                DateTime StartDate = dateTimePicker1.Value;
                DateTime EndDate = dateTimePicker2.Value;
                SqlCommand cmb = new SqlCommand(@"SELECT Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Patient_ID,  Ruby_Jamner123.Billing_OPDFinal.OPDID,Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr, Ruby_Jamner123.Patient_Registration.Name, 
                         RUby_Jamner123.Billing_OPDFinal.OPD_BillAmount, Ruby_Jamner123.Billing_OPDFinal.OPD_LabBillAmount, Ruby_Jamner123.Billing_OPDFinal.OPD_RadiologyBillAmount,Ruby_Jamner123.Billing_OPDFinal.Total_Billing_Amount, Ruby_Jamner123.Billing_OPDFinal.Billing_Date,Ruby_Jamner123.Billing_OPDFinal.Payment_Mode
FROM            Ruby_Jamner123.OPD_Patient_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID INNER JOIN
                         Ruby_Jamner123.Billing_OPDFinal ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDFinal.OPDID 
                         WHERE Ruby_Jamner123.Billing_OPDFinal.Billing_Date >= @StartDate AND Ruby_Jamner123.Billing_OPDFinal.Billing_Date <= @EndDate", con);
                SqlDataAdapter adt = new SqlDataAdapter(cmb);
                cmb.Parameters.AddWithValue("@StartDate", StartDate);
                cmb.Parameters.AddWithValue("@EndDate", EndDate);
                dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["OPDID"].Visible = false;
                    dataGridView1.Columns["PID"].Visible = false;
                    dataGridView1.Columns["PatientOPDIdWithSr"].HeaderText = "OPDID";
                    dataGridView1.Columns["Name"].HeaderText = "Patient Name";
                    dataGridView1.Columns["OPD_RadiologyBillAmount"].HeaderText = "RadiologyAmount";
                    dataGridView1.Columns["OPD_LabBillAmount"].HeaderText = "LabAmount";
                    dataGridView1.Columns["Total_Billing_Amount"].HeaderText = "OPDTotalAmount";
                   
                }
            }
            else
            {
                MessageBox.Show("NO data between  dates");
            }

        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            Report.OPD_Summary1 cryRpt = new Report.OPD_Summary1();


            TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
            ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
            Tables CrTablesNew;
            crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
            crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
            crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
            crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

            CrTablesNew = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
            {
                crtableLogoninfoNew = CrTable.LogOnInfo;
                crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
            }

            cryRpt.SetDataSource(dt);
            cryRpt.SetParameterValue("StartDate", dateTimePicker1.Value.Date.ToString("dd-MM-yyyy"));
            cryRpt.SetParameterValue("EndDate", dateTimePicker2.Value.Date.ToString("dd-MM-yyyy"));
            ReportViewerForOPD_Summary obj = new ReportViewerForOPD_Summary();

            obj.crystalReportViewer1.ReportSource = cryRpt;
            obj.Refresh();
            obj.Show();
            ReportDocument reportDocument = obj.crystalReportViewer1.ReportSource as ReportDocument;
            if (reportDocument != null)
            {
                // Export the report to PDF
                ExportOptions exportOptions = new ExportOptions();
                exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat; // PDF format

                // Set the path where you want to save the report
                string savePath = @"D:\HMS_OLD_BILLS\OPD_Summary\"; // Change this to your desired folder
                
                string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                string fileName = $"{todayDate}.pdf";

                // Combine the path and file name
                string filePath = Path.Combine(savePath, fileName);

                DiskFileDestinationOptions diskOptions = new DiskFileDestinationOptions();
                diskOptions.DiskFileName = filePath;

                exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                exportOptions.ExportDestinationOptions = diskOptions;

                // Export the report
                reportDocument.Export(exportOptions);

                Console.WriteLine("Report exported successfully to: " + filePath);
            }
            else
            {
                Console.WriteLine("Error: No report loaded in the CrystalReportViewer.");
            }
        }
    }
}
