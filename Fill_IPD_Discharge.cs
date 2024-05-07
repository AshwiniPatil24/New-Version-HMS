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
    public partial class Fill_IPD_Discharge : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GLobal_Connection"].ConnectionString);
        public int IPDID;
        public int PID;
        public string IPDwithStr;
        public string PIDwithStr;
        public string PatientName;
        public int Age;
        public string RelativeName;
        public string DrName;
        public string ReferredBy;
        public string AdmissionDate;
        public string Patient_MobNo;
        public string Relative_MobNo;

        public Fill_IPD_Discharge()
        {
            InitializeComponent();
        }

        public  Fill_IPD_Discharge(int PID,int IPDID)
        {
            InitializeComponent();
            this.PID = PID;
            this.IPDID = IPDID;

        }

        private void Fill_IPD_Discharge_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            showdata();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void metroTabControl1_Selected(object sender, TabControlEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"insert into Ruby_Jamner123.IPD_discharge_PatientInfo (PID,PIDwithSTR,IPDID,IPDIDwithSTR,Patient_Name,Age,Mobile_Number,Relative_Name,Relative_MobileNumber,Doctor_Name,Referred_By,Discharge_Type,Approved_By,Admission_Date,FollowUp_Date,Discharge_Date)
values (@PID,@PIDwithSTR,@IPDID,@IPDIDwithSTR,@Patient_Name,@Age,@Mobile_Number,@Relative_Name,@Relative_MobileNumber,@Doctor_Name,@Referred_By,@Discharge_Type,@Approved_By,@Admission_Date,@FollowUp_Date,@Discharge_Date)", con);
            cmd.Parameters.AddWithValue("@PID",PID);
            cmd.Parameters.AddWithValue("@PIDwithSTR",PIDwithStr);
            cmd.Parameters.AddWithValue("@IPDID",IPDID);
            cmd.Parameters.AddWithValue("@IPDIDwithSTR",IPDwithStr);
            cmd.Parameters.AddWithValue("@Patient_Name",PatientName);
            cmd.Parameters.AddWithValue("@Age",Age);
            cmd.Parameters.AddWithValue("@Mobile_Number",Patient_MobNo);
            cmd.Parameters.AddWithValue("@Relative_Name",RelativeName);
            cmd.Parameters.AddWithValue("@Relative_MobileNumber",Relative_MobNo);
            cmd.Parameters.AddWithValue("@Doctor_Name",DrName);
            cmd.Parameters.AddWithValue("@Referred_By",ReferredBy);
            cmd.Parameters.AddWithValue("@Discharge_Type",comboBox2.Text);
            cmd.Parameters.AddWithValue("@Approved_By",comboBox3.Text);
            cmd.Parameters.AddWithValue("@Admission_Date",AdmissionDate);
            cmd.Parameters.AddWithValue("@FollowUp_Date",dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Discharge_Date",dateTimePicker2.Text);
            cmd.ExecuteNonQuery();
            updateDischargeDateinIPDtable();
            MessageBox.Show("Details saved successfully!!!");
            Global_IPDDischargesUpdate();
            updateOldBed();
            vacantOldBed();
            button1.Enabled = false;
            button1.BackColor = Color.Gray;
            button2.Visible = true;
            button3.Visible = true;

        }
        public void Global_IPDDischargesUpdate()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"update IPD_Patient_Details set Discharge_Date=@Discharge_Date where IPD_ID=@IPD_ID", connection);

            cmd.Parameters.AddWithValue("@IPD_ID", IPDID);
            cmd.Parameters.AddWithValue("@Discharge_Date", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public int getID()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select max(ID) from ipd_assignedbeddetails where ipdid = @id", con);
            cmd.Parameters.AddWithValue("@id", IPDID);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return id;
        }
        public void updateOldBed()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update ipd_assignedbeddetails set To_Date = @date where id=@id and To_Date IS NULL", con);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@id", getID());
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void vacantOldBed()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            string segment;
            int id;
            SqlCommand cmd1 = new SqlCommand("SELECT Bed_Segment,Bed_No FROM ipd_assignedbeddetails WHERE ID = " +
                "(SELECT MAX(ID) FROM ipd_assignedbeddetails WHERE ipdid = @ipdid) " +
                "AND ipdid = @ipdid", con);
            cmd1.Parameters.AddWithValue("@ipdid",IPDID);
            SqlDataReader rdr = cmd1.ExecuteReader();
            if (rdr.Read())
            {
                segment = rdr["Bed_Segment"].ToString();
                id = Convert.ToInt32(rdr["Bed_No"]);
                rdr.Close();
                SqlCommand cmd2 = new SqlCommand(@"select ID from Ruby_Jamner123.Master_IPDRoomSegment where Name = '" + segment + "'", con);
                int segId = Convert.ToInt32(cmd2.ExecuteScalar());
                SqlCommand cmd3 = new SqlCommand(@"update Master_IPDBedNo set isvacant = 0 where roomsegmentid = @rs and bedno = @bno", con);
                cmd3.Parameters.AddWithValue("@rs", segId);
                cmd3.Parameters.AddWithValue("@bno", id);
                cmd3.ExecuteNonQuery();
            }
            con.Close();
        }

            public void updateDischargeDateinIPDtable()
            {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Ruby_Jamner123.IPD_Registration set DischargeDate = '"+dateTimePicker2.Text+"' where ipdid = "+IPDID, con);
            cmd.ExecuteNonQuery();
            }

        public void showdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number,Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.IPD_Registration.Relatives_Name,Ruby_Jamner123.IPD_Registration.Relative_Mobile_No,Ruby_Jamner123.IPD_Registration.ConsultantID,Ruby_Jamner123.IPD_Registration.Reserred_By,
                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission,Ruby_Jamner123.IPD_Registration.IPD_ID
FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.IPD_Registration.Patient_Id = Ruby_Jamner123.Patient_Registration.PID
WHERE        (Ruby_Jamner123.IPD_Registration.Patient_Id = @Patient_Id  and Ruby_Jamner123.IPD_Registration.IPDID = @ipdid)", con);
            cmd.Parameters.AddWithValue(@"Patient_Id", PID);
            cmd.Parameters.AddWithValue(@"ipdid", IPDID);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;
                IPDwithStr = dataGridView1.CurrentRow.Cells["IPD_ID"].Value.ToString();
                PIDwithStr = dataGridView1.CurrentRow.Cells["Patient_ID"].Value.ToString();
                PatientName = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                Age = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Age"].Value);
                RelativeName = dataGridView1.CurrentRow.Cells["Relatives_Name"].Value.ToString();
                DrName = dataGridView1.CurrentRow.Cells["ConsultantID"].Value.ToString();
                ReferredBy = dataGridView1.CurrentRow.Cells["Reserred_By"].Value.ToString();
                AdmissionDate = dataGridView1.CurrentRow.Cells["Date_Of_Admission"].Value.ToString();
                Patient_MobNo = dataGridView1.CurrentRow.Cells["Mobile_Number"].Value.ToString();
                Relative_MobNo = dataGridView1.CurrentRow.Cells["Relative_Mobile_No"].Value.ToString();
                dataGridView1.Columns["ConsultantID"].Visible = false;
                dataGridView1.Columns["Reserred_By"].Visible = false;
                dataGridView1.Columns["Date_Of_Admission"].Visible = false;
                dataGridView1.Columns["IPD_ID"].Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Get_Pass o = new Get_Pass(IPDID);
            o.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPDReport.DischargeReport rpt = new IPDReport.DischargeReport();

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

            rpt.SetParameterValue("IPDID", IPDID);
            ShowIPDDischarge obj = new ShowIPDDischarge();
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
                string savePath = @"D:\HMS_OLD_BILLS\DISCHARGE_SUMMARY\"; // Change this to your desired folder
                string ipdId = IPDID.ToString();
                string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                string fileName = $"{ipdId}_{todayDate}.pdf";

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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
