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
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Ruby_Hospital
{
    public partial class Get_Pass : Form
    {
        public string Date = DateTime.Today.ToString("ddMMyyyy");
        public int IPDID;
        public string Pass_ID = "";

        public Get_Pass()
        {
            InitializeComponent();
        }

        public Get_Pass(int IPDID)
        {
            InitializeComponent();
            this.IPDID = IPDID;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void assignID()
        {
            Pass_ID = Date + IPDID;
            txtPASSid.Text = Pass_ID;

        }

        public void getDischargeDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Ruby_Jamner123.IPD_discharge_PatientInfo where IPDID = @ipdid", con);
            cmd.Parameters.AddWithValue("@ipdid",IPDID);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                txtPatientname.Text = rdr["Patient_Name"].ToString();
                txtMobNo.Text = rdr["Mobile_Number"].ToString();
                txtConsultant.Text = rdr["Doctor_Name"].ToString();
                txtReferred.Text = rdr["Referred_By"].ToString();
                txtDischargeType.Text = rdr["Discharge_Type"].ToString();
                txtApprovedBy.Text = rdr["Approved_By"].ToString();
                txtAdmitDate.Text = rdr["Admission_Date"].ToString();
                txtDischargeDate.Text = rdr["Discharge_Date"].ToString();
            }
            rdr.Close();
        }

        public void AssignNote()
        {
            txtNote.Text = "The gate pass will be valid until 11:59 PM of the discharge date.";

        }

        private void Get_Pass_Load(object sender, EventArgs e)
        {
            assignID();
            getDischargeDetails();
            AssignNote();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Ruby_Jamner123.GetPassDetails(GetPass_ID,Patient_Name,Mobile_No,DischargeType,ApprovedBy,AdmitDate,DischargeDate,Note) values(@GetPass_ID,@Patient_Name,@Mobile_No,@DischargeType,@ApprovedBy,@AdmitDate,@DischargeDate,@Note)", con);
            cmd.Parameters.AddWithValue("@GetPass_ID",txtPASSid.Text);
            cmd.Parameters.AddWithValue("@Patient_Name",txtPatientname.Text);
            cmd.Parameters.AddWithValue("@Mobile_No",txtMobNo.Text);
            cmd.Parameters.AddWithValue("@DischargeType",txtDischargeType.Text);
            cmd.Parameters.AddWithValue("@ApprovedBy",txtApprovedBy.Text);
            cmd.Parameters.AddWithValue("@AdmitDate",txtAdmitDate.Text);
            cmd.Parameters.AddWithValue("@DischargeDate",txtDischargeDate.Text);
            cmd.Parameters.AddWithValue("@Note",txtNote.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Get pass alloted!!!");
            btnSave.Enabled = false;
            btnSave.BackColor = Color.Gray;
            btnExit.Visible = true;
            button1.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPDReport.GatePass rpt = new IPDReport.GatePass();

            TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
            ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
            Tables CrTablesNew;
            crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
            crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
            crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
            crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

            CrTablesNew = rpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
            {
                crtableLogoninfoNew = CrTable.LogOnInfo;
                crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
            }

            rpt.SetParameterValue("ID",txtPASSid.Text);
            rpt.SetParameterValue("Name",txtPatientname.Text);
            rpt.SetParameterValue("DischargeType",txtDischargeType.Text);
            rpt.SetParameterValue("ApprovedType",txtApprovedBy.Text);
            rpt.SetParameterValue("DischargeDate",txtDischargeDate.Text);
            rpt.SetParameterValue("Note",txtNote.Text);
            ShowGatePass obj = new ShowGatePass();
            obj.crystalReportViewer1.ReportSource = rpt;
            obj.Refresh();
            obj.Show();
            ReportDocument reportDocument = obj.crystalReportViewer1.ReportSource as ReportDocument;
            if (reportDocument != null)
            {
                // Export the report to PDF
                ExportOptions exportOptions = new ExportOptions();
                exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat; // PDF format

                // Set the path where you want to save the report
                string savePath = @"D:\HMS_OLD_BILLS\GATE_PASS\"; // Change this to your desired folder
                string gatePassId = txtPASSid.Text;
                string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                string fileName = $"{gatePassId}_{todayDate}.pdf";

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
