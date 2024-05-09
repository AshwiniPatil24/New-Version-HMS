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

namespace Ruby_Hospital
{
    public partial class Lab_And_Radiology_Billing : Form
    {
        public int PID;
        public int IPDID;
        public int OPDID;
        public Lab_And_Radiology_Billing()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void showlablist()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            DataTable dataTable1 = ExecuteQuery(@"SELECT distinct Ruby_Jamner123.Patient_Registration.Purpose,Ruby_Jamner123.Patient_Registration.Patient_Id,Ruby_Jamner123.Patient_Registration.PID,Ruby_Jamner123.IPD_Registration.IPDID,Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID,
                         Ruby_Jamner123.Patient_Registration.Doctors_Name
                        FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
                         inner join Ruby_Jamner123.AssignIPDLabTest on Ruby_Jamner123.AssignIPDLabTest.IPDID = Ruby_Jamner123.IPD_Registration.IPDID");

            DataTable dataTable2 = ExecuteQuery(@"select distinct Ruby_Jamner123.Patient_Registration.Purpose,Patient_Registration.PID,Patient_Registration.Patient_Id,Patient_Registration.Name, Patient_Registration.Age, Patient_Registration.Mobile_Number, Patient_Registration.Adhaar_ID,OPD_Patient_Registration.patientopdid,OPD_Patient_Registration.patientopdidwithsr,AssignOnlyTest_Lab.OPDID from 
OPD_Patient_Registration inner join patient_registration on patient_registration.pid = OPD_Patient_Registration.patientid
inner join AssignOnlyTest_Lab on AssignOnlyTest_Lab.opdid = OPD_Patient_Registration.patientopdid");

            DataTable mergedDataTable = MergeDataTables(dataTable1, dataTable2);
            labbilling.DataSource = mergedDataTable;
            labbilling.Columns["IPDID"].Visible = false;
            labbilling.Columns["PID"].Visible = false;
            labbilling.Columns["patientopdid"].Visible = false;
            labbilling.Columns["OPDID"].Visible = false;
            labbilling.Columns["Purpose"].Visible = false;
        }

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner"))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private DataTable MergeDataTables(DataTable dataTable1, DataTable dataTable2)
        {
            DataTable mergedDataTable = new DataTable();
            mergedDataTable.Merge(dataTable1);
            mergedDataTable.Merge(dataTable2);
            return mergedDataTable;
        }

        public void showradiologylist()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            DataTable datatable1 = ExecuteQuery(@"SELECT distinct Ruby_Jamner123.Patient_Registration.Purpose,Ruby_Jamner123.Patient_Registration.Patient_Id,Ruby_Jamner123.Patient_Registration.PID,Ruby_Jamner123.IPD_Registration.IPDID,Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Age, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID,
                         Ruby_Jamner123.Patient_Registration.Doctors_Name
                        FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id
                         inner join Ruby_Jamner123.Assign_IPDRadiology_test on Ruby_Jamner123.Assign_IPDRadiology_test.IPDID = Ruby_Jamner123.IPD_Registration.IPDID");
            DataTable datatable2 = ExecuteQuery(@"select distinct Ruby_Jamner123.Patient_Registration.Purpose,Patient_Registration.PID,Patient_Registration.Patient_Id,Patient_Registration.Name, Patient_Registration.Age, Patient_Registration.Mobile_Number, Patient_Registration.Adhaar_ID,OPD_Patient_Registration.patientopdid,OPD_Patient_Registration.patientopdidwithsr,AssignOnlyTest_Radiology.OPDID from 
OPD_Patient_Registration inner join patient_registration on patient_registration.pid = OPD_Patient_Registration.patientid
inner join AssignOnlyTest_Radiology on AssignOnlyTest_Radiology.OPDID = OPD_Patient_Registration.patientopdid");
            DataTable mergedDataTable = MergeDataTables(datatable1, datatable2);
            radiologybilling.DataSource = mergedDataTable;
            //radiologybilling.Columns["IPDID"].Visible = false;
            radiologybilling.Columns["PID"].Visible = false;
            radiologybilling.Columns["patientopdid"].Visible = false;
            //radiologybilling.Columns["OPDID"].Visible = false;
            //radiologybilling.Columns["Purpose"].Visible = false;
        }

        private void Lab_And_Radiology_Billing_Load(object sender, EventArgs e)
        {
            showlablist();
            showradiologylist();
        }

        private void labbilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.labbilling.Columns[e.ColumnIndex].Name;

            if (columnName.Equals("Name") == true)
            {
                try
                {
                    string purpose = labbilling.CurrentRow.Cells["Purpose"].Value.ToString();
                    PID = Convert.ToInt32(labbilling.CurrentRow.Cells["PID"].Value);
                    if (purpose.Equals("IPD"))
                    {
                        IPDID = Convert.ToInt32(labbilling.CurrentRow.Cells["IPDID"].Value);
                        Lab_Bill lab_Bill = new Lab_Bill(IPDID,PID,purpose,"LAB");
                        lab_Bill.ShowDialog();
                    }
                    else
                    {
                        OPDID = Convert.ToInt32(labbilling.CurrentRow.Cells["OPDID"].Value);
                        Lab_Bill lab_Bill = new Lab_Bill(OPDID,PID,"LAB");
                        lab_Bill.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void radiologybilling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string columnName = this.radiologybilling.Columns[e.ColumnIndex].Name;

            if (columnName.Equals("Name") == true)
            {
                try
                {
                    string purpose = radiologybilling.CurrentRow.Cells["Purpose"].Value.ToString();
                    PID = Convert.ToInt32(radiologybilling.CurrentRow.Cells["PID"].Value);
                    if (purpose.Equals("IPD"))
                    {
                        IPDID = Convert.ToInt32(radiologybilling.CurrentRow.Cells["IPDID"].Value);
                        Lab_Bill lab_Bill = new Lab_Bill(IPDID, PID, purpose, "RADIOLOGY");
                        lab_Bill.ShowDialog();
                    }
                    else
                    {
                        OPDID = Convert.ToInt32(radiologybilling.CurrentRow.Cells["OPDID"].Value);
                        Lab_Bill lab_Bill = new Lab_Bill(OPDID, PID, "RADIOLOGY");
                        lab_Bill.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void labbilling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
