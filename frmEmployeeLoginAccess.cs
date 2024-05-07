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
using System.Configuration;

namespace Ruby_Hospital
{
    public partial class frmEmployeeLoginAccess : Form
    {
        public string EMpName;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        public int EmpId;
        public int EMP_ID;
        public int Isload;
        public frmEmployeeLoginAccess()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public frmEmployeeLoginAccess(int EmpId)
        {
            try
            {
                InitializeComponent();
                txtSearchBy.SelectedIndex = 0;
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employee_registration where EMPID=@EMPID", connection);
                cmd.Parameters.AddWithValue("@EMPID", EmpId);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    EMpName= Convert.ToString(dt.Rows[0]["Name"]);
                }
                connection.Close();

                EMP_ID = EmpId;

                txtEmpID.Text = EmpId.ToString();
                txtName.Text = EMpName;

                label5.Text = EmpId.ToString();
                label6.Text = EMpName;
                SearchUpdate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void SearchUpdate()
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Employee_ADDAccess where EMPID=@EMPID", connection);
            cmd1.Parameters.AddWithValue("@EMPID", EMP_ID);
            SqlDataAdapter adt1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adt1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                if (Convert.ToString(dt1.Rows[0]["Registration"]) == "Active")
                    chkRegistration.CheckState = CheckState.Checked;
                else
                    chkRegistration.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["DoctorDashboard"]) == "Active")
                    chkDoctordash.CheckState = CheckState.Checked;
                else
                    chkDoctordash.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["PatientTransfur"]) == "Active")
                    chkPatientTra.CheckState = CheckState.Checked;
                else
                    chkPatientTra.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["AssignTest"]) == "Active")
                    ChkAssignTest.CheckState = CheckState.Checked;
                else
                    ChkAssignTest.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["AssignProcedure"]) == "Active")
                    chkAssignProc.CheckState = CheckState.Checked;
                else
                    chkAssignProc.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["Discharge"]) == "Active")
                    chkDischaeges.CheckState = CheckState.Checked;
                else
                    chkDischaeges.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["AssignSurgery"]) == "Active")
                    chkAssignSurgery.CheckState = CheckState.Checked;
                else
                    chkAssignSurgery.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["Printdow"]) == "Active")
                    chkprint.CheckState = CheckState.Checked;
                else
                    chkprint.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["Viewreport"]) == "Active")
                    chkViewReport.CheckState = CheckState.Checked;
                else
                    chkViewReport.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["AddNotes"]) == "Active")
                    chkAddNote.CheckState = CheckState.Checked;
                else
                    chkAddNote.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["Billing"]) == "Active")
                    ChkBilling.CheckState = CheckState.Checked;
                else
                    ChkBilling.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["ChangeBilling"]) == "Active")
                    chkChangeBilling.CheckState = CheckState.Checked;
                else
                    chkChangeBilling.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["CreateMaster"]) == "Active")
                    ChkCreateMaster.CheckState = CheckState.Checked;
                else
                    ChkCreateMaster.CheckState = CheckState.Unchecked;

                if (Convert.ToString(dt1.Rows[0]["UserManagement"]) == "Active")
                    chkUserManagement.CheckState = CheckState.Checked;
                else
                    chkUserManagement.CheckState = CheckState.Unchecked;

                
                Isload = 1;
            }
            connection.Close();


        }
        public void save()
        {
            try
            {
                if (Isload == 1)
                {
                    connection.Open();
                    SqlCommand cmb = new SqlCommand(@"Update Employee_ADDAccess set Name=@Name,Registration=@Registration,DoctorDashboard=@DoctorDashboard,PatientTransfur=@PatientTransfur,AssignTest=@AssignTest,AssignProcedure=@AssignProcedure,Discharge=@Discharge,AssignSurgery=@AssignSurgery,Printdow=@Printdow,Viewreport=@Viewreport,AddNotes=@AddNotes,Billing=@Billing,ChangeBilling=@ChangeBilling,CreateMaster=@CreateMaster,UserManagement=@UserManagement,Date=@Date where EMPID=@EMPID", connection);
                    cmb.Parameters.AddWithValue("@EMPID", EMP_ID);
                    cmb.Parameters.AddWithValue("@Name", EMpName);
                    if (chkRegistration.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Registration", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Registration", "InActive");
                    }
                    if (chkDoctordash.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@DoctorDashboard", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@DoctorDashboard", "InActive");
                    }
                    if (chkPatientTra.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@PatientTransfur", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@PatientTransfur", "InActive");
                    }
                    if (ChkAssignTest.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AssignTest", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AssignTest", "InActive");
                    }

                    if (chkAssignProc.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AssignProcedure", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AssignProcedure", "InActive");
                    }
                    if (chkDischaeges.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Discharge", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Discharge", "InActive");
                    }
                    if (chkAssignSurgery.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AssignSurgery", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AssignSurgery", "InActive");
                    }
                    if (chkprint.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Printdow", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Printdow", "InActive");
                    }

                    if (chkViewReport.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Viewreport", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Viewreport", "InActive");
                    }

                    if (chkAddNote.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AddNotes", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AddNotes", "InActive");
                    }

                    if (ChkBilling.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Billing", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Billing", "InActive");
                    }

                    if (chkChangeBilling.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@ChangeBilling", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@ChangeBilling", "InActive");
                    }
                    if (ChkCreateMaster.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@CreateMaster", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@CreateMaster", "InActive");
                    }
                    if (chkUserManagement.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@UserManagement", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@UserManagement", "InActive");
                    }



                    cmb.Parameters.AddWithValue("@Date", System.DateTime.Now);
                    cmb.ExecuteNonQuery();

                    MessageBox.Show("Employee Access level Updated Successfully...");
                    this.Close();
                }
                else
                {

                    connection.Open();
                    SqlCommand cmb = new SqlCommand(@"INSERT INTO Employee_ADDAccess (EMPID,Name,Registration,DoctorDashboard,PatientTransfur,AssignTest,AssignProcedure,Discharge,AssignSurgery,Printdow,Viewreport,AddNotes,Billing,ChangeBilling,CreateMaster,UserManagement,Date)
                                    Values (@EMPID,@Name,@Registration,@DoctorDashboard,@PatientTransfur,@AssignTest,@AssignProcedure,@Discharge,@AssignSurgery,@Printdow,@Viewreport,@AddNotes,@Billing,@ChangeBilling,@CreateMaster,@UserManagement,@Date)", connection);
                    cmb.Parameters.AddWithValue("@EMPID", EMP_ID);
                    cmb.Parameters.AddWithValue("@Name", EMpName);
                    if (chkRegistration.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Registration", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Registration", "InActive");
                    }
                    if (chkDoctordash.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@DoctorDashboard", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@DoctorDashboard", "InActive");
                    }
                    if (chkPatientTra.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@PatientTransfur", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@PatientTransfur", "InActive");
                    }
                    if (ChkAssignTest.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AssignTest", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AssignTest", "InActive");
                    }

                    if (chkAssignProc.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AssignProcedure", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AssignProcedure", "InActive");
                    }
                    if (chkDischaeges.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Discharge", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Discharge", "InActive");
                    }
                    if (chkAssignSurgery.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AssignSurgery", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AssignSurgery", "InActive");
                    }
                    if (chkprint.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Printdow", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Printdow", "InActive");
                    }

                    if (chkViewReport.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Viewreport", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Viewreport", "InActive");
                    }

                    if (chkAddNote.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@AddNotes", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@AddNotes", "InActive");
                    }

                    if (ChkBilling.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@Billing", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@Billing", "InActive");
                    }

                    if (chkChangeBilling.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@ChangeBilling", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@ChangeBilling", "InActive");
                    }
                    if (ChkCreateMaster.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@CreateMaster", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@CreateMaster", "InActive");
                    }
                    if (chkUserManagement.Checked == true)
                    {
                        cmb.Parameters.AddWithValue("@UserManagement", "Active");
                    }
                    else
                    {
                        cmb.Parameters.AddWithValue("@UserManagement", "InActive");
                    }



                    cmb.Parameters.AddWithValue("@Date", System.DateTime.Now);
                    cmb.ExecuteNonQuery();

                    MessageBox.Show("Employee Access level Added Successfully");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                        //SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("Select EMPID,Employee_Of,Name,Role,Mobile_Number from Employee_registration where Name LIKE @name +'%'", connection);
                        cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            frmSearchEmpAccess o = new frmSearchEmpAccess(dt);
                            o.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No Employee Present!!!");
                        }
                        connection.Close();
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
                        //SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("Select EMPID,Employee_Of,Name,Role,Mobile_Number from Employee_registration where EMPID = @EMPID", connection);
                        cmd.Parameters.AddWithValue("@EMPID", txtSearch.Text);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            frmSearchEmpAccess o = new frmSearchEmpAccess(dt);
                            o.Show();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("No Employee Present!!!");
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void getEmpDetails(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                txtEmpID.DataBindings.Add("Text", dt, "ID");
                txtName.DataBindings.Add("Text", dt, "Name");

                txtEmpID.Enabled = false;
                txtName.Enabled = false;
                
            }
        }
        private void frmEmployeeLoginAccess_Load(object sender, EventArgs e)
        {
            txtSearchBy.SelectedIndex = 0;


            //EMpName = txtName.Text;
            //EmpId = Convert.ToInt32(txtEmpID.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();

        }

        private void chkRegistration_CheckedChanged(object sender, EventArgs e)
        {
            chkRegistration.ForeColor = Color.DarkGreen;
        }
    }
}
