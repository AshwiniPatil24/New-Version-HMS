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
    public partial class PatientRegitrationGridview : Form
    {
        public DataTable dt;
        public PatientRegitrationGridview()
        {
            InitializeComponent();
        }
        public PatientRegitrationGridview(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }
        private void PatientRegitrationGridview_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {            
            if (dt.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView1.Columns["Name"].Index)
            {
                try
                {
                    // Create a new DataTable to store the specific row
                    DataTable specificRowTable = new DataTable();

                    // Add columns to the new DataTable matching the DataGridView
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        specificRowTable.Columns.Add(col.Name);
                    }

                    // Get the data from the clicked row
                    DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];

                    // Create a new DataRow for the DataTable and copy values from the clicked row
                    DataRow newRow = specificRowTable.NewRow();
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        newRow[col.Name] = clickedRow.Cells[col.Name].Value;
                    }

                    // Add the new DataRow to the DataTable
                    specificRowTable.Rows.Add(newRow);
                    Patient_Registration o = new Patient_Registration(specificRowTable);
                    o.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
    }
}
