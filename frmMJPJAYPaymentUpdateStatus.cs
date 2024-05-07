using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class frmMJPJAYPaymentUpdateStatus : Form
    {
        SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);

        //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        //public string PatientMJPJAY_Public;
        public int PatientMJPJAYID_Public1;
        public int Flag;
        public int PublicIPDID;
        public string PublicMJPJAYNO;
        public DateTime publicMJPJAYDate;
        public int PublicMJPJAYMain;
        public int PublicMjpjaysub;
        public string PublicMJPJAYSurgery;
        public decimal PublicPackageAmount;
        public int publicDoctor_Check;
        public DateTime publicSurgery_Date;
        public decimal publicDue_Amount;
        public decimal publicDue_Partial;

        public frmMJPJAYPaymentUpdateStatus(int PatientMJPJAYID_Public)
        {
           
            InitializeComponent();
            txtpartial.Visible = false;
            PatientMJPJAYID_Public1 = PatientMJPJAYID_Public;
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew where  Doctor_Check=1 and MJPJAY_NO=@MJPJAY_NO", connection1);
            cmd.Parameters.AddWithValue(@"MJPJAY_NO", PatientMJPJAYID_Public1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dtMJPJAY_Details = new DataTable();
            sd.Fill(dtMJPJAY_Details);

            PublicIPDID = Convert.ToInt32(dtMJPJAY_Details.Rows[0]["IPDID"]);
            PublicMJPJAYNO  =Convert.ToString(dtMJPJAY_Details.Rows[0]["MJPJAY_NO"]);
            publicMJPJAYDate =Convert.ToDateTime(dtMJPJAY_Details.Rows[0]["Date"]);
            PublicMJPJAYMain = Convert.ToInt32(dtMJPJAY_Details.Rows[0]["MJPJAY_MainCategory"]);
            PublicMjpjaysub = Convert.ToInt32(dtMJPJAY_Details.Rows[0]["MJPJAY_SubCategory"]);
            PublicMJPJAYSurgery = Convert.ToString(dtMJPJAY_Details.Rows[0]["MJPJAY_Surgery"]);
            PublicPackageAmount = Convert.ToDecimal(dtMJPJAY_Details.Rows[0]["PackageAmount"]);
            publicDoctor_Check = Convert.ToInt32(dtMJPJAY_Details.Rows[0]["Doctor_Check"]);
            publicSurgery_Date = Convert.ToDateTime(dtMJPJAY_Details.Rows[0]["Surgery_Date"]);
            publicDue_Amount = Convert.ToDecimal(dtMJPJAY_Details.Rows[0]["Due_Amount"]);
            publicDue_Partial = Convert.ToDecimal(dtMJPJAY_Details.Rows[0]["Partial_Amount"]);


            if (Convert.ToInt32(dtMJPJAY_Details.Rows[0]["Received"]) == 1)
                      chbReceived.CheckState = CheckState.Checked;
                    else
                        chbReceived.CheckState = CheckState.Unchecked;

                    if (Convert.ToInt32(dtMJPJAY_Details.Rows[0]["Partial"]) == 1)
                        chbPartial.CheckState = CheckState.Checked;
                    else
                     chbPartial.CheckState = CheckState.Unchecked;

                    txtpartial.DataBindings.Add("Text", dtMJPJAY_Details, "Partial_Amount");
            connection1.Close();
        }

        private void chbReceived_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReceived.Checked)
            {
               
                chbPartial.Enabled = false;
                txtpartial.Visible = false;
            }
            else
            {
                chbPartial.Enabled = true;
                
            }

        }

        private void chbPartial_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPartial.Checked)
            {

                chbReceived.Enabled = false;
                txtpartial.Visible = true;
            }
            else
            {

                chbReceived.Enabled = true;
                txtpartial.Visible = false;
            }
        }

        private void frmMJPJAYPaymentUpdateStatus_Load(object sender, EventArgs e)
        {
            txtpartial.Visible = false;
        }
       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                connection1.Open();
                   SqlCommand cmd = new SqlCommand(@"UPDATE MJPJAY_PatientDetailsnew  SET IPDID=@IPDID,PackageAmount=@PackageAmount,Doctor_Check=@Doctor_Check, Due_Amount=@Due_Amount, Partial_Amount=@Partial_Amount,Received=@Received,Partial=@Partial WHERE MJPJAY_NO=@MJPJAY_NO", connection1);
                cmd.Parameters.AddWithValue(@"IPDID", PublicIPDID);
                cmd.Parameters.AddWithValue(@"MJPJAY_NO", PatientMJPJAYID_Public1);
                cmd.Parameters.AddWithValue(@"PackageAmount", PublicPackageAmount);
                cmd.Parameters.AddWithValue(@"Doctor_Check", publicDoctor_Check);
                cmd.Parameters.AddWithValue(@"Due_Amount", publicDue_Amount);
                cmd.Parameters.AddWithValue(@"Partial_Amount", Convert.ToDecimal(txtpartial.Text));
                if (chbReceived.CheckState == CheckState.Checked)
                    cmd.Parameters.AddWithValue(@"Received", 1);
                else
                    cmd.Parameters.AddWithValue(@"Received", 0);

                if (chbPartial.CheckState == CheckState.Checked)
                    cmd.Parameters.AddWithValue(@"Partial", 1);
                else
                    cmd.Parameters.AddWithValue(@"Partial", 0);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Status Updated Successfully...");
                connection1.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
