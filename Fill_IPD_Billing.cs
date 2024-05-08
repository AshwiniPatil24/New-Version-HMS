using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class Fill_IPD_Billing : Form
    {
        int IPDID, PID;
        string Patient_ID, IPD_ID;
        int rows=0;
        int roomCharge = 0;
        int nursingCharge = 0;
        string billingDate;
        DateTime d;
        public int A;//IPDID
        int Pid;//PID
        private bool isFirstClick = true;
        public string Patient_Name;
        public decimal BillAmount;
        public decimal Applyed_Administrative_charges;
        public decimal Administrative_charges;
        public decimal oldDiscount;
       SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        SqlConnection connection_new = new SqlConnection(ConfigurationManager.ConnectionStrings["GLobal_Connection"].ConnectionString);
        public Fill_IPD_Billing()
        {
            InitializeComponent();
            this.Show();
            
        }

        public Fill_IPD_Billing(int PID, int ID)
        {
            InitializeComponent();
            A = ID;
            Pid = PID;
        }

        public void show()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"SELECT       Ruby_Jamner123.IPD_Registration.IPDID,Ruby_Jamner123.IPD_Registration.IPD_ID,Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Gender, Ruby_Jamner123.IPD_Registration.Patient_Id,Ruby_Jamner123.IPD_Registration.IPDID, Ruby_Jamner123.Patient_Registration.Patient_ID, 
                             Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID
    FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                             Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = @Patient_Id and ipdid = @ipdid", con);
            cmb.Parameters.AddWithValue("@Patient_Id", Pid);
            cmb.Parameters.AddWithValue("@ipdid", A);
            SqlDataAdapter adt = new SqlDataAdapter(cmb);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                infogrid.DataSource = dt;
                IPDID = Convert.ToInt32(infogrid.Rows[0].Cells["IPDID"].Value);
                PID = Convert.ToInt32(infogrid.Rows[0].Cells["PID"].Value);
                Patient_ID = infogrid.Rows[0].Cells["Patient_ID"].Value.ToString();
                IPD_ID = infogrid.Rows[0].Cells["IPD_ID"].Value.ToString();
                Patient_Name= infogrid.Rows[0].Cells["Name"].Value.ToString();
                infogrid.Columns["IPDID"].Visible = false;
                infogrid.Columns["IPD_ID"].Visible = false;
                infogrid.Columns["Patient_ID"].Visible = false;
                infogrid.Columns["PID"].Visible = false;
            }
            con.Close();
        }
        public void update_GlobalIPD_Charges()
        {

            connection_new.Open();
            SqlCommand cmb = new SqlCommand(@"UPDATE IPD_Patient_Details
                SET Registration_Charges=@Registration_Charges,Consultant_Charges=@Consultant_Charges,Nursing_Charges=@Nursing_Charges,Bed_Charges=@Bed_Charges,Hospital_Total=@Hospital_Total,Surgical_Total=@Surgical_Total,Medical_Record_Charges=@Medical_Record_Charges,BioMedical_Waste_Charges=@BioMedical_Waste_Charges,Consultant_Visiting_Charges=@Consultant_Visiting_Charges,Administrative_Charges=@Administrative_Charges,Bill_Amount=@Bill_Amount,Discount=@Discount,Received=@Received,Pending=@Pending,Billing_date=@Billing_date,Update_flag=@Update_flag,Net_Payable=@Net_Payable
                WHERE (IPD_ID=@IPD_ID)", connection_new);
            //decimal Net_Payable = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtTotalDiscountAmount.Text));
            cmb.Parameters.AddWithValue("@IPD_ID", IPDID);
            cmb.Parameters.AddWithValue("@Registration_Charges", registrationCharges.Text);
            cmb.Parameters.AddWithValue("@Consultant_Charges", consultantCharges.Text);
            cmb.Parameters.AddWithValue("@Nursing_Charges", NursingCharges.Text);
            cmb.Parameters.AddWithValue("@Bed_Charges", BedCharges.Text);
            cmb.Parameters.AddWithValue("@Hospital_Total", HospProcedureCharges.Text);
            cmb.Parameters.AddWithValue("@Surgical_Total", surgProcedureCharges.Text);
            cmb.Parameters.AddWithValue("@Medical_Record_Charges", medicalRecordCharges.Text);
            cmb.Parameters.AddWithValue("@BioMedical_Waste_Charges", bioMedicalWasteCharges.Text);
            cmb.Parameters.AddWithValue("@Consultant_Visiting_Charges", consultantVisitingCharges.Text);
            cmb.Parameters.AddWithValue("@Administrative_Charges", adminCharges.Text);
            cmb.Parameters.AddWithValue("@Bill_Amount", totalBill.Text);
            cmb.Parameters.AddWithValue("@Discount", oldDiscount);
            cmb.Parameters.AddWithValue("@Received", advance.Text);
            cmb.Parameters.AddWithValue("@Pending", balanceAmount.Text);
            cmb.Parameters.AddWithValue("@Billing_date", System.DateTime.Now);
            cmb.Parameters.AddWithValue("@Update_flag", 0);
            cmb.Parameters.AddWithValue("@Net_Payable", payableAmount.Text);
            cmb.ExecuteNonQuery();

            connection_new.Close();


        }
        private void Fill_IPD_Billing_Load(object sender, EventArgs e)
        {
            billerName.Text = Dashbord.Ename;
            updateroomsegment();
            updateroomsegment();
            updateDays();
            paymentMode.SelectedIndex = 0;
            show();
            regCharges_consltCharges();
            fn1();
            hospProcCharge();
            showSurgProcCharge();
            showMedicalRecordCharges();
            //showAdminCharges();
            showBioMedWasteCharges();
            showConsultantVisitingCharges();
            showTotalBill();
            showPayableAmt();
            //showAdminCharges();
            //showBalanceAmt();
            cmbTitle.SelectedIndex = 0;
            MJPJAYDisplay();

        }
        public void MJPJAYDisplay()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT IPDID, MJPJAY_NO, MJPJAY_Surgery FROM dbo.MJPJAY_PatientDetailsnew where IPDID = @IPDID", connection);
            cmd.Parameters.AddWithValue("@IPDID", A);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable td = new DataTable();
            sd.Fill(td);
            if(td.Rows.Count>0)
            {
                
                label27.Text = "Under MJPJAY Scheme Net Receivable Amount ₹  00.00";
                paidAmount.Enabled = false;
                discount.Enabled = false;
                discAuthorityName.Enabled = false;
                if(Convert.ToInt32(surgProcedureCharges.Text) >0)
                {
                    label28.Text= "This Patient Register CASH and MJPJAY";
                    paidAmount.Enabled = true;
                    discount.Enabled = true;
                    discAuthorityName.Enabled = true;
                    btnDetail.Enabled = true;
                }

            }
            else
            {
                label27.Text = "";
               
            }

            connection.Close();
        }
        public void updateDays()
        {
            string conn = @"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner";
            using (var selectConnection = new SqlConnection(conn))
            {
                selectConnection.Open();
                using (var selectCommand = new SqlCommand(@"select ID,From_Date,To_Date from ipd_assignedbeddetails where ipdid = @ipdid", selectConnection))
                {
                    selectCommand.Parameters.AddWithValue("@ipdid", A);
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        using (var updateConnection = new SqlConnection(conn))
                        {
                            updateConnection.Open();

                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ID"]);
                                DateTime from = Convert.ToDateTime(reader[1]);
                                DateTime? to = reader.IsDBNull(2) ? billDate.Value : Convert.ToDateTime(reader[2]);
                                if (to.HasValue)
                                {
                                    DateTime To = to.Value;
                                    TimeSpan difference = To - from;
                                    int numberOfDays = (int)difference.TotalDays;
                                    if (numberOfDays == 0)
                                        numberOfDays = 1;
                                    SqlCommand updateCommand = new SqlCommand(@"update ipd_assignedbeddetails set To_Date = @todate,Days = @days where ID = @id", updateConnection);
                                    updateCommand.Parameters.AddWithValue("@id", id);
                                    updateCommand.Parameters.AddWithValue("@days", numberOfDays);
                                    updateCommand.Parameters.AddWithValue("@todate", To.Date.ToString("dd-MM-yyyy"));
                                    updateCommand.ExecuteNonQuery();
                                }
                                rows++;
                            }

                        }
                    }
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            infogrid.Rows.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        public void hospProcCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Billing_IPDHosProc where IPDID = @amt", con);
            cmd.Parameters.AddWithValue("@amt", A);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                HospProcedureCharges.Text = sdr["IPDHosProcAmount"].ToString();
            }
            con.Close();
        }

        public void regCharges_consltCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Registration_Charges,Consultation_Charges from Patient_Registration where pid = @pid", con);
            cmd.Parameters.AddWithValue("@pid", Pid);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                registrationCharges.Text = sdr["Registration_Charges"].ToString();
                consultantCharges.Text = sdr["Consultation_Charges"].ToString();

            }
            sdr.Close();
            con.Close();
        }

        public void fn1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select From_Date,To_Date,Charges,Nursing_Charge from ipd_assignedbeddetails where ipdid = @ipdid", con);
            cmd.Parameters.AddWithValue("@ipdid", A);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                DateTime from = Convert.ToDateTime(sdr[0]);
                DateTime? to = sdr.IsDBNull(1) ? billDate.Value : Convert.ToDateTime(sdr[1]);
                int charge = Convert.ToInt32(sdr[2]);
                int nCharge = Convert.ToInt32(sdr[3]);
                if (to.HasValue)
                {
                    DateTime To = to.Value;
                    fn2(from, To, charge, nCharge);
                }
                rows++;
            }
            BedCharges.Text = roomCharge.ToString();
            NursingCharges.Text = nursingCharge.ToString();

            sdr.Close();
            con.Close();

        }
        public void updateroomsegment()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 ipdid, * 
FROM ipd_assignedbeddetails 
WHERE ipdid = @ipdid 
ORDER BY ID DESC;
", connection);
            cmd.Parameters.AddWithValue("@ipdid", A);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dtone = new DataTable();
            sd.Fill(dtone);
            if (dtone.Rows.Count > 0)
            {
                int ID = Convert.ToInt32(dtone.Rows[0]["ID"]);

                SqlCommand cmd1 = new SqlCommand(@"update ipd_assignedbeddetails set To_Date=@To_Date where ID=@ID", connection);
                cmd1.Parameters.AddWithValue("@ID", ID);
               //DateTime Todate=Convert.ToDateTime(billDate.Value.ToString("dd-MM-yyyyy HH:mm:ss"));

                cmd1.Parameters.AddWithValue("@To_Date", System.DateTime.Now.ToString("dd-MM-yyyy"));

                cmd1.ExecuteNonQuery();

                connection.Close();
            }
        }
        public void fn2(DateTime from, DateTime to, int charge,int nCharge)
        {
            TimeSpan difference = to - from;
            int numberOfDays = (int)difference.TotalDays;
            if (numberOfDays <= 0)
            {
                numberOfDays = 1;
            }
            roomCharge = roomCharge + (charge * numberOfDays);
            nursingCharge = nursingCharge + (nCharge * numberOfDays);
        }

        public void hospProcCharge()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select * from Billing_IPDHosProc where IPDID = @id", con);
            cmd.Parameters.AddWithValue("@id", A);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                HospProcedureCharges.Text = rdr["IPDHosProcAmount"].ToString();
            }
            rdr.Close();
            con.Close();
        }

        public void showSurgProcCharge()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select totalamount from AssignIPDSurgicalProcedure where ipdid = @id", con);
            cmd.Parameters.AddWithValue("@id", A);
            SqlDataReader rdr = cmd.ExecuteReader();
            int surProcCharge = 0;
            while (rdr.Read())
            {
                surProcCharge = surProcCharge + Convert.ToInt32(rdr[0]);
            }
            surgProcedureCharges.Text = surProcCharge.ToString();
            rdr.Close();
            con.Close();
        }

        public void showMedicalRecordCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select MedicalRecord_Charges from Master_IPDFixedCharges", con);
            medicalRecordCharges.Text = (cmd.ExecuteScalar()).ToString();
            con.Close();
        }

        public void showConsultantVisitingCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select ConsultantVisiting_Charges from Master_IPDFixedCharges", con);
            consultantVisitingCharges.Text = (cmd.ExecuteScalar()).ToString();
            con.Close();
        }

        public void showBioMedWasteCharges()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select BioMedicalWaste_Charges from Master_IPDFixedCharges", con);
            bioMedicalWasteCharges.Text = (cmd.ExecuteScalar()).ToString();
            con.Close();
        }

        public void showAdminCharges()
        {
        //    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(@"select Administrative_Charges from Master_IPDFixedCharges", con);
            
        //    con.Close();
            BillAmount = Convert.ToDecimal(totalBill.Text);
            Applyed_Administrative_charges = BillAmount + BillAmount * 10 / 100;
            Administrative_charges = Applyed_Administrative_charges - BillAmount;
            adminCharges.Text = Convert.ToDecimal(Administrative_charges).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SurgicalDetails sd = new SurgicalDetails(A, Pid);
            sd.Show();
            this.Close();
        }
        

        public void showTotalBill()
        {
            decimal admCharges = (Convert.ToDecimal(registrationCharges.Text) + Convert.ToDecimal(consultantCharges.Text) + Convert.ToDecimal(NursingCharges.Text) + Convert.ToDecimal(BedCharges.Text) + Convert.ToDecimal(HospProcedureCharges.Text) + Convert.ToDecimal(surgProcedureCharges.Text) + Convert.ToDecimal(medicalRecordCharges.Text)
                + Convert.ToDecimal(bioMedicalWasteCharges.Text) + Convert.ToDecimal(consultantVisitingCharges.Text))/10;
            adminCharges.Text = admCharges.ToString();
            totalBill.Text = (Convert.ToDecimal(registrationCharges.Text) + Convert.ToDecimal(consultantCharges.Text) + Convert.ToDecimal(NursingCharges.Text) + Convert.ToDecimal(BedCharges.Text) + Convert.ToDecimal(HospProcedureCharges.Text) + Convert.ToDecimal(surgProcedureCharges.Text) + Convert.ToDecimal(medicalRecordCharges.Text) 
                + Convert.ToDecimal(bioMedicalWasteCharges.Text) + Convert.ToDecimal(consultantVisitingCharges.Text) + Convert.ToDecimal(adminCharges.Text)).ToString();

            billAmt.Text = totalBill.Text;
            
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a digit, cancel the key press
                e.Handled = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (discount.Text == "")
            {
                amtAfterDiscount.Text = (Convert.ToDecimal(billAmt.Text) - 0).ToString();
                billAfterDiscount.Text = (Convert.ToDecimal(billAmt.Text) - 0).ToString();
            }
            else
            {
                amtAfterDiscount.Text = (Convert.ToDecimal(billAmt.Text) - Convert.ToDecimal(discount.Text)).ToString();
                billAfterDiscount.Text = (Convert.ToDecimal(billAmt.Text) - Convert.ToDecimal(discount.Text)).ToString();
            }
        }
        
        public void showPayableAmt()
        {
            decimal totalbill = Convert.ToDecimal(totalBill.Text);
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select TotalBillAmount,PaidAmount,Advance,BalanceAmount,AmountAfterDiscount,Discount from MainIPDBillingDetails where ipdid = @ipdid", con);
            cmd.Parameters.AddWithValue("@ipdid",A);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                decimal totalBillPrevious = Convert.ToDecimal(rdr["TotalBillAmount"]);
                if(totalBillPrevious != totalbill)
                {
                    decimal TotalBilldiff = totalbill - totalBillPrevious;
                    decimal amtAFTERDisc = totalbill - Convert.ToDecimal(rdr["Discount"]);
                    decimal Totalpayable = TotalBilldiff + Convert.ToDecimal(rdr["BalanceAmount"]);
                    billAfterDiscount.Text = amtAFTERDisc.ToString();
                    amtAfterDiscount.Text = amtAFTERDisc.ToString();
                    billAmt.Text = amtAFTERDisc.ToString();
                    payableAmount.Text = Totalpayable.ToString();
                    balanceAmount.Text = Totalpayable.ToString();
                    advance.Text = rdr["Advance"].ToString();
                }
                else
                {
                    advance.Text = rdr["Advance"].ToString();
                    billAfterDiscount.Text = rdr["AmountAfterDiscount"].ToString();
                    amtAfterDiscount.Text = rdr["AmountAfterDiscount"].ToString();
                    billAmt.Text = rdr["AmountAfterDiscount"].ToString();
                    payableAmount.Text = rdr["BalanceAmount"].ToString();
                    balanceAmount.Text = rdr["BalanceAmount"].ToString();
                }
                
            }
            rdr.Close();
            con.Close();
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a digit, cancel the key press
                e.Handled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BedCharges_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void consultantVisitingCharges_TextChanged(object sender, EventArgs e)
        {

        }

        private void billDate_ValueChanged(object sender, EventArgs e)
        {
            roomCharge = 0;
            nursingCharge = 0;
            BedCharges.Clear();
            fn1();
        }

        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"select Discount from MainIPDBillingDetails where IPDID = @ipdid", con);
                cmd.Parameters.AddWithValue("@ipdid", A);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (paymentMode.Text != "Select Payment Mode")
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                         oldDiscount = Convert.ToDecimal(rdr["Discount"]);
                        UpdateData(oldDiscount);

                    }
                    else
                    {
                        InsertData();
                    }
                   
                    
                    rdr.Close();
                    PrintDisplay();
                    billAfterDiscount.Clear();
                    amtAfterDiscount.Clear();
                    payableAmount.Clear();
                    
                    balanceAmount.Clear();
                    discount.Clear();
                    //discAuthorityName.Clear();
                    paidAmount.Clear();
                    billerName.Clear();
                    remark.Clear();
                    showPayableAmt();
                    update_GlobalIPD_Charges();
                }
                else
                {
                    MessageBox.Show("Please select Payment Mode....");
                }
            }
            catch (COMException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void billAmt_TextChanged(object sender, EventArgs e)
        {
            amtAfterDiscount.Text = billAmt.Text;
            billAfterDiscount.Text = billAmt.Text;
        }

        private void billAfterDiscount_TextChanged(object sender, EventArgs e)
        {
            if (billAfterDiscount.Text == "")
            {
                payableAmount.Text = (Convert.ToDecimal(billAmt.Text) - Convert.ToDecimal(advance.Text)).ToString();
            }
            else if (billAfterDiscount.Text != "")
            {
                payableAmount.Text = (Convert.ToDecimal(billAfterDiscount.Text) - Convert.ToDecimal(advance.Text)).ToString();
            }
            
        }

        private void advance_Final_PAyment_Click(object sender, EventArgs e)
        {
            try
            {
               
                IPDReport.rptIPDAdvancePaymentReceipt cro = new IPDReport.rptIPDAdvancePaymentReceipt();
                TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                Tables CrTablesNew;
                crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                CrTablesNew = cro.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                {
                    crtableLogoninfoNew = CrTable.LogOnInfo;
                    crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                    CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                }

                cro.SetParameterValue("IPDID", A);
                cro.SetParameterValue("PatientName", Patient_Name);
                cro.SetParameterValue("Title", cmbTitle.Text);
                cro.SetParameterValue("IPDID_withSR", IPD_ID);
                cro.SetParameterValue("Payment_Mode", paymentMode.Text);
                cro.SetParameterValue("Total_Amount", paidAmount.Text);


                ReportViewerForOPD obj = new ReportViewerForOPD();

                obj.crystalReportViewer1.ReportSource = cro;

                obj.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void PrintDisplay()
        {
            try
            {
              
                IPDReport.rptIPDAdvanceReport cro = new IPDReport.rptIPDAdvanceReport();


                TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                Tables CrTablesNew;
                crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                CrTablesNew = cro.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                {
                    crtableLogoninfoNew = CrTable.LogOnInfo;
                    crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                    CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                }

                cro.SetParameterValue("IPDID", A);
                //cro.SetParameterValue("PatientName", Patient_Name);
                cro.SetParameterValue("Title", cmbTitle.Text);
                //cro.SetParameterValue("IPDID_withSR", IPD_ID);
                //cro.SetParameterValue("Payment_Mode", paymentMode.Text);
                if(paidAmount.Text == "")
                {
                    paidAmount.Text = "0";
                }
                cro.SetParameterValue("Total_Amount", paidAmount.Text);
                cro.SetParameterValue("LoginEmp", billerName.Text);

                ReportViewerForOPD obj = new ReportViewerForOPD();

                obj.crystalReportViewer1.ReportSource = cro;
                obj.Refresh();
                obj.Show();
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

                if (!System.IO.Directory.Exists(@path + @"\Advance_IPD_Bill"))
                {
                    System.IO.Directory.CreateDirectory(@path + @"\Advance_IPD_Bill");
                }
                DateTime date = Convert.ToDateTime(billingDate);
                string formattedDate = date.ToString("dd-MM-yyyy_hh-mm-ss");
                string filepath = @path + @"\Advance_IPD_Bill\" + A + "_" + formattedDate + ".pdf";
                #endregion

                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                
                cro.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                #endregion
                billerName.Text = Dashbord.Ename;
                // this.Close();

            }
            catch (COMException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void provisional_bill_print_Click(object sender, EventArgs e)
        {
            billerName.Text = Dashbord.Ename;
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT IPDID, MJPJAY_NO, MJPJAY_Surgery FROM dbo.MJPJAY_PatientDetailsnew where IPDID = @IPDID", connection);
            cmd.Parameters.AddWithValue("@IPDID", A);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable td = new DataTable();
            sd.Fill(td);
            if (td.Rows.Count > 0)
            {

                label27.Text = "Under MJPJAY Scheme Net Receivable Amount ₹  00.00";
                try
                {

                    IPDReport.rptIPDProvisional_Print_MJPJAY cro = new IPDReport.rptIPDProvisional_Print_MJPJAY();
                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cro.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }

                    cro.SetParameterValue("IPDID", A);
                    cro.SetParameterValue("LoginEmp", billerName.Text);

                    //cro.SetParameterValue("IPDID_withSR", IPD_ID);
                    //cro.SetParameterValue("Payment_Mode", paymentMode.Text);



                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cro;
                    obj.Refresh();
                    obj.Show();
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

                    if (!System.IO.Directory.Exists(@path + @"\Provisional_IPD_Bill"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\Provisional_IPD_Bill");
                    }
                    DateTime date = Convert.ToDateTime(billingDate);
                    string formattedDate = date.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\Provisional_IPD_Bill\" + A + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cro.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion

                }
                catch (COMException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

                if (Convert.ToInt32(surgProcedureCharges.Text) > 0)
                {
                    try
                    {

                        IPDReport.rptIPDProvisional_Print cro = new IPDReport.rptIPDProvisional_Print();
                        TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                        TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                        ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                        Tables CrTablesNew;
                        crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                        crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                        crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                        crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                        CrTablesNew = cro.Database.Tables;
                        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                        {
                            crtableLogoninfoNew = CrTable.LogOnInfo;
                            crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                            CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                        }

                        cro.SetParameterValue("IPDID", A);
                        cro.SetParameterValue("LoginEmp", billerName.Text);

                        //cro.SetParameterValue("IPDID_withSR", IPD_ID);
                        //cro.SetParameterValue("Payment_Mode", paymentMode.Text);



                        ReportViewerForOPD obj = new ReportViewerForOPD();

                        obj.crystalReportViewer1.ReportSource = cro;
                        obj.Refresh();
                        obj.Show();
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

                        if (!System.IO.Directory.Exists(@path + @"\Provisional_IPD_Bill"))
                        {
                            System.IO.Directory.CreateDirectory(@path + @"\Provisional_IPD_Bill");
                        }
                        DateTime date = Convert.ToDateTime(billingDate);
                        string formattedDate = date.ToString("dd-MM-yyyy_hh-mm-ss");
                        string filepath = @path + @"\Provisional_IPD_Bill\" + A + "_" + formattedDate + ".pdf";
                        #endregion

                        if (System.IO.File.Exists(filepath))
                        {
                            System.IO.File.Delete(filepath);
                        }
                        cro.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                        #endregion

                    }
                    catch (COMException ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }

            }
            else
            {
                label27.Text = "";
                try
                {

                    IPDReport.rptIPDProvisional_Print cro = new IPDReport.rptIPDProvisional_Print();
                    TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                    Tables CrTablesNew;
                    crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                    crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                    crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                    crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                    CrTablesNew = cro.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                    {
                        crtableLogoninfoNew = CrTable.LogOnInfo;
                        crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                        CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                    }

                    cro.SetParameterValue("IPDID", A);
                    cro.SetParameterValue("LoginEmp", billerName.Text);

                    //cro.SetParameterValue("IPDID_withSR", IPD_ID);
                    //cro.SetParameterValue("Payment_Mode", paymentMode.Text);



                    ReportViewerForOPD obj = new ReportViewerForOPD();

                    obj.crystalReportViewer1.ReportSource = cro;
                    obj.Refresh();
                    obj.Show();
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

                    if (!System.IO.Directory.Exists(@path + @"\Provisional_IPD_Bill"))
                    {
                        System.IO.Directory.CreateDirectory(@path + @"\Provisional_IPD_Bill");
                    }
                    DateTime date = Convert.ToDateTime(billingDate);
                    string formattedDate = date.ToString("dd-MM-yyyy_hh-mm-ss");
                    string filepath = @path + @"\Provisional_IPD_Bill\" + A + "_" + formattedDate + ".pdf";
                    #endregion

                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    cro.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    #endregion

                }
                catch (COMException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            connection.Close();


            
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            try
            {

                IPDReport.rptIPDDetailBillProvisional_Print cro = new IPDReport.rptIPDDetailBillProvisional_Print();


                TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
                ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
                Tables CrTablesNew;
                crConnectionInfoNew.ServerName = ConfigurationSettings.AppSettings["SreverName"].ToString();
                crConnectionInfoNew.DatabaseName = ConfigurationSettings.AppSettings["DatabaseName"].ToString();
                crConnectionInfoNew.UserID = ConfigurationSettings.AppSettings["UsernameForReport"].ToString();
                crConnectionInfoNew.Password = ConfigurationSettings.AppSettings["PasswordForReport"].ToString();

                CrTablesNew = cro.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTablesNew)
                {
                    crtableLogoninfoNew = CrTable.LogOnInfo;
                    crtableLogoninfoNew.ConnectionInfo = crConnectionInfoNew;
                    CrTable.ApplyLogOnInfo(crtableLogoninfoNew);
                }

                cro.SetParameterValue("IPDID", A);
                cro.SetParameterValue("BedCharges", BedCharges.Text);
                cro.SetParameterValue("NursingCharges", NursingCharges.Text);
                cro.SetParameterValue("LoginEmp", billerName.Text);
                
                //cro.SetParameterValue("IPDID_withSR", IPD_ID);
                //cro.SetParameterValue("Payment_Mode", paymentMode.Text);



                ReportViewerForOPD obj = new ReportViewerForOPD();

                obj.crystalReportViewer1.ReportSource = cro;
                obj.Refresh();
                obj.Show();

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

                if (!System.IO.Directory.Exists(@path + @"\Detail_IPD_Bill"))
                {
                    System.IO.Directory.CreateDirectory(@path + @"\Detail_IPD_Bill");
                }
                DateTime date = Convert.ToDateTime(billingDate);
                string formattedDate = date.ToString("dd-MM-yyyy_hh-mm-ss");
                string filepath = @path + @"\Detail_IPD_Bill\" + A + "_" + formattedDate + ".pdf";
                #endregion

                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
                cro.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                #endregion
            }
            catch (COMException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTitle.SelectedIndex==2)
            {
                discount.Enabled = true;
                discAuthorityName.Enabled = true;
                provisional_bill_print.Enabled = true;
                btnDetail.Enabled = true;
            }
            else
            {
                discount.Enabled = false;
                discAuthorityName.Enabled = false;
                provisional_bill_print.Enabled = false;
                btnDetail.Enabled = false;
            }
        }

        public void InsertData()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"insert into MainIPDBillingDetails(IPDID,IPDID_with_str,PID,PID_with_str,RegistrationCharges,ConsultantCharges,NursingCharges,BedCharges,HospitalProcCharges,SurgicalProcCharges,MedicalRecordCharges,BioMedicalWasteCharges,ConsultantVisitingCharges,AdministrativeCharges,TotalBillAmount,Discount,DiscountAuthorityName,AmountAfterDiscount,Advance,PayableAmount,PaidAmount,BalanceAmount,BillerName,PaymentMode,Remark,BillDate)
values (@IPDID,@IPD_ID,@PID,@P_ID,@regisCharges,@consltCharges,@nursingCharges,@bedCharges,@hospPcharge,@surgPcharge,@medicalRecordCharge,@bioMedWasteCharge,@consVisitingCharges,@adminCharges,@totalBillAmt,@disc,@discAuthName,@amtAfterDisc,@adv,@payableAmt,@paidAmt,@balAmt,@billerName,@paymntMode,@remark,@billDate)", con);
                cmd.Parameters.AddWithValue("@IPDID", IPDID);
                cmd.Parameters.AddWithValue("@IPD_ID", IPD_ID);
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@P_ID", Patient_ID);
                cmd.Parameters.AddWithValue("@regisCharges", registrationCharges.Text);
                cmd.Parameters.AddWithValue("@consltCharges", consultantCharges.Text);
                cmd.Parameters.AddWithValue("@nursingCharges", NursingCharges.Text);
                cmd.Parameters.AddWithValue("@bedCharges", BedCharges.Text);
                cmd.Parameters.AddWithValue("@hospPcharge", HospProcedureCharges.Text);
                cmd.Parameters.AddWithValue("@surgPcharge", surgProcedureCharges.Text);
                cmd.Parameters.AddWithValue("@medicalRecordCharge", medicalRecordCharges.Text);
                cmd.Parameters.AddWithValue("@bioMedWasteCharge", bioMedicalWasteCharges.Text);
                cmd.Parameters.AddWithValue("@consVisitingCharges", consultantVisitingCharges.Text);
                cmd.Parameters.AddWithValue("@adminCharges", adminCharges.Text);
                cmd.Parameters.AddWithValue("@totalBillAmt", totalBill.Text);
                if(discount.Text == "")
                {
                    discount.Text = "0";
                }
                cmd.Parameters.AddWithValue("@disc", discount.Text);               
                if (discount.Text != "0" && discAuthorityName.Text == "")
                {
                    MessageBox.Show("Please enter Discount Authority Name...");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@discAuthName", discAuthorityName.Text);
                }
                cmd.Parameters.AddWithValue("@amtAfterDisc", amtAfterDiscount.Text);
                cmd.Parameters.AddWithValue("@adv", Convert.ToDecimal(advance.Text)+Convert.ToDecimal(paidAmount.Text));               
                cmd.Parameters.AddWithValue("@payableAmt", payableAmount.Text);
                if (paidAmount.Text == "")
                {
                    paidAmount.Text = "0";
                }
                cmd.Parameters.AddWithValue("@paidAmt", paidAmount.Text);
                balanceAmount.Text = (Convert.ToDecimal(payableAmount.Text) - Convert.ToDecimal(paidAmount.Text)).ToString();
                cmd.Parameters.AddWithValue("@balAmt", balanceAmount.Text);
                
                    cmd.Parameters.AddWithValue("@billerName", billerName.Text);
                
                if (paymentMode.Text == "")
                {
                    MessageBox.Show("Please select Payment Mode...");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paymntMode", paymentMode.Text);
                }
                cmd.Parameters.AddWithValue("@remark", remark.Text);
                billingDate = billDate.Value.ToString("dd-MM-yyyy HH:mm:ss");
                cmd.Parameters.AddWithValue("@billDate", billingDate );
                cmd.ExecuteNonQuery();
                MessageBox.Show("Billing Details Added Successfully...");
                con.Close();
                //PrintDisplay();                
                //billAfterDiscount.Clear();
                //amtAfterDiscount.Clear();
                //payableAmount.Clear();
                //paidAmount.Clear();
                //balanceAmount.Clear();
                //discount.Clear();
                //discAuthorityName.Clear();
                ////advance.Text = paidAmount.Text;
                //billerName.Clear();
                //remark.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data: " + ex.Message);
            }
        }

        public void UpdateData(decimal oldDis)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"update MainIPDBillingDetails set RegistrationCharges = @registrationCharges,
ConsultantCharges = @consultationCharges,
NursingCharges = @nursingCharges,
BedCharges = @bedCharges,
HospitalProcCharges = @hospitalProcCharges,
SurgicalProcCharges = @surgicalProcCharges,
MedicalRecordCharges = @medRecordCharges,
BioMedicalWasteCharges = @bioWasteCharges,
ConsultantVisitingCharges = @consultantVisitingCharges,
AdministrativeCharges = @adminCharges,
TotalBillAmount = @totalBillAmt,
Discount = @discount,
DiscountAuthorityName = @disAuthName,
AmountAfterDiscount = @amtAfterDis,
Advance = @advance,
PayableAmount = @payableAmt,
PaidAmount = @paidAmt,
BalanceAmount = @balAmt,
BillerName = @billerName,
BillDate = @billDate,
PaymentMode = @mode,
Remark = @remark WHERE ipdid = @ipdid", con);
                cmd.Parameters.AddWithValue("@registrationCharges",registrationCharges.Text);
                cmd.Parameters.AddWithValue("@consultationCharges",consultantCharges.Text);
                cmd.Parameters.AddWithValue("@nursingCharges",NursingCharges.Text);
                cmd.Parameters.AddWithValue("@bedCharges",BedCharges.Text);
                cmd.Parameters.AddWithValue("@hospitalProcCharges",HospProcedureCharges.Text);
                cmd.Parameters.AddWithValue("@surgicalProcCharges",surgProcedureCharges.Text);
                cmd.Parameters.AddWithValue("@medRecordCharges",medicalRecordCharges.Text);
                cmd.Parameters.AddWithValue("@bioWasteCharges",bioMedicalWasteCharges.Text);
                cmd.Parameters.AddWithValue("@consultantVisitingCharges",consultantVisitingCharges.Text);
                cmd.Parameters.AddWithValue("@adminCharges",adminCharges.Text);
                cmd.Parameters.AddWithValue("@totalBillAmt",totalBill.Text);
                if(discount.Text == "")
                {
                    cmd.Parameters.AddWithValue("@discount", 0 + oldDis);
                }
                else
                {
                    decimal newDiscount = Convert.ToDecimal(discount.Text) + oldDis;
                    cmd.Parameters.AddWithValue("@discount", newDiscount);
                }
                if (discount.Text != "" && discAuthorityName.Text == "")
                {
                    MessageBox.Show("Please enter Discount Authority Name...");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@disAuthName", discAuthorityName.Text);
                }
                cmd.Parameters.AddWithValue("@amtAfterDis",amtAfterDiscount.Text);
                cmd.Parameters.AddWithValue("@advance", Convert.ToDecimal(advance.Text) + Convert.ToDecimal(paidAmount.Text));
                cmd.Parameters.AddWithValue("@payableAmt",payableAmount.Text);
                if (paidAmount.Text == "")
                {
                    paidAmount.Text = "0";
                }
                cmd.Parameters.AddWithValue("@paidAmt",paidAmount.Text);
                balanceAmount.Text = (Convert.ToDecimal(payableAmount.Text) - Convert.ToDecimal(paidAmount.Text)).ToString();
                cmd.Parameters.AddWithValue("@balAmt",balanceAmount.Text);
               
                    cmd.Parameters.AddWithValue("@billerName", billerName.Text);
                
                if (paymentMode.Text == "")
                {
                    MessageBox.Show("Please select Payment Mode...");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@mode", paymentMode.Text);
                }
                billingDate = billDate.Value.ToString("dd-MM-yyyy HH:mm:ss");
                cmd.Parameters.AddWithValue("@billDate", billingDate);
                cmd.Parameters.AddWithValue("@remark",remark.Text);
                cmd.Parameters.AddWithValue("@ipdid",A);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Billing Details Updated Successfully...");
                con.Close();
                //PrintDisplay();
                //billAfterDiscount.Clear();
                //amtAfterDiscount.Clear();
                //payableAmount.Clear();
                //paidAmount.Clear();
                //balanceAmount.Clear();
                //discount.Clear();
                //discAuthorityName.Clear();
               
                //billerName.Clear();
                //remark.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }
    }
}
