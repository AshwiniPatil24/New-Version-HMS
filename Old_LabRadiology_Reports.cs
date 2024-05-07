using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class Old_LabRadiology_Reports : Form
    {
        public string testType;
        public Old_LabRadiology_Reports()
        {
            InitializeComponent();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    testType = "LAB";
                    dataGridView1.DataSource = null;
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
                            SqlCommand cmd = new SqlCommand(@"Select Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.IPDID,Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.OPDID,
Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Date from Ruby_Jamner123.Patient_Registration
 inner join Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest on Ruby_Jamner123.Patient_Registration.Patient_ID = Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Patient_ID
where  Ruby_Jamner123.Patient_Registration.Name like @name +'%' and Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Balance = 0 and Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Date >= @from and Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Date <= @to
", con);
                            cmd.Parameters.AddWithValue("@from", FromDate.Value.Date);
                            cmd.Parameters.AddWithValue("@to", ToDate.Value.Date);
                            cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                            SqlDataAdapter adt = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adt.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                                //dataGridView1.Columns["OPDID"].Visible = true;
                                //dataGridView1.Columns["IPDID"].Visible = true;
                                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                                dataGridView1.ReadOnly = true;
                                dataGridView1.AllowUserToAddRows = false;
                                dataGridView1.AllowUserToDeleteRows = false;
                                dataGridView1.AllowUserToResizeRows = false;
                                dataGridView1.AllowUserToResizeColumns = false;

                            }
                            else
                            {
                                MessageBox.Show("No Patient Present!!!");
                            }
                        }
                    }
                    else if (txtSearchBy.Text == "Patient ID")
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
                            SqlCommand cmd = new SqlCommand(@"Select Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.IPDID,Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.OPDID,
Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Date from Ruby_Jamner123.Patient_Registration
 inner join Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest on Ruby_Jamner123.Patient_Registration.Patient_ID = Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Patient_ID
where  Ruby_Jamner123.Patient_Registration.Patient_ID = @pid and Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Balance = 0 and Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Date >= @from and Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Date <= @to", con);
                            cmd.Parameters.AddWithValue("@from", FromDate.Value.Date);
                            cmd.Parameters.AddWithValue("@to", ToDate.Value.Date);
                            cmd.Parameters.AddWithValue("@pid", txtSearch.Text);
                            SqlDataAdapter adt = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adt.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                                //dataGridView1.Columns["Billing_Date"].Visible = false;
                                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                                dataGridView1.ReadOnly = true;
                                dataGridView1.AllowUserToAddRows = false;
                                dataGridView1.AllowUserToDeleteRows = false;
                                dataGridView1.AllowUserToResizeRows = false;
                                dataGridView1.AllowUserToResizeColumns = false;

                            }
                            else
                            {
                                MessageBox.Show("No Patient Present!!!");
                            }
                        }
                    }
                }
                else if(radioButton2.Checked == true)
                {
                    testType = "RADIOLOGY";
                    dataGridView1.DataSource = null;
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
                            SqlCommand cmd = new SqlCommand(@"Select Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.IPDID,Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.OPDID,
Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Date from Ruby_Jamner123.Patient_Registration
 inner join Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest on Ruby_Jamner123.Patient_Registration.Patient_ID = Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Patient_ID
where  Ruby_Jamner123.Patient_Registration.Name like @name +'%' and Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance = 0 and Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Date >= @from and Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Date<= @to", con);
                            cmd.Parameters.AddWithValue("@from", FromDate.Value.Date);
                            cmd.Parameters.AddWithValue("@to", ToDate.Value.Date);
                            cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                            SqlDataAdapter adt = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adt.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                                //dataGridView1.Columns["Billing_Date"].Visible = false;
                                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                                dataGridView1.ReadOnly = true;
                                dataGridView1.AllowUserToAddRows = false;
                                dataGridView1.AllowUserToDeleteRows = false;
                                dataGridView1.AllowUserToResizeRows = false;
                                dataGridView1.AllowUserToResizeColumns = false;

                            }
                            else
                            {
                                MessageBox.Show("No Patient Present!!!");
                            }
                        }
                    }
                    else if (txtSearchBy.Text == "Patient ID")
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
                            SqlCommand cmd = new SqlCommand(@"Select Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.IPDID,Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.OPDID,
Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Date from Ruby_Jamner123.Patient_Registration
 inner join Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest on Ruby_Jamner123.Patient_Registration.Patient_ID = Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Patient_ID
where  Ruby_Jamner123.Patient_Registration.Patient_ID = @pid and Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance = 0 and Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Date >= @from and Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Date <= @to", con);
                            cmd.Parameters.AddWithValue("@from", FromDate.Value.Date);
                            cmd.Parameters.AddWithValue("@to", ToDate.Value.Date);
                            cmd.Parameters.AddWithValue("@pid", txtSearch.Text);
                            SqlDataAdapter adt = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adt.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                                //dataGridView1.Columns["Billing_Date"].Visible = false;
                                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                                dataGridView1.ReadOnly = true;
                                dataGridView1.AllowUserToAddRows = false;
                                dataGridView1.AllowUserToDeleteRows = false;
                                dataGridView1.AllowUserToResizeRows = false;
                                dataGridView1.AllowUserToResizeColumns = false;

                            }
                            else
                            {
                                MessageBox.Show("No Patient Present!!!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select type!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Name"].Index && e.RowIndex >= 0)
            {
                string ipd = dataGridView1.Rows[e.RowIndex].Cells["IPDID"].Value.ToString() == "0" ? dataGridView1.Rows[e.RowIndex].Cells["OPDID"].Value.ToString() : dataGridView1.Rows[e.RowIndex].Cells["IPDID"].Value.ToString();
                string type = dataGridView1.Rows[e.RowIndex].Cells["IPDID"].Value.ToString() == "0" ? "OPD" : "IPD";
                DateTime bill_date1 = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Date"].Value);
                DateTime bill_date = Convert.ToDateTime(bill_date1);
                string Billdate = bill_date.ToString("dd-MM-yyyy_hh-mm-ss");
                string fileName = ipd + "_" + Billdate;
                string pdfPath;
                if (testType.Equals("LAB"))
                {
                    if (type.Equals("IPD"))
                    {
                        pdfPath = @"D:\HMS_OLD_BILLS\IPD_LAB_Bills\" + ipd + "_" + Billdate + ".pdf";

                    }
                    else
                    {
                        pdfPath = @"D:\HMS_OLD_BILLS\ONLY_OPD_LAB_Bills\" + ipd + "_" + Billdate + ".pdf";

                    }

                }
                else
                {
                    if (type.Equals("IPD"))
                    {
                        pdfPath = @"D:\HMS_OLD_BILLS\IPD_Radiology_Bills\" + ipd + "_" + Billdate + ".pdf";

                    }
                    else
                    {
                        pdfPath = @"D:\HMS_OLD_BILLS\OPD_Radiology_Bills\" + ipd + "_" + Billdate + ".pdf";

                    }

                }

                // Check if the file exists
                if (File.Exists(pdfPath))
                {
                    // Open the PDF file
                    try
                    {
                        System.Diagnostics.Process.Start(pdfPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error opening file: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
        }
    }
}
