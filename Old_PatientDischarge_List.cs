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
    public partial class Old_PatientDischarge_List : Form
    {
        public Old_PatientDischarge_List()
        {
            InitializeComponent();
        }

        private void Old_PatientDischarge_List_Load(object sender, EventArgs e)
        {
            showOldDischargelist();
        }

        public void showOldDischargelist()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Ruby_Jamner123.IPD_discharge_PatientInfo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["PID"].Visible = false;
                dataGridView1.Columns["IPDID"].Visible = false;
            }
        }
    }
}
