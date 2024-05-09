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
    public partial class Dashbord : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SpecalistHospitalSystem.Properties.Settings.Db_BNHConnectionString"].ConnectionString);
        public int Emp_id;
        public string EMPNAME;
        public int Isload;
        public static string Ename;

        public Dashbord(int EMPID ,string EMp_Name)
        {
            InitializeComponent();
            constomizedesing();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            Ename = EMp_Name;
            Emp_id = EMPID;
            this.Text= "Welcome :" +EMp_Name;
        }
        public void Accesslevel()
        {
            connection.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Employee_ADDAccess where EMPID=@EMPID", connection);
            cmd1.Parameters.AddWithValue("@EMPID", Emp_id);
            SqlDataAdapter adt1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adt1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                if (Convert.ToString(dt1.Rows[0]["Registration"]) == "Active")
                {
                    Isload = 1;
                   
                    btn_regi_slid.Visible = true;
                    Registration.Visible = true;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;
                    IPD.Visible = false;
                    Bill.Visible = false;
                    Admin.Visible = false;
                    Report.Visible = false;
                }
               

                if (Convert.ToString(dt1.Rows[0]["DoctorDashboard"]) == "Active")
                {

                    Registration.Visible = false;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = true;
                    IPD.Visible = true;
                    Bill.Visible = false;
                    Admin.Visible = false;
                    Report.Visible = false;
                }
                

                if (Convert.ToString(dt1.Rows[0]["PatientTransfur"]) == "Active")
                {
                    Registration.Visible = true;
                    btn_ipdregi_slid.Visible = true;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;
                    IPD.Visible = false;
                    Bill.Visible = false;
                    Admin.Visible = false;
                    Report.Visible = false;
                }
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["AssignTest"]) == "Active")
                {
                    Registration.Visible = true;
                    panel_Regi_down.Visible = true;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;
                    IPD.Visible = false;
                    Bill.Visible = false;
                    Admin.Visible = false;
                    Report.Visible = false;
                }
                else
                {

                }

                if (Convert.ToString(dt1.Rows[0]["AssignProcedure"]) == "Active")
                {
                    Registration.Visible = false;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = true;
                    btnopdregistration.Visible = true;
                    btnoldopdrecepites.Visible = false;
                    IPD.Visible = false;
                    Bill.Visible = false;
                    Admin.Visible = false;
                    Report.Visible = false;
                }   
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["Discharge"]) == "Active")
                {
                    Registration.Visible = false;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;                   
                    IPD.Visible = true;
                   
                    btndischargesummary.Visible = true;
                    btnoldipdreport.Visible = false;
                    btndaliyprocdure.Visible = false;
                    Bill.Visible = false;
                    Admin.Visible = false;
                    Report.Visible = false;

                }
                else
                {
               
                }

                if (Convert.ToString(dt1.Rows[0]["AssignSurgery"]) == "Active")
                {
                    Registration.Visible = false;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;
                    IPD.Visible = true;

                    btndischargesummary.Visible = false;
                    btnoldipdreport.Visible = false;
                    btndaliyprocdure.Visible = true;
                    Bill.Visible = false;
                    Admin.Visible = false;
                    Report.Visible = false;
                }  
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["Printdow"]) == "Active")
                {

                }
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["Viewreport"]) == "Active")
                {
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;

                    panel_Regi_down.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    Report.Visible = true;
                }
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["AddNotes"]) == "Active")
                {
                   
                }
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["Billing"]) == "Active")
                {
                    Registration.Visible = false;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;
                    IPD.Visible = false;

                    btndischargesummary.Visible = false;
                    btnoldipdreport.Visible = false;
                    btndaliyprocdure.Visible = false;
                    Bill.Visible = true;
                    Admin.Visible = false;
                    Report.Visible = false;
                }
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["ChangeBilling"]) == "Active")
                {
                    Registration.Visible = false;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;
                    IPD.Visible = false;
                    btndischargesummary.Visible = false;
                    btnoldipdreport.Visible = false;
                    btndaliyprocdure.Visible = false;
                    Bill.Visible = true;
                    Admin.Visible = false;
                    Report.Visible = false;
                }
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["CreateMaster"]) == "Active")
                {
                    Registration.Visible = false;
                    panel_Regi_down.Visible = false;
                    btn_ipdregi_slid.Visible = false;
                    btn_regi_Printform_slid.Visible = false;
                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    OPD.Visible = false;
                    IPD.Visible = false;
                    btndischargesummary.Visible = false;
                    btnoldipdreport.Visible = false;
                    btndaliyprocdure.Visible = false;
                    Bill.Visible = false;
                    Admin.Visible = true;
                    btnreport.Visible = false;
                    btnempmanagement.Visible = false;
                    Btnmaster.Visible = true;
                    Report.Visible = false;
                    btnapproval.Visible = false;
                }
                else
                {

                }
                if (Convert.ToString(dt1.Rows[0]["UserManagement"]) == "Active")
                {
                    //Registration.Visible = false;
                    //panel_Regi_down.Visible = false;
                    //btn_ipdregi_slid.Visible = false;
                    //btn_regi_Printform_slid.Visible = false;
                    //Panel_admin_master_.Visible = false;
                    //panel_admin_misReport.Visible = false;
                    //panel_OPD_down.Visible = false;
                    //panel_IPD_down.Visible = false;
                    //panel_bill_down.Visible = false;
                    //panel_admin_down.Visible = false;
                    //panel4.Visible = false;
                    //button10.Visible = false;
                    //button11.Visible = false;
                    //OPD.Visible = false;
                    //IPD.Visible = false;
                    //btndischargesummary.Visible = false;
                    //btnoldipdreport.Visible = false;
                    //btndaliyprocdure.Visible = false;
                    //Bill.Visible = false;
                    //Admin.Visible = true;
                    //btnreport.Visible = false;
                    //btnempmanagement.Visible = true;
                    //Btnmaster.Visible = false;
                    //Report.Visible = false;
                    //btnapproval.Visible = false;


                    Panel_admin_master_.Visible = false;
                    panel_admin_misReport.Visible = false;

                    panel_Regi_down.Visible = false;
                    panel_OPD_down.Visible = false;
                    panel_IPD_down.Visible = false;
                    panel_bill_down.Visible = false;
                    panel_admin_down.Visible = false;
                    panel4.Visible = false;
                }
                else
                {

                }
               
            }
            connection.Close();

        }
        private void movepanel(Control btn)
        {
            //panel_slide.Width = btn.Width;
            //panel_slide.Left = btn.Left;
        }
        private void Dashbord_Load(object sender, EventArgs e)
        {
             Accesslevel();


            //Panel_admin_master_.Visible = false;
            //panel_admin_misReport.Visible = false;

            //panel_Regi_down.Visible = false;
            //panel_OPD_down.Visible = false;
            //panel_IPD_down.Visible = false;
            //panel_bill_down.Visible = false;
            //panel_admin_down.Visible = false;
            //panel4.Visible = false;



        }
        private void constomizedesing()
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            //   panel_admin_misreprt.Visible = false;
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            movepanel(Registration);
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panel_admin_misReport.Visible = false;

            //   panel_admin_misreprt.Visible = false;
        }

        private void OPD_Click(object sender, EventArgs e)
        {
            movepanel(OPD);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = true;
            panel_IPD_down.Visible = false;
            panel_admin_down.Visible = false;
            //panel4.Visible = false;
            panel_bill_down.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panel_admin_misReport.Visible = false;
        }

        private void IPD_Click(object sender, EventArgs e)
        {
            movepanel(IPD);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = true;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panel_admin_misReport.Visible = false;
        }

        private void Bill_Click(object sender, EventArgs e)
        {
            movepanel(Bill);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = true;
            panel_admin_down.Visible = false;
            Panel_admin_master_.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel8.Visible = false;
            panel6.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panel_admin_misReport.Visible = false;
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            movepanel(Admin);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel4.Visible = false;
            panel_admin_down.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void Help_Click(object sender, EventArgs e)
        {
            movepanel(Report);
            panel_OPD_down.Visible = false;
            panel_Regi_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panel_admin_misReport.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMJPJAYGridView o = new frmMJPJAYGridView();
            o.ShowDialog();
        }

        private void Registration_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Regi_down.Visible = true;
           
        }

        private void OPD_MouseClick(object sender, MouseEventArgs e)
        {
            panel_OPD_down.Visible = true;
            panel4.Visible = false; 
        }

        private void IPD_MouseClick(object sender, MouseEventArgs e)
        {
            panel_IPD_down.Visible = true;
            panel4.Visible = false;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            frmMJPJAYPaymentDetails o = new frmMJPJAYPaymentDetails();
            o.Show();
        }

        private void Bill_MouseClick(object sender, MouseEventArgs e)
        {
            panel_bill_down.Visible = true;
            panel4.Visible = false;

        }

        private void Admin_MouseClick(object sender, MouseEventArgs e)
        {
            panel_admin_down.Visible = true;

            panel4.Visible = false;
        }

        

        private void btnreport_Click(object sender, EventArgs e)
        {
            panel_admin_misReport.Visible = true;
            panel4.Visible = false;

        }

        private void btnempmanagement_Click(object sender, EventArgs e)
        {
            // panel_admin_misreprt.Visible = false;
            panel8.Visible = true;
            panel4.Visible = false;
            Panel_admin_master_.Visible = false;
            panel_bill_down.Visible = false;
            panel6.Visible = false;
        }

        private void btnapproval_Click(object sender, EventArgs e)
        {
            /// panel_admin_misreprt.Visible = false;
            
            Panel_admin_master_.Visible = false;
            panel4.Visible = false;

        }

        private void btnreport_MouseClick(object sender, MouseEventArgs e)
        {
            panel4.Visible = false;
            panel_admin_misReport.Visible = true;
            panel_bill_down.Visible = false;
           
        }

      

        private void Btnmaster_Click(object sender, EventArgs e)
        {
            Panel_admin_master_.Visible = true;
            panel_admin_misReport.Visible = false;
            panel4.Visible = false;
            panel8.Visible = false;
        }

        private void Btnmaster_MouseClick(object sender, MouseEventArgs e)
        {
            Panel_admin_master_.Visible = true;
            panel_admin_misReport.Visible = false;
            panel4.Visible = false;
        }

        private void btnipdadmin_Click(object sender, EventArgs e)
        {
            if (panel10.Visible == true)
            {
                panel10.Visible = false;
            }
            else
            {
                panel10.Visible = true;
            }
        }

        

        private void btnopdd_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == false)
            {
                panel9.Visible = true;
            }
            else
            {
                panel9.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_regi_slid_Click(object sender, EventArgs e)
        {
            Patient_Registration o = new Patient_Registration();
            o.ShowDialog();
        }

        private void btnopdlist_Click(object sender, EventArgs e)
        {

        }

        private void btndaliyprocdure_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            IPD_Daily_Procedure_grid o = new IPD_Daily_Procedure_grid();
            o.ShowDialog();
        }

        private void btnopdregistration_Click(object sender, EventArgs e)
        {
            OPD_Consultaion_gridview o = new OPD_Consultaion_gridview();
            o.ShowDialog();
        }

        private void btn_opdpatinetlist_slid_Click(object sender, EventArgs e)
        {
            OPD_List o = new OPD_List();
            o.ShowDialog();
        }

        private void btnoldopdrecepites_Click(object sender, EventArgs e)
        {
            if(panel4.Visible==false)
            {
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
            }

        }

        private void btnoldipdreport_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }

        }

        private void btn_ipdECGandraddiology_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void btnipdlabbill_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            Lab_And_Radiology_Billing o = new Lab_And_Radiology_Billing();
            o.ShowDialog();
        }

        private void btnipd_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            IPD_Billng_Gridview o = new IPD_Billng_Gridview();
            o.Show();
        }

        private void btnopd_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            OPD_Billing_List o = new OPD_Billing_List();
            o.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void btndischargesummary_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            IPD_Discharge_PatientList o = new IPD_Discharge_PatientList();
            o.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //movepanel(Dashboard);
            Login_Form o = new Login_Form();
            o.Show();
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel_IPD_down.Visible = false;
            panel_bill_down.Visible = false;
            panel4.Visible = false;
            panel_admin_down.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
           // pictureBox1.BackColor=""
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
           // pictureBox2.BackColor = "Transparent";
        }

        private void btnpending_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void BtnDrug_Click(object sender, EventArgs e)
        {
            Master_Drugs o = new Master_Drugs();
            o.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_ipdregi_slid_Click(object sender, EventArgs e)
        {
            Transfer t = new Transfer();
                t.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Old_PatientDischarge_List o = new Old_PatientDischarge_List();
            o.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            movepanel(button11);
            panel_Regi_down.Visible = false;
            panel_OPD_down.Visible = false;
            panel6.Visible = true;
            panel_bill_down.Visible = false;
            panel_admin_down.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel8.Visible = false;
            panel_IPD_down.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panel_admin_misReport.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Assign_Lab_Reports o = new Assign_Lab_Reports();
            o.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Assign_Radiology_Report o = new Assign_Radiology_Report();
            o.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Manage_RoomSegment o = new Manage_RoomSegment();
            o.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Master_RoomNumber o = new Master_RoomNumber();
            o.Show();
        }

        private void Btnconcult_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Employeeregistration o = new Employeeregistration();
            o.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Employee_Login_Details o = new Employee_Login_Details();
            o.Show();
        }

        private void Btnreferral_Click(object sender, EventArgs e)
        {
            Referred_doctor o = new Referred_doctor();
            o.Show();
        }

        private void Btnopdsurgicalprocedure_Click(object sender, EventArgs e)
        {
            Master_OPD_Procedures o = new Master_OPD_Procedures();
            o.Show();
        }

        private void Btnipdprocedure_Click(object sender, EventArgs e)
        {
            Master_Procedures o = new Master_Procedures();
            o.Show();
        }

        private void BtnLAb_Click(object sender, EventArgs e)
        {
            Master_Lab_test o = new Master_Lab_test();
            o.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Master_Radiology o = new Master_Radiology();
            o.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Old_IPD_Reports o = new Old_IPD_Reports();
            o.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
             Old_OPD_Reports o = new Old_OPD_Reports();
            o.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Old_LabRadiology_Reports o  = new Old_LabRadiology_Reports();
            o.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            OPD_Summary s = new OPD_Summary();
            s.Show();
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            OPD_Details d = new OPD_Details();
            d.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Discharge_Details u = new Discharge_Details();
            u.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            IPD_Billing_Details b = new IPD_Billing_Details();
            b.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            IPD_Details i = new IPD_Details();
            i.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            frmEmployeeLoginAccess o = new frmEmployeeLoginAccess();
            o.Show();
        }
    }
}
