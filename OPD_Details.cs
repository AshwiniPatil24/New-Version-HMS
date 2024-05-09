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
    public partial class OPD_Details : Form
    {
        DataTable dt;
        public OPD_Details()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void OPD_Details_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "By Between Dates")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                DateTime StartDate = dateTimePicker1.Value;
                DateTime EndDate = dateTimePicker2.Value;
                SqlCommand cmd = new SqlCommand(@"SELECT  Ruby_Jamner123.Patient_Registration.PID,OPD_Patient_Registration.PatientId,Patient_Registration.Patient_ID,OPD_Patient_Registration.PatientOPDIdWithSr,Patient_Registration.Name, Patient_Registration.Gender,Patient_Registration.Age, Patient_Registration.Mobile_Number, Patient_Registration.Adhaar_ID,OPD_Patient_Registration.VisitDate
                      FROM Patient_Registration INNER JOIN OPD_Patient_Registration ON Patient_Registration.PID = OPD_Patient_Registration.PatientId where OPD_Patient_Registration.VisitDate >= @StartDate AND OPD_Patient_Registration.VisitDate <= @EndDate", con);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                 dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["PatientId"].Visible = false;
                    dataGridView1.Columns["PID"].Visible = false;
                    dataGridView1.Columns["PatientOPDIdWithSr"].HeaderText = "OPDID";
                }

            }
            else
            {
                MessageBox.Show("NO data between  dates");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            Report.Opd_details cryRpt = new Report.Opd_details();


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

            ReportViewerForOPD_Details obj = new ReportViewerForOPD_Details();

            obj.crystalReportViewer1.ReportSource = cryRpt;
            obj.Refresh();
            obj.Show();
        }
    }
}
