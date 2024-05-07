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
using System.Text.RegularExpressions;
using System.Collections;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace Ruby_Hospital
{
    public partial class Patient_Registration : Form
    {
        public int P_ID;
        string PID = "RSHJ";
        string OIDA = "OPD/RSHJ";
        public int PatientBindIPD;
        public int countpatient;
        public int opdID;
        public int Patient_ID;
        public int pID;
        public string Isload;
        public string Doctors_Name;
        public string Referred_By;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GLobal_Connection"].ConnectionString);
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
       // String selectedby;
        public Patient_Registration()
        {
            InitializeComponent();
        }
        public Patient_Registration(DataTable data)
        {
            Isload = "1";
            InitializeComponent();
            DataTable dt = data;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    Doctors_Name = dt.Rows[0]["Doctors_Name"].ToString();
                    Referred_By = dt.Rows[0]["Referred_By"].ToString();
                    cmbDoctor.Text = Doctors_Name;
                    cmbReferred.Text = Referred_By;
                }
                string gender = dt.Rows[0]["Gender"].ToString();
                if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                {
                    btnmale.Checked = true;
                }
                else if (gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                {
                    btnfemale.Checked = true;
                }
                txtprofix.DataBindings.Add("Text", dt, "Prefixes");
                txtname.DataBindings.Add("Text", dt, "Name");
                txtarogyacard.DataBindings.Add("Text", dt, "AROGYA_Card");
                txtdate.DataBindings.Add("Text", dt, "DOB");
                txtage.DataBindings.Add("Text", dt, "Age");
                cbmmaritalstatus.DataBindings.Add("Text", dt, "Marital_Status");
                txtmobilenumber.DataBindings.Add("Text", dt, "Mobile_Number");
                txtmail.DataBindings.Add("Text", dt, "Email");
                txtaadhaar.DataBindings.Add("Text", dt, "Adhaar_ID");
                txtweight.DataBindings.Add("Text", dt, "Weight");
                txtpurpose.DataBindings.Add("Text", dt, "Purpose");
                txtalternateno.DataBindings.Add("Text", dt, "Alternate_Mobile");
                txtnationality.DataBindings.Add("Text", dt, "Nationality");
                txtDrName.DataBindings.Add("Text", dt, "Dr_Name");
                txtremark.DataBindings.Add("Text", dt, "Remark");
                txtregistration.DataBindings.Add("Text", dt, "Registration_Charges");
                txtconsultacharges.DataBindings.Add("Text", dt, "Consultation_Charges");
                txtaddress.DataBindings.Add("Text", dt, "Address");
                txtstate.DataBindings.Add("Text", dt, "State");
                txtdistrict.DataBindings.Add("Text", dt, "District");
                txttaluka.DataBindings.Add("Text", dt, "Taluka");
                txtcity.DataBindings.Add("Text", dt, "City");
               
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void txtmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtmail.Text, pattern))
            {
                errorProvider1.Clear();
                txtmail.BackColor = Color.White;
            }
            else
            {

                errorProvider1.SetError(this.txtmail, "PLEASE PROVIDE VALID EMAIL ADDRESS...");
                txtmail.BackColor = Color.LightPink;
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtaadhaar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtalternateno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtpatient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtreferred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Patient_Registration_Load(object sender, EventArgs e)
        {
            txtloginEmp.Text = Dashbord.Ename;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            btnGOTOIPD.Visible = false;
            button4.Visible = false;
            maritalstatusindex();
            purposeindex();
            //nationalityindex();
            searchindex();
            #region Auto Complete Property
            System.Collections.ArrayList ListArray = new ArrayList();
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Patient_Registration", con);

            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
                namesCollection.Add(dt.Rows[i]["Name"].ToString());

            txtpatient.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtpatient.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtpatient.AutoCompleteCustomSource = namesCollection;
            #endregion
            // if(!IsPostBack)
            generateAutoId();
            FetchDoctor();
            Referred_Doctor();
            State();
            District();
            Taluka();
            if (Isload == "1")
            {
                cmbDoctor.Text = Doctors_Name;
                cmbReferred.Text = Referred_By;
            }

            txtnationality.SelectedIndex = 0;
        }
        public void purposeindex()
        {
            if (txtpurpose.Text == "OPD")
            {
                txtpurpose.SelectedIndex = 0;
            }
            else if (txtpurpose.Text == "IPD")
            {
                txtpurpose.SelectedIndex = 1;
            }
            else if (txtpurpose.Text == "Only Test")
            {
                txtpurpose.SelectedIndex = 2;
            }
        }
        public void maritalstatusindex()
        {
            if (cbmmaritalstatus.Text == "---Select---")
            {
                cbmmaritalstatus.SelectedIndex = 0;
            }
            else if (cbmmaritalstatus.Text == "Married")
            {
                cbmmaritalstatus.SelectedIndex = 1;
            }
            else if (cbmmaritalstatus.Text == "Unmarried")
            {
                cbmmaritalstatus.SelectedIndex = 2;
            }
            else if (cbmmaritalstatus.Text == "Divorced")
            {
                cbmmaritalstatus.SelectedIndex = 3;
            }
        }
        //public void nationalityindex()
        //{
        //    if (txtnationality.Text == "Indian")
        //    {
        //        txtnationality.SelectedIndex = 0;
        //    }
        //    else if (txtnationality.Text == "Indian")
        //    {
        //        txtnationality.SelectedIndex = 1;
        //    }
        //    else if (txtnationality.Text == "Non-Indian")
        //    {
        //        txtnationality.SelectedIndex = 2;
        //    }
        //}
        public void searchindex()
        {
            if (txtpatientsearch.Text == "Select Type")
            {
                txtpatientsearch.SelectedIndex = 0;
            }
            else if (txtpatientsearch.Text == "Name")
            {
                txtpatientsearch.SelectedIndex = 1;
            }
            else if (txtpatientsearch.Text == "Mobile_Number")
            {
                txtpatientsearch.SelectedIndex = 2;
            }
        }
        public void generateAutoId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Count(PID) From Patient_Registration", con);
            int i = Convert.ToInt32(cmb.ExecuteScalar());
            con.Close();
            i++;
            P_ID = i;
            string a = i.ToString("0000");
            textBox1.Text = PID + a;

            //PatientBindIPD = textBox1.ToString();

        }
        public void generateAutoOId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Count(PatientOPDId) From OPD_Patient_Registration", con);
            int i = Convert.ToInt32(cmb.ExecuteScalar());
            con.Close();
            i++;
            string a = i.ToString("0000");
            textBox2.Text = OIDA + a;
            //opdID = textBox2.ToString();
        }
        public void State()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From States", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtstate.DataSource = dt;
                txtstate.DisplayMember = "State";
                txtstate.ValueMember = "SID";
            }

        }
        public void District()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From District where (SID=@SID) ", con);
            cmb.Parameters.AddWithValue("@SID", txtstate.SelectedIndex);
            cmb.ExecuteNonQuery();
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtdistrict.DataSource = dt;
                txtdistrict.DisplayMember = "District";
                txtdistrict.ValueMember = "DID";
            }
        }
        public void Taluka()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Taluka where (DID=@DID) ", con);
            cmb.Parameters.AddWithValue("@DID", txtdistrict.SelectedIndex);
            cmb.ExecuteNonQuery();
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txttaluka.DataSource = dt;
                txttaluka.DisplayMember = "Taluka";
                txttaluka.ValueMember = "TID";
            }

        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                string must = "";

                if (txtname.Text == "")
                {
                    must += " Enter Patient name";
                    txtname.BackColor = Color.Salmon;
                }
                else
                    txtname.BackColor = Color.White;

                if (txtprofix.Text == "")
                {
                    must += " Enter Prifix";
                    txtprofix.BackColor = Color.Salmon;
                }
                else
                    txtprofix.BackColor = Color.White;

                if (cbmmaritalstatus.Text == "")
                {
                    must += " Enter Marital Status";
                    cbmmaritalstatus.BackColor = Color.Salmon;
                }
                else
                    cbmmaritalstatus.BackColor = Color.White;

                if (txtpurpose.Text == "")
                {
                    must += " Enter Purpose";
                    txtpurpose.BackColor = Color.Salmon;
                }
                else
                    txtpurpose.BackColor = Color.White;

                if (txtnationality.Text == "")
                {
                    must += " Enter Nationality";
                    txtnationality.BackColor = Color.Salmon;
                }
                else
                    txtnationality.BackColor = Color.White;

                
                if (txtcity.Text == "")
                {
                    must += " Enter City";
                    txtcity.BackColor = Color.Salmon;
                }
                else
                    txtcity.BackColor = Color.White;

                
                if (txtaddress.Text == "")
                {
                    must += " Enter Address";
                    txtaddress.BackColor = Color.Salmon;
                }
                else
                    txtaddress.BackColor = Color.White;

                if (must == "")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand selectCmd = new SqlCommand("SELECT Patient_ID,PID FROM Patient_registration WHERE Name = @Name", con);
                    selectCmd.Parameters.AddWithValue("@Name", txtname.Text);
                    SqlDataReader reader = selectCmd.ExecuteReader();
                    string patientID = string.Empty;
                    pID = 0;
                    if (reader.Read())
                    {
                        patientID = reader["Patient_ID"].ToString();
                        pID = reader.GetInt32(reader.GetOrdinal("PID"));
                    }
                    reader.Close();
                    SqlDataAdapter Adt = new SqlDataAdapter(selectCmd);
                    DataTable dt = new DataTable();
                    Adt.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand cmd = new SqlCommand(@"UPDATE Patient_registration SET Prefixes=@Prefixes, Name=@Name, Gender=@Gender, DOB=@DOB, Age=@Age, Marital_Status=@Marital_Status, Mobile_Number=@Mobile_Number, Email=@Email, Adhaar_ID=@Adhaar_ID, Weight=@Weight, Purpose=@Purpose, Alternate_Mobile=@Alternate_Mobile, Nationality=@Nationality, Remark=@Remark, Dr_Name=@Dr_Name, AROGYA_Card=@AROGYA_Card, Registration_Charges=@Registration_Charges, Consultation_Charges=@Consultation_Charges, Address=@Address, State=@State, District=@District, Taluka=@Taluka, City=@City, Doctors_Name=@Doctors_Name, Referred_By=@Referred_By, Date=@Date WHERE Patient_ID = @Patient_ID", con);
                        cmd.Parameters.AddWithValue("@Patient_ID", patientID);
                        cmd.Parameters.AddWithValue("@Prefixes", txtprofix.Text);
                        cmd.Parameters.AddWithValue("@Name", txtname.Text);
                        cmd.Parameters.AddWithValue("@DOB", txtdate.Text);
                        if (btnmale.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Male");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Female");
                        }
                        cmd.Parameters.AddWithValue("@Age", txtage.Text);
                        cmd.Parameters.AddWithValue("@Marital_Status", cbmmaritalstatus.Text);
                        cmd.Parameters.AddWithValue("@Mobile_Number", txtmobilenumber.Text);
                        cmd.Parameters.AddWithValue("@Email", txtmail.Text);
                        cmd.Parameters.AddWithValue("@Adhaar_ID", txtaadhaar.Text);
                        cmd.Parameters.AddWithValue("@Weight", txtweight.Text);
                        cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
                        cmd.Parameters.AddWithValue("@Alternate_Mobile", txtalternateno.Text);
                        cmd.Parameters.AddWithValue("@Nationality", txtnationality.Text);
                        cmd.Parameters.AddWithValue("@Remark", txtDrName.Text);
                        cmd.Parameters.AddWithValue("@AROGYA_Card", txtarogyacard.Text);
                        cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text);
                        cmd.Parameters.AddWithValue("@Consultation_Charges", txtconsultacharges.Text);
                        cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                        cmd.Parameters.AddWithValue("@State", txtstate.Text);
                        cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
                        cmd.Parameters.AddWithValue("@Taluka", txttaluka.Text);
                        cmd.Parameters.AddWithValue("@City", txtcity.Text);
                        cmd.Parameters.AddWithValue("@Doctors_Name", cmbDoctor.Text);
                        cmd.Parameters.AddWithValue("@Referred_By", cmbReferred.Text);
                        cmd.Parameters.AddWithValue("@Dr_Name", txtDrName.Text);
                        cmd.Parameters.AddWithValue("@Date", dtpAdmissonDate.Value);

                        cmd.ExecuteNonQuery();

                        Globalsearch();

                        if (txtpurpose.Text == "OPD")
                        {
                            SqlCommand insertcmd = new SqlCommand(@"Insert into OPD_Patient_Registration (PatientId,Summary,Treatement,ChargesId,XRay,OPDSurgicalProcedureID,ConsultantID,ReferredId,VisitDate,IsCheck,FollowUpDate,PatientOPDIdWithSr)Values(@PatientId,@Summary,@Treatement,@ChargesId,@XRay,@OPDSurgicalProcedureID,@ConsultantID,@ReferredId,@VisitDate,@IsCheck,@FollowUpDate,@PatientOPDIdWithSr)", con);
                            insertcmd.Parameters.AddWithValue("@PatientId", pID);
                            insertcmd.Parameters.AddWithValue("@Summary", "");
                            insertcmd.Parameters.AddWithValue("@Treatement", "");
                            insertcmd.Parameters.AddWithValue("@ChargesId", "");
                            insertcmd.Parameters.AddWithValue("@XRay", "");
                            insertcmd.Parameters.AddWithValue("@OPDSurgicalProcedureID", "");
                            insertcmd.Parameters.AddWithValue("@ConsultantID", cmbDoctor.Text);
                            insertcmd.Parameters.AddWithValue("@ReferredId", cmbReferred.Text);
                            insertcmd.Parameters.AddWithValue("@VisitDate", System.DateTime.Now);
                            insertcmd.Parameters.AddWithValue("@IsCheck", 0);
                            insertcmd.Parameters.AddWithValue("@FollowUpDate", System.DateTime.Now);
                            insertcmd.Parameters.AddWithValue("@PatientOPDIdWithSr", textBox2.Text);
                            insertcmd.ExecuteNonQuery();
                            MessageBox.Show("Record Updated");
                            btnPrint_Click(sender, e);
                        }
                        if (txtpurpose.Text == "IPD")
                        {
                            MessageBox.Show("Record Added Successfully to IPD...");
                            global_IPD_data();
                            btnGOTOIPD.Visible = true;
                            btnsave.Visible = false;
                            btnPrint.Visible = false;
                        }
                        if (txtpurpose.Text == "Only Test")
                        {
                            generateAutoOId();
                            MessageBox.Show("Record Added Successfully ...");
                            OPDRegistration();
                            global_OPDOnlyTest_data();
                            btnGOTOIPD.Visible = false;
                            btnsave.Visible = false;
                            btnPrint.Visible = false;
                            button4.Visible = true;
                        }
                    }
                    else
                    {

                        SqlCommand cmd = new SqlCommand(@"Insert Into Patient_Registration (Patient_ID,Prefixes,Name,Gender,DOB,Age,Marital_Status,Mobile_Number,
                                               Email,Adhaar_ID,Weight,Purpose,Alternate_Mobile,Nationality,Remark,Dr_Name,AROGYA_Card,Registration_Charges,Consultation_Charges,
                                               Address,State,District,Taluka,City,Doctors_Name,Referred_By,Date) Values (@Patient_ID,@Prefixes,@Name,@Gender,@DOB,@Age,@Marital_Status,@Mobile_Number,
                                               @Email,@Adhaar_ID,@Weight,@Purpose,@Alternate_Mobile,@Nationality,@Remark,@Dr_Name,@AROGYA_Card,@Registration_Charges,@Consultation_Charges,

                                               @Address,@State,@District,@Taluka,@City,@Doctors_Name,@Referred_By,@Date)", con);
                        cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);

                        //cmd.Parameters.AddWithValue("@Patient_ID", "RSHJ001");b

                        cmd.Parameters.AddWithValue("@Prefixes", txtprofix.Text);

                        if (txtweight.Text.Equals("Enter the Weight "))
                        {
                            cmd.Parameters.AddWithValue("@Weight", txtweight.Text = "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Weight", txtweight.Text);
                        }
                        if (txtname.Text.Equals("Fisrtname           Middle             Lastname\n"))
                        {
                            MessageBox.Show("Please enter name...");
                            return;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Name", txtname.Text);
                        }

                        if (btnmale.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Male");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Female");
                        }
                        cmd.Parameters.AddWithValue("@DOB", txtdate.Text);
                        if (txtage.Text.Equals("Enter the Age"))
                        {
                            cmd.Parameters.AddWithValue("@Age", txtage.Text = "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Age", txtage.Text);
                        }
                        if (txtpurpose.SelectedItem.Equals("---Select---"))
                        {
                            MessageBox.Show("Please select Purpose...");
                            return;
                        }

                        cmd.Parameters.AddWithValue("@Marital_Status", cbmmaritalstatus.Text);
                        cmd.Parameters.AddWithValue("@Mobile_Number", txtmobilenumber.Text);
                        cmd.Parameters.AddWithValue("@Email", txtmail.Text);
                        cmd.Parameters.AddWithValue("@Adhaar_ID", txtaadhaar.Text);
                        cmd.Parameters.AddWithValue("@Alternate_Mobile", txtalternateno.Text);
                        cmd.Parameters.AddWithValue("@Nationality", txtnationality.Text);
                        cmd.Parameters.AddWithValue("@Remark", txtremark.Text);
                        cmd.Parameters.AddWithValue("@AROGYA_Card", txtarogyacard.Text);

                        if (txtconsultacharges.Text.Equals("Enter Registration Charges"))
                        {
                            cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text = "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text);
                        }


                        if (txtconsultacharges.Text.Equals("Enter Consultation Charges"))
                        {
                            cmd.Parameters.AddWithValue("@Consultation_Charges", txtconsultacharges.Text = "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Consultation_Charges", txtconsultacharges.Text);
                        }
                        cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
                        cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
                        cmd.Parameters.AddWithValue("@Dr_Name", txtDrName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                        cmd.Parameters.AddWithValue("@State", txtstate.Text);
                        cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
                        cmd.Parameters.AddWithValue("@Taluka", txttaluka.Text);
                        cmd.Parameters.AddWithValue("@City", txtcity.Text);
                        if (txtpurpose.Text == "Only Test")
                        {
                            cmd.Parameters.AddWithValue("@Doctors_Name", cmbDoctor.Text);
                            cmd.Parameters.AddWithValue("@Referred_By", cmbReferred.Text);
                        }
                        else
                        {
                            if (cmbDoctor.Text.Equals("---Select---"))
                            {
                                MessageBox.Show("Please select Doctor...");
                                return;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Doctors_Name", cmbDoctor.Text);
                            }
                            if (cmbReferred.Text.Equals("---Select---"))
                            {
                                MessageBox.Show("Please select Reffered Doctor...");
                                return;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Referred_By", cmbReferred.Text);
                            }
                        }
                        cmd.ExecuteNonQuery();
                        global_data();


                        if (txtpurpose.Text == "Only Test")
                        {
                            generateAutoOId();
                            MessageBox.Show("Record Added Successfully ...");
                            OPDRegistration();
                            global_OPDOnlyTest_data();
                            btnGOTOIPD.Visible = false;
                            btnsave.Visible = false;
                            btnPrint.Visible = false;
                            button4.Visible = true;
                        }
                        if (txtpurpose.Text == "IPD")
                        {
                            MessageBox.Show("Record Added Successfully to IPD...");
                            global_IPD_data();
                            btnGOTOIPD.Visible = true;
                            btnsave.Visible = false;
                            btnPrint.Visible = false;
                        }
                        if (txtpurpose.Text == "OPD")
                        {
                            generateAutoOId();
                            MessageBox.Show("Record Added Successfully");
                            btnPrint_Click(sender, e);
                            OPDRegistration();
                            global_OPD_data();
                            btnGOTOIPD.Visible = false;
                            btnsave.Visible = false;
                            btnPrint.Visible = false;
                        }

                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please fill the remaining values :- " + must);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Globalsearch()
        {

           connection.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Patient_Details where (PID=@PID)", connection);
            cmd.Parameters.AddWithValue("@PID", pID);          
            SqlDataReader rdr = cmd.ExecuteReader();
            
            if (rdr.HasRows)
            {
                global_data_Update();
            }
            else
            {
                global_data();
            }
            rdr.Close();
        }
        public void global_data()
        {     
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Insert Into Patient_Details (PID,Patient_ID,Patient_Name,Doctor_Name,AdmissionDate,Purpose,Branch,Consultant_Charges,Registration_Charges) values(@PID,@Patient_ID,@Patient_Name,@Doctor_Name,@AdmissionDate,@Purpose,@Branch,@Consultant_Charges,@Registration_Charges)", connection);
            cmd.Parameters.AddWithValue("@PID", P_ID);
            cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Doctor_Name", cmbDoctor.Text);
            cmd.Parameters.AddWithValue("@AdmissionDate", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
            cmd.Parameters.AddWithValue("@Branch", "Kurduwadi");
            cmd.Parameters.AddWithValue("@Consultant_Charges", txtconsultacharges.Text);
            cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void global_data_Update()
        {
            connection.Close();
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Update Patient_Details set Patient_ID=@Patient_ID,Patient_Name=@Patient_Name,Doctor_Name=@Doctor_Name,AdmissionDate=@AdmissionDate,Purpose=@Purpose,Branch=@Branch,Consultant_Charges=@Consultant_Charges,Registration_Charges=@Registration_Charges where (PID=@PID)", connection);
            cmd.Parameters.AddWithValue("@PID", P_ID);
            cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Patient_Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Doctor_Name", cmbDoctor.Text);
            cmd.Parameters.AddWithValue("@AdmissionDate", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
            cmd.Parameters.AddWithValue("@Branch", "Kurduwadi");
            cmd.Parameters.AddWithValue("@Consultant_Charges", txtconsultacharges.Text);
            cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text);
            cmd.ExecuteNonQuery();
           connection.Close();
        }
        public void global_OPD_data()
        {
            decimal x = Convert.ToDecimal(txtconsultacharges.Text);
            decimal y = Convert.ToDecimal(txtregistration.Text);
            decimal totalamt = x + y;

            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Insert Into OPD_Patient_Details(PID,OPDID,OPDID_Sr,Date,Branch,Purpose,Procedure_Total,Lab_Total,Radiology_Total,Bill_Amount,Received,Pending,Patient_Name,Consultant_Charges,Registration_Charges) 
                                     values(@PID,@OPDID,@OPDID_Sr,@Date,@Branch,@Purpose,@Procedure_Total,@Lab_Total,@Radiology_Total,@Bill_Amount,@Received,@Pending,@Patient_Name,@Consultant_Charges,@Registration_Charges)", connection);
            cmd.Parameters.AddWithValue("@PID", P_ID);
            cmd.Parameters.AddWithValue("@OPDID", opdID);
            cmd.Parameters.AddWithValue("@OPDID_Sr", textBox2.Text);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Branch", "Kurduwadi");
            cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
            cmd.Parameters.AddWithValue("@Procedure_Total", 0);
            cmd.Parameters.AddWithValue("@Lab_Total", 0);
            cmd.Parameters.AddWithValue("@Radiology_Total", 0);
            cmd.Parameters.AddWithValue("@Bill_Amount", totalamt);
            cmd.Parameters.AddWithValue("@Received", totalamt);
            cmd.Parameters.AddWithValue("@Pending", 0);
            cmd.Parameters.AddWithValue("@Patient_Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Consultant_Charges", txtconsultacharges.Text);
            cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void global_IPD_data()
        {
            connection.Open();
            SqlCommand cmb = new SqlCommand(@"insert into IPD_Patient_Details (Patient_ID,Patient_ID_sr,IPD_ID,IPD_ID_Sr,Branch,Name,Doctor_name,Admission_Date,Hospital_Total,Surgical_Total,Lab_Total,Radiology_Total)
                    Values      (@Patient_ID,@Patient_ID_sr,@IPD_ID,@IPD_ID_Sr,@Branch,@Name,@Doctor_name,@Admission_Date,@Hospital_Total,@Surgical_Total,@Lab_Total,@Radiology_Total)", connection);
            cmb.Parameters.AddWithValue("@Patient_ID", P_ID);
            cmb.Parameters.AddWithValue("@Patient_ID_sr", textBox1.Text);
            cmb.Parameters.AddWithValue("@IPD_ID", 0);
            cmb.Parameters.AddWithValue("@IPD_ID_Sr", 0);
            cmb.Parameters.AddWithValue("@Branch", "Kurduwadi");
            cmb.Parameters.AddWithValue("@Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Doctor_name", cmbDoctor.Text);
            cmb.Parameters.AddWithValue("@Admission_Date", System.DateTime.Now);
            cmb.Parameters.AddWithValue("@Hospital_Total", 0.00);
            cmb.Parameters.AddWithValue("@Surgical_Total", 0.00);
            cmb.Parameters.AddWithValue("@Lab_Total", 0.00);
            cmb.Parameters.AddWithValue("@Radiology_Total", 0.00);
            cmb.ExecuteNonQuery();
            // MessageBox.Show(".....!");
        }
        public void global_OPDOnlyTest_data()
        {
            decimal x = Convert.ToDecimal(txtconsultacharges.Text);
            decimal y = Convert.ToDecimal(txtregistration.Text);
            decimal totalamt = x + y;
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Insert Into OnlyTest_PatientDetails(PID,OPDID,OPDID_Sr,Date,Billing_Date,Branch,Purpose,Lab_Total,Radiology_Total,Bill_Amount,Received,Pending,Patient_Name,Consultant_Charges,Registration_Charges) 
                                     values(@PID,@OPDID,@OPDID_Sr,@Date,@Billing_Date,@Branch,@Purpose,@Lab_Total,@Radiology_Total,@Bill_Amount,@Received,@Pending,@Patient_Name,@Consultant_Charges,@Registration_Charges)", connection);
            cmd.Parameters.AddWithValue("@PID", P_ID);
            cmd.Parameters.AddWithValue("@OPDID", opdID);
            cmd.Parameters.AddWithValue("@OPDID_Sr", textBox2.Text);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Billing_Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Branch", "Kurduwadi");
            cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
            cmd.Parameters.AddWithValue("@Lab_Total", 0);
            cmd.Parameters.AddWithValue("@Radiology_Total", 0);
            cmd.Parameters.AddWithValue("@Bill_Amount", totalamt);
            cmd.Parameters.AddWithValue("@Received", totalamt);
            cmd.Parameters.AddWithValue("@Pending", 0);
            cmd.Parameters.AddWithValue("@Patient_Name", txtname.Text);
            cmd.Parameters.AddWithValue("@Consultant_Charges", txtconsultacharges.Text);
            cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Record Added");
            connection.Close();
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
            txtNew.Text = countpatient.ToString();
            Patient_ID = countpatient;
        }

        public void rowopdcount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from OPD_Patient_Registration", con);
            SqlDataAdapter s = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            s.Fill(dt);
            opdID = dt.Rows.Count;
            //txtNew.Text = countpatient.ToString();
        }

        public void OPDRegistration()
        {
            try
            {
                rowcount();
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into OPD_Patient_Registration (PatientId,Summary,Treatement,ChargesId,XRay,OPDSurgicalProcedureID,ConsultantID,ReferredId,VisitDate,IsCheck,FollowUpDate,PatientOPDIdWithSr)Values(@PatientId,@Summary,@Treatement,@ChargesId,@XRay,@OPDSurgicalProcedureID,@ConsultantID,@ReferredId,@VisitDate,@IsCheck,@FollowUpDate,@PatientOPDIdWithSr)", con);
                cmd.Parameters.AddWithValue("@PatientId", countpatient);
                cmd.Parameters.AddWithValue("@Summary", "");
                cmd.Parameters.AddWithValue("@Treatement", "");
                cmd.Parameters.AddWithValue("@ChargesId", "");
                cmd.Parameters.AddWithValue("@XRay", "");
                cmd.Parameters.AddWithValue("@OPDSurgicalProcedureID", "");
                cmd.Parameters.AddWithValue("@ConsultantID", cmbDoctor.Text);
                cmd.Parameters.AddWithValue("@ReferredId", cmbReferred.Text);
                cmd.Parameters.AddWithValue("@VisitDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@IsCheck", 0);
                cmd.Parameters.AddWithValue("@FollowUpDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@PatientOPDIdWithSr", textBox2.Text);
                cmd.ExecuteNonQuery();
                rowopdcount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       
        public void UpdateRegistration()
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Update Patient_Registration set (Prefixes=@Prefixes,Name=@Name,Gender=@Gende,DOB=@DOB,Age=@Age,Marital_Status=@Marital_Status,Mobile_Number=@Mobile_Number,
                                               Email=@Email,Adhaar_ID=@Adhaar_ID,Weight=@Weight,Purpose=@Purpose,Alternate_Mobile=@Alternate_Mobile,Nationality=@Nationality,Remark=@Remark,AROGYA_Card=@AROGYA_Card,Registration_Charges=@Registration_Charges,Consultation_Charges=@Consultation_Charges,
                                               Address=@Address,State=@State,District=@District,Taluka=@Taluka,City=@City,Doctors_Name=@Doctors_Name,Referred_By=@Referred_By,Date=@Date)  where Patient_ID=@Patient_ID)", con);
                cmd.Parameters.AddWithValue("@Patient_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Prefixes", txtprofix.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                if (btnmale.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Male");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Gender", "Female");
                }

                cmd.Parameters.AddWithValue("@DOB", txtdate.Text);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Marital_Status", cbmmaritalstatus.Text);
                cmd.Parameters.AddWithValue("@Mobile_Number", txtmobilenumber.Text);
                cmd.Parameters.AddWithValue("@Email", txtmail.Text);
                cmd.Parameters.AddWithValue("@Adhaar_ID", txtaadhaar.Text);
                cmd.Parameters.AddWithValue("@Weight", txtweight.Text);
                cmd.Parameters.AddWithValue("@Purpose", txtpurpose.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtalternateno.Text);
                cmd.Parameters.AddWithValue("@Nationality", txtnationality.Text);
                cmd.Parameters.AddWithValue("@Remark", txtDrName.Text);
                cmd.Parameters.AddWithValue("@AROGYA_Card", txtarogyacard.Text);
                cmd.Parameters.AddWithValue("@Registration_Charges", txtregistration.Text);
                cmd.Parameters.AddWithValue("@Consultation_Charges", txtconsultacharges.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@State", txtstate.Text);
                cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@Taluka", txttaluka.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.Parameters.AddWithValue("@Doctors_Name", cmbDoctor.Text);
                cmd.Parameters.AddWithValue("@Referred_By", cmbReferred.Text);
                cmd.Parameters.AddWithValue("@Date", dtpAdmissonDate);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtmobilenumber_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpatientsearch.Text == "Name")
                {

                    if (txtpatient.Text == "")
                    {
                        MessageBox.Show("Please Enter Patient Name!!!");
                    }
                    else
                    {

                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select * from Patient_Registration where Name LIKE '" + txtpatient.Text + "%'", con);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            PatientRegitrationGridview o = new PatientRegitrationGridview(dt);
                            o.Show();
                        }

                    }
                }
                else if (txtpatientsearch.Text == "Mobile_Number")
                {

                    if (txtpatient.Text == "")
                    {
                        MessageBox.Show("Please Enter Patient Mobile_Number!!!");
                    }
                    else
                    {

                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select * from Patient_Registration where Mobile_Number LIKE '" + txtpatient.Text + "%'", con);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            PatientRegitrationGridview o = new PatientRegitrationGridview(dt);
                            o.Show();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void txtpatient_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpatientsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Fisrtname           Middle             Lastname\n")
            {
                txtname.Text = "";
                txtname.ForeColor = Color.Black;
            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Fisrtname           Middle             Lastname\n";
                txtname.ForeColor = Color.Gray;
            }
        }

        private void txtmobilenumber_Enter(object sender, EventArgs e)
        {
            if (txtmobilenumber.Text == "123456789")
            {
                txtmobilenumber.Text = "";
                txtmobilenumber.ForeColor = Color.Black;
            }
        }

        public Tuple<bool, string> CheckIfMobileNumberExists(string mobileNumber)
        {
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*),MAX(Name)FROM Patient_Registration WHERE Mobile_Number = @Mobile_Number", con);
                cmd.Parameters.AddWithValue("@Mobile_Number", mobileNumber);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count > 0)
                    {
                        string name = reader.GetString(1);
                        return Tuple.Create(true, name);
                    }
                }
                return Tuple.Create(false, "");
            }
        }
        private void txtmobilenumber_Leave(object sender, EventArgs e)
        {

            string mobileNumber = txtmobilenumber.Text;
            Tuple<bool, string> result = CheckIfMobileNumberExists(mobileNumber);
            bool phoneNumberExists = result.Item1;
            string Name = result.Item2;

            if (phoneNumberExists)
            {
                errorProvider2.SetError(this.txtmobilenumber, $"This Mobile Number already exists in the database. Patient Name: {Name}");
                txtmobilenumber.BackColor = Color.LightPink;
                MessageBox.Show($"This Mobile Number Already Used For Regitration To: {Name}");
                DialogResult Output = MessageBox.Show("Do you want to continue registration?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Output == DialogResult.No)
                {
                    txtmobilenumber.Clear();
                    errorProvider2.Clear();
                    txtmobilenumber.BackColor = Color.White;
                }
                errorProvider2.Clear();
                txtmobilenumber.BackColor = Color.White;
            }
            else
            {
                errorProvider2.Clear();
                txtmobilenumber.BackColor = Color.White;
            }
        }

        private void txtpatient_Enter(object sender, EventArgs e)
        {
            if (txtpatient.Text == "Enter the Patient Info")
            {
                txtpatient.Text = "";
                txtpatient.ForeColor = Color.Black;
            }
        }

        private void txtpatient_Leave(object sender, EventArgs e)
        {
            if (txtpatient.Text == "")
            {
                txtpatient.Text = "Enter the Patient Info";
                txtpatient.ForeColor = Color.Gray;
            }
        }

        private void txtmail_Enter(object sender, EventArgs e)
        {
            if (txtmail.Text == "Enter Your Email")
            {
                txtmail.Text = "";
                txtmail.ForeColor = Color.Black;
            }
        }

        private void txtaadhaar_Enter(object sender, EventArgs e)
        {
            if (txtaadhaar.Text == "1233456789012")
            {
                txtaadhaar.Text = "";
                txtaadhaar.ForeColor = Color.Black;

            }
        }

        private void txtaadhaar_Leave(object sender, EventArgs e)
        {
            if (txtaadhaar.Text == "")
            {
                txtaadhaar.Text = "1233456789012";
                txtaadhaar.ForeColor = Color.Gray;

            }
        }

        private void txtregicharges_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtregicharges_Leave(object sender, EventArgs e)
        {

           
        }

        private void txtconsultacharges_Enter(object sender, EventArgs e)
        {

            if (txtconsultacharges.Text == "Enter Consultation Charges")
            {
                txtconsultacharges.Text = "0";
                txtconsultacharges.ForeColor = Color.Black;
            }
        }

        private void txtconsultacharges_Leave(object sender, EventArgs e)
        {
            if (txtconsultacharges.Text == "")
            {
                txtconsultacharges.Text = "Enter Charges";
                txtconsultacharges.ForeColor = Color.Gray;
            }
        }

        private void txtarogyacard_Enter(object sender, EventArgs e)
        {
            if (txtarogyacard.Text == "1233456789012")
            {
                txtarogyacard.Text = "";
                txtarogyacard.ForeColor = Color.Black;
            }
        }

        private void txtarogyacard_Leave(object sender, EventArgs e)
        {
            if (txtarogyacard.Text == "")
            {
                txtarogyacard.Text = "1233456789012";
                txtarogyacard.ForeColor = Color.Gray;
            }
        }

        private void txtage_Enter(object sender, EventArgs e)
        {

        }

        private void txtdate_ValueChanged(object sender, EventArgs e)
        {
            int AgeYear = DateTime.Today.Year - txtdate.Value.Year;
            txtage.Text = AgeYear.ToString();
        }

        private void txtname_Click(object sender, EventArgs e)
        {

        }

        private void txtname_MouseClick(object sender, MouseEventArgs e)
        {
            txtname.Clear();
        }

        private void txtmobilenumber_MouseClick(object sender, MouseEventArgs e)
        {
            txtmobilenumber.Clear();
        }

        private void txtarogyacard_MouseClick(object sender, MouseEventArgs e)
        {
            txtarogyacard.Clear();
        }

        private void txtage_MouseClick(object sender, MouseEventArgs e)
        {
            txtage.Clear();
        }

        private void txtweight_MouseClick(object sender, MouseEventArgs e)
        {
            txtweight.Clear();
        }

        private void txtalternateno_MouseClick(object sender, MouseEventArgs e)
        {
            txtalternateno.Clear();
        }

        private void txtremark_MouseClick(object sender, MouseEventArgs e)
        {
            txtDrName.Clear();
        }

        private void txtaddress_MouseClick(object sender, MouseEventArgs e)
        {
            txtaddress.Clear();
        }

        private void btnGOTOIPD_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner"))
                {
                    con.Open();
                    rowcount();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM Patient_Registration WHERE PID = @countpatient", con);
                    cmd.Parameters.AddWithValue("@countpatient", txtNew.Text);

                    SqlDataAdapter s = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    s.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        PatientBindIPD = Convert.ToInt32(dt.Rows[0]["PID"]);
                        IPD_Registration o = new IPD_Registration(PatientBindIPD);
                        o.Show();
                    }
                    else
                    {
                        SqlCommand cmb = new SqlCommand(@"SELECT PID FROM Patient_Registration WHERE PID = @PID", con);
                        cmb.Parameters.AddWithValue("@PID", pID);
                        SqlDataAdapter s2 = new SqlDataAdapter(cmb);
                        DataTable adt = new DataTable();
                        s2.Fill(adt);

                        if (adt.Rows.Count > 0)
                        {
                            PatientBindIPD = Convert.ToInt32(adt.Rows[0]["PID"]);
                            IPD_Registration o = new IPD_Registration(PatientBindIPD);
                            o.Show();
                        }
                        else
                        {
                            MessageBox.Show("Patient not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtage_Enter_1(object sender, EventArgs e)
        {
            if (txtage.Text == "Enter the Age")
            {
                txtage.Text = "";
                txtage.ForeColor = Color.Black;
            }
        }

        private void txtage_Leave(object sender, EventArgs e)
        {
            if (txtage.Text == "")
            {
                txtage.Text = "Enter the Age";
                txtage.ForeColor = Color.Gray;
            }
        }

        private void txtweight_Enter(object sender, EventArgs e)
        {
            if (txtweight.Text == "Enter the Weight")
            {
                txtweight.Text = "";
                txtweight.ForeColor = Color.Black;
            }
        }

        private void txtweight_Leave(object sender, EventArgs e)
        {
            if (txtweight.Text == "")
            {
                txtweight.Text = "Enter the Weight";
                txtweight.ForeColor = Color.Gray;
            }
        }

        private void txtalternateno_Enter(object sender, EventArgs e)
        {
            if (txtalternateno.Text == "1234567890")
            {
                txtalternateno.Text = "";
                txtalternateno.ForeColor = Color.Black;
            }

        }

        private void txtremark_Enter(object sender, EventArgs e)
        {
            if (txtDrName.Text == "Enter the Remark")
            {
                txtDrName.Text = "";
                txtDrName.ForeColor = Color.Black;
            }
        }

        private void txtalternateno_Leave(object sender, EventArgs e)
        {
            if (txtalternateno.Text == "")
            {
                txtalternateno.Text = "1234567890";
                txtalternateno.ForeColor = Color.Gray;
            }
        }

        private void txtremark_Leave(object sender, EventArgs e)
        {
            if (txtDrName.Text == "")
            {
                txtDrName.Text = "Enter the Remark";

                txtDrName.ForeColor = Color.Gray;
            }
        }

        private void txtaddress_Enter(object sender, EventArgs e)
        {
            if (txtaddress.Text == "Enter the Address")
            {
                txtaddress.Text = "";
                txtaddress.ForeColor = Color.Black;
            }
        }


        private void txtconsultacharges_MouseClick(object sender, MouseEventArgs e)
        {
            txtconsultacharges.Clear();
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
                cmbDoctor.DataSource = dt;
                cmbDoctor.DisplayMember = "Dr_Name";
                cmbDoctor.ValueMember = "DR_ID";
                

                DataRow drr3;
                drr3 = dt.NewRow();
                drr3["DR_ID"] = "0";
                drr3["Dr_Name"] = "---Select---";
                dt.Rows.Add(drr3);
                dt.DefaultView.Sort = "DR_ID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                //cmbDoctor.DataSource = dt;
                //cmbDoctor.DisplayMember = "Dr_Name";
                //cmbDoctor.ValueMember = "DR_ID";
               

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
                cmbReferred.DataSource = dt;
                cmbReferred.DisplayMember = "Referred_Name";
                cmbReferred.ValueMember = "ReferredID";

                DataRow drr1;
                drr1 = dt.NewRow();
                drr1["ReferredID"] = "0";
                drr1["Referred_Name"] = "---Select---";
                dt.Rows.Add(drr1);
                dt.DefaultView.Sort = "ReferredID asc";


                //dt1.DefaultView.Sort = "PurposeId asc";
                //cmbReferred.DataSource = dt;
                //cmbReferred.DisplayMember = "Referred_Name";
                //cmbReferred.ValueMember = "ReferredID";
                //cmbReferred.Text = "--Select Doctor--";
            }
            con.Close();
        }

        private void txtdistrict_TextChanged(object sender, EventArgs e)
        {
            //if(txtstate.Text.Trim)
            //{

            //}
            Taluka();
        }

        private void txtstate_TextChanged(object sender, EventArgs e)
        {
            District();

        }

        private void NN(object sender, PaintEventArgs e)
        {

        }

        private void txtconsultacharges_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpurpose_TextChanged(object sender, EventArgs e)
        {
            if (txtpurpose.Text == "OPD")
            {
                generateAutoOId();
            }
            else 
            {
                textBox2.Text = "";
            }

            if (txtpurpose.Text == "Only Test")
            {
                txtDrName.Visible = true;
                label17.Visible = true;
                cmbReferred.Visible = false;
                label23.Visible = false;
                cmbDoctor.Visible = false;
                label16.Visible = false;
            }
            else
            {
                txtDrName.Visible = false;
                label17.Visible = false;
                cmbReferred.Visible = true;
                label23.Visible = true;
                cmbDoctor.Visible = true;
                label16.Visible = true;
            }
        }
        public void onlytest()
        {
            txtDrName.Visible = true;
        }

        private void txtstate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtconsultacharges_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtconsultacharges.Clear();
        }

        private void txtpatient_MouseClick(object sender, MouseEventArgs e)
        {
            txtpatient.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            SelectOnlyTest o = new SelectOnlyTest(opdID);
            o.Show();

        }

        private void txtpurpose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpAdmissonDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttaluka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CasePaper()
        {
            Report.OPDCase_Paper cryRpt = new Report.OPDCase_Paper();
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



            cryRpt.SetParameterValue("PID", P_ID);

            ReportViewerForOPD obj = new ReportViewerForOPD();

            obj.crystalReportViewer1.ReportSource = cryRpt;
            obj.Refresh();
            //obj.Show();

            this.Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report.OPDRegistrationBilling cryRptNew = new Report.OPDRegistrationBilling();

           
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

           

            cryRptNew.SetParameterValue("PID", P_ID); 
            cryRptNew.SetParameterValue("LoginEmp", txtloginEmp.Text);
            ReportViewerForOPD obj = new ReportViewerForOPD();

            obj.crystalReportViewer1.ReportSource = cryRptNew;
            obj.Refresh();
            obj.Show();

            this.Close();

            #region Export to PDF in Computer Drive
            #region new installation

            //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
            string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

            //    //MessageBox.Show(@"\\"+path);
            if (!System.IO.Directory.Exists(@path))
            {
                //step 1 : create on D
                //step 2 : share it
                System.IO.Directory.CreateDirectory(@path);
            }

            if (!System.IO.Directory.Exists(@path + @"\OPD_Registration_Bill"))
            {
                System.IO.Directory.CreateDirectory(@path + @"\OPD_Registration_Bill");
            }

            string filepath = @path + @"\OPD_Registration_Bill\" + P_ID + ".pdf";
            #endregion

            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            #endregion

            CasePaper();
        }

        private void txtweight_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtconsultacharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbReferred_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbReferred.Text = cmbReferred.SelectedItem.ToString();
            //Referred_Doctor();
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Text = cmbDoctor.SelectedItem.ToString();
            //FetchDoctor();
        }

        private void cmbDoctor_Leave(object sender, EventArgs e)
        {
            if(cmbDoctor.Text == "")
            {
                cmbDoctor.Text = "---Select---";
            }
        }

        private void cmbReferred_Leave(object sender, EventArgs e)
        {
            if(cmbReferred.Text == "")
            {
                cmbReferred.Text = "---Select---";
            }
        }

        private void cmbDoctor_Enter(object sender, EventArgs e)
        {
            if(cmbDoctor.Text == "---Select---")
            {
                cmbDoctor.Text = "";
            }
        }

        private void cmbReferred_Enter(object sender, EventArgs e)
        {
            if (cmbReferred.Text == "---Select---")
            {
                cmbReferred.Text = "";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtregicharges_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtregistration_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtregistration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtregistration_MouseClick(object sender, MouseEventArgs e)
        {
            txtregistration.Clear();
        }

        private void txtregistration_Enter(object sender, EventArgs e)
        {
            txtregistration.Clear();
        }

        private void txtnationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
