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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace Ruby_Hospital
{
    public partial class Lab_Bill : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GLobal_Connection"].ConnectionString);
        public int IPD;
        public int PID;
        public int OPDID;
        public string type;
        public string Patient_ID;
        public string IPD_with_str;
        public string OPD_with_str;
        public string Section;
        public DateTime date;
        public decimal Public_Received;
        public Lab_Bill()
        {
            InitializeComponent();
        }
        public Lab_Bill(int ipdid,int pid,string ipd,string sec)
        {
            InitializeComponent();
            IPD = ipdid;
            PID = pid;
            type = "IPD";
            Section = sec;
        }
        public Lab_Bill(int opdid, int pid,string sec)
        {
            InitializeComponent();
            OPDID = opdid;
            PID = pid;
            type = "Only test";
            Section = sec;
        }
        private void Lab_Bill_Load(object sender, EventArgs e)
        {
            textBox1.Text = Dashbord.Ename;

            if (Section == "LAB")
            {
                if (type == "IPD")
                {
                    showIPDdetails();
                    displayIPDTestCharge();
                }
                else
                {
                    showOnlyTestDetails();
                    displayOnlyTestCharge();
                }
                showupdateddetails();
            }
            else
            {
                if (type == "IPD")
                {
                    showIPDdetails();
                    displayIPDRadiologyCharges();
                }
                else
                {
                    showOnlyTestDetails();
                    displayOnlyTestRadiologyCharges();
                }
                showupdateddetails();
            }
            
        }

        private void pailab_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ballab_TextChanged(object sender, EventArgs e)
        {

        }

        public void showIPDdetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT  Ruby_Jamner123.Patient_Registration.Patient_Id,Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number,Ruby_Jamner123.IPD_Registration.IPD_ID,
                         Ruby_Jamner123.Patient_Registration.Doctors_Name
                        FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
                         where Ruby_Jamner123.IPD_Registration.IPDID = @ipdid", con);
            cmd.Parameters.AddWithValue("@ipdid",IPD);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                dataGridView1.DataSource = dt;
                Patient_ID = dt.Rows[0]["Patient_Id"].ToString();
                IPD_with_str = dt.Rows[0]["IPD_ID"].ToString();
            }
        }


        public void showOnlyTestDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select  Ruby_Jamner123.Patient_Registration.Patient_Id,Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number,
Ruby_Jamner123.OPD_Patient_Registration.patientopdidwithsr from Ruby_Jamner123.OPD_Patient_Registration inner join
Ruby_Jamner123.Patient_Registration on Ruby_Jamner123.Patient_Registration.PID = OPD_Patient_Registration.patientid where OPD_Patient_Registration.PatientOPDId = @opdid", con);
            cmd.Parameters.AddWithValue("@opdid", OPDID);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                dataGridView1.DataSource = dt;
                Patient_ID = dt.Rows[0]["Patient_Id"].ToString();
                OPD_with_str = dt.Rows[0]["patientopdidwithsr"].ToString();
            }
        }

        public void displayIPDTestCharge()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select TotalLabAmount from Billing_IPDTotal_LabAmount where IPDID = @ipdid", con);
            cmd.Parameters.AddWithValue("@ipdid", IPD);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtlabBilling.Text = sdr["TotalLabAmount"].ToString();
            }
            con.Close();
        }

        public void displayOnlyTestCharge()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select OnlyTest_LabTAmount from Billing_OnlyLabTatolAmount where OPDID = @opdid", con);
            cmd.Parameters.AddWithValue("@opdid", OPDID);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtlabBilling.Text = sdr["OnlyTest_LabTAmount"].ToString();
            }
            con.Close();
        }

        public void displayIPDRadiologyCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select TotalRadiologyAmount from Billing_IPDTotal_RadiologyA where IPDID = @ipdid", con);
            cmd.Parameters.AddWithValue("@ipdid", IPD);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtlabBilling.Text = sdr["TotalRadiologyAmount"].ToString();
            }
            con.Close();
        }

        public void displayOnlyTestRadiologyCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select OnlyRTotalAmount from Billing_OnlyRTAmount where OPDID = @opdid", con);
            cmd.Parameters.AddWithValue("@opdid", OPDID);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtlabBilling.Text = sdr["OnlyRTotalAmount"].ToString();
            }
            con.Close();
        }

        private void disLab_TextChanged(object sender, EventArgs e)
        {
            if (disLab.Text == "")
            {
                disLab.Text = "0";
            }
            else
            {
                if (Section == "LAB")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"select Bill_AfterDiscount,Paid,Balance from PatientTestBilling_IPDnOnlyTest where IPDID=@ipdid and OPDID=@opdid", con);
                    if (type == "IPD")
                    {
                        cmd.Parameters.AddWithValue("@ipdid", IPD);
                        cmd.Parameters.AddWithValue("@opdid", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ipdid", 0);
                        cmd.Parameters.AddWithValue("@opdid", OPDID);
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        payLabA.Text = (Convert.ToDecimal(rdr["Bill_AfterDiscount"]) - Convert.ToDecimal(disLab.Text)).ToString();
                        TotalA.Text = (Convert.ToDecimal(rdr["Bill_AfterDiscount"]) - Convert.ToDecimal(disLab.Text)).ToString();
                        //payLabA.Text = rdr["Bill_AfterDiscount"].ToString();
                        //TotalP.Text = rdr["Paid"].ToString();
                        //ballab.Text = rdr["Balance"].ToString();
                        TotalB.Text = rdr["Balance"].ToString();
                    }
                    else
                    {
                        payLabA.Text = (Convert.ToDecimal(txtlabBilling.Text) - Convert.ToDecimal(disLab.Text)).ToString();
                        TotalA.Text = txtlabBilling.Text;
                        TotalB.Text = txtlabBilling.Text;
                        //ballab.Text = txtlabBilling.Text;
                    }
                    rdr.Close();
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"select Bill_AfterDiscount,Paid,Balance from PatientRadiologyBilling_IPDnOnlyTest where IPDID=@ipdid and OPDID=@opdid", con);
                    if (type == "IPD")
                    {
                        cmd.Parameters.AddWithValue("@ipdid", IPD);
                        cmd.Parameters.AddWithValue("@opdid", 0);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ipdid", 0);
                        cmd.Parameters.AddWithValue("@opdid", OPDID);
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        payLabA.Text = (Convert.ToDecimal(rdr["Bill_AfterDiscount"]) - Convert.ToDecimal(disLab.Text)).ToString();
                        TotalA.Text = (Convert.ToDecimal(rdr["Bill_AfterDiscount"]) - Convert.ToDecimal(disLab.Text)).ToString();
                        //payLabA.Text = rdr["Bill_AfterDiscount"].ToString();
                        //TotalP.Text = rdr["Paid"].ToString();
                        //ballab.Text = rdr["Balance"].ToString();
                        TotalB.Text = rdr["Balance"].ToString();
                    }
                    else
                    {
                        payLabA.Text = (Convert.ToDecimal(txtlabBilling.Text) - Convert.ToDecimal(disLab.Text)).ToString();
                        TotalA.Text = txtlabBilling.Text;
                        TotalB.Text = txtlabBilling.Text;
                        //ballab.Text = txtlabBilling.Text;
                    }
                    rdr.Close();
                }

            }
        }

        private void disLab_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a digit, cancel the key press
                e.Handled = true;
            }
        }

        private void disLab_Click(object sender, EventArgs e)
        {
            if (disLab.Text == "0")
            {
                disLab.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text !="Select Payment Mode")
                {

                    if (Section == "LAB")
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"select * from Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest where IPDID = @ipdid and OPDID = @opdid", con);
                        if (type == "IPD")
                        {
                            cmd.Parameters.AddWithValue("@ipdid", IPD);
                            cmd.Parameters.AddWithValue("@opdid", 0);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ipdid", 0);
                            cmd.Parameters.AddWithValue("@opdid", OPDID);
                        }

                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            rdr.Read();
                            decimal oldDiscount = (decimal)rdr["Discount"];
                            updateData(oldDiscount);
                        }
                        else
                        {
                            insertData();
                        }
                        rdr.Close();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"select * from Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest where IPDID = @ipdid and OPDID = @opdid", con);
                        if (type == "IPD")
                        {
                            cmd.Parameters.AddWithValue("@ipdid", IPD);
                            cmd.Parameters.AddWithValue("@opdid", 0);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ipdid", 0);
                            cmd.Parameters.AddWithValue("@opdid", OPDID);
                        }

                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            rdr.Read();
                            decimal oldDiscount = (decimal)rdr["Discount"];
                            updateData(oldDiscount);
                        }
                        else
                        {
                            insertData();
                        }
                        rdr.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please select Payment mode");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void global_OPDAmoun_data()
        {
            Billing_OPD_BalanceFetcing();
            decimal z = Convert.ToDecimal(pailab.Text);
            decimal x = Public_Received + z;

            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Update OnlyTest_PatientDetails set Date=@Date,Received=@Received,Pending=@Pending,Update_flag=@Update_flag where  OPDID=@OPDID", connection);

            cmd.Parameters.AddWithValue("@OPDID", OPDID);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Received", x);
            cmd.Parameters.AddWithValue("@Pending", ballab.Text);
            cmd.Parameters.AddWithValue("@Update_flag", 0);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Record Added");
            connection.Close();
        }
        public void global_OPDAmounIPD_data()
        {
            Billing_OPD_BalanceFetcing();
            decimal z = Convert.ToDecimal(pailab.Text);
            decimal x = Public_Received + z;

            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Update OnlyTest_PatientDetails set Date=@Date,Received=@Received,Pending=@Pending,Update_flag=@Update_flag where  OPDID=@OPDID", connection);

            cmd.Parameters.AddWithValue("@OPDID", IPD);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Received", x);
            cmd.Parameters.AddWithValue("@Pending", ballab.Text);
            cmd.Parameters.AddWithValue("@Update_flag", 0);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Record Added");
            connection.Close();
        }
        public void Billing_OPD_BalanceFetcing()
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From OnlyTest_PatientDetails where OPDID=@PatientOPD_Id_Public", connection);
            cmd.Parameters.AddWithValue("@PatientOPD_Id_Public", OPDID);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Public_Received = Convert.ToDecimal(dt.Rows[0]["Received"]);
                //Public_Pending= Convert.ToDecimal(dt.Rows[0]["Pending"]);

            }
            connection.Close();
        }

        public void insertData()
        {
            if (Section == "LAB")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"insert into Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest (Patient_ID,IPDID,IPDIDwithStr,OPDID,OPDIDwithStr,Bill_Amount,Discount,Bill_AfterDiscount,Paid,Balance,ReceiverName,PaymentMode,Remark,Date)
                values(@patient_id,@ipdid,@ipdwithstr,@opdid,@opdwithstr,@bill_amt,@discount,@bill_afterdiscount,@paid,@balance,@receivername,@paymentmode,@remark,@Date)", con);
                cmd.Parameters.AddWithValue("@patient_id", Patient_ID);
                if (type == "IPD")
                {
                    cmd.Parameters.AddWithValue("@ipdid", IPD);
                    cmd.Parameters.AddWithValue("@ipdwithstr", IPD_with_str);
                    cmd.Parameters.AddWithValue("@opdid", 0);
                    cmd.Parameters.AddWithValue("@opdwithstr", " ");
                    global_OPDAmounIPD_data();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ipdid", 0);
                    cmd.Parameters.AddWithValue("@ipdwithstr", " ");
                    cmd.Parameters.AddWithValue("@opdid", OPDID);
                    cmd.Parameters.AddWithValue("@opdwithstr", OPD_with_str);
                    global_OPDAmoun_data();
                }

                cmd.Parameters.AddWithValue("@bill_amt", txtlabBilling.Text);
                cmd.Parameters.AddWithValue("@discount", disLab.Text);
                cmd.Parameters.AddWithValue("@bill_afterdiscount", payLabA.Text);
                cmd.Parameters.AddWithValue("@paid", pailab.Text);
                ballab.Text = (Convert.ToDecimal(payLabA.Text) - Convert.ToDecimal(pailab.Text)).ToString();
                cmd.Parameters.AddWithValue("@balance", ballab.Text);
                cmd.Parameters.AddWithValue("@receivername", textBox1.Text);
                cmd.Parameters.AddWithValue("@paymentmode", comboBox1.Text);
                cmd.Parameters.AddWithValue("@remark", textBox2.Text);
                date = DateTime.Now;
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Billing Details Stored...");



                if (type=="IPD")
                {
                    Report.rptIPDTestDetailBilling cryRptNew = new Report.rptIPDTestDetailBilling();


                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("OPDLab_IPD", pailab.Text);

                    cryRptNew.SetParameterValue("IPDID", IPD);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();
                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\IPD_LAB_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\IPD_LAB_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\IPD_LAB_Bills\" + IPD + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion

                }
                else
                {
                    Report.rptOnlyTestDetailBilling cryRptNew = new Report.rptOnlyTestDetailBilling();


                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("OPDLab_Onlytest", pailab.Text);
                   
                    cryRptNew.SetParameterValue("OPDID", OPDID);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();
                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\ONLY_OPD_LAB_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\ONLY_OPD_LAB_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\ONLY_OPD_LAB_Bills\" + OPDID + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion
                }
                disLab.Clear();
                payLabA.Clear();
                pailab.Clear();
                textBox1.Clear();
                textBox2.Clear();
                showupdateddetails();
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"insert into Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest (Patient_ID,IPDID,IPDIDwithStr,OPDID,OPDIDwithStr,Bill_Amount,Discount,Bill_AfterDiscount,Paid,Balance,ReceiverName,PaymentMode,Remark,Date)
                values(@patient_id,@ipdid,@ipdwithstr,@opdid,@opdwithstr,@bill_amt,@discount,@bill_afterdiscount,@paid,@balance,@receivername,@paymentmode,@remark,@Date)", con);
                cmd.Parameters.AddWithValue("@patient_id", Patient_ID);
                if (type == "IPD")
                {
                    cmd.Parameters.AddWithValue("@ipdid", IPD);
                    cmd.Parameters.AddWithValue("@ipdwithstr", IPD_with_str);
                    cmd.Parameters.AddWithValue("@opdid", 0);
                    cmd.Parameters.AddWithValue("@opdwithstr", " ");
                    global_OPDAmounIPD_data();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ipdid", 0);
                    cmd.Parameters.AddWithValue("@ipdwithstr", " ");
                    cmd.Parameters.AddWithValue("@opdid", OPDID);
                    cmd.Parameters.AddWithValue("@opdwithstr", OPD_with_str);
                    global_OPDAmoun_data();
                }
                cmd.Parameters.AddWithValue("@bill_amt", txtlabBilling.Text);
                cmd.Parameters.AddWithValue("@discount", disLab.Text);
                cmd.Parameters.AddWithValue("@bill_afterdiscount", payLabA.Text);
                cmd.Parameters.AddWithValue("@paid", pailab.Text);
                ballab.Text = (Convert.ToDecimal(payLabA.Text) - Convert.ToDecimal(pailab.Text)).ToString();
                cmd.Parameters.AddWithValue("@balance", ballab.Text);
                cmd.Parameters.AddWithValue("@receivername", textBox1.Text);
                cmd.Parameters.AddWithValue("@paymentmode", comboBox1.Text);
                cmd.Parameters.AddWithValue("@remark", textBox2.Text);
                date = DateTime.Now;
                cmd.Parameters.AddWithValue("@Date",date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Billing Details Stored...");
                if (type == "IPD")
                {
                    Report.rptIPDRadiologyDetailBilling cryRptNew = new Report.rptIPDRadiologyDetailBilling();                   
                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("IPDPaidamt", pailab.Text);

                    cryRptNew.SetParameterValue("IPDID", IPD);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();
                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\IPD_Radiology_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\IPD_Radiology_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\IPD_Radiology_Bills\" + IPD + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion
                }
                else
                {
                    Report.rptOnlyRadiologyDetailBilling cryRptNew = new Report.rptOnlyRadiologyDetailBilling();
                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("OPDLab_Onlytest", pailab.Text);

                    cryRptNew.SetParameterValue("OPDID", OPDID);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();
                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\OPD_Radiology_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\OPD_Radiology_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\OPD_Radiology_Bills\" + OPDID + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion
                }
                disLab.Clear();
                payLabA.Clear();
                pailab.Clear();
                textBox1.Clear();
                textBox2.Clear();
                showupdateddetails();
            }
            
        }

        public void updateData(decimal olddiscount)
        {
            if (Section == "LAB")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"update Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest set Bill_Amount = @billamt,
Discount = @discount,
Bill_AfterDiscount = @billafterdisc,
Paid = @paid,
Balance = @balance,
ReceiverName = @receiverName,
PaymentMode = @mode,
Remark = @remark,
Date = @Date
where IPDID = @ipdid and OPDID = @opdid", con);
                if (type == "IPD")
                {
                    cmd.Parameters.AddWithValue("@ipdid", IPD);
                    cmd.Parameters.AddWithValue("@opdid", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ipdid", 0);
                    cmd.Parameters.AddWithValue("@opdid", OPDID);
                }
                cmd.Parameters.AddWithValue("@billamt", txtlabBilling.Text);

                decimal totalDiscount = Convert.ToDecimal(disLab.Text) + olddiscount;
                cmd.Parameters.AddWithValue("@discount", totalDiscount);
                cmd.Parameters.AddWithValue("@billafterdisc", payLabA.Text);
                decimal paid = Convert.ToDecimal(pailab.Text) + Convert.ToDecimal(TotalP.Text);
                cmd.Parameters.AddWithValue("@paid", paid);
                ballab.Text = (Convert.ToDecimal(payLabA.Text) - paid).ToString();
                cmd.Parameters.AddWithValue("@balance", ballab.Text);
                cmd.Parameters.AddWithValue("@receiverName", textBox1.Text);
                cmd.Parameters.AddWithValue("@mode", comboBox1.Text);
                cmd.Parameters.AddWithValue("@remark", textBox2.Text);
                date = DateTime.Now;
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated successfully !");
                if (type == "IPD")
                {
                    Report.rptIPDTestDetailBilling cryRptNew = new Report.rptIPDTestDetailBilling();


                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("OPDLab_IPD", pailab.Text);

                    cryRptNew.SetParameterValue("IPDID", IPD);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();
                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\IPD_LAB_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\IPD_LAB_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\IPD_LAB_Bills\" + IPD + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion
                }
                else
                {
                    Report.rptOnlyTestDetailBilling cryRptNew = new Report.rptOnlyTestDetailBilling();


                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("OPDLab_Onlytest", pailab.Text);

                    cryRptNew.SetParameterValue("OPDID", OPDID);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();
                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\ONLY_OPD_LAB_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\ONLY_OPD_LAB_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\ONLY_OPD_LAB_Bills\" + OPDID + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion
                }
                disLab.Clear();
                payLabA.Clear();
                pailab.Clear();
                textBox1.Clear();
                textBox2.Clear();
                showupdateddetails();
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"update Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest set Bill_Amount = @billamt,
Discount = @discount,
Bill_AfterDiscount = @billafterdisc,
Paid = @paid,
Balance = @balance,
ReceiverName = @receiverName,
PaymentMode = @mode,
Remark = @remark,
Date = @Date
where IPDID = @ipdid and OPDID = @opdid", con);
                if (type == "IPD")
                {
                    cmd.Parameters.AddWithValue("@ipdid", IPD);
                    cmd.Parameters.AddWithValue("@opdid", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ipdid", 0);
                    cmd.Parameters.AddWithValue("@opdid", OPDID);
                }
                cmd.Parameters.AddWithValue("@billamt", txtlabBilling.Text);
                decimal totalDiscount = olddiscount + Convert.ToDecimal(disLab.Text);
                cmd.Parameters.AddWithValue("@discount", totalDiscount);
                cmd.Parameters.AddWithValue("@billafterdisc", payLabA.Text);
                decimal paid = Convert.ToDecimal(pailab.Text) + Convert.ToDecimal(TotalP.Text);
                cmd.Parameters.AddWithValue("@paid", paid);
                ballab.Text = (Convert.ToDecimal(payLabA.Text) - paid).ToString();
                cmd.Parameters.AddWithValue("@balance", ballab.Text);
                cmd.Parameters.AddWithValue("@receiverName", textBox1.Text);
                cmd.Parameters.AddWithValue("@mode", comboBox1.Text);
                cmd.Parameters.AddWithValue("@remark", textBox2.Text);
                date = DateTime.Now;
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated successfully !");
                if (type == "IPD")
                {
                    Report.rptIPDRadiologyDetailBilling cryRptNew = new Report.rptIPDRadiologyDetailBilling();


                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("IPDPaidamt", pailab.Text);

                    cryRptNew.SetParameterValue("IPDID", IPD);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();

                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\IPD_Radiology_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\IPD_Radiology_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\IPD_Radiology_Bills\" + IPD + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion
                }
                else
                {
                    Report.rptOnlyRadiologyDetailBilling cryRptNew = new Report.rptOnlyRadiologyDetailBilling();


                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cryRptNew.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }


                    cryRptNew.SetParameterValue("OPDLab_Onlytest", pailab.Text);

                    cryRptNew.SetParameterValue("OPDID", OPDID);
                    cryRptNew.SetParameterValue("LoginEmp", textBox1.Text);
                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cryRptNew;
                    obj.Refresh();
                    obj.Show();

                    this.Close();

                    #region Export to PDF in Computer Drive
                    #region new installation

                    //    //string path = @"" + Properties.Settings.Default.OldBillsPath;//\\\\COMP-PC\SQLEXPRESS\\D\SSH_OLD_BILLS
                    string path = @"" + System.Configuration.ConfigurationSettings.AppSettings["OldBillsPath"].ToString();

                    //    //MessageBox.Show(@"\\"+path);
                    if (!System.IO.Directory.Exists(@path))
                    {
                        //step 1 : create on D
                        //step 2 : share it
                        System.IO.Directory.CreateDirectory(@path);
                    }

                    if (!System.IO.Directory.Exists(@path + @"\OPD_Radiology_Bills"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\OPD_Radiology_Bills");
                    }
                    DateTime datetime = date;
                    string formattedDate = datetime.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\OPD_Radiology_Bills\" + OPDID + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion
                }
                disLab.Clear();
                payLabA.Clear();
                pailab.Clear();
                textBox1.Clear();
                textBox2.Clear();
                showupdateddetails();
            }
            
        }

        public void showupdateddetails()
        {
            if (Section == "LAB")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"select Bill_AfterDiscount,Paid,Balance from PatientTestBilling_IPDnOnlyTest where IPDID=@ipdid and OPDID=@opdid", con);
                if (type == "IPD")
                {
                    cmd.Parameters.AddWithValue("@ipdid", IPD);
                    cmd.Parameters.AddWithValue("@opdid", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ipdid", 0);
                    cmd.Parameters.AddWithValue("@opdid", OPDID);
                }
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    TotalA.Text = rdr["Bill_AfterDiscount"].ToString();
                    payLabA.Text = rdr["Bill_AfterDiscount"].ToString();
                    TotalP.Text = rdr["Paid"].ToString();
                    ballab.Text = rdr["Balance"].ToString();
                    TotalB.Text = rdr["Balance"].ToString();
                }
                else
                {
                    payLabA.Text = txtlabBilling.Text;
                    TotalA.Text = txtlabBilling.Text;
                    TotalP.Text = "0";
                    TotalB.Text = txtlabBilling.Text;
                    ballab.Text = txtlabBilling.Text;
                }
                rdr.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"select Bill_AfterDiscount,Paid,Balance from PatientRadiologyBilling_IPDnOnlyTest where IPDID=@ipdid and OPDID=@opdid", con);
                if (type == "IPD")
                {
                    cmd.Parameters.AddWithValue("@ipdid", IPD);
                    cmd.Parameters.AddWithValue("@opdid", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ipdid", 0);
                    cmd.Parameters.AddWithValue("@opdid", OPDID);
                }
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    TotalA.Text = rdr["Bill_AfterDiscount"].ToString();
                    payLabA.Text = rdr["Bill_AfterDiscount"].ToString();
                    TotalP.Text = rdr["Paid"].ToString();
                    ballab.Text = rdr["Balance"].ToString();
                    TotalB.Text = rdr["Balance"].ToString();
                }
                else
                {
                    payLabA.Text = txtlabBilling.Text;
                    TotalA.Text = txtlabBilling.Text;
                    TotalP.Text = "0";
                    TotalB.Text = txtlabBilling.Text;
                    ballab.Text = txtlabBilling.Text;
                }
                rdr.Close();
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
