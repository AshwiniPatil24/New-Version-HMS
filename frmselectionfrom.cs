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
    public partial class frmselectionfrom : Form
    {
        SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);

        public static int id;
        public static int ipdid;

        public frmselectionfrom()
        {
            InitializeComponent();
        }
        public frmselectionfrom(int a, int b)
        {
            InitializeComponent();
            id = a;
            ipdid = b;
        }
        private void frmselectionfrom_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                MessageBox.Show("Selected Surgery Type is Cash", "Message 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Are you sure this patient Surgery is register on CASH", "Message 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IPD_Surgical_Procedure o = new IPD_Surgical_Procedure(id, ipdid);
                o.ShowDialog();
                checkBox1.Enabled = false;
                chkInsurance.Enabled = false;
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                connection1.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT       dbo.MJPJAY_PatientDetailsnew.MJPJAY_NO, Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.IPD_Registration.IPD_ID, Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Gender, 
                         Ruby_Jamner123.IPD_Registration.ConsultantID, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID, Ruby_Jamner123.Patient_Registration.PID, 
                         Ruby_Jamner123.IPD_Registration.IPDID, Ruby_Jamner123.IPD_Registration.Room_Segment, Ruby_Jamner123.IPD_Registration.Bed_No, Ruby_Jamner123.IPD_Registration.Mediclaim, 
                         Ruby_Jamner123.IPD_Registration.Date_Of_Admission, Ruby_Jamner123.IPD_Registration.Reserred_By
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id INNER JOIN
                         dbo.MJPJAY_PatientDetailsnew ON Ruby_Jamner123.IPD_Registration.IPDID = dbo.MJPJAY_PatientDetailsnew.IPDID
WHERE        (Ruby_Jamner123.IPD_Registration.IPDID = @IPDID)", connection1);
                cmd.Parameters.AddWithValue("@IPDID", ipdid);
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Selected Surgery Type is MJPJAY", "Message 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Are you sure this patient Surgery is register on MJPJAY", "Message 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMJPJAYDoctor o = new frmMJPJAYDoctor(id, ipdid);
                    o.ShowDialog();
                    checkBox2.Enabled = false;
                    chkInsurance.Enabled = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This patient is not found in MJPJAY");
                }
                connection1.Close();
            }
        }

        private void chkInsurance_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
