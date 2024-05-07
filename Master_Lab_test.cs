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
    public partial class Master_Lab_test : Form
    {
        public int LabID;
        public Master_Lab_test()
        {
            InitializeComponent();
        }

        private void Master_Lab_test_Load(object sender, EventArgs e)
        {
            show();
        }

        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Select * from Master_LabTestType", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comtype.DataSource = dt;
                comtype.DisplayMember = "LabTestType_Name";
                comtype.ValueMember = "LabTestTypeID";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comtype.Text != "" && txtcharge.Text !="" && txtname.Text != "")
            {
                if (txtsearch.Text != "Enter Lab Test Name")
                {
                    update();
                }
                else
                {
                    insert();                    
                }
            }
            else
            {
                MessageBox.Show("Fill Lab Details!!!");
            }
            
        }
        public void insert()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT into Master_LabTest (LabTestTypeID,LabTestName,LabTestCharge,HospCharge,Lab_Test_Details,CreatedOn)
values            (@LabTestTypeID,@LabTestName,@LabTestCharge,@HospCharge,@Lab_Test_Details,@CreatedOn)  ", con);
            cmd.Parameters.AddWithValue("@LabTestTypeID", comtype.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@LabTestName", txtname.Text);
            cmd.Parameters.AddWithValue("@LabTestCharge", txtcharge.Text);
            cmd.Parameters.AddWithValue("@HospCharge", txthosp_charge.Text);
            cmd.Parameters.AddWithValue("@Lab_Test_Details", txtdetails.Text);
            cmd.Parameters.AddWithValue("@CreatedOn", txtdate.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
            button2.BackColor = Color.Gray;
            button2.Enabled = false;
            clear();
        }

        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Master_LabTest set LabTestTypeID=@LabTestTypeID,LabTestName=@LabTestName,LabTestCharge=@LabTestCharge,HospCharge=@HospCharge,Lab_Test_Details=@Lab_Test_Details,UpdatedOn=@UpdatedOn
WHERE  LabTestID=@LabTestID", con);
            cmd.Parameters.AddWithValue("@LabTestTypeID", comtype.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@LabTestName", txtsearch.Text);
            cmd.Parameters.AddWithValue("@LabTestCharge", txtcharge.Text);
            cmd.Parameters.AddWithValue("@HospCharge", txthosp_charge.Text);
            cmd.Parameters.AddWithValue("@Lab_Test_Details", txtdetails.Text);
            cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@LabTestID", LabID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated successfully.....!");
            con.Close();
            button2.BackColor = Color.Gray;
            button2.Enabled = false;
            clear();
        }
        //        public void Search()
        //        {

        //            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.Master_LabTestType.LabTestType_Name, Ruby_Jamner123.Master_LabTest.LabTestName, Ruby_Jamner123.Master_LabTest.LabTestCharge, Ruby_Jamner123.Master_LabTest.HospCharge, 
        //                         Ruby_Jamner123.Master_LabTest.Lab_Test_Details
        //FROM            Ruby_Jamner123.Master_LabTest INNER JOIN
        //                         Ruby_Jamner123.Master_LabTestType ON Ruby_Jamner123.Master_LabTest.LabTestTypeID = Ruby_Jamner123.Master_LabTestType.LabTestTypeID
        //WHERE        (Ruby_Jamner123.Master_LabTest.LabTestName = @LabTestName)", con);
        //            cmd.Parameters.AddWithValue("@LabTestName", txtsearch.Text);
        //            cmd.ExecuteNonQuery();
        //            SqlDataAdapter adt = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            adt.Fill(dt);
        //           // IDOPDProc = Convert.ToInt32(dt.Rows[0]["OPD_ProcedureID"]);
        //            if (dt.Rows.Count > 0)
        //            {
        //                txtname.DataBindings.Add("Text", dt, "LabTestName");
        //                txtcharge.DataBindings.Add("Text", dt, "LabTestCharge");
        //                txthosp_charge.DataBindings.Add("Text", dt, "HospCharge");
        //                txtdetails.DataBindings.Add("Text", dt, "Lab_Test_Details");

        //            }

        //            con.Close();
        //        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            txtcharge.Clear();
            txtdetails.Clear();
            txthosp_charge.Clear();
            txtname.Clear();
            comtype.Text = "";
            txtdate.Value = DateTime.Now.Date;
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "Enter Lab Test Name")
            {
                txtsearch.Text = "";
            }
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                txtsearch.Text = "Enter Lab Test Name";
            }
        }

        private void txtsearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtsearch.Text == "Enter Lab Test Name")
            {
                txtsearch.Clear();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                button2.Enabled = true;
                button2.BackColor = Color.DarkGreen;
                if (txtsearch.Text == "Enter Lab Test Name")
                {
                    MessageBox.Show("Fill details to search!");
                }
                else if (txtsearch.Text != "")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.Master_LabTestType.LabTestType_Name,Ruby_Jamner123.Master_LabTest.LabTestID ,Ruby_Jamner123.Master_LabTest.LabTestName, Ruby_Jamner123.Master_LabTest.LabTestCharge, Ruby_Jamner123.Master_LabTest.HospCharge, Ruby_Jamner123.Master_LabTest.CreatedOn,
                         Ruby_Jamner123.Master_LabTest.Lab_Test_Details
FROM            Ruby_Jamner123.Master_LabTest INNER JOIN
                         Ruby_Jamner123.Master_LabTestType ON Ruby_Jamner123.Master_LabTest.LabTestTypeID = Ruby_Jamner123.Master_LabTestType.LabTestTypeID
WHERE        (Ruby_Jamner123.Master_LabTest.LabTestName = @LabTestName)", con);
                    cmd.Parameters.AddWithValue("@LabTestName", txtsearch.Text);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    // IDOPDProc = Convert.ToInt32(dt.Rows[0]["OPD_ProcedureID"]);
                    if (dt.Rows.Count > 0)
                    {
                        LabID = Convert.ToInt32(dt.Rows[0]["LabTestID"]);
                        comtype.DataBindings.Add("Text", dt, "LabTestType_Name");
                        txtname.DataBindings.Add("Text", dt, "LabTestName");
                        txtcharge.DataBindings.Add("Text", dt, "LabTestCharge");
                        txthosp_charge.DataBindings.Add("Text", dt, "HospCharge");
                        txtdetails.DataBindings.Add("Text", dt, "Lab_Test_Details");
                        object valueFromTable = dt.Rows[0]["CreatedOn"];
                        txtdate.Value = (valueFromTable != DBNull.Value) ? Convert.ToDateTime(valueFromTable) : DateTime.Now.Date;
                    }
                    else
                    {
                        MessageBox.Show("test not present!!!");
                        txtsearch.Clear();
                        button2.Enabled = true;
                    }

                    con.Close();
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
    }
}
