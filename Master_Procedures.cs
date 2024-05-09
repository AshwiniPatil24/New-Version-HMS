using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Hospital
{
    public partial class Master_Procedures : Form
    {
        public int procID;
        public Master_Procedures()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Master_Procedures_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtprocedure.Text != "" && txthospcharge.Text != "")
            {
                if (button2.Text == "Save")
                {
                    save();
                }
                else
                {

                    update();
                }
            }
            else
            {
                MessageBox.Show("Fill Procedure details !");
            }

        }

        public void save()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"INSERT into Master_IPDHospitalProcedure (ProcedureType,ProcedureName,ProcedureDetails,ProcedureCharge,HospCharge,Createdby)
values      (@ProcedureType,@ProcedureName,@ProcedureDetails,@ProcedureCharge,@HospCharge,@Createdby)", con);
            cmb.Parameters.AddWithValue("@ProcedureType", "1");
            cmb.Parameters.AddWithValue("@ProcedureName", txtname.Text);
            cmb.Parameters.AddWithValue("@ProcedureDetails", txtdetails.Text);
            cmb.Parameters.AddWithValue("@ProcedureCharge", txtprocedure.Text);
            cmb.Parameters.AddWithValue("@HospCharge", txthospcharge.Text);
            cmb.Parameters.AddWithValue("@Createdby", txtdate.Value);
            cmb.ExecuteNonQuery();
            MessageBox.Show("inserted successfully.....!");
            con.Close();
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
            clearData();
        }

        public void update()
        {
            SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
            con.Open();
            SqlCommand cmb = new SqlCommand(@"Update Master_IPDHospitalProcedure set ProcedureType = @ProcedureType,ProcedureName=@ProcedureName,ProcedureDetails=@ProcedureDetails,ProcedureCharge=@ProcedureCharge,HospCharge=@HospCharge,Updatedby=@Updatedby
WHERE  ProcedureName=@ProcedureName", con);
            cmb.Parameters.AddWithValue("@ProcedureType", "1");
            cmb.Parameters.AddWithValue("@ProcedureName", txtsearch.Text);
            cmb.Parameters.AddWithValue("@ProcedureDetails", txtdetails.Text);
            cmb.Parameters.AddWithValue("@ProcedureCharge", txtprocedure.Text);
            cmb.Parameters.AddWithValue("@HospCharge", txthospcharge.Text);
            cmb.Parameters.AddWithValue("@Updatedby", DateTime.Now.Date);
            cmb.ExecuteNonQuery();
            MessageBox.Show("updated successfully.....!");
            con.Close();
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
            clearData();
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if (txtsearch.Text == "enter procedure name")
            {
                txtsearch.Text = "";
            }
        }

        private void txtsearch_Leave(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                txtsearch.Text = "enter procedure name";
            }
        }

        private void txtsearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtsearch.Text == "enter procedure name")
            {
                txtsearch.Clear();
            }
        }

        public void clearData()
        {
            txtname.Clear();
            txtdetails.Clear();
            txtprocedure.Clear();
            txthospcharge.Clear();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                clearData();
                button2.Enabled = true;
                button2.Text = "Save";
                button2.BackColor = Color.DarkGreen;
                if (txtsearch.Text == "enter procedure name")
                {
                    MessageBox.Show("please fill details !!!");
                    
                }
                else if(txtsearch.Text != "")
                {
                    String ProcedureName = txtsearch.Text;
                    SqlConnection con = new SqlConnection(@"Data Source=208.91.198.196;User ID=Ruby_Jamner123;Password=ruby@jamner");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Master_IPDHospitalProcedure where ProcedureName LIKE @name +'%'", con);
                    cmd.Parameters.AddWithValue("@name", txtsearch.Text);
                    SqlDataAdapter adt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        button2.Text = "Update";
                        button2.Enabled = true;
                        button2.BackColor = Color.DarkGreen;
                        DataRow row = dt.Rows[0];
                        procID = Convert.ToInt32(row["Procedureid"]);
                        txtname.Text = row["ProcedureName"].ToString();
                        txtdetails.Text = row["ProcedureDetails"].ToString();
                        txtprocedure.Text = row["ProcedureCharge"].ToString();
                        txthospcharge.Text = row["HospCharge"].ToString();
                        object valueFromTable = row["Createdby"];
                        txtdate.Value = (valueFromTable != DBNull.Value) ? Convert.ToDateTime(valueFromTable) : DateTime.Now.Date;                
                    }
                    else
                    {
                        MessageBox.Show("No Procedure Present!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
