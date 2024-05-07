using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class DisplayEmployees : Form
    {
        public DataTable dt;
        public DisplayEmployees()
        {
            InitializeComponent();
        }

        public DisplayEmployees(DataTable datatable)
        {
            InitializeComponent();
            dt = datatable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                name = this.dataGridView1.Columns[e.ColumnIndex].Name;
                if (name.Equals("Name"))
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
                    Employeeregistration o = new Employeeregistration(specificRowTable);
                    o.Show();
                }
                else
                {
                    MessageBox.Show("Click On Name!!");
                }
            }
        }

        private void DisplayEmployees_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
        }
    }
}
