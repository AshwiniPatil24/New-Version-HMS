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
    public partial class Master_Drugs : Form
    {
        public int ID;
        public Master_Drugs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtDescription.Text != "")
            {
                if (button2.Text == "Update")
                {
                    update();
                }
                else
                {
                    save();
                }
            }
        }
        public void save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"INSERT into Master_OPD_DrugsList (Name,Description,Createdby)
values      (@Name,@Description,@Createdby)", con);
            cmb.Parameters.AddWithValue("@Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmb.Parameters.AddWithValue("@Createdby", txtdate.Value.Date);
            cmb.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
            button2.BackColor = Color.Gray;
            button2.Enabled = false;
        }
        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Update Master_OPD_DrugsList set Name=@Name,Description=@Description,Updatedby=@Updatedby
WHERE  (ID=@ID)", con);
            cmb.Parameters.AddWithValue("@Name", txtname.Text);
            cmb.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmb.Parameters.AddWithValue("@Updatedby", DateTime.Now.Date);
            cmb.Parameters.AddWithValue("@ID", ID);
            cmb.ExecuteNonQuery();
            MessageBox.Show("updated successfully.....!");
            con.Close();
            button2.BackColor = Color.Gray;
            button2.Enabled = false;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter Drug Name")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Enter Drug Name";
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearch.Text == "Enter Drug Name")
            {
                txtSearch.Clear();
            }
        }

        public void clearBindings()
        {
            txtname.Clear();
            txtDescription.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                button2.Text = "Save";
                button2.Enabled = true;
                clearBindings();
                dataGridView1.DataSource = null;
                dataGridView1.Visible = false;
                if (txtSearch.Text == "Enter Drug Name")
                {
                    MessageBox.Show("Please fill details!!!");
                }
                else
                {
                    String DrugName = txtSearch.Text;
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Master_OPD_DrugsList where Name LIKE @name +'%'", con);
                    cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        button2.Text = "Update";
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dt;
                        button2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No Drug Present!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearBindings();
            string name;
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                name = this.dataGridView1.Columns[e.ColumnIndex].Name;
                if (name.Equals("Name"))
                {
                    button2.BackColor = Color.DarkGreen;
                    button2.Enabled = true;

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

        public void getRefferalDetails(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                button2.Text = "Update";
                button2.Enabled = true;
                DataRow row = dt.Rows[0];
                ID = Convert.ToInt32(row["ID"]);
                txtname.Text = row["Name"].ToString();
                txtDescription.Text = row["Description"].ToString();
                txtdate.Value = Convert.ToDateTime(row["Createdby"]);
            }
        }
    }
}
