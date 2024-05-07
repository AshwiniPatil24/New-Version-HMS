﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using System.IO;

namespace Ruby_Hospital
{
    public partial class OnlyTestLabTest : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GLobal_Connection"].ConnectionString);
        public int a;
        public int Public_LabTestID;
        public int Public_LabTestTypeID;
        public string Public_HospCharge;
        public int AddLab;
        public int Public_ID;
        public decimal OTLabTotalAmount;
        public decimal Public_LabCharges;
        public int Labsave;
        public decimal TotalLab;
        public decimal Public_BillAmt;
        public decimal Public_Received;

        public OnlyTestLabTest()
        {
            InitializeComponent();
        }
        public OnlyTestLabTest(int OpdTestID)
        {
            InitializeComponent();
            a = OpdTestID;

        }

        public void showPatientDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT        Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, 
                         Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.Patient_Registration.Referred_By, Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId, 
                         Ruby_Jamner123.OPD_Patient_Registration.PatientId
FROM            Ruby_Jamner123.OPD_Patient_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID
WHERE        (Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId=@OPDID)", con);
            cmd.Parameters.AddWithValue("@OPDID ", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.DataSource = o;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                dataGridView1.Columns["PatientOPDIdWithSr"].HeaderText = "OPD_ID";
                dataGridView1.Columns["PatientOPDId"].Visible = false;
            }
            con.Close();

        }
        public void labtype()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from Master_LabTestType", con);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "LabTestType_Name";
                comboBox1.ValueMember = "LabTestTypeID";
            }
            con.Close();

        }
        public void test()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * from Master_LabTest WHERE  (LabTestTypeID=@LabTestTypeID)", con);
            cmd.Parameters.AddWithValue("@LabTestTypeID", comboBox1.SelectedIndex);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "LabTestName";
                Public_LabTestID = Convert.ToInt32(dt.Rows[0]["LabTestID"]);
                Public_LabTestTypeID = Convert.ToInt32(dt.Rows[0]["LabTestTypeID"]);
                Public_HospCharge = Convert.ToString(dt.Rows[0]["HospCharge"]);
               
            }
            con.Close();
        }
        public void Save()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into AssignOnlyTest_Lab (OPDID,LabTestTypeID,labTestID,LabTest,Charges,TestDate) Values(@OPDID,@LabTestTypeID,@labTestID,@LabTest,@Charges,@TestDate)", con);
                cmd.Parameters.AddWithValue("@OPDID", a);
                cmd.Parameters.AddWithValue("@LabTestTypeID", Public_LabTestTypeID);
                cmd.Parameters.AddWithValue("@labTestID", Public_LabTestID);
                cmd.Parameters.AddWithValue("@LabTest", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Charges", Public_HospCharge);
                cmd.Parameters.AddWithValue("@TestDate", dtpLabtestDate.Text);          
                cmd.ExecuteNonQuery();
                OTLabTotalAmount = Convert.ToDecimal(lblabTotalAmount.Text) + Convert.ToDecimal(Public_HospCharge.ToString());
                if (OTLabTotalAmount >= 0)
                {
                    lblabTotalAmount.Text = OTLabTotalAmount.ToString();
                }
                con.Close();
                show_ADD();
                AddLab = 1;     
                button7.Enabled = true;
                
                button7.BackColor = Color.DarkGreen;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void show_ADD()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From AssignOnlyTest_Lab where OPDID=@a", con);
            cmd.Parameters.AddWithValue(@"a", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            
            dataGridView2.DataSource = dtPublic;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["OPDID"].Visible = false;
            dataGridView2.Columns["LabTestTypeID"].Visible = false;
            dataGridView2.Columns["labTestID"].Visible = false;
            dataGridView2.Columns["Charges"].Visible = false;
            dataGridView2.Columns["TestDate"].Visible = false;
            dataGridView2.Columns["DleStatus"].Visible = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            con.Close();
            button3.Visible = true;
        }

        public void Save_AmountOnlyLab()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Billing_OnlyLabTatolAmount (OPDID,OnlyTest_LabTAmount) Values(@OPDID,@OnlyTest_LabTAmount)", con);
            cmd.Parameters.AddWithValue("@OPDID", a);
            cmd.Parameters.AddWithValue("@OnlyTest_LabTAmount", lblabTotalAmount.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Update_AmountOnlyLab()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update Billing_OnlyLabTatolAmount set OnlyTest_LabTAmount=@OnlyTest_LabTAmount where OPDID=@a", con);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@OnlyTest_LabTAmount", lblabTotalAmount.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void FetchingOnlyAmount_LabTest()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_OnlyLabTatolAmount where OPDID=@a", con);
            cmd.Parameters.AddWithValue(@"a", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dtPublic = new DataTable();
            adt.Fill(dtPublic);
            if (dtPublic.Rows.Count > 0)
            {
                TotalLab = Convert.ToDecimal(dtPublic.Rows[0]["OnlyTest_LabTAmount"]);
            }
            con.Close();
        }
        private void OnlyTestLabTest_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            showPatientDetails();
            show_ADD();
            labtype();
            test();
            lblabTotalAmount.Text = TotalLab.ToString();
        }

        private void cmblabtest_TextChanged(object sender, EventArgs e)
        {
            test();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Labsave = 0;

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddLab == 1)
                {
                   
                    Labsave = 1;
                    MessageBox.Show("Record Added Successfully");
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_OnlyLabTatolAmount where OPDID=@a", con);
                    cmd.Parameters.AddWithValue(@"a", a);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        Update_AmountOnlyLab();
                        button3.Enabled = false;
                        button3.BackColor = Color.Silver;
                    }
                    else
                    {
                        Save_AmountOnlyLab();
                        button3.Enabled = false;
                        button3.BackColor = Color.Silver;
                    }
                    con.Close();
                    button1.Visible = true;
                }
                else
                {
                    MessageBox.Show("First Add Test");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView2.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("Delete") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    Public_ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);
                    Public_LabCharges = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Charges"].Value);
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Delete from AssignOnlyTest_Lab where ID=@Public_ID", con);
                    cmd.Parameters.AddWithValue("@Public_ID", Public_ID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Deleted Successfully..");
                    if (Labsave == 1)
                    {
                        Labsave = 0;
                        FetchingOnlyAmount_LabTest();
                        lblabTotalAmount.Text = (TotalLab - Public_LabCharges).ToString();

                    }
                    else
                    {
                        lblabTotalAmount.Text = (Convert.ToDecimal(lblabTotalAmount.Text) - Public_LabCharges).ToString();
                    }
                    Update_AmountOnlyLab();
                    show_ADD();

                    //OnlyTestLabTest_Load(sender, e);
                    

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Report.Onlytestlab cryRptLab = new Report.Onlytestlab();

                TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                Tables CrTablesNew;
                crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                CrTablesNew = cryRptLab.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                {
                    crtableLogoninfoNew = CrTable.LogOnInfo;
                    crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                    CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                }

                cryRptLab.SetParameterValue("OPDID", a);
                 
                ReportViewerForOnlylabtest objLab = new ReportViewerForOnlylabtest();
                objLab.crystalReportViewer1.ReportSource = cryRptLab;
                objLab.Refresh();
                objLab.Show();
                ReportDocument reportDocument = objLab.crystalReportViewer1.ReportSource as ReportDocument;
                if (reportDocument != null)
                {
                    // Export the report to PDF
                    ExportOptions exportOptions = new ExportOptions();
                    exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat; // PDF format

                    // Set the path where you want to save the report
                    string savePath = @"D:\HMS_OLD_BILLS\ONLY_TEST_LABTEST\"; // Change this to your desired folder
                    string opdId = a.ToString();
                    string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                    string fileName = $"{opdId}_{todayDate}.pdf";

                    // Combine the path and file name
                    string filePath = Path.Combine(savePath, fileName);

                    DiskFileDestinationOptions diskOptions = new DiskFileDestinationOptions();
                    diskOptions.DiskFileName = filePath;

                    exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    exportOptions.ExportDestinationOptions = diskOptions;

                    // Export the report
                    reportDocument.Export(exportOptions);

                    Console.WriteLine("Report exported successfully to: " + filePath);
                }
                else
                {
                    Console.WriteLine("Error: No report loaded in the CrystalReportViewer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        public void Billing_OPD_BalanceFetcing()
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From OnlyTest_PatientDetails where OPDID=@OPDID", connection);
            cmd.Parameters.AddWithValue("@OPDID", a);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Public_BillAmt = Convert.ToDecimal(dt.Rows[0]["Bill_Amount"]);
                Public_Received = Convert.ToDecimal(dt.Rows[0]["Received"]);

            }
            connection.Close();
        }
        public void Global_update_LabCharges()
        {
            Billing_OPD_BalanceFetcing();
            decimal TotalCharges = Convert.ToDecimal(lblabTotalAmount.Text);
            decimal GlobalTotal = TotalCharges + Public_BillAmt;
            decimal Pending = GlobalTotal - Public_Received;

            connection.Open();
            SqlCommand cmd = new SqlCommand(@"update OnlyTest_PatientDetails set Lab_Total=@Lab_Total,Bill_Amount=@Bill_Amount,Received=@Received,Pending=@Pending where OPDID=@OPDID", connection);

            cmd.Parameters.AddWithValue("@OPDID", a);
            cmd.Parameters.AddWithValue("@Lab_Total", lblabTotalAmount.Text);
            cmd.Parameters.AddWithValue("@Bill_Amount", GlobalTotal);
            cmd.Parameters.AddWithValue("@Received", Public_Received);
            cmd.Parameters.AddWithValue("@Pending", Pending);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddLab == 1)
                {

                    Labsave = 1;
                    MessageBox.Show("Record Added Successfully");
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"Select * From Billing_OnlyLabTatolAmount where OPDID=@a", con);
                    cmd.Parameters.AddWithValue(@"a", a);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dtPublic = new DataTable();
                    adt.Fill(dtPublic);
                    if (dtPublic.Rows.Count > 0)
                    {
                        Update_AmountOnlyLab();
                        button7.Enabled = false;
                        button7.BackColor = Color.Silver;
                        Global_update_LabCharges();
                    }
                    else
                    {
                        Save_AmountOnlyLab();
                        button7.Enabled = false;
                        button7.BackColor = Color.Silver;
                        Global_update_LabCharges();
                    }
                    con.Close();
                    button1.Visible = true;
                }
                else
                {
                    MessageBox.Show("First Add Test");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
