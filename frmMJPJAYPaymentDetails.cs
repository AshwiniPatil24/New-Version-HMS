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
    public partial class frmMJPJAYPaymentDetails : Form
    {
        SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
     
        public int PatientIPDId_Public;
        public string PatientMJPJAY_Public;
        public int PatientMJPJAYID_Public;

        public frmMJPJAYPaymentDetails()
        {
            InitializeComponent();

            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew where  Doctor_Check=1 AND Received=0", connection1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dtMJPJAY_Details1 = new DataTable();
            sd.Fill(dtMJPJAY_Details1);
            DVGMJPJAYPyment.DataSource = dtMJPJAY_Details1;
            if (DVGMJPJAYPyment.RowCount > 0)
            {
                PatientIPDId_Public = Convert.ToInt32(dtMJPJAY_Details1.Rows[0]["IPDID"]);
                PatientMJPJAY_Public = Convert.ToString(dtMJPJAY_Details1.Rows[0]["MJPJAY_NO"]);
                PatientMJPJAYID_Public = Convert.ToInt32(dtMJPJAY_Details1.Rows[0]["MJPJAY_ID"]);
                DVGMJPJAYPyment.Columns["Date"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_MainCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_SubCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_Surgery"].HeaderText = "MJPJAY Surgery Name";
                DVGMJPJAYPyment.Columns["Surgery_Date"].HeaderText = "Surgery Date";
                DVGMJPJAYPyment.Columns["Doctor_Check"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_ID"].Visible = false;
                DVGMJPJAYPyment.Columns["Received"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial_Amount"].Visible = false;
                DVGMJPJAYPyment.Columns["Remark"].HeaderText = "    Add Remark     ";
                DVGMJPJAYPyment.Columns["Anaesthesia"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID1"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID2"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID1"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID2"].Visible = false;

                DVGMJPJAYPyment.Columns[1].ReadOnly = true;
                DVGMJPJAYPyment.Columns[2].ReadOnly = true;
                DVGMJPJAYPyment.Columns[3].ReadOnly = true;
                DVGMJPJAYPyment.Columns[4].ReadOnly = true;
                DVGMJPJAYPyment.Columns[5].ReadOnly = true;
                DVGMJPJAYPyment.Columns[6].ReadOnly = true;
                DVGMJPJAYPyment.Columns[7].ReadOnly = true;
                DVGMJPJAYPyment.Columns[8].ReadOnly = true;
                DVGMJPJAYPyment.Columns[9].ReadOnly = true;
                DVGMJPJAYPyment.Columns[10].ReadOnly = true;
            }
            else
            {
                MessageBox.Show("No Records Found");
            }

            connection1.Close();
        }

        private void frmMJPJAYPaymentDetails_Load(object sender, EventArgs e)
        {
            //btnRefresh.Visible = false;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew where  Doctor_Check=1 AND Received=0", connection1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dtMJPJAY_Details1 = new DataTable();
            sd.Fill(dtMJPJAY_Details1);
            DVGMJPJAYPyment.DataSource = dtMJPJAY_Details1;
            if (DVGMJPJAYPyment.RowCount > 0)
            {
                PatientIPDId_Public = Convert.ToInt32(dtMJPJAY_Details1.Rows[0]["IPDID"]);
                PatientMJPJAY_Public = Convert.ToString(dtMJPJAY_Details1.Rows[0]["MJPJAY_NO"]);
                PatientMJPJAYID_Public = Convert.ToInt32(dtMJPJAY_Details1.Rows[0]["MJPJAY_ID"]);
                DVGMJPJAYPyment.Columns["Date"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_MainCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_SubCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_Surgery"].HeaderText = "MJPJAY Surgery Name";
                DVGMJPJAYPyment.Columns["Surgery_Date"].HeaderText = "Surgery Date";
                DVGMJPJAYPyment.Columns["Doctor_Check"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_ID"].Visible = false;
                DVGMJPJAYPyment.Columns["Received"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial_Amount"].Visible = false;
                DVGMJPJAYPyment.Columns["Remark"].HeaderText = "    Add Remark     ";
                DVGMJPJAYPyment.Columns["Anaesthesia"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID1"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID2"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID1"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID2"].Visible = false;
                DVGMJPJAYPyment.Columns[1].ReadOnly = true;
                DVGMJPJAYPyment.Columns[2].ReadOnly = true;
                DVGMJPJAYPyment.Columns[3].ReadOnly = true;
                DVGMJPJAYPyment.Columns[4].ReadOnly = true;
                DVGMJPJAYPyment.Columns[5].ReadOnly = true;
                DVGMJPJAYPyment.Columns[6].ReadOnly = true;
                DVGMJPJAYPyment.Columns[7].ReadOnly = true;
                DVGMJPJAYPyment.Columns[8].ReadOnly = true;
                DVGMJPJAYPyment.Columns[9].ReadOnly = true;
                DVGMJPJAYPyment.Columns[10].ReadOnly = true;
            }
            else
            {
                MessageBox.Show("No Records Found");
                DVGMJPJAYPyment.Columns["Date"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_MainCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_SubCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_Surgery"].HeaderText = "MJPJAY Surgery Name";
                DVGMJPJAYPyment.Columns["Surgery_Date"].HeaderText = "Surgery Date";
                DVGMJPJAYPyment.Columns["Doctor_Check"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_ID"].Visible = false;
                DVGMJPJAYPyment.Columns["Received"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial_Amount"].Visible = false;
                DVGMJPJAYPyment.Columns["Remark"].HeaderText = "    Add Remark     ";
                DVGMJPJAYPyment.Columns["Anaesthesia"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID1"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID2"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID1"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID2"].Visible = false;
            }
            connection1.Close();
        }

        private void DVGMJPJAYPyment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.DVGMJPJAYPyment.Columns[e.ColumnIndex].Name;


            if (columnName.Equals("Column1") == true)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {

                    //PatientMJPJAY_Public = Convert.ToString(DVGMJPJAYPyment.CurrentRow.Cells["MJPJAY_NO"].Value);
                    PatientMJPJAYID_Public = Convert.ToInt32(DVGMJPJAYPyment.CurrentRow.Cells["MJPJAY_NO"].Value);
                    frmMJPJAYPaymentUpdateStatus o = new frmMJPJAYPaymentUpdateStatus(PatientMJPJAYID_Public);
                    o.Show();
                    //this.Close();

                }
                //this.Load(object sender, EventArgs e);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            if (DVGMJPJAYPyment.Rows.Count > 0)
            {
                int[] TestIdArr = new int[DVGMJPJAYPyment.Rows.Count];
                for (int i = 0; i < DVGMJPJAYPyment.Rows.Count; i++)
                {

                    if (Convert.ToBoolean(DVGMJPJAYPyment["Doctor_Check", i].EditedFormattedValue))
                   {

                        int MJPJAY_ID = Convert.ToInt32(DVGMJPJAYPyment["MJPJAY_ID", i].Value);
                        int IPDID = Convert.ToInt32(DVGMJPJAYPyment["IPDID", i].Value);
                        string MJPJAY_NO = Convert.ToString(DVGMJPJAYPyment["MJPJAY_NO", i].Value);
                        DateTime Date = Convert.ToDateTime(DVGMJPJAYPyment["Date", i].Value);
                        int MJPJAY_MainCategory = Convert.ToInt32(DVGMJPJAYPyment["MJPJAY_MainCategory", i].Value);
                        int MJPJAY_SubCategory = Convert.ToInt32(DVGMJPJAYPyment["MJPJAY_SubCategory", i].Value);
                        string MJPJAY_Surgery = Convert.ToString(DVGMJPJAYPyment["MJPJAY_Surgery", i].Value);

                        Decimal PackageAmount = Convert.ToDecimal(DVGMJPJAYPyment["PackageAmount", i].Value);
                        int Doctor_Check = Convert.ToInt32(DVGMJPJAYPyment["Doctor_Check", i].Value);
                        DateTime Surgery_Date = Convert.ToDateTime(DVGMJPJAYPyment["Surgery_Date", i].Value);
                        Decimal Due_Amount = Convert.ToDecimal(DVGMJPJAYPyment["Due_Amount", i].Value);
                        Decimal Partial_Amount = Convert.ToDecimal(DVGMJPJAYPyment["Partial_Amount", i].Value);
                        int Received = Convert.ToInt32(DVGMJPJAYPyment["Received", i].Value);
                        int Partial = Convert.ToInt32(DVGMJPJAYPyment["Partial", i].Value);
                        string Remark = Convert.ToString(DVGMJPJAYPyment["Remark", i].Value);

                        connection1.Open();
                        SqlCommand cmd = new SqlCommand(@"UPDATE MJPJAY_PatientDetailsnew  SET  IPDID=@IPDID, MJPJAY_Surgery=@MJPJAY_Surgery,PackageAmount=@PackageAmount, Doctor_Check=@Doctor_Check, Due_Amount=@Due_Amount, Partial_Amount=@Partial_Amount, Received=@Received, Partial=@Partial, Remark=@Remark WHERE MJPJAY_NO=@MJPJAY_NO", connection1);
                        cmd.Parameters.AddWithValue(@"IPDID", IPDID);
                        cmd.Parameters.AddWithValue(@"MJPJAY_NO", MJPJAY_NO);
                        cmd.Parameters.AddWithValue(@"MJPJAY_Surgery", MJPJAY_Surgery);
                        cmd.Parameters.AddWithValue(@"PackageAmount", PackageAmount);
                        cmd.Parameters.AddWithValue(@"Doctor_Check", Doctor_Check);
                        cmd.Parameters.AddWithValue(@"Due_Amount", Due_Amount);
                        cmd.Parameters.AddWithValue(@"Partial_Amount", Partial_Amount);
                        cmd.Parameters.AddWithValue(@"Received", Received);
                        cmd.Parameters.AddWithValue(@"Partial", Partial);
                        cmd.Parameters.AddWithValue(@"Remark", Remark);
                        cmd.ExecuteNonQuery();
                        connection1.Close();
                    }
                }
                MessageBox.Show("Record Save Successfully...");
                //btnRefresh.Visible = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"select * from MJPJAY_PatientDetailsnew where  Doctor_Check=1 AND Received=0", connection1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dtMJPJAY_Details1 = new DataTable();
            sd.Fill(dtMJPJAY_Details1);
            DVGMJPJAYPyment.DataSource = dtMJPJAY_Details1;
            if (DVGMJPJAYPyment.RowCount > 0)
            {
                PatientIPDId_Public = Convert.ToInt32(dtMJPJAY_Details1.Rows[0]["IPDID"]);
                PatientMJPJAY_Public = Convert.ToString(dtMJPJAY_Details1.Rows[0]["MJPJAY_NO"]);
                PatientMJPJAYID_Public = Convert.ToInt32(dtMJPJAY_Details1.Rows[0]["MJPJAY_ID"]);
                DVGMJPJAYPyment.Columns["Date"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_MainCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_SubCategory"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_Surgery"].HeaderText = "MJPJAY Surgery Name";
                DVGMJPJAYPyment.Columns["Surgery_Date"].HeaderText = "Surgery Date";
                DVGMJPJAYPyment.Columns["Doctor_Check"].Visible = false;
                DVGMJPJAYPyment.Columns["MJPJAY_ID"].Visible = false;
                DVGMJPJAYPyment.Columns["Received"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial"].Visible = false;
                DVGMJPJAYPyment.Columns["Partial_Amount"].Visible = false;
                DVGMJPJAYPyment.Columns["Remark"].HeaderText = "    Add Remark     ";
                DVGMJPJAYPyment.Columns["Anaesthesia"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID1"].Visible = false;
                DVGMJPJAYPyment.Columns["SurgeonID2"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID1"].Visible = false;
                DVGMJPJAYPyment.Columns["AssistantID2"].Visible = false;
                DVGMJPJAYPyment.Columns[1].ReadOnly = true;
                DVGMJPJAYPyment.Columns[2].ReadOnly = true;
                DVGMJPJAYPyment.Columns[3].ReadOnly = true;
                DVGMJPJAYPyment.Columns[4].ReadOnly = true;
                DVGMJPJAYPyment.Columns[5].ReadOnly = true;
                DVGMJPJAYPyment.Columns[6].ReadOnly = true;
                DVGMJPJAYPyment.Columns[7].ReadOnly = true;
                DVGMJPJAYPyment.Columns[8].ReadOnly = true;
                DVGMJPJAYPyment.Columns[9].ReadOnly = true;
                DVGMJPJAYPyment.Columns[10].ReadOnly = true;
            }
            connection1.Close();
        }

        private void lblFillOPD_Click(object sender, EventArgs e)
        {

        }
    }
}
