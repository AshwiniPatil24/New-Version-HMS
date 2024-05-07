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
    public partial class Manage_RoomSegment : Form
    {
        public int ID;
        public Manage_RoomSegment()
        {
            InitializeComponent();
        }

        private void Manage_RoomSegment_NursingCharges_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchName.Text != "Enter Room Segment")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE Ruby_Jamner123.Master_IPDRoomSegment set Name = @Name,Charge = @Charge,NursingCharge = @NursingCharge,Date = @Date WHERE ID = @ID", con);
                    cmd.Parameters.AddWithValue("@Name",txtRoomName.Text);
                    cmd.Parameters.AddWithValue("@Charge", txtRoomCharges.Text);
                    cmd.Parameters.AddWithValue("@NursingCharge", txtNursingCharges.Text);
                    cmd.Parameters.AddWithValue("@Date",txtDate.Value );
                    cmd.Parameters.AddWithValue("@ID",ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully..");
                    btnsave.Enabled = false;
                    btnsave.BackColor = Color.Gray;
                    ClearControls();
                    txtSearchName.Clear();
                }
                else
                {
                    if (txtRoomName.Text != "Enter the Room Segment Name" && txtRoomCharges.Text != "Enter Room Segment Charges" && txtNursingCharges.Text != "Enter Nursing Charges")
                    {
                        btnsave.Enabled = true;
                        btnsave.BackColor = Color.DarkGreen;
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"INSERT into Ruby_Jamner123.Master_IPDRoomSegment(Name,Charge,NursingCharge,Date) values(@Name,@Charge,@NursingCharge,@Date)", con);
                        cmd.Parameters.AddWithValue("@Name", txtRoomName.Text);
                        cmd.Parameters.AddWithValue("@Charge", txtRoomCharges.Text);
                        cmd.Parameters.AddWithValue("@NursingCharge", txtNursingCharges.Text);
                        cmd.Parameters.AddWithValue("@Date", txtDate.Value);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted Successfully..");
                        btnsave.Enabled = false;
                        btnsave.BackColor = Color.Gray;
                        ClearControls();
                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void txtSearchName_Enter(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "Enter Room Segment")
            {
                txtSearchName.Text = "";
            }
        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "")
            {
                txtSearchName.Text = "Enter Room Segment";
            }
        }

        private void txtSearchName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSearchName.Text == "Enter Room Segment")
            {
                txtSearchName.Clear();
            }
        }

        private void txtRoomName_Enter(object sender, EventArgs e)
        {
            if (txtRoomName.Text == "Enter the Room Segment Name")
            {
                txtRoomName.Text = "";
            }
        }

        private void txtRoomName_Leave(object sender, EventArgs e)
        {
            if (txtRoomName.Text == "")
            {
                txtRoomName.Text = "Enter the Room Segment Name";
            }
        }

        private void txtRoomName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtRoomName.Text == "Enter the Room Segment Name")
            {
                txtRoomName.Clear();
            }
        }

        private void txtRoomCharges_Enter(object sender, EventArgs e)
        {
            if (txtRoomCharges.Text == "Enter Room Segment Charges")
            {
                txtRoomCharges.Text = "";
            }
        }

        private void txtRoomCharges_Leave(object sender, EventArgs e)
        {
            if (txtRoomCharges.Text == "")
            {
                txtRoomCharges.Text = "Enter Room Segment Charges";
            }
        }

        private void txtRoomCharges_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtRoomCharges.Text == "Enter Room Segment Charges")
            {
                txtRoomCharges.Clear();
            }
        }

        private void txtNursingCharges_Enter(object sender, EventArgs e)
        {
            if (txtNursingCharges.Text == "Enter Nursing Charges")
            {
                txtNursingCharges.Text = "";
            }
        }

        private void txtNursingCharges_Leave(object sender, EventArgs e)
        {
            if (txtNursingCharges.Text == "")
            {
                txtNursingCharges.Text = "Enter Nursing Charges";
            }
        }

        private void txtNursingCharges_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNursingCharges.Text == "Enter Nursing Charges")
            {
                txtNursingCharges.Clear();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ClearControls();
            try
            {
                if (txtSearchName.Text != "Enter Room Segment")
                {
                    string roomSeg = txtSearchName.Text;
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Ruby_Jamner123.Master_IPDRoomSegment where Name = @name", con);
                    cmd.Parameters.AddWithValue("@name", roomSeg);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        ID = Convert.ToInt32(row["ID"]);
                        txtRoomName.Text = row["Name"].ToString();
                        txtRoomCharges.Text = row["Charge"].ToString();
                        txtNursingCharges.Text = row["NursingCharge"].ToString();
                        txtDate.Value = Convert.ToDateTime(row["Date"]);
                        dt.Clear();
                        btnsave.Enabled = true;
                        btnsave.BackColor = Color.DarkGreen;
                        //btnDelete.Visible = true;
                        //btnDelete.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No Room Segment Present!");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter room segment!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ClearControls()
        {
            // Clear textboxes
            txtRoomName.Text = "";
            txtRoomCharges.Text = "";
            txtNursingCharges.Text = "";

            // Clear datetimepicker
            txtDate.Value = DateTime.Now; // or any default date you want
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE from Ruby_Jamner123.Master_IPDRoomSegment WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted Successfully..");
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
            ClearControls();
            txtSearchName.Clear();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
