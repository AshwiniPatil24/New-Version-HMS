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
    public partial class Old_OPD_Reports : Form
    {
        public Old_OPD_Reports()
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
                        SqlCommand cmd = new SqlCommand(@"Select Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr,Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId,Ruby_Jamner123.Patient_Registration.Patient_ID,
Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Billing_OPDFinal.Billing_Date from Ruby_Jamner123.OPD_Patient_Registration
 inner join Ruby_Jamner123.Patient_Registration on Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID
 inner
                                                                                            join Ruby_Jamner123.Billing_OPDFinal on Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDFinal.OPDID
where  Ruby_Jamner123.Patient_Registration.Name like @name +'%' and Ruby_Jamner123.Billing_OPDFinal.Total_Balance_Amount = 0 and Ruby_Jamner123.Billing_OPDFinal.Billing_Date between @from and @to", con);
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
                        SqlCommand cmd = new SqlCommand(@"Select Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr,Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId,Ruby_Jamner123.Patient_Registration.Patient_ID,
Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Billing_OPDFinal.Billing_Date from Ruby_Jamner123.OPD_Patient_Registration
 inner join Ruby_Jamner123.Patient_Registration on Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID
 inner
                                                                                            join Ruby_Jamner123.Billing_OPDFinal on Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDFinal.OPDID
where  Ruby_Jamner123.Patient_Registration.Patient_ID = @pid and Ruby_Jamner123.Billing_OPDFinal.Total_Balance_Amount = 0 and Ruby_Jamner123.Billing_OPDFinal.Billing_Date between @from and @to", con);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Name"].Index && e.RowIndex >= 0)
            {
                string opd = dataGridView1.Rows[e.RowIndex].Cells["PatientOPDId"].Value.ToString();
                DateTime bill_date = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Billing_Date"].Value);
                string Billdate = bill_date.ToString("dd-MM-yyyy_hh-mm-ss");
                string fileName = opd + "_" + Billdate;
                string pdfPath = @"D:\HMS_OLD_BILLS\OPD_BillS_FILES\" + opd + "_" + Billdate + ".pdf";

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

        private void Old_OPD_Reports_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
