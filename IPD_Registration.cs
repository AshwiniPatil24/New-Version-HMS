﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
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

namespace Ruby_Hospital
{
    public partial class IPD_Registration : Form
    {
        SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GLobal_Connection"].ConnectionString);
        string IIDA = "IPD/RSHJ";
        int countpatient;
        int abc;
        int A;//PID
       public int ipd_id;//IPDID
        public int Public_BEDID;
        public string mjpjay;
        public int PatientID;
        public int PatientIPDID;
        public string MJPJAY ;
        public int MjpjayIPD;
        public int Mpatient_id;
        

       public IPD_Registration()
        {
            InitializeComponent();
        }
      
        public IPD_Registration(int abc)
        {
            A = abc;
            InitializeComponent();

        }
        public IPD_Registration(string MJPJAY_INSU ,int Patient_ID, int Patient_IPDID )
        {

           mjpjay = MJPJAY_INSU;
            InitializeComponent();
            A = Patient_ID;
            PatientID = Patient_ID;
            PatientIPDID = Patient_IPDID;
            //show_mjpjayPatientDetails();
        }

        public void show_PatientDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT  Name, Age, Mobile_Number, Doctors_Name
FROM           Patient_Registration
WHERE        (PID = @PID)", con);
            cmd.Parameters.AddWithValue("@PID", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                DVGPatientInfo.DataSource = o;
                DVGPatientInfo.ColumnHeadersDefaultCellStyle.Font = new Font(DVGPatientInfo.Font, FontStyle.Bold);

            }
        }
        public void show_mjpjayPatientDetails()
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT           Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.IPD_Registration.IPD_ID,Ruby_Jamner123.Patient_Registration.Name,Ruby_Jamner123.Patient_Registration.Gender,Ruby_Jamner123.IPD_Registration.ConsultantID,Ruby_Jamner123.Patient_Registration.Mobile_Number, 
Ruby_Jamner123.Patient_Registration.Adhaar_ID,Ruby_Jamner123.Patient_Registration.PID,Ruby_Jamner123.IPD_Registration.IPDID,Ruby_Jamner123.IPD_Registration.Room_Segment,Ruby_Jamner123.IPD_Registration.Bed_No,Ruby_Jamner123.IPD_Registration.Mediclaim,Ruby_Jamner123.IPD_Registration.Date_Of_Admission,Ruby_Jamner123.IPD_Registration.Reserred_By
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
where Ruby_Jamner123.IPD_Registration.IPDID=@IPDID", connection1);
            cmd.Parameters.AddWithValue("@IPDID", PatientIPDID);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                dateTimePicker1.Text = Convert.ToString(dt.Rows[0]["Date_Of_Admission"]);
                cmbRoomSegment.Text=Convert.ToString(dt.Rows[0]["Room_Segment"]);
                cmb_BedNo.Text= Convert.ToString(dt.Rows[0]["Bed_No"]);
                MjpjayIPD = Convert.ToInt32(dt.Rows[0]["IPDID"]);
                Mpatient_id= Convert.ToInt32(dt.Rows[0]["PID"]);
                txtPatientIPDID.Text = Convert.ToString(dt.Rows[0]["IPD_ID"]);
                cmbMediclaim.Text = Convert.ToString(dt.Rows[0]["Mediclaim"]);
                cmbConsultant.Text=Convert.ToString(dt.Rows[0]["ConsultantID"]);
                cmbReferredBy.Text= Convert.ToString(dt.Rows[0]["Reserred_By"]);
            }
            connection1.Close();
        }
        
        private void IPD_Registration_Load(object sender, EventArgs e)
        {
            if (mjpjay == "YES")
            {
                //panel1.Visible = true;
                //groupBox1.Visible = false;

                bunSave.Visible = false;
                btnUpdate.Visible = true;

                show_PatientDetails();
                show_mjpjayPatientDetails();
                BindRoomsegment();
                BindbedNo();
                cmbTypeOfAddmission.SelectedIndex = 0;
                 
                groupBox2.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                groupBox1.Visible = true;
                rowcountipd();
                // txtidi.Text = A;
                generateAutoIId();
                //int w = Screen.PrimaryScreen.Bounds.Width;
                //int h = Screen.PrimaryScreen.Bounds.Height;
                //this.Location = new Point(0, 0);
                //this.Size = new Size(w, h);
                FetchDoctor();
                Referred_Doctor();
                show_PatientDetails();
                BindRoomsegment();
                if (checkIfselected() == false)
                {
                    cmb_BedNo.Enabled = false;
                }
                BindbedNo();
                btnUpdate.Visible = false;
            }

        }
        public void rowcountipd()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Patient_Registration", con);
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            s.Fill(dt);
            abc = dt.Rows.Count;
            //abc = abc + 6;
            txtidi.Text = abc.ToString();
        }
        public void generateAutoIId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Count(IPDID) From IPD_Registration", con);
            int i = Convert.ToInt32(cmb.ExecuteScalar());
            con.Close();
            i++;
            ipd_id = i;
            string a = i.ToString("0000");
            txtPatientIPDID.Text = IIDA + a;
        }
        public void BindRoomsegment()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Master_IPDRoomSegment", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbRoomSegment.DataSource = dt;
                cmbRoomSegment.DisplayMember = "Name";
                cmbRoomSegment.ValueMember = "ID";
            }
            con.Close();
        }
        public void BindbedNo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Master_IPDBedNo where (RoomSegmentID=@RoomSegmentID) and IsVacant=0", con);
            cmd.Parameters.AddWithValue(@"RoomSegmentID", cmbRoomSegment.SelectedIndex + 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmb_BedNo.DataSource = dt;
                cmb_BedNo.DisplayMember = "BedNo";
                cmb_BedNo.ValueMember = "ID";
                if (cmb_BedNo.Text != "")
                {
                    Public_BEDID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    txtIDBed.Text = Public_BEDID.ToString();
                }

            }
            con.Close();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtmlc.Checked == true)
            {
                MLC_Details md = new MLC_Details();
                md.Show();
            }
        }
        public void rowcount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Patient_Registration", con);
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            s.Fill(dt);
            countpatient = dt.Rows.Count;
        }
        public void global_IPD_data()
        {
            connection.Open();
            SqlCommand cmb = new SqlCommand(@"Update IPD_Patient_Details set IPD_ID=@IPD_ID,IPD_ID_Sr=@IPD_ID_Sr where Patient_ID=@Patient_ID", connection);
            cmb.Parameters.AddWithValue("@Patient_ID", A);           
            cmb.Parameters.AddWithValue("@IPD_ID", ipd_id);
            cmb.Parameters.AddWithValue("@IPD_ID_Sr", txtPatientIPDID.Text);                  
            cmb.ExecuteNonQuery();
            // MessageBox.Show(".....!");
        }
       
        private void bunSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmb_BedNo.Text == "")
                {
                    MessageBox.Show("No bed available in " + cmbRoomSegment.Text + " Segment");
                    return;
                }
                else
                {
                    rowcount();
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Insert into IPD_Registration (IPD_ID,Patient_Id,Relatives_Name,Relation,Relative_Mobile_No,
                                Date_Of_Admission,Type_Of_Admission,Mediclaim
                   ,Room_Segment,Bed_No,ConsultantID,Reserred_By,MLC_NonMLC,Remark) Values(@IPD_ID,@Patient_Id,@Relatives_Name,@Relation,@Relative_Mobile_No,@Date_Of_Admission,@Type_Of_Admission,@Mediclaim
                   ,@Room_Segment,@Bed_No,@ConsultantID,@Reserred_By,@MLC_NonMLC,@Remark)", con);

                    cmd.Parameters.AddWithValue("@IPD_ID", txtPatientIPDID.Text);
                    cmd.Parameters.AddWithValue("@Patient_Id", A);
                    if (txtReativeName.Text == "" || txtReativeName.Text == "Firstname                                    Middlename                                 Lastname")
                    {
                        MessageBox.Show("Enter relative name...");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Relatives_Name", txtReativeName.Text);
                    }
                    if (cmbRelation.Text == "")
                    {
                        MessageBox.Show("Select Relation...");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Relation", cmbRelation.Text);
                    }
                    if (txtRelativeMobileNo.Text == "")
                    {
                        MessageBox.Show("Select Mobile Number...");
                        return;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Relative_Mobile_No", txtRelativeMobileNo.Text);
                    }
                    if (cmbTypeOfAddmission.Text == "IPD")
                    {
                        cmd.Parameters.AddWithValue("@Type_Of_Admission", cmbTypeOfAddmission.Text);

                    }
                    else
                    {
                        MessageBox.Show("Select Admission Type...");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@Date_Of_Admission", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Mediclaim", cmbMediclaim.Text);
                    cmd.Parameters.AddWithValue("@Room_Segment", cmbRoomSegment.Text);
                    cmd.Parameters.AddWithValue("@Bed_No", cmb_BedNo.Text);
                    cmd.Parameters.AddWithValue("@ConsultantID", cmbConsultant.Text);
                    cmd.Parameters.AddWithValue("@Reserred_By", cmbReferredBy.Text);
                    cmd.Parameters.AddWithValue("@Remark", txtRemark.Text);

                    if (rbtnonmlc.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@MLC_NonMLC", "NON MLC");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MLC_NonMLC", "MLC");
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added Successfully ...");
                    SqlCommand cmd2 = new SqlCommand(@"update Master_IPDBedNo set Isvacant = 1 where roomsegmentid = @rs and bedno = @bno", con);
                    cmd2.Parameters.AddWithValue("@rs", cmbRoomSegment.SelectedIndex + 1);
                    cmd2.Parameters.AddWithValue("@bno", cmb_BedNo.Text);
                    cmd2.ExecuteNonQuery();
                    global_IPD_data();
                    con.Close();
                    assignedBedDetails();
                    bunSave.Visible = false;
                   

                   btnPrintIPDPaper_Click(sender, e);
                   btnPrintConsentForm_Click(sender, e);
                    button4.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void assignedBedDetails()
        {
            int charge = 0;
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand c = new SqlCommand(@"select charge from Master_IPDroomsegment where name = @name", con);
            c.Parameters.AddWithValue("@name", cmbRoomSegment.Text);
            SqlDataReader rdr = c.ExecuteReader();
            if (rdr.Read())
            {
                charge = Convert.ToInt32(rdr[0]);
            }
            rdr.Close();
            SqlCommand cmd = new SqlCommand(@"insert into [Ruby_Jamner123].[ipd_assignedbeddetails](IPDID,Bed_Segment,Bed_No,From_Date,Charges,Nursing_Charge) values (@ipdid,@seg,@bnumber,@date1,@charges,@nursingChrge)", con);
            cmd.Parameters.AddWithValue("@ipdid", ipd_id);
            cmd.Parameters.AddWithValue("@seg", cmbRoomSegment.Text);
            cmd.Parameters.AddWithValue("@bnumber", cmb_BedNo.Text);
            cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@charges", charge);
            if (cmbRoomSegment.Text == "ICU")
            {
                cmd.Parameters.AddWithValue("@nursingChrge", 500);
            }
            if (cmbRoomSegment.Text == "Genral Ward")
            {
                cmd.Parameters.AddWithValue("@nursingChrge", 300);
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void txtReativeName_MouseClick(object sender, MouseEventArgs e)
        {
            txtReativeName.Clear();
        }

        private void txtRelativeMobileNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtRelativeMobileNo.Clear();
        }

        private void cmbRoomSegment_Click(object sender, EventArgs e)
        {

        }
        
        private void txtPatientIPDID_Leave(object sender, EventArgs e)
        {
            if (txtPatientIPDID.Text == "")
            {
                txtPatientIPDID.Text = "123456789";
                txtPatientIPDID.ForeColor = Color.Gray;
            }
        }

        public void FetchDoctor()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand com = new SqlCommand(@"Select * From Doctors", con);
            SqlDataAdapter adt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbConsultant.DataSource = dt;
                cmbConsultant.DisplayMember = "Dr_Name";
                cmbConsultant.ValueMember = "DR_ID";
            }
            con.Close();
        }
        public void Referred_Doctor()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand com = new SqlCommand(@"Select * From Referred_Doctor", con);
            SqlDataAdapter adt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbReferredBy.DataSource = dt;
                cmbReferredBy.DisplayMember = "Referred_Name";
                cmbReferredBy.ValueMember = "ReferredID";
            }
            con.Close();
        }

        private void cmbRoomSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_BedNo.Enabled = true;
            cmb_BedNo.DataSource = null;
            BindbedNo();
        }

        public bool checkIfselected()
        {
            if (cmbRoomSegment.SelectedIndex == -1)
                return false;
            return true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnPrintIPDPaper_Click(object sender, EventArgs e)
        {
            try
            {

                //2 for Login to server                 
                IPDReport.rptIPDPaper cryRptNew = new IPDReport.rptIPDPaper();


                TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                Tables CrTablesNew;


                crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                CrTablesNew = cryRptNew.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                {
                    crtableLogoninfoNew = CrTable.LogOnInfo;
                    crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                    CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                }

                cryRptNew.SetParameterValue("IPDID", ipd_id);


                ReportViewerForOPD obj = new ReportViewerForOPD();
                obj.crystalReportViewer1.ReportSource = cryRptNew;
                obj.Refresh();
                obj.Show();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPrintConsentForm_Click(object sender, EventArgs e)
        {
            try
            {

                //2 for Login to server                 
                IPDReport.rptConsentForm cryRptNew = new IPDReport.rptConsentForm();


                TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                Tables CrTablesNew;

                //crConnectionInfo.ServerName = "COMP-PC\SQLEXPRESS\\SQLEXPRESS";
                //crConnectionInfo.DatabaseName = "Db_SSH";
                //crConnectionInfo.UserID = "SSH1";
                //crConnectionInfo.Password = "SSH1";

                //crConnectionInfo.ServerName = "SERVER\\SQLEXPRESS";
                //crConnectionInfo.DatabaseName = "Db_SSH";
                //crConnectionInfo.UserID = "SSH2";
                //crConnectionInfo.Password = "SSH2";

                //crConnectionInfo.IntegratedSecurity = true;
                //crConnectionInfo.ServerName = "SERVER\\SQLEXPRESS";
                crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                CrTablesNew = cryRptNew.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                {
                    crtableLogoninfoNew = CrTable.LogOnInfo;
                    crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                    CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                }

                cryRptNew.SetParameterValue("IPDID", ipd_id);

                ReportViewerForOPD obj = new ReportViewerForOPD();
                //frmrptLabPaymentReceipt obj = new frmrptLabPaymentReceipt();
                obj.crystalReportViewer1.ReportSource = cryRptNew;
                obj.Refresh();
                obj.Show();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@" Update IPD_Registration set Date_Of_Admission=@Date_Of_Admission,Room_Segment=@Room_Segment,Bed_No=@Bed_No,Mediclaim=@Mediclaim,ConsultantID=@ConsultantID,Reserred_By=@Reserred_By where IPDID=@IPDID", connection1);
            cmd.Parameters.AddWithValue("@IPDID", MjpjayIPD);
            cmd.Parameters.AddWithValue("@Date_Of_Admission", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Room_Segment", cmbRoomSegment.Text);
            cmd.Parameters.AddWithValue("@Bed_No", cmb_BedNo.Text);
            cmd.Parameters.AddWithValue("@Mediclaim", cmbMediclaim.Text);
            cmd.Parameters.AddWithValue("@ConsultantID", cmbConsultant.Text);
            cmd.Parameters.AddWithValue("@Reserred_By", cmbReferredBy.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            frmMJPJAYPatientRegistration mjpjay = new frmMJPJAYPatientRegistration(Mpatient_id,MjpjayIPD);
            mjpjay.Show();


        }

        private void btnMJPJAY_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Patient added to MYPYAY.Please select below details.");
            //MJPJAY = "YES";
            ///IPD_Registration_Load(sender, e);
        }
    }
}


