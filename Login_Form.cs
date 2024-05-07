using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Ruby_Hospital
{
    public partial class Login_Form : Form
    {
        public int EMPID;
        public string EMp_Name;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse
      );
        public Login_Form()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            AcceptButton = button1;
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_Enter(object sender, EventArgs e)
        {
            if(txtid.Text == "Enter Username")
            {
                txtid.Text = "";
                txtid.ForeColor = Color.Black;
            }
        }

        private void txtid_Leave(object sender, EventArgs e)
        {

            if (txtid.Text == "")
            {
                txtid.Text = "Enter Username";
                txtid.ForeColor = Color.Gray;
            }


        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if(txtpass.Text == "Enter Password")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Black;

            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if(txtpass.Text == " ")
            {
                txtpass.Text = "Enter Password";
                txtpass.ForeColor = Color.Gray;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtid_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtid.Text == "Enter Username")
            {
                txtid.Clear();
            }
        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtpass.Text == "Enter Password")
            {
                txtpass.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmb = new SqlCommand(@"Select EMP_id,Name, Username,Password from Ruby_Jamner123.Login_Details WHERE Username = @Username AND Password = @Password", con);
                cmb.Parameters.AddWithValue("@Username",txtid.Text);
                cmb.Parameters.AddWithValue("@Password",txtpass.Text);
                //SqlDataReader rdr = cmb.ExecuteReader();
                //if (rdr.HasRows)
                //{
                //    MessageBox.Show("Login Success !!!");
                //    Dashbord o = new Dashbord();
                //    o.Show();
                //}
                //else
                //{
                //    MessageBox.Show("Login Failed !!!");
                //    txtpass.Clear();
                //    return;
                //}
                SqlDataAdapter adt = new SqlDataAdapter(cmb);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    EMPID = Convert.ToInt32(dt.Rows[0]["EMP_id"]);
                    EMp_Name = Convert.ToString(dt.Rows[0]["Name"]);
                    MessageBox.Show("Login Success !!!");
                    Dashbord o = new Dashbord(EMPID, EMp_Name);
                    o.Show();

                }
                else
                {
                    MessageBox.Show("Login Failed !!!");
                    txtpass.Clear();
                    return;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
    }
}
