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
    public partial class IPD_Details : Form
    {
        DataTable dt;
        public IPD_Details()
        {
            InitializeComponent();
        }

        private void IPD_Details_Load(object sender, EventArgs e)
        {
           
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "By Between Dates")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                string StartDate = dateTimePicker1.Value.ToString("dd-mm-yyyy");
                string EndDate = dateTimePicker2.Value.ToString("dd-mm-yyyy");
                SqlCommand cmb = new SqlCommand(@"SELECT Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.IPD_Registration.IPD_ID,Ruby_Jamner123.IPD_Registration.IPDID,Ruby_Jamner123.Patient_Registration.Name,Ruby_Jamner123.Patient_Registration.Gender, Ruby_Jamner123.Patient_Registration.Age,Ruby_Jamner123.IPD_Registration.Room_Segment, Ruby_Jamner123.Patient_Registration.Mobile_Number, 
                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission
                         FROM Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id where  Ruby_Jamner123.IPD_Registration.Date_Of_Admission >= @StartDate AND   Ruby_Jamner123.IPD_Registration.Date_Of_Admission <= @EndDate", con);
                SqlDataAdapter adt = new SqlDataAdapter(cmb);
                cmb.Parameters.AddWithValue("@StartDate", StartDate);
                cmb.Parameters.AddWithValue("@EndDate", EndDate);
                dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["IPDID"].Visible = false;
                    dataGridView1.Columns["PID"].Visible = false;

                }
                else
                {
                    MessageBox.Show("NO data between  dates");
                }
            }
           
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            IPDReport.Ipd_Details cryRpt = new IPDReport.Ipd_Details();

             
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

            ReportViewerForIPD_Details obj = new ReportViewerForIPD_Details();

            obj.crystalReportViewer1.ReportSource = cryRpt;
            obj.Refresh();
            obj.Show();
        }
    }
}
