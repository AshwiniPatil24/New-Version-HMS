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
    public partial class Discharge_Details : Form
    {
        DataTable o;
        public Discharge_Details()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Discharge_Details_Load(object sender, EventArgs e)
        {
           
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Between Dates")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                DateTime StartDate = dateTimePicker1.Value;
                DateTime EndDate = dateTimePicker2.Value;
                SqlCommand cmb = new SqlCommand(@"select * From IPD_discharge_PatientInfo where Ruby_Jamner123.IPD_discharge_PatientInfo.Discharge_date >= @StartDate AND  Ruby_Jamner123.IPD_discharge_PatientInfo.Discharge_date <= @EndDate", con);
                SqlDataAdapter adt = new SqlDataAdapter(cmb);
                cmb.Parameters.AddWithValue("@StartDate", StartDate);
                cmb.Parameters.AddWithValue("@EndDate", EndDate);
                o = new DataTable();
                adt.Fill(o);
                if (o.Rows.Count > 0)
                {
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.DataSource = o;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["PID"].Visible = false;
                    dataGridView1.Columns["IPDID"].Visible = false;
                    dataGridView1.Columns["Referred_By"].Visible = false;
                    dataGridView1.Columns["FollowUP_Date"].Visible = false;
                    dataGridView1.Columns["Relative_Name"].Visible = false;
                    dataGridView1.Columns["Relative_MobileNumber"].Visible = false;
                    dataGridView1.Columns["Admission_Date"].Visible = false;
                    dataGridView1.Columns["PIDwithSTR"].HeaderText = "PatientID";
                    dataGridView1.Columns["IPDIDwithSTR"].HeaderText = "IPDID";
                }
                else
                {
                    MessageBox.Show("NO data between  dates");
                }
            }
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            IPDReport.Dischrge_details cryRpt = new IPDReport.Dischrge_details();


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

            RepportViewerForDischargedetail obj = new RepportViewerForDischargedetail();

            obj.crystalReportViewer1.ReportSource = cryRpt;
            obj.Refresh();
            obj.Show();
        }
    }
}
