using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class Employee_Login_Details : Form
    {
        public int EMP_id;
        public Employee_Login_Details()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string password = txtpass.Text;
                string cpassword = txtConfirmPass.Text;
                if (password.Equals(cpassword))
                {
                    if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
                    {
                        if (btnSave.Text.Equals("Update"))
                        {
                            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                            con.Open();
                            SqlCommand cmd = new SqlCommand(@"Update Ruby_Jamner123.Login_Details set
Password = @Password WHERE Name = @Name AND Username = @Username", con);
                            cmd.Parameters.AddWithValue("@Password", txtpass.Text);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User Updated!!!");
                            btnSave.Enabled = false;
                            btnSave.BackColor = Color.Gray;
                            this.Close();
                        }
                        else
                        {
                            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                            con.Open();
                            SqlCommand cmd = new SqlCommand(@"Insert into Login_Details (EMP_id,Name,Username,Password,Created_Date)
values (@EMP_id,@Name,@Username,@Password,@date)", con);
                            cmd.Parameters.AddWithValue("@EMP_id", EMP_id);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                            cmd.Parameters.AddWithValue("@Password", txtpass.Text);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User Registered!!!");
                            btnSave.Enabled = false;
                            btnSave.BackColor = Color.Gray;
                            this.Close();
                        }                   
                    }
                    else
                    {
                        MessageBox.Show("Please create a valid password.");
                    }
                }
                else
                {
                    MessageBox.Show("Password and Confirm Password not same !!!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Enter Name")
            {
                txtName.Text = "";
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Enter Name";
            }
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtName.Text == "Enter Name")
            {
                txtName.Clear();
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
                        SqlCommand cmd = new SqlCommand(@"SELECT        Employee_Of, Name, Gender, Role, Status
FROM            Ruby_Jamner123.Employee_registration where Name LIKE @name +'%'", con);
                        cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                            EMP_id = Convert.ToInt32(dt.Rows[0]["EMPID"]);
                        }
                        else
                        {
                            MessageBox.Show("No Employee Present!!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Name!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            string Username;
            string role;
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                name = this.dataGridView1.Columns[e.ColumnIndex].Name;
                Username = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                role = dataGridView1.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                if (name.Equals("Name"))
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"select * from Ruby_Jamner123.Login_Details where Name = @Name", con);
                    cmd.Parameters.AddWithValue("@Name", Username);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable datatable = new DataTable();
                    sda.Fill(datatable);
                    if (datatable.Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        txtName.DataBindings.Add("Text", datatable, "Name");
                        txtRole.Text = role;
                        txtUserName.DataBindings.Add("Text", datatable, "Username");
                        txtpass.DataBindings.Add("Text", datatable, "Password");
                        txtConfirmPass.DataBindings.Add("Text", datatable, "Password");
                        txtpass.Enabled = true;
                        txtConfirmPass.Enabled = true;
                    }
                    else
                    {
                        // Create a new DataTable to store the specific row
                        DataTable specificRowTable = new DataTable();

                        // Add columns to the new DataTable matching the DataGridView
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            specificRowTable.Columns.Add(col.Name);
                        }

                        // Get the data from the clicked row
                        DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];

                        // Create a new DataRow for the DataTable and copy values from the clicked row
                        DataRow newRow = specificRowTable.NewRow();
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            newRow[col.Name] = clickedRow.Cells[col.Name].Value;
                        }

                        // Add the new DataRow to the DataTable
                        specificRowTable.Rows.Add(newRow);
                        if (specificRowTable.Rows.Count > 0)
                        {
                           
                            txtName.DataBindings.Add("Text", specificRowTable, "Name");
                            txtRole.DataBindings.Add("Text", specificRowTable, "Role");
                            txtName.Enabled = false;
                            txtRole.Enabled = false;
                            if (txtName.Text != "Enter Name" && txtRole.Text != "")
                            {
                                txtUserName.Enabled = true;
                                txtpass.Enabled = true;
                                txtConfirmPass.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Click On Name!!");
                }
            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            string password = txtpass.Text;

            // Use regular expressions to check if password meets criteria
            if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                errorProvider1.SetError(txtpass, ""); // Password is valid
            }
            else
            {
                errorProvider1.SetError(txtpass, "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one symbol (@$!%*?&)");
            }

        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Enter Username")
            {
                txtUserName.Text = "";
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Enter Username";
            }
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "Enter Username")
            {
                txtUserName.Clear();
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Enter Password")
            {
                txtpass.Text = "";
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Enter Password";
            }
        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpass.Text == "Enter Password")
            {
                txtpass.Clear();
            }
        }

        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "Confirm Password")
            {
                txtConfirmPass.Text = "";
            }
        }

        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "")
            {
                txtConfirmPass.Text = "Confirm Password";
            }
        }

        private void txtConfirmPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtConfirmPass.Text == "Confirm Password")
            {
                txtConfirmPass.Clear();
            }
        }

        private void Employee_Login_Details_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
