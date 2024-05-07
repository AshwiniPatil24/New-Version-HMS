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
    public partial class Master_RoomNumber : Form
    {
        public int ID;
        public int SegID;
        public Master_RoomNumber()
        {
            InitializeComponent();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchName.Text != "Enter Room Segment")
                {
                    txtRoomName.Clear();
                    txtNoOFBeds.Clear();
                    string roomSeg = txtSearchName.Text;
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand checkForseg = new SqlCommand(@"SELECT ID from Ruby_Jamner123.Master_IPDRoomSegment where Name = @n", con);
                    checkForseg.Parameters.AddWithValue("@n", roomSeg);
                    int SID = Convert.ToInt32(checkForseg.ExecuteScalar());
                    if (SID > 0)
                    {
                        SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 Ruby_Jamner123.Master_IPDBedNo.RoomSegmentID,Ruby_Jamner123.Master_IPDBedNo.ID,Ruby_Jamner123.Master_IPDRoomSegment.Name,Ruby_Jamner123.Master_IPDBedNo.BedNo,Ruby_Jamner123.Master_IPDBedNo.Date FROM Ruby_Jamner123.Master_IPDBedNo
INNER JOIN Ruby_Jamner123.Master_IPDRoomSegment ON Ruby_Jamner123.Master_IPDBedNo.RoomSegmentID = Ruby_Jamner123.Master_IPDRoomSegment.ID
WHERE Ruby_Jamner123.Master_IPDRoomSegment.Name = @name ORDER BY Ruby_Jamner123.Master_IPDBedNo.BedNo DESC ", con);
                        cmd.Parameters.AddWithValue("@name", roomSeg);
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            ID = Convert.ToInt32(row["ID"]);
                            SegID = Convert.ToInt32(row["RoomSegmentID"]);
                            txtRoomName.Text = row["Name"].ToString();
                            txtNoOFBeds.Text = row["BedNo"].ToString();
                            txtDate.Value = Convert.ToDateTime(row["Date"]);
                            dt.Clear();
                            btnsave.Enabled = true;
                            btnsave.BackColor = Color.DarkGreen;
                            btnsave.Visible = true;
                            btnDelete.Enabled = true;
                            btnDelete.Visible = true;
                        }
                        else if(dt.Rows.Count < 1)
                        {
                            //new seg and no rows currently present 
                            SegID = SID;
                            txtRoomName.Text = roomSeg;
                            txtNoOFBeds.Text = "0";
                            txtDate.Value = DateTime.Now;
                            btnsave.Enabled = true;
                            btnsave.BackColor = Color.DarkGreen;
                            btnDelete.Visible = false;
                            MessageBox.Show("No Beds present in Current Segment!");
                        }
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtNoOFBeds.Text != "" && txtRoomName.Text != "")
            {

                btnsave.Enabled = true;
                btnsave.BackColor = Color.DarkGreen;
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT into Ruby_Jamner123.Master_IPDBedNo(RoomSegmentID,BedNo,IsVacant,Date) values(@RoomSegmentID,@BedNo,@IsVacant,@Date)", con);
                cmd.Parameters.AddWithValue("@RoomSegmentID", SegID);
                cmd.Parameters.AddWithValue("@BedNo", Convert.ToInt32(txtNoOFBeds.Text) + 1);
                cmd.Parameters.AddWithValue("@IsVacant", "0");
                cmd.Parameters.AddWithValue("@Date", txtDate.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully..");
                btnsave.Enabled = false;
                btnsave.Visible = false;
                ClearControls();
                txtSearchName.Clear();
            }
            
        }

        public void ClearControls()
        {
            // Clear textboxes
            txtRoomName.Text = "";
            txtNoOFBeds.Text = "";

            // Clear datetimepicker
            txtDate.Value = DateTime.Now; // or any default date you want
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtNoOFBeds.Text != "" && txtRoomName.Text != "")
            {
                btnsave.Enabled = true;
                btnsave.BackColor = Color.DarkGreen;
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE from Ruby_Jamner123.Master_IPDBedNo WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully..");
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
                ClearControls();
                txtSearchName.Clear();
            }
        }
    }
}
