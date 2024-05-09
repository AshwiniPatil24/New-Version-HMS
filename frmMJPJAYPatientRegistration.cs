using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Ruby_Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Ruby_Hospital
{

    public partial class frmMJPJAYPatientRegistration : Form
    {
        SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);

        public int flag_for_ADDSurgery = 0;
        public int SaveFlag = 0;
        public int PatientId_Public;
        public int PatientIPD_Public;
        public Decimal PublicPackageAmount;
        public int publicSubSurgery = 0;
        public int publicMainSurgery = 0;
        private DataTable dtPublic;
        private int IsLoaded;
        private int IsBinded;
        public string PatientMJPJAYNOForRemoved;
        public int PatientMJPJAY_MAINForRemoved;
        public int PatientMJPJAYNO_SUBForRemoved;
        public string PatientMJPJAYNO_SurgeryForRemoved;
        public Decimal PatientMJPJAYNOFor_packageRemoved;
        public string PatientMJPJAY_Public;
        public int DiseaseMainCategoryID;
        public int DiseaseSubCategoryID;


        public frmMJPJAYPatientRegistration()
        {
            InitializeComponent();
        }

        public void show_mjpjayPatientDetails()
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT           Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.IPD_Registration.IPD_ID,Ruby_Jamner123.Patient_Registration.Name,Ruby_Jamner123.Patient_Registration.Gender,Ruby_Jamner123.IPD_Registration.ConsultantID,Ruby_Jamner123.Patient_Registration.Mobile_Number, 
Ruby_Jamner123.Patient_Registration.Adhaar_ID,Ruby_Jamner123.Patient_Registration.PID,Ruby_Jamner123.IPD_Registration.IPDID,Ruby_Jamner123.IPD_Registration.Room_Segment,Ruby_Jamner123.IPD_Registration.Bed_No,Ruby_Jamner123.IPD_Registration.Mediclaim,Ruby_Jamner123.IPD_Registration.Date_Of_Admission,Ruby_Jamner123.IPD_Registration.Reserred_By
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
where Ruby_Jamner123.IPD_Registration.IPDID=@IPDID", connection1);
            cmd.Parameters.AddWithValue("@IPDID", PatientIPD_Public);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                dataGridView1.DataSource = dt;
            }
            connection1.Close();
        }
        public frmMJPJAYPatientRegistration(int PatientId, int IPDID)
        {
            try
            {
                InitializeComponent();

                PatientIPD_Public = IPDID;

                connection1.Open();
                SqlCommand cmd1 = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew  WHERE IPDID=@IPDID", connection1);
                cmd1.Parameters.AddWithValue(@"IPDID",PatientIPD_Public);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dtPublic = new DataTable();
                sda.Fill(dtPublic);
               
               
                DVGMJPJAYAddSurgery.DataSource = dtPublic;
                DVGMJPJAYAddSurgery.Columns["MJPJAY_ID"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["IPDID"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Date"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["MJPJAY_MainCategory"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["MJPJAY_SubCategory"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["PackageAmount"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Doctor_Check"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Surgery_Date"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Due_Amount"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Partial_Amount"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Received"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Partial"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Remark"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["Anaesthesia"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["SurgeonID1"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["SurgeonID2"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["AssistantID1"].Visible = false;
                DVGMJPJAYAddSurgery.Columns["AssistantID2"].Visible = false;
                connection1.Close();

                connection1.Open();
                SqlCommand cmd = new SqlCommand(@"select * from MJPJAY_DiseaseMainCategory", connection1);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable DTmain = new DataTable();
                sd.Fill(DTmain);
                cmbMainCategory.DataSource = DTmain;
                cmbMainCategory.DisplayMember = "DiseaseMainCategory";
                cmbMainCategory.ValueMember = "ID";
                //adding SELECT
                DataRow dr1;
                dr1 = DTmain.NewRow();
                dr1["DiseaseMainCategory"] = "Select Main Category";
                dr1["ID"] = 0;
                DTmain.Rows.Add(dr1);
                DTmain.DefaultView.Sort = "ID";
                //DTmain.DefaultView.Sort = "DiseaseMainCategory asc";
                IsLoaded = 1;
                IsBinded = 1;
                connection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void frmMJPJAYPatientRegistration_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            show_mjpjayPatientDetails();
           

        }

        private void lblHeading_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (IsLoaded == 1)
                {
                    DiseaseMainCategoryID = Convert.ToInt32(cmbMainCategory.SelectedValue);
                    connection1.Open();
                    SqlCommand cmd = new SqlCommand(@"select * from  MJPJAY_SubCategory  WHERE DiseaseMainCategoryID=@DiseaseMainCategoryID", connection1);
                    cmd.Parameters.AddWithValue(@"DiseaseMainCategoryID", DiseaseMainCategoryID);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt3 = new DataTable();
                    sd.Fill(dt3);
                    connection1.Close();
                    cmbSubCategory.DisplayMember = "DiseaseSubCategory";
                    cmbSubCategory.ValueMember = "ID";
                    cmbSubCategory.DataSource = dt3;
                    publicMainSurgery = Convert.ToInt32(dt3.Rows[0]["DiseaseMainCategoryID"]);
                    DataRow dr1;
                    dr1 = dt3.NewRow();
                    dr1["DiseaseSubCategory"] = "Select Sub Category";
                    dr1["ID"] = 0;
                    dt3.Rows.Add(dr1);
                    dt3.DefaultView.Sort = "ID";
                    
                    //txtMainCategory.Text = DiseaseMainCategoryID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsBinded == 1)
                {
                    DiseaseSubCategoryID = Convert.ToInt32(cmbSubCategory.SelectedValue);
                    connection1.Open();
                    SqlCommand cmd = new SqlCommand(@"select * from  MJPJAY_Surgery WHERE DiseaseSubCategoryID=@DiseaseSubCategoryID and ISActive=1", connection1);
                    cmd.Parameters.AddWithValue(@"DiseaseSubCategoryID", DiseaseSubCategoryID);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataTable dt123 = new DataTable();
                    sd.Fill(dt123);
                    
                    cmbSurgeryName.DataSource = dt123;
                    cmbSurgeryName.DisplayMember = "Surgery";
                    cmbSurgeryName.ValueMember = "ID";
                    PublicPackageAmount = Convert.ToDecimal(dt123.Rows[0]["PackageAmount"]);
                    publicSubSurgery = Convert.ToInt32(dt123.Rows[0]["DiseaseSubCategoryID"]);
                    DataRow dr1;
                    dr1 = dt123.NewRow();
                    dr1["Surgery"] = "Select Surgery";
                    dr1["ID"] = 0;
                    dt123.Rows.Add(dr1);
                    dt123.DefaultView.Sort = "ID";

                    txtSubSurgery.Text = cmbSubCategory.Text;

                    connection1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ClearComboBoxItems(ComboBox comboBox)
        {
            connection1.Close();
            DiseaseMainCategoryID = 0;
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"select * from  MJPJAY_SubCategory  WHERE DiseaseMainCategoryID=@DiseaseMainCategoryID", connection1);
            cmd.Parameters.AddWithValue(@"DiseaseMainCategoryID", DiseaseMainCategoryID);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt3 = new DataTable();
            sd.Fill(dt3);
            connection1.Close();
            cmbSubCategory.DisplayMember = "DiseaseSubCategory";
            cmbSubCategory.ValueMember = "ID";
            cmbSubCategory.DataSource = dt3;
            publicMainSurgery = 0;
            DataRow dr1;
            dr1 = dt3.NewRow();
            dr1["DiseaseSubCategory"] = "Select Sub Category";
            dr1["ID"] = 0;
            dt3.Rows.Add(dr1);
            dt3.DefaultView.Sort = "ID";
           
        }
        private void ClearComboBoxItemsMain(ComboBox comboBox)
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"select * from MJPJAY_DiseaseMainCategory", connection1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable DTmain = new DataTable();
            sd.Fill(DTmain);
            connection1.Close();
            cmbMainCategory.DataSource = DTmain;
            cmbMainCategory.DisplayMember = "DiseaseMainCategory";
            cmbMainCategory.ValueMember = "ID";
            //adding SELECT
            DataRow dr1;
            dr1 = DTmain.NewRow();
            dr1["DiseaseMainCategory"] = "Select Main Category";
            dr1["ID"] = 0;
            DTmain.Rows.Add(dr1);
            DTmain.DefaultView.Sort = "ID";
            
        }
        private void button3_Click(object sender, EventArgs e)
        {

            //connection1.Open();
            //SqlCommand cmd1 = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew  WHERE IPDID=@IPDID and PackageAmount=0 ", connection1);
            //cmd1.Parameters.AddWithValue(@"IPDID", PatientIPD_Public);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            //DataTable dtPublic = new DataTable();
            //sda.Fill(dtPublic);            
            //DVGMJPJAYAddSurgery.DataSource = dtPublic;
            try
            {
                MJPJAYNo();
                if (txtSurgeryName.Text == "" || txtMJPJAYNO.Text == "" || cmbSurgeryName.Text == "Select Surgery")
                {

                    MessageBox.Show("Enter MJPJAY NO and Select Surgery Name");
                }

                else
                {
                    connection1.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into MJPJAY_PatientDetailsnew (IPDID,MJPJAY_NO,Date,Doctor_Check,MJPJAY_MainCategory,MJPJAY_SubCategory,MJPJAY_Surgery,PackageAmount,Surgery_Date,Due_Amount,Partial_Amount,Received,Partial)
                                                                                         values(@IPDID,@MJPJAY_NO,@Date,@Doctor_Check,@MJPJAY_MainCategory,@MJPJAY_SubCategory,@MJPJAY_Surgery,@PackageAmount,@Surgery_Date,@Due_Amount,@Partial_Amount,@Received,@Partial)", connection1);
                    cmd.Parameters.AddWithValue(@"IPDID", PatientIPD_Public);
                    cmd.Parameters.AddWithValue(@"Date", dtpAddedOn.Value);
                    cmd.Parameters.AddWithValue(@"Doctor_Check", 0);
                    cmd.Parameters.AddWithValue(@"MJPJAY_NO", txtMJPJAYNO.Text);
                    cmd.Parameters.AddWithValue(@"MJPJAY_Surgery", txtSurgeryName.Text);
                    cmd.Parameters.AddWithValue(@"MJPJAY_MainCategory", publicMainSurgery);
                    cmd.Parameters.AddWithValue(@"MJPJAY_SubCategory", publicSubSurgery);
                    cmd.Parameters.AddWithValue(@"PackageAmount", PublicPackageAmount);
                    cmd.Parameters.AddWithValue(@"Surgery_Date", System.DateTime.Now);

                    cmd.Parameters.AddWithValue(@"Due_Amount", 0);
                    cmd.Parameters.AddWithValue(@"Partial_Amount", 0);
                    cmd.Parameters.AddWithValue(@"Received", 0);
                    cmd.Parameters.AddWithValue(@"Partial", 0);


                    cmd.ExecuteNonQuery();
                    connection1.Close();

                    connection1.Open();
                    SqlCommand cmd1 = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew  WHERE IPDID=@IPDID", connection1);
                    cmd1.Parameters.AddWithValue(@"IPDID", PatientIPD_Public);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    DataTable dtPublic = new DataTable();
                    sda.Fill(dtPublic);                               
                    DVGMJPJAYAddSurgery.DataSource = dtPublic;
                    PatientMJPJAY_Public = Convert.ToString(dtPublic.Rows[0]["MJPJAY_NO"]);

                    DVGMJPJAYAddSurgery.Columns["MJPJAY_ID"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["IPDID"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["Date"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["MJPJAY_MainCategory"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["MJPJAY_SubCategory"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["PackageAmount"].Visible = false;

                    DVGMJPJAYAddSurgery.Columns["Doctor_Check"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["Surgery_Date"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["Due_Amount"].Visible = false;

                    DVGMJPJAYAddSurgery.Columns["Partial_Amount"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["Received"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["Partial"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["Remark"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["Anaesthesia"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["SurgeonID1"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["SurgeonID2"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["AssistantID1"].Visible = false;
                    DVGMJPJAYAddSurgery.Columns["AssistantID2"].Visible = false;
                    
                    #region  Clear All
                    txtSurgeryName.Clear();
                    txtPackageAmount.Clear();
                    cmbSurgeryName.SelectedIndex = 0;

                    ClearComboBoxItems(cmbSubCategory);
                    ClearComboBoxItemsMain(cmbMainCategory);

                    cmbMainCategory.SelectedItem = 0;
                    txtMJPJAYNO.Clear();
                    //txtPackageAmount.Clear();
                    flag_for_ADDSurgery = 1;
                    
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       
        private void cmbSurgeryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSurgeryName.Text = cmbSurgeryName.Text;
        }
        public void savedata()
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO MJPJAY_BillingDetails (MJPJAY_IPDID)
                                    values (@MJPJAY_IPDID) ", connection1);
            cmd.Parameters.AddWithValue("@MJPJAY_IPDID", PatientIPD_Public);
            cmd.ExecuteNonQuery();
            connection1.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                
                   // dtpAddedOn.Value = Convert.ToDateTime(o.dtAddedOn);

                    //for (int i = 0; i < DVGMJPJAYAddSurgery.Rows.Count; i++)
                    //{

                    //    //|| Convert.ToString(DVGMJPJAYAddSurgery["MJPJAY_Surgery", i].Value) == ""
                    //    // if (DVGMJPJAYAddSurgery["MJPJAY_NO", i].Value.ToString() == "" || Convert.ToString(DVGMJPJAYAddSurgery["MJPJAY_Surgery", i].Value) == "")
                    //    if (flag_for_ADDSurgery == 1)
                    //    {

                    //    connection1.Open();
                    //    SqlCommand cmd = new SqlCommand(@"insert into MJPJAY_PatientDetailsnew (IPDID,MJPJAY_NO,Date,Doctor_Check,MJPJAY_MainCategory,MJPJAY_SubCategory,MJPJAY_Surgery,PackageAmount,Surgery_Date,Due_Amount,Partial_Amount,Received,Partial)
                    //                                                                     values(@IPDID,@MJPJAY_NO,@Date,@Doctor_Check,@MJPJAY_MainCategory,@MJPJAY_SubCategory,@MJPJAY_Surgery,@PackageAmount,@Surgery_Date,@Due_Amount,@Partial_Amount,@Received,@Partial)", connection1);
                    //    cmd.Parameters.AddWithValue(@"IPDID", PatientIPD_Public);
                    //    cmd.Parameters.AddWithValue(@"Date", dtpAddedOn.Value);
                    //    cmd.Parameters.AddWithValue(@"Doctor_Check", 0);
                    //    cmd.Parameters.AddWithValue(@"MJPJAY_NO", DVGMJPJAYAddSurgery["MJPJAY_NO", i].Value.ToString());
                    //    cmd.Parameters.AddWithValue(@"MJPJAY_Surgery", DVGMJPJAYAddSurgery["MJPJAY_Surgery", i].Value.ToString());
                    //    cmd.Parameters.AddWithValue(@"MJPJAY_MainCategory", Convert.ToInt32(DVGMJPJAYAddSurgery["MJPJAY_MainCategory", i].Value));
                    //    cmd.Parameters.AddWithValue(@"MJPJAY_SubCategory", Convert.ToInt32(DVGMJPJAYAddSurgery["MJPJAY_SubCategory", i].Value));
                    //    cmd.Parameters.AddWithValue(@"PackageAmount", Convert.ToDecimal(DVGMJPJAYAddSurgery["PackageAmount", i].Value));
                    //    cmd.Parameters.AddWithValue(@"Surgery_Date", System.DateTime.Now);
                        
                    //    cmd.Parameters.AddWithValue(@"Due_Amount", 0);
                    //    cmd.Parameters.AddWithValue(@"Partial_Amount", 0);
                    //    cmd.Parameters.AddWithValue(@"Received", 0);
                    //    cmd.Parameters.AddWithValue(@"Partial", 0);

                        
                    //    cmd.ExecuteNonQuery();
                    //    connection1.Close();

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Please Select Surgery Details.");
                    //    }

                    //}
                    MessageBox.Show("Record Added Successfully...");
                    btnPrintMJPJAYConsent_Click(sender, e);
                    savedata();
                    this.Close();

                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbSubCategory_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSurgeryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DVGMJPJAYAddSurgery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = DVGMJPJAYAddSurgery.CurrentCell.RowIndex;
            DVGMJPJAYAddSurgery.Rows.RemoveAt(RowIndex);
        }

        private void txtMJPJAYNO_Leave(object sender, EventArgs e)
        {
            SqlCommand CMD = new SqlCommand("Select MJPJAY_NO FROM MJPJAY_PatientDetailsnew WHERE MJPJAY_NO=@MJPJAY_NO", connection1);
            CMD.Parameters.AddWithValue("MJPJAY_NO", txtMJPJAYNO.Text);
            SqlDataReader SQLreader1;
            connection1.Open();
            SQLreader1 = CMD.ExecuteReader();
            if (SQLreader1.Read())
            {
                MessageBox.Show("The MJPJAY Number is already taken. Please Enter a different Number");
                txtMJPJAYNO.Focus();
                connection1.Close();
            }
            else
            {
                connection1.Close();
            }

        }
        public void MJPJAYNo()
        {
              for (int i = 0; i < DVGMJPJAYAddSurgery.Rows.Count; i++)
              {
                    if (txtMJPJAYNO.Text == DVGMJPJAYAddSurgery.Rows[i].Cells[3].Value.ToString())
                    {
                        MessageBox.Show("The MJPJAY Number is already taken. Please Enter a different Number");
                      txtMJPJAYNO.Clear();
                    break;
                       
                    }
                    
              }
            
        }
        private void btnPrintMJPJAYConsent_Click(object sender, EventArgs e)
        {
            IPDReport.rptMJPJAYConsentfrom11 cryRptNew = new IPDReport.rptMJPJAYConsentfrom11();


            TableLogOnInfos crtableLogoninfosNew = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfoNew = new TableLogOnInfo();
            ConnectionInfo crConnectionInfoNew = new ConnectionInfo();
            Tables CrTablesNew;


            //crConnectionInfo.IntegratedSecurity = true;
            //crConnectionInfo.ServerName = "SERVER\\SQLEXPRESS";
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

            cryRptNew.SetParameterValue("IPDID", PatientIPD_Public);

            ReportViewerForOPD obj = new ReportViewerForOPD();
            //frmrptLabPaymentReceipt obj = new frmrptLabPaymentReceipt();
            obj.crystalReportViewer1.ReportSource = cryRptNew;
            obj.Refresh();
            obj.Show();

            this.Close();

        }

        private void DVGMJPJAYAddSurgery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex==0)
            //{

            //}
        }

        private void txtMJPJAYNO_TextChanged(object sender, EventArgs e)
        {
            SqlCommand CMD = new SqlCommand("Select MJPJAY_NO FROM MJPJAY_PatientDetailsnew WHERE MJPJAY_NO=@MJPJAY_NO", connection1);
            CMD.Parameters.AddWithValue("MJPJAY_NO", txtMJPJAYNO.Text);
            SqlDataReader SQLreader1;
            connection1.Open();
            SQLreader1 = CMD.ExecuteReader();
            if (SQLreader1.Read())
            {
                MessageBox.Show("The number is already taken. Please Enter a different number");
                connection1.Close();
            }
            else
            {
                connection1.Close();
            }
        }

        private void DVGMJPJAYAddSurgery_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && DVGMJPJAYAddSurgery.CurrentCell.Value != null)
            {
                foreach (DataGridViewRow row in this.DVGMJPJAYAddSurgery.Rows)
                {
                    if (row.Index == this.DVGMJPJAYAddSurgery.CurrentCell.RowIndex)
                    {
                        continue;
                    }
                    if (this.DVGMJPJAYAddSurgery.CurrentCell.Value == null)
                    {
                        continue;
                    }
                    if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() == DVGMJPJAYAddSurgery.CurrentCell.Value.ToString())
                    {
                        MessageBox.Show("The number is already taken. Please Enter a different number");
                        DVGMJPJAYAddSurgery.CurrentCell.Value = null;
                    }
                }
            }
        }
    }
            
 }

