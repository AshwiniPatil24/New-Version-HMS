using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class Referred_doctor : Form
    {
        public int ID;//referrelID

        public Referred_doctor()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Referred_doctor_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void txtdrrename_Enter(object sender, EventArgs e)
        {
            if(txtdrrename.Text == "Enter the Doctor Name")
            {
                txtdrrename.Text = "";
                txtdrrename.ForeColor = Color.Black;
            }
        }

        private void txtdrrename_Leave(object sender, EventArgs e)
        {
            if (txtdrrename.Text == "")
            {
                txtdrrename.Text = "Enter the Doctor Name";
                txtdrrename.ForeColor = Color.Gray;
            }
        }

        private void txtdigree_Enter(object sender, EventArgs e)
        {
           if(txtdegree.Text == "Degree")
            {
                txtdegree.Text = "";
                txtdegree.ForeColor = Color.Black;
            }
        }

        private void txtdigree_Leave(object sender, EventArgs e)
        {
            if (txtdegree.Text == "")
            {
                txtdegree.Text = "Degree";
                txtdegree.ForeColor = Color.Gray;
            }
        }

        private void txtdrremobileno_Enter(object sender, EventArgs e)
        {
            if(txtdrremobileno.Text== "Mobile No")
            {
                txtdrremobileno.Text = "";
                txtdrremobileno.ForeColor = Color.Black;
            }
        }

        private void txtdrremobileno_Leave(object sender, EventArgs e)
        {
            if (txtdrremobileno.Text == "")
            {
                txtdrremobileno.Text = "Mobile No";
                txtdrremobileno.ForeColor = Color.Gray;
            }
        }

        private void txtdrrgeaddress_Enter(object sender, EventArgs e)
        {
            if(txtdrrgeaddress.Text=="Address")
            {
                txtdrrgeaddress.Text = "";
                txtdrrgeaddress.ForeColor = Color.Black;

            }
        }

        private void txtdrrgeaddress_Leave(object sender, EventArgs e)
        {
            if (txtdrrgeaddress.Text == "")
            {
                txtdrrgeaddress.Text = "Address";
                txtdrrgeaddress.ForeColor = Color.Gray;

            }
        }

        private void txtdrrename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtdigree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txtdrremobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled =  true;

            }
        }
        public void Save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Referred_Doctor (Referred_Name,Degree,Mobile_no,Address,Status)Values (@Referred_Name,@Degree,@Mobile_no,@Address,@Status)", con);
            cmd.Parameters.AddWithValue("@Referred_Name", txtdrrename.Text);
            cmd.Parameters.AddWithValue("@Degree", txtdegree.Text);
            cmd.Parameters.AddWithValue("@Mobile_no", txtdrremobileno.Text);
            cmd.Parameters.AddWithValue("@Address", txtdrrgeaddress.Text);
            if (chbactive.Checked == true)
            {
                cmd.Parameters.AddWithValue("@Status", "Active");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", "InActive");
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added Successfully..");
            btnsave.Enabled = false;
            btnsave.BackColor = Color.Gray;
            clearBindings();
        }

        public void saveUpdated()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Referred_Doctor set Referred_Name=@Referred_Name,Degree=@Degree,Mobile_no=@Mobile_no,Address=@Address,Status=@Status where Referred_Name=@Referred_Name", con);
            cmd.Parameters.AddWithValue("@Referred_Name", txtdrrename.Text);
            cmd.Parameters.AddWithValue("@Degree", txtdegree.Text);
            cmd.Parameters.AddWithValue("@Mobile_no", txtdrremobileno.Text);
            cmd.Parameters.AddWithValue("@Address", txtdrrgeaddress.Text);
            if (chbactive.Checked == true)
            {
                cmd.Parameters.AddWithValue("@Status", "Active");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", "InActive");
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully..");
            btnsave.Enabled = false;
            btnsave.BackColor = Color.Gray;
            clearBindings();
        }

        private void txtdrremobileno_TextChanged(object sender, EventArgs e)
        {
            int NoLeng = txtdrremobileno.Text.Length;
            if(NoLeng < 10 || NoLeng > 10)
            {
                errorProvider1.SetError(txtdrremobileno, "Invalid Mobile Number !");
            }
            else
            {
                errorProvider1.SetError(txtdrremobileno, "");
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

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearch.Text == "Enter Details")
            {
                txtSearch.Clear();
            }
        }

        public void getRefferalDetails(DataTable dt)
        {
            if(dt.Rows.Count > 0)
            {
                btnsave.Text = "Update";
                btnsave.Enabled = true;
                btnDelete.Visible = true;
                DataRow row = dt.Rows[0];
                ID = Convert.ToInt32(row["ReferredID"]);
                txtdrrename.Text = row["Referred_Name"].ToString();
                txtdegree.Text = row["Degree"].ToString();
                txtdrremobileno.Text = row["Mobile_no"].ToString();
                txtdrrgeaddress.Text = row["Address"].ToString();
                string status = dt.Rows[0]["Status"].ToString();
                if (status.Equals("Active"))
                {
                    chbactive.Checked = true;
                }
                else
                {
                    chbactive.Checked = false;
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                btnsave.Text = "Save";
                clearBindings();
                dataGridView1.DataSource = null;
                dataGridView1.Visible = false;
                if (txtSearchBy.Text == "Name")
                {
                    if (txtSearch.Text == "Enter Details")
                    {
                        MessageBox.Show("Please fill details!!!");
                    }
                    else
                    {
                        String ReferredName = txtSearch.Text;
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select * from Referred_Doctor where Referred_Name LIKE @name +'%'", con);
                        cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.Visible = true;
                            dataGridView1.DataSource = dt;
                            //dataGridView1.Columns["ReferredID"].Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("No Referrel Present!!!");
                        }
                    }
                }
                else if(txtSearchBy.Text == "Mobile Number")
                {
                    if (txtSearch.Text == "Enter Details")
                    {
                        MessageBox.Show("Please fill details!!!");
                    }
                    else
                    {
                        String mobNo = txtSearch.Text;
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select * from Referred_Doctor where Mobile_no = @Mobile ", con);
                        cmd.Parameters.AddWithValue("@Mobile", txtSearch.Text);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            getRefferalDetails(dt);
                        }
                        else
                        {
                            MessageBox.Show("No Referrel Present!!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("select appropriate type !");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
        }

        private void txtdrrename_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtdrrename.Text == "Enter the Doctor Name")
            {
                txtdrrename.Clear();
            }
        }

        public void clearBindings()
        {
            txtdrrename.Clear();
            txtdrremobileno.Clear();
            txtdegree.Clear();
            txtdrrgeaddress.Clear();
            chbactive.Checked = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearBindings();
            btnsave.Text = "Update";
            btnsave.BackColor = Color.DarkGreen;
            string name;
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                name = this.dataGridView1.Columns[e.ColumnIndex].Name;
                if (name.Equals("Referred_Name"))
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
                    getRefferalDetails(specificRowTable);
                }
                else
                {
                    MessageBox.Show("Click On Name!!");
                }
            }
        }

        private void txtdegree_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtdegree.Text == "Degree")
            {
                txtdegree.Clear();
            }
        }

        private void txtdrrgeaddress_TextChanged(object sender, EventArgs e)
        {
            if (txtdrrgeaddress.Text == "Address")
            {
                txtdrrgeaddress.Clear();
            }
        }

        private void txtdrremobileno_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtdrremobileno.Text == "Mobile No")
            {
                txtdrremobileno.Clear();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtdrrename.Text != "Enter the Doctor Name" && txtdrremobileno.Text != "Mobile No")
            {
                if (btnsave.Text.Equals("Save"))
                {
                    Save();
                }
                else
                {
                    saveUpdated();
                }
            }                             
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtdrrename.Text != "Enter the Doctor Name" && txtdrremobileno.Text != "Mobile No")
            {
                if (btnsave.Text == "Update")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from Referred_Doctor where ReferredID = @ReferredID", con);
                    cmd.Parameters.AddWithValue("@ReferredID", ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully..");
                    btnDelete.Visible = false;
                    clearBindings();
                }
            }
                
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
