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
    public partial class frmSearchEmpAccess : Form
    {
        public int EmpId;

        public frmSearchEmpAccess(DataTable dt)
        {
            try
            {
                InitializeComponent();
                dataGridView1.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                EmpId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EmpId"].Value);
                frmEmployeeLoginAccess o = new frmEmployeeLoginAccess(EmpId);//here 'true' is for update patient inrto
                o.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmSearchEmployee_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EmpId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["EMPID"].Value);
                frmEmployeeLoginAccess o = new frmEmployeeLoginAccess(EmpId);//here 'true' is for update patient inrto
                o.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmSearchEmpAccess_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
