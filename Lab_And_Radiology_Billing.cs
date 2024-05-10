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
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void showlablist()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            DataTable dataTable1 = ExecuteQuery(@"SELECT DISTINCT Ruby_Jamner123.Patient_Registration.Purpose, Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.IPD_Registration.IPDID, 
                         Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID, 
                         Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.Patient_Registration.Age
FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id INNER JOIN
                         Ruby_Jamner123.AssignIPDLabTest ON Ruby_Jamner123.AssignIPDLabTest.IPDID = Ruby_Jamner123.IPD_Registration.IPDID LEFT OUTER JOIN
                         Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest ON Ruby_Jamner123.AssignIPDLabTest.IPDID = Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.IPDID
WHERE        (Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Balance IS NULL) OR
                         (Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Balance != 0)");

            DataTable dataTable2 = ExecuteQuery(@"SELECT DISTINCT 
                         Ruby_Jamner123.Patient_Registration.Purpose, Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.Name, 
                          Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID, Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId, 
                         Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr, Ruby_Jamner123.AssignOnlyTest_Lab.OPDID, Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Balance,Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Bill_Amount,Ruby_Jamner123.Patient_Registration.Age
FROM            Ruby_Jamner123.OPD_Patient_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.OPD_Patient_Registration.PatientId INNER JOIN
                         Ruby_Jamner123.AssignOnlyTest_Lab ON Ruby_Jamner123.AssignOnlyTest_Lab.OPDID = Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId LEFT OUTER JOIN
                         Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest ON Ruby_Jamner123.AssignOnlyTest_Lab.OPDID = Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.OPDID WHERE Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Balance IS NULL OR Ruby_Jamner123.PatientTestBilling_IPDnOnlyTest.Balance !=0");

            DataTable mergedDataTable = MergeDataTables(dataTable1, dataTable2);
            labbilling.DataSource = mergedDataTable;
            labbilling.Columns["IPDID"].Visible = false;
            labbilling.Columns["PID"].Visible = false;
            labbilling.Columns["patientopdid"].Visible = false;
            labbilling.Columns["OPDID"].Visible = false;
            labbilling.Columns["Purpose"].Visible = true;
            labbilling.Columns["Adhaar_ID"].Visible = false;
            labbilling.Columns["Mobile_Number"].Visible = false;
            labbilling.Columns["PatientOPDIdWithSr"].Visible = false;
            labbilling.Columns["Balance"].Visible = false;
            labbilling.Columns["Bill_Amount"].Visible = false;
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
            DataTable datatable1 = ExecuteQuery(@"
						 SELECT DISTINCT 
                         Ruby_Jamner123.Patient_Registration.Purpose, Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.IPD_Registration.IPDID, 
                         Ruby_Jamner123.Patient_Registration.Name, Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID, 
                         Ruby_Jamner123.Patient_Registration.Doctors_Name, Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance, Ruby_Jamner123.Patient_Registration.Age
FROM            Ruby_Jamner123.IPD_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.IPD_Registration.Patient_Id INNER JOIN
                         Ruby_Jamner123.Assign_IPDRadiology_test ON Ruby_Jamner123.Assign_IPDRadiology_test.IPDID = Ruby_Jamner123.IPD_Registration.IPDID LEFT OUTER JOIN
                         Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest ON Ruby_Jamner123.Assign_IPDRadiology_test.IPDID = Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.IPDID WHERE Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance IS NULL OR Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance !=0");

            DataTable datatable2 = ExecuteQuery(@"SELECT DISTINCT Ruby_Jamner123.Patient_Registration.Purpose, Ruby_Jamner123.Patient_Registration.PID, Ruby_Jamner123.Patient_Registration.Patient_ID, Ruby_Jamner123.Patient_Registration.Name, 
                          Ruby_Jamner123.Patient_Registration.Mobile_Number, Ruby_Jamner123.Patient_Registration.Adhaar_ID, Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId, 
                         Ruby_Jamner123.OPD_Patient_Registration.PatientOPDIdWithSr, Ruby_Jamner123.AssignOnlyTest_Radiology.OPDID, Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance, Ruby_Jamner123.Patient_Registration.Age
FROM            Ruby_Jamner123.OPD_Patient_Registration INNER JOIN
                         Ruby_Jamner123.Patient_Registration ON Ruby_Jamner123.Patient_Registration.PID = Ruby_Jamner123.OPD_Patient_Registration.PatientId INNER JOIN
                         Ruby_Jamner123.AssignOnlyTest_Radiology ON Ruby_Jamner123.AssignOnlyTest_Radiology.OPDID = Ruby_Jamner123.OPD_Patient_Registration.PatientOPDId LEFT OUTER JOIN
                         Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest ON Ruby_Jamner123.AssignOnlyTest_Radiology.OPDID = Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.OPDID WHERE Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance IS NULL OR Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest.Balance !=0");
            DataTable mergedDataTable = MergeDataTables(datatable1, datatable2);
            radiologybilling.DataSource = mergedDataTable;
            //radiologybilling.Columns["IPDID"].Visible = false;
            radiologybilling.Columns["PID"].Visible = false;
            radiologybilling.Columns["PatientOPDId"].Visible = false;

            radiologybilling.Columns["Adhaar_ID"].Visible = false;
            radiologybilling.Columns["Balance"].Visible = false;

            radiologybilling.Columns["IPDID"].Visible = false;
            radiologybilling.Columns["Mobile_Number"].Visible = false;
            radiologybilling.Columns["IPDID"].Visible = false;
            radiologybilling.Columns["OPDID"].Visible = false;
            radiologybilling.Columns["PatientOPDIdWithSr"].Visible = false;
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
