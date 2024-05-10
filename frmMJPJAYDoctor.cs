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
    public partial class frmMJPJAYDoctor : Form
    {
        SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        DateTimePicker dtp;
        public int id;
        public int ipdid;
        public string PublicMJPJAY_Check;


        public int PatientMJPJAYID_Public;
        public int PublicDoctor_Check;
        public frmMJPJAYDoctor()
        {
            InitializeComponent();
        }
        public frmMJPJAYDoctor(int a, int b)
        {
            InitializeComponent();
            id = a;
            ipdid = b;
        }
        public void Patientinfo()
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT       dbo.MJPJAY_PatientDetailsnew.MJPJAY_NO, Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.IPD_Registration.IPD_ID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Gender, 
                         Ruby_Jamner123.IPD_Registration.ConsultantID, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID, Ruby_Jamner123.Patient_Registration.PID, 
                         Ruby_Jamner123.IPD_Registration.IPDID, Ruby_Jamner123.IPD_Registration.Room_Segment, Ruby_Jamner123.IPD_Registration.Bed_No, Ruby_Jamner123.IPD_Registration.Mediclaim, 
                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission, Ruby_Jamner123.IPD_Registration.Reserred_By
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id INNER JOIN
                         dbo.MJPJAY_PatientDetailsnew ON Ruby_Jamner123.IPD_Registration.IPDID = dbo.MJPJAY_PatientDetailsnew.IPDID
WHERE        (Ruby_Jamner123.IPD_Registration.IPDID = @IPDID)", connection1);
            cmd.Parameters.AddWithValue("@IPDID", ipdid);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Adhaar_ID"].HeaderText = "Aadhar_ID";
                dataGridView1.Columns["Reserred_By"].HeaderText = "Referred_By";

            }
            connection1.Close();
     
        }
        public void MJpjaysurgery()
        {
            try
            {
                connection1.Open();
                SqlCommand cmd = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew where IPDID=@IPDID and MJPJAY_NO>0", connection1);
                 cmd.Parameters.AddWithValue("@IPDID", ipdid);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dtDoctor = new DataTable();
                sd.Fill(dtDoctor);
                
                DVGMJPJAYDetails.DataSource = dtDoctor;
                if (DVGMJPJAYDetails.RowCount > 0)
                {
                    PatientMJPJAYID_Public = Convert.ToInt32(dtDoctor.Rows[0]["MJPJAY_ID"]);
                    PublicDoctor_Check = Convert.ToInt32(dtDoctor.Rows[0]["Doctor_Check"]);
                    /// PublicMJPJAYNO = Convert.ToString(dtDoctor.Rows[0]["MJPJAY_NO"]);
                    DVGMJPJAYDetails.Columns["MJPJAY_NO"].Visible = false;
                    DVGMJPJAYDetails.Columns["MJPJAY_ID"].Visible = false;
                    DVGMJPJAYDetails.Columns["IPDID"].Visible = false;
                    DVGMJPJAYDetails.Columns["Date"].Visible = false;
                    DVGMJPJAYDetails.Columns["MJPJAY_MainCategory"].Visible = false;
                    DVGMJPJAYDetails.Columns["MJPJAY_SubCategory"].Visible = false;
                    DVGMJPJAYDetails.Columns["PackageAmount"].Visible = false;
                    DVGMJPJAYDetails.Columns["Surgery_Date"].HeaderText = "Select Date For surgery";
                    DVGMJPJAYDetails.Columns["Doctor_Check"].HeaderText = "Select Surgery";
                    DVGMJPJAYDetails.Columns["Due_Amount"].Visible = false;
                    DVGMJPJAYDetails.Columns["Partial_Amount"].Visible = false;
                    DVGMJPJAYDetails.Columns["Received"].Visible = false;
                    DVGMJPJAYDetails.Columns["Partial"].Visible = false;
                    DVGMJPJAYDetails.Columns["Remark"].Visible = false;
                    DVGMJPJAYDetails.Columns["Anaesthesia"].Visible = false;
                    DVGMJPJAYDetails.Columns["SurgeonID1"].Visible = false;
                    DVGMJPJAYDetails.Columns["SurgeonID2"].Visible = false;
                    DVGMJPJAYDetails.Columns["AssistantID1"].Visible = false;
                    DVGMJPJAYDetails.Columns["AssistantID2"].Visible = false;
                    DVGMJPJAYDetails.Columns["MJPJAY_Surgery"].HeaderText = "MJPJAY Surgery Name";
                    //DVGMJPJAYDetails.Columns[1].Width = 100;
                    DVGMJPJAYDetails.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    DVGMJPJAYDetails.Columns[7].Width = 850;
                    DVGMJPJAYDetails.Columns[7].ReadOnly = true;
                    //DVGMJPJAYDetails.Columns[7].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //DVGMJPJAYDetails.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    DVGMJPJAYDetails.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    DVGMJPJAYDetails.Columns[9].Width = 150;
                    //DVGMJPJAYDetails.RowTemplate.Height = 60;

                    
                }
                else
                {
                    DVGMJPJAYDetails.Visible = false;
                    
                }
                connection1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from Doctors", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbSurgen1.DataSource = dt;
                cmbSurgen1.DisplayMember = "Dr_Name";
                cmbSurgen1.ValueMember = "DR_ID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["DR_ID"] = "0";
                drr1["Dr_Name"] = "---Select Surgon Name---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "DR_ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                cmbSurgen1.DataSource = dt;
                cmbSurgen1.DisplayMember = "Dr_Name";
                cmbSurgen1.ValueMember = "DR_ID";
                cmbSurgen1.Text = "--Select Surgon Name--";

            }
            con.Close();
        }
        public void showAssistantName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from ListOfAssistants", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbAssistant1.DataSource = dt;
                cmbAssistant1.DisplayMember = "Assistant_Name";
                cmbAssistant1.ValueMember = "ID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["ID"] = "0";
                drr1["Assistant_Name"] = "---Select Assistant Name---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                cmbAssistant1.DataSource = dt;
                cmbAssistant1.DisplayMember = "Assistant_Name";
                cmbAssistant1.ValueMember = "ID";
                cmbAssistant1.Text = "--Select Assistant Name--";

            }
        }
        public void showAnesthethit()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from ListOfAnesthetist", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbAnesthetist.DataSource = dt;
                cmbAnesthetist.DisplayMember = "Anesthetist";
                cmbAnesthetist.ValueMember = "ID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["ID"] = "0";
                drr1["Anesthetist"] = "---Select Anesthetist ---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                cmbAnesthetist.DataSource = dt;
                cmbAnesthetist.DisplayMember = "Anesthetist";
                cmbAnesthetist.ValueMember = "ID";
                cmbAnesthetist.Text = "--Select Anesthetist--";

            }
        }
        public void SaveSurgonName()
        {
            try
            {

                if (cmbSurgen1.Text != "---Select Surgon Name---")
                {

                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Insert into SurgeonName (IPDID,SurgeryName,SurgeonName) Values(@IPDID,@SurgeryName,@SurgeonName)", con);
                    cmd.Parameters.AddWithValue("@IPDID", ipdid);
                    cmd.Parameters.AddWithValue("@SurgeryName", PublicMJPJAY_Check);
                    cmd.Parameters.AddWithValue("@SurgeonName", cmbSurgen1.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    ShowSurgon();
                    bunSave.Enabled = true;
                    bunSave.BackColor = Color.DarkGreen;
                    show();

                }
                else
                {
                    MessageBox.Show("Select Surgon Name");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void ShowSurgon()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select ID,SurgeonName From SurgeonName where SurgeryName=@SurgeryName and IPDID=@id", con);
            cmd.Parameters.AddWithValue(@"id", ipdid);
            cmd.Parameters.AddWithValue(@"SurgeryName", PublicMJPJAY_Check);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > -1)
            {
                dataGridView3.DataSource = dtPublic;
                dataGridView3.Columns["ID"].Visible = false;
            }
            con.Close();
        }
        //public void ShowAnesthetistName()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(@"Select ID,Anesthetist From  Anesthetit_SurgeryName where SurgeryName=@SurgeryName and IPDID=@id", con);
        //    cmd.Parameters.AddWithValue(@"id", ipdid);
        //    cmd.Parameters.AddWithValue(@"SurgeryName", PublicMJPJAY_Check);
        //    SqlDataAdapter adt = new SqlDataAdapter(cmd);
        //    DataTable dtPublic = new DataTable();
        //    adt.Fill(dtPublic);
        //    if (dtPublic.Rows.Count > -1)
        //    {
        //        dataGridView5.DataSource = dtPublic;
        //        dataGridView5.Columns["ID"].Visible = false;
        //    }

        //}
        public void SaveAnesthetistName()
        {
            if (cmbAnesthetist.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into Anesthetit_SurgeryName(IPDID,SurgeryName,Anesthetist) Values(@IPDID,@SurgeryName,@Anesthetist)", con);
                cmd.Parameters.AddWithValue("@IPDID", ipdid);
                cmd.Parameters.AddWithValue("@SurgeryName", PublicMJPJAY_Check);
                cmd.Parameters.AddWithValue("@Anesthetist", cmbAnesthetist.Text);

                cmd.ExecuteNonQuery();
                
            }
            else
            {
                MessageBox.Show("Select Anesthetist");
            }
        }
        private void frmMJPJAYDoctor_Load(object sender, EventArgs e)
        {
            Patientinfo();
            MJpjaysurgery();
            show();
            showAssistantName();
            showAnesthethit();
        }

        private void DVGMJPJAYDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void DVGMJPJAYDetails_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if ((DVGMJPJAYDetails.Focused) && (DVGMJPJAYDetails.CurrentCell.ColumnIndex == 9))
                {
                    dtp.Location = DVGMJPJAYDetails.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    dtp.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DVGMJPJAYDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((DVGMJPJAYDetails.Focused) && (DVGMJPJAYDetails.CurrentCell.ColumnIndex == 9))
                {
                    DVGMJPJAYDetails.CurrentCell.Value = dtp.Value.Date;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DVGMJPJAYDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    PublicDoctor_Check = Convert.ToInt32(DVGMJPJAYDetails.CurrentRow.Cells["Doctor_Check"].Value);
                    if (PublicDoctor_Check == 1)
                    {
                        PublicMJPJAY_Check = Convert.ToString(DVGMJPJAYDetails.CurrentRow.Cells["MJPJAY_Surgery"].Value);
                        var cell = DVGMJPJAYDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        if (cell.ReadOnly == false && cell is DataGridViewTextBoxCell)
                        {
                            DVGMJPJAYDetails.CurrentCell = cell;
                            var cellRectangle = DVGMJPJAYDetails.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                            var dateTimePicker = new DateTimePicker()
                            {
                                Format = DateTimePickerFormat.Custom,
                                CustomFormat = cell.Style.Format,
                                Value = DateTime.Parse(cell.Value.ToString()),
                                Visible = true,
                                Width = cellRectangle.Width,
                                Height = cellRectangle.Height,
                                Location = cellRectangle.Location
                            };
                            dateTimePicker.ValueChanged += (s, ev) =>
                            {
                                cell.Value = dateTimePicker.Value;
                            };
                            DVGMJPJAYDetails.Controls.Add(dateTimePicker);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select surgery and then update date");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        public void ShowAssistantName()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select ID,AssistantName From AssistantName_Table where SurgeryName=@SurgeryName and IPDID=@id", con);
            cmd.Parameters.AddWithValue(@"id", ipdid);
            cmd.Parameters.AddWithValue(@"SurgeryName", PublicMJPJAY_Check);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > -1)
            {
                dataGridView2.DataSource = dtPublic;
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["AssistantName"].HeaderText = "Assistant_Name";
            }
           bunSave.Enabled = true;
            bunSave.BackColor = Color.DarkGreen;
            con.Close();
        }
        public void SaveAssistantName()
        {
            try
            {

                if (cmbAssistant1.Text != "")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Insert into AssistantName_Table (IPDID,SurgeryName,AssistantName) Values(@IPDID,@SurgeryName,@AssistantName)", con);
                    cmd.Parameters.AddWithValue("@IPDID", ipdid);
                    cmd.Parameters.AddWithValue("@SurgeryName", PublicMJPJAY_Check);
                    cmd.Parameters.AddWithValue("@AssistantName", cmbAssistant1.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    ShowAssistantName();
                    bunSave.Enabled = true;
                    bunSave.BackColor = Color.DarkGreen;
                }

                else
                {
                    MessageBox.Show("Select Assistant Name");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveSurgonName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveAssistantName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveAnesthetistName();

        }
        public void updatesurgerydetails()
        {

            if (cmbSurgen1.Text == "$---Select---$")
            {

                MessageBox.Show("Select Surgeon");
            }
            else
            {

                if (DVGMJPJAYDetails.Rows.Count > 0)
                {
                    int[] TestIdArr = new int[DVGMJPJAYDetails.Rows.Count];

                    for (int i = 0; i < DVGMJPJAYDetails.Rows.Count; i++)
                    {

                        if (Convert.ToBoolean(DVGMJPJAYDetails["Doctor_Check", i].EditedFormattedValue))
                        {
                            int MJPJAY_ID = Convert.ToInt32(DVGMJPJAYDetails["MJPJAY_ID", i].Value);
                            string MJPJAY_NO = Convert.ToString(DVGMJPJAYDetails["MJPJAY_NO", i].Value);
                            DateTime Date = Convert.ToDateTime(DVGMJPJAYDetails["Date", i].Value);
                            int MJPJAY_MainCategory = Convert.ToInt32(DVGMJPJAYDetails["MJPJAY_MainCategory", i].Value);
                            int MJPJAY_SubCategory = Convert.ToInt32(DVGMJPJAYDetails["MJPJAY_SubCategory", i].Value);
                            string MJPJAY_Surgery = Convert.ToString(DVGMJPJAYDetails["MJPJAY_Surgery", i].Value);

                            Decimal PackageAmount = Convert.ToDecimal(DVGMJPJAYDetails["PackageAmount", i].Value);
                            int Doctor_Check = Convert.ToInt32(DVGMJPJAYDetails["Doctor_Check", i].Value);
                            DateTime Surgery_Date = Convert.ToDateTime(DVGMJPJAYDetails["Surgery_Date", i].Value);
                            Decimal Due_Amount = Convert.ToDecimal(DVGMJPJAYDetails["Due_Amount", i].Value);
                            Decimal Partial_Amount = Convert.ToDecimal(DVGMJPJAYDetails["Partial_Amount", i].Value);
                            int Received = Convert.ToInt32(DVGMJPJAYDetails["Received", i].Value);
                            int Partial = Convert.ToInt32(DVGMJPJAYDetails["Partial", i].Value);
                            connection1.Open();
                            SqlCommand cmd = new SqlCommand(@"UPDATE MJPJAY_PatientDetailsnew  SET PackageAmount= @PackageAmount,Doctor_Check=@Doctor_Check,Surgery_Date=@Surgery_Date,Due_Amount=@Due_Amount, Partial_Amount=@Partial_Amount,Received=@Received,Partial=@Partial,Remark=@Remark WHERE MJPJAY_NO=@MJPJAY_NO", connection1);
                            cmd.Parameters.AddWithValue(@"MJPJAY_NO", MJPJAY_NO);
                           // cmd.Parameters.AddWithValue(@"MJPJAY_ID", MJPJAY_ID);
                            cmd.Parameters.AddWithValue(@"PackageAmount", PackageAmount);

                            cmd.Parameters.AddWithValue(@"Doctor_Check", Doctor_Check);

                            cmd.Parameters.AddWithValue(@"Surgery_Date", Surgery_Date);

                            cmd.Parameters.AddWithValue(@"Due_Amount", Due_Amount);
                            cmd.Parameters.AddWithValue(@"Partial_Amount", Partial_Amount);
                            cmd.Parameters.AddWithValue(@"Received", Received);
                            cmd.Parameters.AddWithValue(@"Partial", Partial);
                            cmd.Parameters.AddWithValue(@"Remark", txtRemark.Text);
                            
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Save Successfully...");
                            connection1.Close();
                        }
                    }
                   

                    //Due_AmountCalculation();


                }
            }
        }
        private void bunSave_Click(object sender, EventArgs e)
        {
            updatesurgerydetails();
            MJpjaysurgery();
           // frmMJPJAYDoctor_Load(sender, e);

        }
    }
}
