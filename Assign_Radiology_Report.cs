using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class Assign_Radiology_Report : Form
    {
        public int PID;
        public string type;

        public Assign_Radiology_Report()
        {
            InitializeComponent();
        }

        private void DeleteAllButtons(DataGridView dataGridView)
        {
            List<DataGridViewColumn> list = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column is DataGridViewButtonColumn)
                {
                    list.Add(column);
                }
            }
            foreach (DataGridViewColumn column2 in list)
            {
                dataGridView.Columns.Remove(column2);
            }
            foreach (DataGridViewRow row in (IEnumerable)dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is DataGridViewButtonCell)
                    {
                        row.Cells[cell.ColumnIndex] = new DataGridViewTextBoxCell();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.type == "IPD")
                {

                    SqlConnection connection = new SqlConnection("Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        // Skip the last empty row if DataGridView's AllowUserToAddRows is set to true
                        if (row.IsNewRow)
                            continue;

                        string str = row.Cells["Patient_ID"].Value.ToString();
                        string str2 = row.Cells["Name"].Value.ToString();
                        string str3 = row.Cells["IPD_ID"].Value.ToString();
                        string str4 = "";
                        string str5 = row.Cells["RadiologyName"].Value.ToString();
                        string str6 = row.Cells["TestDate"].Value.ToString();
                        string str7 = row.Cells["Sample_Date"].Value.ToString();
                        string str8 = row.Cells["Report_Date"].Value.ToString();
                        string str9 = row.Cells["Attached_File"].Value.ToString();

                        SqlCommand command = new SqlCommand("insert into Ruby_Jamner123.Assign_Radiology_Report (Patient_ID,Name,IPD_ID,OPD_ID,Test_Name,Test_Date,Sample_Date,Report_Date,Attached_File) \r\nvalues(@Patient_ID,@Name,@IPD_ID,@OPD_ID,@Test_Name,@Test_Date,@Sample_Date,@Report_Date,@Attached_File)", connection);
                        command.Parameters.AddWithValue("@Patient_ID", str);
                        command.Parameters.AddWithValue("@Name", str2);
                        command.Parameters.AddWithValue("@IPD_ID", str3);
                        command.Parameters.AddWithValue("@OPD_ID", str4);
                        command.Parameters.AddWithValue("@Test_Name", str5);
                        command.Parameters.AddWithValue("@Test_Date", Convert.ToDateTime(str6));
                        command.Parameters.AddWithValue("@Sample_Date", Convert.ToDateTime(str7));
                        command.Parameters.AddWithValue("@Report_Date", Convert.ToDateTime(str8));
                        command.Parameters.AddWithValue("@Attached_File", str9);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Details saved successfully!!!");
                    this.btnSave.Enabled = false;
                    this.btnSave.BackColor = Color.Gray;
                }
                if (this.type == "Only Test")
                {
                    SqlConnection connection = new SqlConnection("Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    connection.Open();

                    foreach (DataGridViewRow row2 in dataGridView2.Rows)
                    {
                        // Skip the last empty row if DataGridView's AllowUserToAddRows is set to true
                        if (row2.IsNewRow)
                            continue;

                        string str10 = row2.Cells["Patient_ID"].Value.ToString();
                        string str11 = row2.Cells["Name"].Value.ToString();
                        string str12 = "";
                        string str13 = row2.Cells["OPD_ID"].Value.ToString();
                        string str14 = row2.Cells["RadiologyName"].Value.ToString();
                        string str15 = row2.Cells["TestDate"].Value.ToString();
                        string str16 = row2.Cells["Sample_Date"].Value.ToString();
                        string str17 = row2.Cells["Report_Date"].Value.ToString();
                        string str18 = row2.Cells["Attached_File"].Value.ToString();

                        SqlCommand command2 = new SqlCommand("insert into Ruby_Jamner123.Assign_Radiology_Report (Patient_ID,Name,IPD_ID,OPD_ID,Test_Name,Test_Date,Sample_Date,Report_Date,Attached_File) \r\nvalues(@Patient_ID,@Name,@IPD_ID,@OPD_ID,@Test_Name,@Test_Date,@Sample_Date,@Report_Date,@Attached_File)", connection);
                        command2.Parameters.AddWithValue("@Patient_ID", str10);
                        command2.Parameters.AddWithValue("@Name", str11);
                        command2.Parameters.AddWithValue("@IPD_ID", str12);
                        command2.Parameters.AddWithValue("@OPD_ID", str13);
                        command2.Parameters.AddWithValue("@Test_Name", str14);
                        command2.Parameters.AddWithValue("@Test_Date", Convert.ToDateTime(str15));
                        command2.Parameters.AddWithValue("@Sample_Date", Convert.ToDateTime(str16));
                        command2.Parameters.AddWithValue("@Report_Date", Convert.ToDateTime(str17));
                        command2.Parameters.AddWithValue("@Attached_File", str18);
                        command2.ExecuteNonQuery();

                    }
                    MessageBox.Show("Details saved successfully!!!");
                    this.btnSave.Enabled = false;
                    this.btnSave.BackColor = Color.Gray;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.type == "IPD")
                {

                    SqlConnection connection = new SqlConnection("Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        // Skip the last empty row if DataGridView's AllowUserToAddRows is set to true
                        if (row.IsNewRow)
                            continue;

                        string id = row.Cells["ID"].Value.ToString();
                        string str = row.Cells["Patient_ID"].Value.ToString();
                        string str2 = row.Cells["Name"].Value.ToString();
                        string str3 = row.Cells["IPD_ID"].Value.ToString();
                        string str4 = "";
                        string str5 = row.Cells["Test_Name"].Value.ToString();
                        string str6 = row.Cells["Test_Date"].Value.ToString();
                        string str7 = row.Cells["Sample_Date"].Value.ToString();
                        string str8 = row.Cells["Report_Date"].Value.ToString();
                        string str9 = row.Cells["Attached_File"].Value.ToString();

                        SqlCommand command = new SqlCommand("update Ruby_Jamner123.Assign_Radiology_Report set Patient_ID = @Patient_ID,Name = @Name,IPD_ID = @IPD_ID,OPD_ID = @OPD_ID,Test_Name = @Test_Name,Test_Date = @Test_Date,Sample_Date = @Sample_Date,Report_Date = @Report_Date,Attached_File = @Attached_File where ID = @ID", connection);
                        command.Parameters.AddWithValue("@Patient_ID", str);
                        command.Parameters.AddWithValue("@Name", str2);
                        command.Parameters.AddWithValue("@IPD_ID", str3);
                        command.Parameters.AddWithValue("@OPD_ID", str4);
                        command.Parameters.AddWithValue("@Test_Name", str5);
                        command.Parameters.AddWithValue("@Test_Date", Convert.ToDateTime(str6));
                        command.Parameters.AddWithValue("@Sample_Date", Convert.ToDateTime(str7));
                        command.Parameters.AddWithValue("@Report_Date", Convert.ToDateTime(str8));
                        command.Parameters.AddWithValue("@Attached_File", str9);
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Details saved successfully!!!");
                    button1.Enabled = false;
                    button1.BackColor = Color.Gray;
                }
                if (this.type == "Only Test")
                {
                    SqlConnection connection = new SqlConnection("Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    connection.Open();

                    foreach (DataGridViewRow row2 in dataGridView2.Rows)
                    {
                        // Skip the last empty row if DataGridView's AllowUserToAddRows is set to true
                        if (row2.IsNewRow)
                            continue;

                        string id = row2.Cells["ID"].Value.ToString();
                        string str10 = row2.Cells["Patient_ID"].Value.ToString();
                        string str11 = row2.Cells["Name"].Value.ToString();
                        string str12 = "";
                        string str13 = row2.Cells["OPD_ID"].Value.ToString();
                        string str14 = row2.Cells["Test_Name"].Value.ToString();
                        string str15 = row2.Cells["Test_Date"].Value.ToString();
                        string str16 = row2.Cells["Sample_Date"].Value.ToString();
                        string str17 = row2.Cells["Report_Date"].Value.ToString();
                        string str18 = row2.Cells["Attached_File"].Value.ToString();

                        SqlCommand command2 = new SqlCommand("update Ruby_Jamner123.Assign_Radiology_Report set Patient_ID = @Patient_ID,Name = @Name,IPD_ID = @IPD_ID,OPD_ID = @OPD_ID,Test_Name = @Test_Name,Test_Date = @Test_Date,Sample_Date = @Sample_Date,Report_Date = @Report_Date,Attached_File = @Attached_File where ID = @ID", connection);
                        command2.Parameters.AddWithValue("@Patient_ID", str10);
                        command2.Parameters.AddWithValue("@Name", str11);
                        command2.Parameters.AddWithValue("@IPD_ID", str12);
                        command2.Parameters.AddWithValue("@OPD_ID", str13);
                        command2.Parameters.AddWithValue("@Test_Name", str14);
                        command2.Parameters.AddWithValue("@Test_Date", Convert.ToDateTime(str15));
                        command2.Parameters.AddWithValue("@Sample_Date", Convert.ToDateTime(str16));
                        command2.Parameters.AddWithValue("@Report_Date", Convert.ToDateTime(str17));
                        command2.Parameters.AddWithValue("@Attached_File", str18);
                        command2.Parameters.AddWithValue("@ID", id);
                        command2.ExecuteNonQuery();

                    }
                    MessageBox.Show("Details saved successfully!!!");
                    button1.Enabled = false;
                    button1.BackColor = Color.Gray;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.btnSave.Visible = false;
            this.button1.Visible = false;
            this.DeleteAllButtons(this.dataGridView1);
            this.DeleteAllButtons(this.dataGridView2);
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            if (this.txtpatientsearch.Text == "Name")
            {
                SqlConnection connection = new SqlConnection("Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SELECT Name,PID,purpose FROM Ruby_Jamner123.Patient_Registration WHERE Name LIKE @name + '%' and Purpose != 'OPD'", connection);
                selectCommand.Parameters.AddWithValue("@name", this.txtpatient.Text);
                DataTable dataTable = new DataTable();
                new SqlDataAdapter(selectCommand).Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    this.dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No Patient Present with given Name");
                }
                connection.Close();
            }
            else if (this.txtpatientsearch.Text != "PID")
            {
                MessageBox.Show("select appropriate type!!!");
            }
            else
            {
                SqlConnection connection = new SqlConnection("Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SELECT Name,PID,purpose FROM Ruby_Jamner123.Patient_Registration WHERE Patient_ID = @pid and Purpose != 'OPD'", connection);
                selectCommand.Parameters.AddWithValue("@pid", this.txtpatient.Text);
                DataTable dataTable = new DataTable();
                new SqlDataAdapter(selectCommand).Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    this.dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No Patient Present with given Patient ID");
                }
                connection.Close();
            }
        }

        private void txtpatient_Enter_1(object sender, EventArgs e)
        {
            if (this.txtpatient.Text == "Enter the Patient Info")
            {
                this.txtpatient.Text = "";
            }
        }

        private void txtpatient_Leave_1(object sender, EventArgs e)
        {
            if (this.txtpatient.Text == "")
            {
                this.txtpatient.Text = "Enter the Patient Info";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                DataGridViewCell cell = this.dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if ((this.dataGridView2.Columns[e.ColumnIndex].HeaderText == "ATTACH FILE") && (cell is DataGridViewButtonCell))
                {
                    OpenFileDialog dialog = new OpenFileDialog
                    {
                        Title = "Attach File",
                        Filter = "All files (*.*)|*.*",
                        InitialDirectory = @"D:\"
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = dialog.FileName;
                        this.dataGridView2.Rows[e.RowIndex].Cells["Attached_File"].Value = fileName;
                    }
                }
                if ((this.dataGridView2.Columns[e.ColumnIndex].HeaderText == "VIEW FILE") && (cell is DataGridViewButtonCell))
                {
                    string str2 = this.dataGridView2.Rows[e.RowIndex].Cells["Attached_File"].Value.ToString();
                    if (!string.IsNullOrEmpty(str2) && File.Exists(str2))
                    {
                        Process.Start(str2);
                    }
                    else
                    {
                        MessageBox.Show("File path is invalid or file doesn't exist.");
                    }
                }
                if ((this.dataGridView2.Columns[e.ColumnIndex].HeaderText == "DELETE FILE") && (cell is DataGridViewButtonCell))
                {
                    this.dataGridView2.Rows[e.RowIndex].Cells["Attached_File"].Value = "";
                }
            }
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((this.dataGridView2.Columns[e.ColumnIndex].Name != "Sample_Date") && (this.dataGridView2.Columns[e.ColumnIndex].Name != "Report_Date"))
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            this.btnSave.Visible = false;
            this.button1.Visible = false;
            this.DeleteAllButtons(this.dataGridView2);
            while (dataGridView2.Columns.Count > 0)
            {
                dataGridView2.Columns.RemoveAt(0);
            }
            this.dataGridView2.DataSource = null;
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                name = this.dataGridView1.Columns[e.ColumnIndex].Name;
                if (name.Equals("Name"))
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection("Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                        connection.Open();
                        this.PID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["PID"].Value);
                        this.type = this.dataGridView1.CurrentRow.Cells["purpose"].Value.ToString();
                        SqlCommand selectCommand = new SqlCommand("SELECT * from Ruby_Jamner123.Assign_Radiology_Report where Name = @name", connection);
                        selectCommand.Parameters.AddWithValue("@name", this.dataGridView1.CurrentRow.Cells["Name"].Value.ToString());
                        DataTable dataTable = new DataTable();
                        new SqlDataAdapter(selectCommand).Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView2.DataSource = dataTable;
                            dataGridView2.Columns["ID"].Visible = false;
                            DataGridViewButtonColumn dataGridViewColumn = new DataGridViewButtonColumn
                            {
                                HeaderText = "ATTACH FILE",
                                Text = "Attach",
                                UseColumnTextForButtonValue = true,
                                Name = "btnATTACH"
                            };
                            DataGridViewButtonColumn column8 = new DataGridViewButtonColumn
                            {
                                HeaderText = "VIEW FILE",
                                Text = "View",
                                UseColumnTextForButtonValue = true,
                                Name = "btnVIEW"
                            };
                            DataGridViewButtonColumn column9 = new DataGridViewButtonColumn
                            {
                                HeaderText = "DELETE FILE",
                                Text = "Delete",
                                UseColumnTextForButtonValue = true,
                                Name = "btnDELETE"
                            };

                            this.dataGridView2.Columns.Add(dataGridViewColumn);
                            this.dataGridView2.Columns.Add(column8);
                            this.dataGridView2.Columns.Add(column9);
                            button1.Visible = true;
                            button1.Enabled = true;
                        }
                        else
                        {
                            if (this.type == "IPD")
                            {
                                SqlCommand command2 = new SqlCommand("SELECT MAX(IPDID) FROM Ruby_Jamner123.IPD_Registration \r\n                        WHERE Patient_Id = @pid", connection);
                                command2.Parameters.AddWithValue("@pid", this.PID);
                                int IPDID = Convert.ToInt32(command2.ExecuteScalar());
                                SqlCommand command3 = new SqlCommand("select * from Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest where IPDID = @IPDID and Balance = 0", connection);
                                command3.Parameters.AddWithValue("@IPDID", IPDID);
                                using (SqlDataReader reader = command3.ExecuteReader())
                                {
                                    string str2;
                                    DataTable table2 = new DataTable();
                                    DataTable table3 = new DataTable();
                                    DataTable combinedDataTable = new DataTable();

                                    if (!reader.HasRows)
                                    {
                                        MessageBox.Show("Pay Bill First!!!");
                                    }
                                    else
                                    {
                                        reader.Read();
                                        str2 = reader["IPDIDwithStr"].ToString();
                                        reader.Close();

                                        using (SqlCommand command4 = new SqlCommand("select Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.Patient_Registration.Name from Ruby_Jamner123.Patient_Registration\r\nwhere PID = @PId", connection))
                                        {
                                            command4.Parameters.AddWithValue("@PId", this.PID);
                                            using (SqlDataAdapter adapter2 = new SqlDataAdapter(command4))
                                            {
                                                adapter2.Fill(table2);
                                            }
                                        }
                                        table2.Columns.Add("IPD_ID", typeof(string));
                                        table2.Rows[0]["IPD_ID"] = str2;

                                        using (SqlCommand command13 = new SqlCommand("select RadiologyName,TestDate from Ruby_Jamner123.Assign_IPDRadiology_test where IPDID = @IPDID", connection))
                                        {
                                            command13.Parameters.AddWithValue("@IPDID", IPDID);
                                            using (SqlDataAdapter adapter7 = new SqlDataAdapter(command13))
                                            {
                                                adapter7.Fill(table3);
                                            }
                                        }


                                        combinedDataTable.Columns.Add("Patient_ID", typeof(string));
                                        combinedDataTable.Columns.Add("Name", typeof(string));
                                        combinedDataTable.Columns.Add("IPD_ID", typeof(string));
                                        combinedDataTable.Columns.Add("RadiologyName", typeof(string));
                                        combinedDataTable.Columns.Add("TestDate", typeof(string));

                                        foreach (DataRow row1 in table2.Rows)
                                        {
                                            foreach (DataRow row2 in table3.Rows)
                                            {
                                                combinedDataTable.Rows.Add(row1["Patient_ID"], row1["Name"], row1["IPD_ID"], row2["RadiologyName"], row2["TestDate"]);
                                            }
                                        }

                                        dataGridView2.DataSource = combinedDataTable;
                                        DataGridViewTextBoxColumn Sdate = new DataGridViewTextBoxColumn();
                                        Sdate.HeaderText = "SAMPLE DATE";
                                        Sdate.Name = "Sample_Date"; // optional, but can be useful for referencing the column later
                                        dataGridView2.Columns.Add(Sdate);

                                        DataGridViewTextBoxColumn Rdate = new DataGridViewTextBoxColumn();
                                        Rdate.HeaderText = "REPORT DATE";
                                        Rdate.Name = "Report_Date"; // optional, but can be useful for referencing the column later
                                        dataGridView2.Columns.Add(Rdate);

                                        DataGridViewTextBoxColumn fle = new DataGridViewTextBoxColumn();
                                        fle.HeaderText = "FILE";
                                        fle.Name = "Attached_File"; // optional, but can be useful for referencing the column later
                                        dataGridView2.Columns.Add(fle);

                                        DataGridViewButtonColumn dataGridViewColumn = new DataGridViewButtonColumn
                                        {
                                            HeaderText = "ATTACH FILE",
                                            Text = "Attach",
                                            UseColumnTextForButtonValue = true,
                                            Name = "btnATTACH"
                                        };
                                        DataGridViewButtonColumn column8 = new DataGridViewButtonColumn
                                        {
                                            HeaderText = "VIEW FILE",
                                            Text = "View",
                                            UseColumnTextForButtonValue = true,
                                            Name = "btnVIEW"
                                        };
                                        DataGridViewButtonColumn column9 = new DataGridViewButtonColumn
                                        {
                                            HeaderText = "DELETE FILE",
                                            Text = "Delete",
                                            UseColumnTextForButtonValue = true,
                                            Name = "btnDELETE"
                                        };

                                        this.dataGridView2.Columns.Add(dataGridViewColumn);
                                        this.dataGridView2.Columns.Add(column8);
                                        this.dataGridView2.Columns.Add(column9);
                                        this.btnSave.Visible = true;
                                        this.btnSave.Enabled = true;
                                    }


                                }
                            }
                            if (this.type == "Only Test")
                            {
                                SqlCommand command2 = new SqlCommand("select MAX(PatientOPDId) from Ruby_Jamner123.OPD_Patient_Registration where PatientId =  @pid", connection);
                                command2.Parameters.AddWithValue("@pid", this.PID);
                                int OPDID = Convert.ToInt32(command2.ExecuteScalar());
                                SqlCommand command3 = new SqlCommand("select * from Ruby_Jamner123.PatientRadiologyBilling_IPDnOnlyTest where OPDID = @OPDID and Balance = 0", connection);
                                command3.Parameters.AddWithValue("@OPDID", OPDID);
                                using (SqlDataReader reader = command3.ExecuteReader())
                                {
                                    string str2;
                                    DataTable table2 = new DataTable();
                                    DataTable table3 = new DataTable();
                                    DataTable combinedDataTable = new DataTable();

                                    if (!reader.HasRows)
                                    {
                                        MessageBox.Show("Pay Bill First!!!");
                                    }
                                    else
                                    {
                                        reader.Read();
                                        str2 = reader["OPDIDwithStr"].ToString();
                                        reader.Close();

                                        using (SqlCommand command4 = new SqlCommand("select Ruby_Jamner123.Patient_Registration.Patient_ID,Ruby_Jamner123.Patient_Registration.Name from Ruby_Jamner123.Patient_Registration\r\nwhere PID = @PId", connection))
                                        {
                                            command4.Parameters.AddWithValue("@PId", this.PID);
                                            using (SqlDataAdapter adapter2 = new SqlDataAdapter(command4))
                                            {
                                                adapter2.Fill(table2);
                                            }
                                        }
                                        table2.Columns.Add("OPD_ID", typeof(string));
                                        table2.Rows[0]["OPD_ID"] = str2;

                                        using (SqlCommand command13 = new SqlCommand("select RadiologyName,TestDate from Ruby_Jamner123.AssignOnlyTest_Radiology where OPDID = @OPDID", connection))
                                        {
                                            command13.Parameters.AddWithValue("@OPDID", OPDID);
                                            using (SqlDataAdapter adapter7 = new SqlDataAdapter(command13))
                                            {
                                                adapter7.Fill(table3);
                                            }
                                        }


                                        combinedDataTable.Columns.Add("Patient_ID", typeof(string));
                                        combinedDataTable.Columns.Add("Name", typeof(string));
                                        combinedDataTable.Columns.Add("OPD_ID", typeof(string));
                                        combinedDataTable.Columns.Add("RadiologyName", typeof(string));
                                        combinedDataTable.Columns.Add("TestDate", typeof(string));

                                        foreach (DataRow row1 in table2.Rows)
                                        {
                                            foreach (DataRow row2 in table3.Rows)
                                            {
                                                combinedDataTable.Rows.Add(row1["Patient_ID"], row1["Name"], row1["OPD_ID"], row2["RadiologyName"], row2["TestDate"]);
                                            }
                                        }

                                        dataGridView2.DataSource = combinedDataTable;
                                        DataGridViewTextBoxColumn Sdate = new DataGridViewTextBoxColumn();
                                        Sdate.HeaderText = "SAMPLE DATE";
                                        Sdate.Name = "Sample_Date"; // optional, but can be useful for referencing the column later
                                        dataGridView2.Columns.Add(Sdate);

                                        DataGridViewTextBoxColumn Rdate = new DataGridViewTextBoxColumn();
                                        Rdate.HeaderText = "REPORT DATE";
                                        Rdate.Name = "Report_Date"; // optional, but can be useful for referencing the column later
                                        dataGridView2.Columns.Add(Rdate);

                                        DataGridViewTextBoxColumn fle = new DataGridViewTextBoxColumn();
                                        fle.HeaderText = "FILE";
                                        fle.Name = "Attached_File"; // optional, but can be useful for referencing the column later
                                        dataGridView2.Columns.Add(fle);

                                        DataGridViewButtonColumn dataGridViewColumn = new DataGridViewButtonColumn
                                        {
                                            HeaderText = "ATTACH FILE",
                                            Text = "Attach",
                                            UseColumnTextForButtonValue = true,
                                            Name = "btnATTACH"
                                        };
                                        DataGridViewButtonColumn column8 = new DataGridViewButtonColumn
                                        {
                                            HeaderText = "VIEW FILE",
                                            Text = "View",
                                            UseColumnTextForButtonValue = true,
                                            Name = "btnVIEW"
                                        };
                                        DataGridViewButtonColumn column9 = new DataGridViewButtonColumn
                                        {
                                            HeaderText = "DELETE FILE",
                                            Text = "Delete",
                                            UseColumnTextForButtonValue = true,
                                            Name = "btnDELETE"
                                        };

                                        this.dataGridView2.Columns.Add(dataGridViewColumn);
                                        this.dataGridView2.Columns.Add(column8);
                                        this.dataGridView2.Columns.Add(column9);
                                        this.btnSave.Visible = true;
                                        this.btnSave.Enabled = true;
                                    }


                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Double Click on Name !!!");
                }
            }
        }

        private void Assign_Radiology_Report_Load(object sender, EventArgs e)
        {

        }
    }
}
