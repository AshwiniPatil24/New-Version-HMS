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

namespace Ruby_Hospital
{
    public partial class Employeeregistration : Form
    {
        public string onLoad;
        string role;
        public Employeeregistration()
        {
            InitializeComponent();
        }

        public Employeeregistration(DataTable data)
        {
            onLoad = "1";
            InitializeComponent();           
            DataTable dt = data;
            getEmpDetails(dt);            
        }

        public void getEmpDetails(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {       
                txtmr.DataBindings.Add("Text", dt, "MR_M");
                txtname.DataBindings.Add("Text", dt, "Name");
                string Emp_Type = dt.Rows[0]["Employee_Of"].ToString();
                if (Emp_Type.Equals("Ruby Star Hospital", StringComparison.OrdinalIgnoreCase))
                {
                    rbtrubystarhospital.Checked = true;
                }
                else if (Emp_Type.Equals("Contractor", StringComparison.OrdinalIgnoreCase))
                {
                    rbtcontractor.Checked = true;
                }
                txtMobileNumber.DataBindings.Add("Text", dt, "Mobile_Number");
                txtAlternateNumber.DataBindings.Add("Text", dt, "Alternate_Mobile_number");
                txtDepartment.DataBindings.Add("Text", dt, "Department");
                txtDesignation.DataBindings.Add("Text", dt, "Designation");
                txtcurrentAddress.DataBindings.Add("Text", dt, "Current_Address");
                txtPermanentAddress.DataBindings.Add("Text", dt, "Permanent_Address");
                txtExperience.DataBindings.Add("Text", dt, "Experience");
                txtJoinDate.DataBindings.Add("Value", dt, "Joining_Date");
                txtuid.DataBindings.Add("Text", dt, "UID");
                txtremark.DataBindings.Add("Text", dt, "Remark");
                string status = dt.Rows[0]["Status"].ToString();
                if (status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    chkBoxActive.Checked = true;
                }
                else
                {
                    chkBoxActive.Checked = false;
                }
                txtgender.DataBindings.Add("Text", dt, "Gender");
                txtDateOfBirth.DataBindings.Add("Value", dt, "Date_Of_Birth");
                txtMaritalStatus.DataBindings.Add("Text", dt, "MaritalStatus");
                txtprobationDate.DataBindings.Add("Value", dt, "Probation");
                role = dt.Rows[0]["Role"].ToString();
                cmbRole.DataBindings.Add("Text", dt, "Role");
                txtname.Enabled = false;
                txtmr.Enabled = false;
                txtMobileNumber.Enabled = false;
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            txtMaritalStatus.SelectedIndex = 0;
            txtgender.SelectedIndex = 0;
            //int w = Screen.PrimaryScreen.Bounds.Width;
            //int h = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(0, 0);
            //this.Size = new Size(w, h);
            show();
            Department();
            Designation();
            Role();
            if (onLoad == "1")
            {
                cmbRole.Text = role;
            }
            panel1.Visible = false;
        }
        public void Department()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Department", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtDepartment.DataSource = dt;
                txtDepartment.DisplayMember = "Department";
                txtDepartment.ValueMember = "ID";

                DataRow drr3;
                drr3 = dt.NewRow();
                drr3["ID"] = "0";
                drr3["Department"] = "---Select---";
                dt.Rows.Add(drr3);
                dt.DefaultView.Sort = "ID asc";
            }

        }

        public void Role()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Role_Master", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbRole.DataSource = dt;
                cmbRole.DisplayMember = "Role";
                cmbRole.ValueMember = "ID";



                DataRow drr3;
                drr3 = dt.NewRow();
                drr3["ID"] = "0";
                drr3["Role"] = "---Select---";
                dt.Rows.Add(drr3);
                dt.DefaultView.Sort = "ID asc";
            }
        }

        public void Designation()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * From Designation where (DepartmentID=@DepartmentID) ", con);
            cmb.Parameters.AddWithValue("@DepartmentID", txtDepartment.SelectedIndex);
            cmb.ExecuteNonQuery();
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtDesignation.DataSource = dt;
                txtDesignation.DisplayMember = "Designation";
                txtDesignation.ValueMember = "ID";



                DataRow drr3;
                drr3 = dt.NewRow();
                drr3["ID"] = "0";
                drr3["Designation"] = "---Select---";
                dt.Rows.Add(drr3);
                dt.DefaultView.Sort = "ID asc";
            }
        }
        private void radiocontractor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            show();
            if (txtDesignation.Text == "Doctor")
            {
                doctors();
                savedata();
            }
            else
            {
                savedata();
            }
        }
        public void savedata()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();


                SqlCommand cmb = new SqlCommand(@"INSERT INTO Employee_registration (Employee_of,MR_M,Name,UID,Gender,Current_Address,Role,Permanent_Address,Mobile_Number,MaritalStatus,Experience,Alternate_Mobile_number,Date_Of_Birth,Department,Designation,Joining_Date,Probation,Status,Remark)
                                    Values (@Employee_of,@MR_M,@Name,@UID,@Gender,@Current_Address,@Role,@Permanent_Address,@Mobile_Number,@MaritalStatus,@Experience,@Alternate_Mobile_number,@Date_Of_Birth,@Department,@Designation,@Joining_Date,@Probation,@Status,@Remark)", con);
                if (rbtrubystarhospital.Checked == true)

                {
                    cmb.Parameters.AddWithValue("@Employee_of", "Ruby Star Hospital");
                }
                if(rbtcontractor.Checked == true)
                {
                    cmb.Parameters.AddWithValue("@Employee_of", "Contractor");
                }
                cmb.Parameters.AddWithValue("@MR_M", txtmr.Text);
                cmb.Parameters.AddWithValue("@Name", txtname.Text);
                if (txtuid.Text == "Enter  Your UID ")
                {
                    MessageBox.Show("Enter UID...");
                    return;
                }
                else
                {
                    cmb.Parameters.AddWithValue("@UID", txtuid.Text);
                }
                cmb.Parameters.AddWithValue("@Gender", txtgender.Text);
                cmb.Parameters.AddWithValue("@Current_Address", txtcurrentAddress.Text);

                cmb.Parameters.AddWithValue("@Role", cmbRole.Text);

                //  cmb.Parameters.AddWithValue("@Nearest_Landmark", txtpost.Text);

                cmb.Parameters.AddWithValue("@Permanent_Address", txtPermanentAddress.Text);
                if (txtMobileNumber.Text == "123456789")
                {
                    MessageBox.Show("Enter Correct Mobile Number...");
                    return;
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Mobile_Number", txtMobileNumber.Text);
                }
                if (txtAlternateNumber.Text == "Alternate Mobile No")
                {
                    MessageBox.Show("Enter Correct Mobile Number...");
                    return;
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Alternate_Mobile_number", txtAlternateNumber.Text);
                }
                cmb.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                cmb.Parameters.AddWithValue("@Experience", txtExperience.Text);
                cmb.Parameters.AddWithValue("@Date_Of_Birth", txtDateOfBirth.Text);
                cmb.Parameters.AddWithValue("@Department", txtDepartment.Text);
                if (txtDesignation.Text.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
                {
                    if (rbResidentialDoctor.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Designation", "Resident Doctor");
                    }
                    if (rbVisitingDotor.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Designation", "Visiting Doctor");
                    }
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                }
                cmb.Parameters.AddWithValue("@Joining_Date", txtJoinDate.Text);
                cmb.Parameters.AddWithValue("@Probation", txtprobationDate.Text);
                if (chkBoxActive.Checked == true)
                {
                    cmb.Parameters.AddWithValue("@Status", "Active");
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Status", "Inactive");
                }
                cmb.Parameters.AddWithValue("@Remark", txtremark.Text);
                cmb.ExecuteNonQuery();
                show();
                MessageBox.Show("Employee successfully Added...");
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void doctors()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Insert INTO Doctors (Dr_Name,Contact_Number,Is_Active)
            values(@Dr_Name,@Contact_Number,@Is_Active)", con);
            cmb.Parameters.AddWithValue("@Dr_Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Contact_Number", txtMobileNumber.Text);
            if (checkStatus.Enabled == true)
            {
                cmb.Parameters.AddWithValue("@Is_Active", "Active");
            }
            else
            {
                cmb.Parameters.AddWithValue("@Is_Active", "Inactive");
            }
            cmb.ExecuteNonQuery();

            // MessageBox.Show("Employee successfully Added...");
            // clearData();
        }
        public void clearData()
        {
            txtAlternateNumber.Text = "";
            txtcurrentAddress.Text = "";
            txtDateOfBirth.Text = "";
            txtDepartment.Text = "";
            txtDesignation.Text = "";
            txtExperience.Text = "";
            txtgender.Text = "";
            txtJoinDate.Text = "";

            //txtpost.Text = "";

            txtMaritalStatus.Text = "";
            txtMobileNumber.Text = "";
            txtmr.Text = "";
            txtname.Text = "";
            txtPermanentAddress.Text = "";
            txtprobationDate.Text = "";
            txtremark.Text = "";
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select Employee_Of,Name,Current_Address,Mobile_Number,Department,Designation,Status From Employee_registration", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;
            }

        }
        private void txtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();

                SqlCommand cmb = new SqlCommand(@"UPDATE Employee_registration 
                                    SET Employee_of = @Employee_of,
MR_M = @MR_M,
Name = @Name,
UID = @UID,
Gender = @Gender,
Current_Address = @Current_Address,
Role = @Role,
Permanent_Address = @Permanent_Address,
Mobile_Number = @Mobile_Number,
MaritalStatus = @MaritalStatus,
Experience = @Experience,
Alternate_Mobile_number = @Alternate_Mobile_number,
Date_Of_Birth = @Date_Of_Birth,
Department = @Department,
Designation = @Designation,
Joining_Date = @Joining_Date,
Probation = @Probation,
Status = @Status,
Remark = @Remark
Where Mobile_Number=@Mobile_Number and name=@name", con);
                if (rbtrubystarhospital.Checked == true)
                {
                    cmb.Parameters.AddWithValue("@Employee_of", "Ruby Star Hospital");
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Employee_of", "Contractor");
                }
                cmb.Parameters.AddWithValue("@MR_M", txtmr.Text);
                cmb.Parameters.AddWithValue("@Name", txtname.Text);
                if (txtuid.Text == "Enter  Your UID ")
                {
                    MessageBox.Show("Enter UID...");
                    return;
                }
                else
                {
                    cmb.Parameters.AddWithValue("@UID", txtuid.Text);
                }
                cmb.Parameters.AddWithValue("@Gender", txtgender.Text);
                cmb.Parameters.AddWithValue("@Current_Address", txtcurrentAddress.Text);

                cmb.Parameters.AddWithValue("@Role", cmbRole.Text);

                //  cmb.Parameters.AddWithValue("@Nearest_Landmark", txtpost.Text);

                cmb.Parameters.AddWithValue("@Permanent_Address", txtPermanentAddress.Text);
                if (txtMobileNumber.Text == "123456789")
                {
                    MessageBox.Show("Enter Correct Mobile Number...");
                    return;
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Mobile_Number", txtMobileNumber.Text);
                }
                if (txtAlternateNumber.Text == "Alternate Mobile No")
                {
                    MessageBox.Show("Enter Correct Mobile Number...");
                    return;
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Alternate_Mobile_number", txtAlternateNumber.Text);
                }
                cmb.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                cmb.Parameters.AddWithValue("@Experience", txtExperience.Text);
                cmb.Parameters.AddWithValue("@Date_Of_Birth", txtDateOfBirth.Text);
                cmb.Parameters.AddWithValue("@Department", txtDepartment.Text);
                if (txtDesignation.Text.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
                {
                    if (rbResidentialDoctor.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Designation", "Resident Doctor");
                    }
                    if (rbVisitingDotor.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Designation", "Visiting Doctor");
                    }
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                }
                cmb.Parameters.AddWithValue("@Joining_Date", txtJoinDate.Text);
                cmb.Parameters.AddWithValue("@Probation", txtprobationDate.Text);
                if (chkBoxActive.Checked == true)
                {
                    cmb.Parameters.AddWithValue("@Status", "Active");
                }
                else
                {
                    cmb.Parameters.AddWithValue("@Status", "Inactive");
                }
                cmb.Parameters.AddWithValue("@Remark", txtremark.Text);
                cmb.ExecuteNonQuery();
                show();
                MessageBox.Show("Employee Updated Successfully...");
                clearData();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void txtname_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtname.Text == "Fisrtname                    Middle                  Lastname")
            {
                //txtname.Clear();
            }

        }

        private void txtname_MouseLeave(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtDesignation.Text == "Doctor")
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (panel1.Visible == true)
            {
                if ((rbResidentialDoctor.Checked) || (rbVisitingDotor.Checked))
                {

                }
                else
                {
                    panel1.Focus();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            show();
            if (txtDesignation.Text == "Doctor")
            {
                doctors();
                savedata();
            }
            else
            {
                savedata();
            }
        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            Designation();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Firstname          middlename            lastname";
            }
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Firstname          middlename            lastname")
            {
                txtname.Text = "";
            }
            txtname.Clear();
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMobileNumber_Leave(object sender, EventArgs e)
        {
            if (txtMobileNumber.Text == "")
            {
                txtMobileNumber.Text = "123456789";
            }
        }

        private void txtMobileNumber_Enter(object sender, EventArgs e)
        {
            if (txtMobileNumber.Text == "123456789")
            {
                txtMobileNumber.Text = "";
            }
            txtMobileNumber.Clear();
        }

        private void txtMobileNumber_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMobileNumber.Text == "123456789")
            {
                //txtMobileNumber.Clear();
            }
        }

        private void txtcurrentAddress_Leave(object sender, EventArgs e)
        {
            if (txtcurrentAddress.Text == "")
            {
                txtcurrentAddress.Text = "Enter the Address";
            }
        }

        private void txtcurrentAddress_Enter(object sender, EventArgs e)
        {
            if (txtcurrentAddress.Text == "Enter the Address")
            {
                txtcurrentAddress.Text = "";
            }
            txtcurrentAddress.Clear();
        }

        private void txtcurrentAddress_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtcurrentAddress.Text == "Enter the Address")
            {
                //txtcurrentAddress.Clear();
            }
        }

        private void txtAlternateNumber_Enter(object sender, EventArgs e)
        {
            if (txtAlternateNumber.Text == "Alternate Mobile No")
            {
                txtAlternateNumber.Text = "";
            }
        }

        private void txtAlternateNumber_Leave(object sender, EventArgs e)
        {
            if (txtAlternateNumber.Text == "")
            {
                txtAlternateNumber.Text = "Alternate Mobile No";
            }
        }

        private void txtAlternateNumber_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtAlternateNumber.Text == "Alternate Mobile No")
            {
                //txtAlternateNumber.Clear();
            }
        }

        private void txtPermanentAddress_Enter(object sender, EventArgs e)
        {
            if (txtPermanentAddress.Text == "Permanent Address")
            {
                txtPermanentAddress.Text = "";
            }
            txtPermanentAddress.Clear();
        }

        private void txtPermanentAddress_Leave(object sender, EventArgs e)
        {
            if (txtPermanentAddress.Text == "")
            {
                txtPermanentAddress.Text = "Permanent Address";
            }
        }

        private void txtPermanentAddress_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPermanentAddress.Text == "")
            {
               //
            }
        }

        private void txtExperience_Enter(object sender, EventArgs e)
        {
            if (txtExperience.Text == "Enter  The Working Experience")
            {
                txtExperience.Text = "";
            }
        }

        private void txtExperience_Leave(object sender, EventArgs e)
        {
            if (txtExperience.Text == "")
            {
                txtExperience.Text = "Enter  The Working Experience";
            }
        }

        private void txtExperience_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtExperience.Text == "Enter  The Working Experience")
            {
               // txtExperience.Clear();
            }
        }

        private void txtuid_Enter(object sender, EventArgs e)
        {
            if (txtuid.Text == "Enter  Your UID ")
            {
                txtuid.Text = "";
            }
            txtuid.Clear();
        }

        private void txtuid_Leave(object sender, EventArgs e)
        {
            if (txtuid.Text == "")
            {
                txtuid.Text = "Enter  Your UID ";
            }
        }

        private void txtuid_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtuid.Text == "Enter  Your UID ")
            {
                //txtuid.Clear();
            }
        }

        private void txtAlternateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtuid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchBy.Text == "Name")
                {
                    if (txtSearch.Text == "Enter Details")
                    {
                        MessageBox.Show("Please fill details!!!");
                    }
                    else
                    {
                        String PatientName = txtSearch.Text;
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"SELECT        Employee_Of, Name, Gender, Role, Experience, Mobile_Number, Department, Joining_Date, Status
FROM            Ruby_Jamner123.Employee_registration where Name LIKE @name +'%'", con);
                        cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DisplayEmployees o = new DisplayEmployees(dt);
                            o.Show();
                        }
                        else
                        {
                            MessageBox.Show("No Employee Present!!!");
                        }
                    }
                }
                else if (txtSearchBy.Text == "EMPID")
                {
                    if (txtSearch.Text == "Enter Details")
                    {
                        MessageBox.Show("Please fill details!!!");
                    }
                    else
                    {
                        String PatientName = txtSearch.Text;
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select * from Employee_registration where EMPID = @EMPID", con);
                        cmd.Parameters.AddWithValue("@EMPID", txtSearch.Text);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            getEmpDetails(dt);

                        }
                        else
                        {
                            MessageBox.Show("No Employee Present!!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter Details")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Enter Details";
            }
        }

        private void rbtninactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
