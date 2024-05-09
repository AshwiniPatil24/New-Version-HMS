using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class OPD_Billing_Details : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GLobal_Connection"].ConnectionString);
        public DateTime visitDate;
        public decimal opd_bill;
        public decimal red_bill;
        public decimal lab_bill;
        public int A;
        public decimal Bill=0;
        public decimal Dis_OPD = 0;
        public decimal DisOPDRadio = 0;
        public decimal DisOPDLAb = 0;
        public decimal payamount = 0;
        public decimal paid = 0;
        public decimal bal = 0;
        public decimal TotalAmount = 0;
        public decimal TotlPaid = 0;
        public decimal TotalBalence = 0;
        public decimal Public_OPDBal = 0;
        public decimal Public_OPDRadioBal = 0;
        public decimal Public_OPDLabBal = 0;
        public decimal Public_OPDPaid = 0;
        public decimal Public_OPDRadioPaid = 0;
        public decimal Public_OPDLabPaid = 0;
        public decimal Public_OPDAfterDisOPDAmount = 0;
        public decimal Public_OPDAfterDisOPDRadioAmount = 0;
        public decimal Public_OPDAfterDisOPDLabAmount = 0;
        public decimal Public_OPDDis = 0;
        public decimal Public_OPDRadioDis = 0;
        public decimal Public_OPDLabDis = 0;

        public decimal UpadatePaid = 0;
        public decimal UpdatedRadioPaid = 0;
        public decimal UpdatedLabPaid = 0;

        public DateTime MainDate;
        public decimal Public_Received;

        public OPD_Billing_Details()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }
        public OPD_Billing_Details(int ID)
        {
            InitializeComponent();
            A = ID;
        }
        public void OPDCal()
        {
            Bill = Convert.ToDecimal(txtopdBillAmount.Text);
            Dis_OPD = Convert.ToDecimal(disOpd.Text)+Public_OPDDis;
            payamount = Bill - Dis_OPD;
            payopdA.Text = payamount.ToString();
         
            paid = Convert.ToDecimal(paidopd.Text);
            bal = payamount - paid- Public_OPDPaid;
            balopd.Text = bal.ToString();
             UpadatePaid = Public_OPDPaid + paid;
        }
        public void RadioCal()
        {
            Bill = Convert.ToDecimal(txtradiologyBilling.Text);
            DisOPDRadio = Convert.ToDecimal(disradiology.Text)+ Public_OPDRadioDis;
            payamount = Bill - DisOPDRadio;
            payradioA.Text = payamount.ToString();
            paid = Convert.ToDecimal(paidradio.Text);
            bal = payamount - paid - Public_OPDRadioPaid;
            balradio.Text = bal.ToString();
            UpdatedRadioPaid = Public_OPDRadioPaid + paid;
        }
        public void LabCal()
        {
            Bill = Convert.ToDecimal(txtlabBilling.Text);
            DisOPDLAb = Convert.ToDecimal(disLab.Text)+ Public_OPDLabDis;
            payamount = Bill - DisOPDLAb;
            payLabA.Text = payamount.ToString();
            paid = Convert.ToDecimal(pailab.Text);
            bal = payamount - paid - Public_OPDLabPaid;
            ballab.Text = bal.ToString();
            UpdatedLabPaid= Public_OPDLabPaid + paid;
        }
        public void Billing_OPD_BalanceFetcing()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDFinal where OPDID=@A", con);
            cmd.Parameters.AddWithValue("@A",A);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
               
                    Public_OPDBal= Convert.ToDecimal(dt.Rows[0]["OPD_Balance"]);
                    Public_OPDRadioBal = Convert.ToDecimal(dt.Rows[0]["OPD_RadiologyBalance"]);
                    Public_OPDLabBal = Convert.ToDecimal(dt.Rows[0]["OPD_LabBalance"]);

                balopd.Text = Public_OPDBal.ToString();
                balradio.Text = Public_OPDRadioBal.ToString();
                ballab.Text = Public_OPDLabBal.ToString();

                TotalB.Text = (Convert.ToDecimal(balopd.Text) + Convert.ToDecimal(balradio.Text) + Convert.ToDecimal(ballab.Text)).ToString();

                Public_OPDPaid = Convert.ToDecimal(dt.Rows[0]["OPD_Paid"]);
                Public_OPDRadioPaid = Convert.ToDecimal(dt.Rows[0]["OPD_RadiologyPaid"]);
                Public_OPDLabPaid = Convert.ToDecimal(dt.Rows[0]["OPD_LabPaid"]);

                // paidopd.Text = Public_OPDPaid.ToString();
                // paidradio.Text = Public_OPDRadioPaid.ToString();
                // pailab.Text = Public_OPDLabPaid.ToString();
                TotalP.Text = (Public_OPDPaid + Public_OPDRadioPaid + Public_OPDLabPaid).ToString();

                 Public_OPDAfterDisOPDAmount = Convert.ToDecimal(dt.Rows[0]["OPD_DisAfterAmount"]);
                Public_OPDAfterDisOPDRadioAmount = Convert.ToDecimal(dt.Rows[0]["OPD_DisAfterRadioligyAmount"]);
                Public_OPDAfterDisOPDLabAmount = Convert.ToDecimal(dt.Rows[0]["OPD_DisAfterLabAmount"]);

                payopdA.Text = Public_OPDAfterDisOPDAmount.ToString();
                payradioA.Text = Public_OPDAfterDisOPDRadioAmount.ToString();
                payLabA.Text = Public_OPDAfterDisOPDLabAmount.ToString();

                Public_OPDDis = Convert.ToDecimal(dt.Rows[0]["OPD_Discount"]);
                Public_OPDRadioDis = Convert.ToDecimal(dt.Rows[0]["OPD_RadiologyDiscount"]);
                Public_OPDLabDis = Convert.ToDecimal(dt.Rows[0]["OPD_LabDiscount"]);

                

            }
           

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }
        public void opdBill()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        OPDID, OPDProcedureAmount
FROM            Ruby_Jamner123.Billing_OPDProcedure
WHERE        (OPDID = @OPDID)", con);
            cmd.Parameters.AddWithValue("@OPDID",A);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if(dt.Rows.Count>0)
            {
                opd_bill = Convert.ToInt32(dt.Rows[0]["OPDProcedureAmount"]);
                txtopdBillAmount.Text = opd_bill.ToString();
            }
            OPDCal();
        }
        public void radiologyBill()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        OPDID, OPDRadiologyAmount
FROM            Ruby_Jamner123.Billing_OPDRadiologyTAmount
WHERE        (OPDID = @OPDID)", con);
            cmd.Parameters.AddWithValue("@OPDID", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                red_bill = Convert.ToInt32(dt.Rows[0]["OPDRadiologyAmount"]);
                txtradiologyBilling.Text = red_bill.ToString();
            }
            RadioCal();
        }
        public void lab_Bill()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT        OPDID, TotalLabAmount
FROM            Ruby_Jamner123.Billing_OPDTotalALabTest
WHERE        (OPDID = @OPDID)", con);
            cmd.Parameters.AddWithValue("@OPDID", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lab_bill = Convert.ToInt32(dt.Rows[0]["TotalLabAmount"]);
                txtlabBilling.Text = lab_bill.ToString();
            }
            LabCal();
        }
        public void total()
        {
            OPDCal();
            RadioCal();
            LabCal();
            decimal a = Convert.ToDecimal(payLabA.Text);
            decimal b = Convert.ToDecimal(payopdA.Text);
            decimal c = Convert.ToDecimal(payradioA.Text);
            TotalAmount = a + b + c;
            TotalA.Text = TotalAmount.ToString();

            // decimal p = Convert.ToDecimal(paidopd.Text);
            //decimal q = Convert.ToDecimal(paidradio.Text);
            //decimal r = Convert.ToDecimal(pailab.Text);
            decimal p = UpadatePaid;
            decimal q = UpdatedRadioPaid;
            decimal r = UpdatedLabPaid;
            TotlPaid = p + q + r;
            TotalP.Text = TotlPaid.ToString();

            decimal x = Convert.ToDecimal(balopd.Text);
            decimal y = Convert.ToDecimal(balradio.Text);
            decimal z = Convert.ToDecimal(ballab.Text);
            TotalBalence = x + y + z;
            TotalB.Text = TotalBalence.ToString();
        }
        public void showinfo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT        Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId,Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Purpose, 
                         Ruby_Jamner123.Billing_OPDProcedure.OPDProcedureAmount, Ruby_Jamner123.Billing_OPDTotalALabTest.TotalLabAmount, Ruby_Jamner123.Billing_OPDRadiologyTAmount.OPDRadiologyAmount
FROM            Ruby_Jamner123.OPD_Patient_Registration LEFT OUTER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.OPD_Patient_Registration.PatientId = Ruby_Jamner123.Patient_Registration.PID LEFT OUTER JOIN
                         Ruby_Jamner123.Billing_OPDTotalALabTest ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDTotalALabTest.OPDID LEFT OUTER JOIN
                         Ruby_Jamner123.Billing_OPDProcedure ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDProcedure.OPDID LEFT OUTER JOIN
                         Ruby_Jamner123.Billing_OPDRadiologyTAmount ON Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId = Ruby_Jamner123.Billing_OPDRadiologyTAmount.OPDID where (OPD_Patient_Registration.PatientOPDId=@PatientOPDId)", con);
            cmb.Parameters.AddWithValue("@PatientOPDId", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable o = new DataTable();
            adt.Fill(o);
            if (o.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                dataGridView1.DataSource = o;
                dataGridView1.Columns["PatientOPDId"].Visible = false;
                dataGridView1.Columns["PatientOPDIdWithSr"].HeaderText = "Patient OPD ID";
            }
        }
        public void Save()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into Billing_OPDFinal (OPDID,OPD_BillAmount,OPD_Discount,OPD_DisAfterAmount,OPD_Paid,OPD_Balance,OPD_RadiologyBillAmount,OPD_RadiologyDiscount,OPD_DisAfterRadioligyAmount,OPD_RadiologyPaid,OPD_RadiologyBalance,OPD_LabBillAmount,OPD_LabDiscount,OPD_DisAfterLabAmount,OPD_LabPaid,OPD_LabBalance,Total_Billing_Amount,Total_Paid_Amount,Total_Balance_Amount,Receiver_Name,Payment_mode,Remark,Billing_Date)
                                             Values(@OPDID,@OPD_BillAmount,@OPD_Discount,@OPD_DisAfterAmount,@OPD_Paid,@OPD_Balance,@OPD_RadiologyBillAmount,@OPD_RadiologyDiscount,@OPD_DisAfterRadioligyAmount,@OPD_RadiologyPaid,@OPD_RadiologyBalance,@OPD_LabBillAmount,@OPD_LabDiscount,@OPD_DisAfterLabAmount,@OPD_LabPaid,@OPD_LabBalance,@Total_Billing_Amount,@Total_Paid_Amount,@Total_Balance_Amount,@Receiver_Name,@Payment_mode,@Remark,@Billing_Date)", con);
                cmd.Parameters.AddWithValue("@OPDID", A);
                cmd.Parameters.AddWithValue("@OPD_BillAmount", txtopdBillAmount.Text);
                cmd.Parameters.AddWithValue("@OPD_Discount", disOpd.Text);
                cmd.Parameters.AddWithValue("@OPD_DisAfterAmount", payopdA.Text);
                cmd.Parameters.AddWithValue("@OPD_Paid", paidopd.Text);
                cmd.Parameters.AddWithValue("@OPD_Balance", balopd.Text);

                cmd.Parameters.AddWithValue("@OPD_RadiologyBillAmount", txtradiologyBilling.Text);
                cmd.Parameters.AddWithValue("@OPD_RadiologyDiscount", disradiology.Text);
                cmd.Parameters.AddWithValue("@OPD_DisAfterRadioligyAmount", payradioA.Text);
                cmd.Parameters.AddWithValue("@OPD_RadiologyPaid", paidradio.Text);
                cmd.Parameters.AddWithValue("@OPD_RadiologyBalance", balradio.Text);

                cmd.Parameters.AddWithValue("@OPD_LabBillAmount", txtlabBilling.Text);
                cmd.Parameters.AddWithValue("@OPD_LabDiscount", disLab.Text);
                cmd.Parameters.AddWithValue("@OPD_DisAfterLabAmount", payLabA.Text);
                cmd.Parameters.AddWithValue("@OPD_LabPaid", payLabA.Text);
                cmd.Parameters.AddWithValue("@OPD_LabBalance", ballab.Text);

                cmd.Parameters.AddWithValue("@Total_Billing_Amount", TotalA.Text);
                cmd.Parameters.AddWithValue("@Total_Paid_Amount", TotalP.Text);
                cmd.Parameters.AddWithValue("@Total_Balance_Amount", TotalB.Text);

                cmd.Parameters.AddWithValue("@Receiver_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Payment_mode", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Remark", textBox2.Text);
                MainDate = DateTime.Now;
                cmd.Parameters.AddWithValue("@Billing_Date", MainDate);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void UpdateFinalUpdateBill()
        {
            try
            {
                ///OPDCal();
                //RadioCal();
                //LabCal();
                total();

                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Update Billing_OPDFinal set OPD_BillAmount=@OPD_BillAmount,OPD_Discount=@OPD_Discount,OPD_DisAfterAmount=@OPD_DisAfterAmount,OPD_Paid=@OPD_Paid,OPD_Balance=@OPD_Balance,OPD_RadiologyBillAmount=@OPD_RadiologyBillAmount,OPD_RadiologyDiscount=@OPD_RadiologyDiscount,OPD_DisAfterRadioligyAmount=@OPD_DisAfterRadioligyAmount,OPD_RadiologyPaid=@OPD_RadiologyPaid,OPD_RadiologyBalance=@OPD_RadiologyBalance,OPD_LabBillAmount=@OPD_LabBillAmount,OPD_LabDiscount=@OPD_LabDiscount,OPD_DisAfterLabAmount=@OPD_DisAfterLabAmount,OPD_LabPaid=@OPD_LabPaid,OPD_LabBalance=@OPD_LabBalance,Total_Billing_Amount=@Total_Billing_Amount,Total_Paid_Amount=@Total_Paid_Amount,Total_Balance_Amount=@Total_Balance_Amount,Receiver_Name=@Receiver_Name,Payment_mode=@Payment_mode,Remark=@Remark,Billing_Date=@Billing_Date where OPDID=@A ", con);
                cmd.Parameters.AddWithValue("@A", A);
                cmd.Parameters.AddWithValue("@OPD_BillAmount", txtopdBillAmount.Text);
                cmd.Parameters.AddWithValue("@OPD_Discount", Dis_OPD);
                cmd.Parameters.AddWithValue("@OPD_DisAfterAmount", payopdA.Text);
                cmd.Parameters.AddWithValue("@OPD_Paid", UpadatePaid);
                cmd.Parameters.AddWithValue("@OPD_Balance", balopd.Text);

                cmd.Parameters.AddWithValue("@OPD_RadiologyBillAmount", txtradiologyBilling.Text);
                cmd.Parameters.AddWithValue("@OPD_RadiologyDiscount", DisOPDRadio);
                cmd.Parameters.AddWithValue("@OPD_DisAfterRadioligyAmount", payradioA.Text);
                cmd.Parameters.AddWithValue("@OPD_RadiologyPaid", UpdatedRadioPaid);
                cmd.Parameters.AddWithValue("@OPD_RadiologyBalance", balradio.Text);

                cmd.Parameters.AddWithValue("@OPD_LabBillAmount", txtlabBilling.Text);
                cmd.Parameters.AddWithValue("@OPD_LabDiscount", DisOPDLAb);
                cmd.Parameters.AddWithValue("@OPD_DisAfterLabAmount", payLabA.Text);
                cmd.Parameters.AddWithValue("@OPD_LabPaid", UpdatedLabPaid);
                cmd.Parameters.AddWithValue("@OPD_LabBalance", ballab.Text);

                cmd.Parameters.AddWithValue("@Total_Billing_Amount", TotalA.Text);
                cmd.Parameters.AddWithValue("@Total_Paid_Amount", TotalP.Text);
                cmd.Parameters.AddWithValue("@Total_Balance_Amount", TotalB.Text);

                cmd.Parameters.AddWithValue("@Receiver_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Payment_mode", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Remark", textBox2.Text);
                MainDate = DateTime.Now;
                cmd.Parameters.AddWithValue("@Billing_Date", MainDate);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                //Billing_OPD_BalanceFetcing();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void OPD_Billing_Details_Load(object sender, EventArgs e)
        {
            textBox1.Text = Dashbord.Ename;
            comboBox1.SelectedIndex = 0;
            showinfo();
            lab_Bill();
            if (txtlabBilling.Text != "0")
            {
                
                lbllab.Enabled = true;
                //txtlabBilling.Enabled = true;
                disLab.Enabled = true;
                pailab.Enabled = true;
                //payLabA.Enabled = true;
               //ballab.Enabled = true;
            }
            opdBill();
            if (txtopdBillAmount.Text != "0")
            {
              
                lblopd.Enabled = true;
                //txtopdBillAmount.Enabled = true;
                disOpd.Enabled = true;
                paidopd.Enabled = true;
                //payopdA.Enabled = true;
               //balopd.Enabled = true;
            }
            radiologyBill();
            if(txtradiologyBilling.Text!="0")
            {
                lblradio.Enabled = true;
                //txtradiologyBilling.Enabled = true;
                disradiology.Enabled = true;
               // payradioA.Enabled = true;
                paidradio.Enabled = true;
              //  balradio .Enabled = true;
            }
            total();
            Billing_OPD_BalanceFetcing();
            dataGridView1.ReadOnly = true;

            // Disable user interaction with the grid
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

        }

        private void disOpd_TextChanged(object sender, EventArgs e)
        {
            Billing_OPD_BalanceFetcing();
            OPDCal();
            total();
        }

        private void paidopd_TextChanged(object sender, EventArgs e)
        {
            Billing_OPD_BalanceFetcing();
            OPDCal();
            total();
        }

        private void disradiology_TextChanged(object sender, EventArgs e)
        {

            Billing_OPD_BalanceFetcing();
            RadioCal();
            total();
        }

        private void paidradio_TextChanged(object sender, EventArgs e)
        {
            Billing_OPD_BalanceFetcing();
            RadioCal();
            total();
        }

        private void disLab_TextChanged(object sender, EventArgs e)
        {
            Billing_OPD_BalanceFetcing();
            LabCal();
            total();
        }

        private void pailab_TextChanged(object sender, EventArgs e)
        {
            Billing_OPD_BalanceFetcing();
            LabCal();
            total();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Select Payment Mode")
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Select * From Billing_OPDFinal where OPDID=@A", con);
                cmd.Parameters.AddWithValue("@A", A);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    UpdateFinalUpdateBill();
                }
                else
                {
                    Save();
                }
                Billing_OPD_BalanceFetcing();

                global_OPDAmoun_data();
            }
            else
            {
                MessageBox.Show("Please Select Payment Mode");
            }
        }
        public void global_OPDAmoun_data()
        {
            GlobalBilling_OPD_BalanceFetcing();
            decimal a = Convert.ToDecimal(TotalP.Text);
            decimal paid_amt = Public_Received + a;
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Update OPD_Patient_Details set Date=@Date,Received=@Received,Pending=@Pending,Update_flag=@Update_flag where  OPDID=@OPDID", connection);

            cmd.Parameters.AddWithValue("@OPDID", A);
            cmd.Parameters.AddWithValue("@Date", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@Received", paid_amt);
            cmd.Parameters.AddWithValue("@Pending", TotalB.Text);
            cmd.Parameters.AddWithValue("@Update_flag", 0);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Record Added");
            connection.Close();
        }
        public void GlobalBilling_OPD_BalanceFetcing()
        {

            connection.Open();
            SqlCommand cmd = new SqlCommand(@"Select * From OPD_Patient_Details where OPDID=@PatientOPD_Id_Public", connection);
            cmd.Parameters.AddWithValue("@PatientOPD_Id_Public", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Public_Received = Convert.ToDecimal(dt.Rows[0]["Received"]);
                

            }
            connection.Close();
        }

        private void TotalA_Click(object sender, EventArgs e)
        {

        }

        private void OPDFinalBill_Click(object sender, EventArgs e)
        {
            Report.OPDFinalBilling cryRptNew = new Report.OPDFinalBilling();


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


            cryRptNew.SetParameterValue("OPDPAid", paidopd.Text);
            cryRptNew.SetParameterValue("OPDRadiology", paidradio.Text);
            cryRptNew.SetParameterValue("OPDLab", pailab.Text);
            cryRptNew.SetParameterValue("OPDID", A);
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

            if (!System.IO.Directory.Exists(@path + @"\OPD_BillS_FILES"))
            {
                System.IO.Directory.CreateDirectory(@path + @"\OPD_BillS_FILES");
            }
            DateTime date = MainDate;
            string formattedDate = date.ToString("dd-MM-yyyy_hh-mm-ss");
            string filepath = @path + @"\OPD_BillS_FILES\" + A + "_"+ formattedDate +".pdf";
            #endregion

            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            #endregion
        }

        private void OPD_detail_bill_Click(object sender, EventArgs e)
        {
            Report.rptOPDFinalDetailBilling cryRptNew = new Report.rptOPDFinalDetailBilling();


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


            cryRptNew.SetParameterValue("OPDPAid", paidopd.Text);
            cryRptNew.SetParameterValue("OPDRadiology", paidradio.Text);
            cryRptNew.SetParameterValue("OPDLab", pailab.Text);
            cryRptNew.SetParameterValue("OPDID", A);
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

            if (!System.IO.Directory.Exists(@path + @"\OPD_Detail_Bills"))
            {
                System.IO.Directory.CreateDirectory(@path + @"\OPD_Detail_Bills");
            }
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("dd-MM-yyyy_hh-mm-ss");
            string filepath = @path + @"\OPD_Detail_Bills\" + A + "_" + formattedDate + ".pdf";
            #endregion

            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            cryRptNew.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            #endregion
        }
    }
}
