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


namespace Ruby_Hospital
{
    public partial class IPD_Billing_Details : Form
    {
        DataTable o;
        public IPD_Billing_Details()
        {
            InitializeComponent();
        }

        private void IPD_Summary_Load(object sender, EventArgs e)
        {
               
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            IPDReport.IPD_Billing_Details cryRpt = new IPDReport.IPD_Billing_Details();


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

            cryRpt.SetDataSource(o);
            cryRpt.SetParameterValue("StartDate", dateTimePicker1.Value.Date.ToString("dd-MM-yyyy"));
            cryRpt.SetParameterValue("EndDate", dateTimePicker2.Value.Date.ToString("dd-MM-yyyy"));
            ReportViewerForIPDBillingDetail obj = new ReportViewerForIPDBillingDetail();

            obj.crystalReportViewer1.ReportSource = cryRpt;
            obj.Refresh();
            obj.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "By Between Dates")
            {

                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                string StartDate = dateTimePicker1.Value.ToString("dd-mm-yyyy");
                string EndDate = dateTimePicker2.Value.ToString("dd-mm-yyyy");
                SqlCommand cmb = new SqlCommand(@"SELECT Ruby_Jamner123.Patient_Registration.PID,Ruby_Jamner123.MainIPDBillingDetails.IPDID_with_str,Ruby_Jamner123.Patient_Registration.Name,Ruby_Jamner123.MainIPDBillingDetails.IPDID,Ruby_Jamner123.MainIPDBillingDetails.BillDate,Ruby_Jamner123.MainIPDBillingDetails.RegistrationCharges,Ruby_Jamner123.MainIPDBillingDetails.ConsultantCharges,
                                               Ruby_Jamner123.MainIPDBillingDetails.NursingCharges,Ruby_Jamner123.MainIPDBillingDetails.BedCharges,Ruby_Jamner123.MainIPDBillingDetails.HospitalProcCharges,Ruby_Jamner123.MainIPDBillingDetails.SurgicalProcCharges,Ruby_Jamner123.MainIPDBillingDetails.MedicalRecordCharges,
                                               Ruby_Jamner123.MainIPDBillingDetails.BioMedicalWasteCharges,Ruby_Jamner123.MainIPDBillingDetails.ConsultantVisitingCharges,Ruby_Jamner123.MainIPDBillingDetails.AdministrativeCharges,Ruby_Jamner123.MainIPDBillingDetails.TotalBillAmount
                        FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.MainIPDBillingDetails ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.MainIPDBillingDetails.IPDID where Ruby_Jamner123.MainIPDBillingDetails.BillDate >= @StartDate AND  Ruby_Jamner123.MainIPDBillingDetails.BillDate <= @EndDate", con);
                SqlDataAdapter adt = new SqlDataAdapter(cmb);
                cmb.Parameters.AddWithValue("@StartDate", StartDate);
                cmb.Parameters.AddWithValue("@EndDate", EndDate);
                o = new DataTable();
                adt.Fill(o);
                if (o.Rows.Count > 0)
                {
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.DataSource = o;
                    dataGridView1.Columns["IPDID"].Visible = false;
                    dataGridView1.Columns["PID"].Visible = false;
                    dataGridView1.Columns["BillDate"].Visible = false;
                    dataGridView1.Columns["IPDID_with_str"].HeaderText = "IPDID";
                }
                else
                {
                    MessageBox.Show("NO data between  dates");
                }
            }
            
        }
    }
}
