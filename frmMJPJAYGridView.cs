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
    public partial class frmMJPJAYGridView : Form
    {
        public string MJPJAY_INSU;
        public int Patient_ID;
        public int Patient_IPDID;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        public frmMJPJAYGridView()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmMJPJAYGridView_Load(object sender, EventArgs e)
        {
            show();
            MJPJAY_INSU = "YES";
        }

        public void show()
        {
            connection.Open();

            SqlCommand cmb = new SqlCommand(@"SELECT           Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.IPD_Registration.IPD_ID,Ruby_Jamner123.Patient_Registration.Name,Ruby_Jamner123.Patient_Registration.Gender,Ruby_Jamner123.IPD_Registration.ConsultantID,Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID,Ruby_Jamner123.Patient_Registration.PID,Ruby_Jamner123.IPD_Registration.IPDID
FROM            Ruby_Jamner123.Patient_Registration INNER JOIN
                         Ruby_Jamner123.IPD_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
where Ruby_Jamner123.IPD_Registration.DischargeDate is NULL", connection);
                SqlDataAdapter adt = new SqlDataAdapter(cmb);
                DataTable o = new DataTable();
                adt.Fill(o);
                if (o.Rows.Count > 0)
                {
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.DataSource = o;
                   
                    dataGridView1.Columns["PID"].Visible = false;

                    dataGridView1.Columns["IPDID"].Visible = false;
                    dataGridView1.Columns["ConsultantID"].HeaderText = "Consultant Name";
                   dataGridView1.Columns["Adhaar_ID"].HeaderText = "Aadhar_ID";
                   dataGridView1.Columns["Reserred_By"].HeaderText = "Referred_By";

            }
            }

            //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            //{
            //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //        return;
            //    string columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;
            //    if (columnName.Equals("Name") == true)
            //    {
            //        try
            //        {
            //            PID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PID"].Value);
            //            ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IPDID"].Value);
            //           IPD_Registration o = new IPD_Registration(PID, ID);
            //            o.Show();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("Name") == true)
            {
                try
                {
                    Patient_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PID"].Value);
                    Patient_IPDID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IPDID"].Value);
                    IPD_Registration o = new IPD_Registration(MJPJAY_INSU,Patient_ID, Patient_IPDID);
                    o.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
    }
 }

