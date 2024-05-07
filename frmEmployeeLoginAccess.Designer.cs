namespace Ruby_Hospital
{
    partial class frmEmployeeLoginAccess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearchBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDischaeges = new System.Windows.Forms.CheckBox();
            this.chkUserManagement = new System.Windows.Forms.CheckBox();
            this.chkChangeBilling = new System.Windows.Forms.CheckBox();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.chkAddNote = new System.Windows.Forms.CheckBox();
            this.chkViewReport = new System.Windows.Forms.CheckBox();
            this.chkAssignSurgery = new System.Windows.Forms.CheckBox();
            this.chkAssignProc = new System.Windows.Forms.CheckBox();
            this.ChkBilling = new System.Windows.Forms.CheckBox();
            this.ChkCreateMaster = new System.Windows.Forms.CheckBox();
            this.chkPatientTra = new System.Windows.Forms.CheckBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkDoctordash = new System.Windows.Forms.CheckBox();
            this.ChkAssignTest = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRegistration = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(250, 81);
            this.label9.Margin = new System.Windows.Forms.Padding(50, 5, 50, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Search Employee By";
            // 
            // txtSearchBy
            // 
            this.txtSearchBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSearchBy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBy.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtSearchBy.FormattingEnabled = true;
            this.txtSearchBy.Items.AddRange(new object[] {
            "Select BY",
            "EMPID",
            "Name"});
            this.txtSearchBy.Location = new System.Drawing.Point(459, 81);
            this.txtSearchBy.Margin = new System.Windows.Forms.Padding(50, 5, 50, 90);
            this.txtSearchBy.Name = "txtSearchBy";
            this.txtSearchBy.Size = new System.Drawing.Size(155, 27);
            this.txtSearchBy.TabIndex = 16;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtSearch.Location = new System.Drawing.Point(630, 81);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(50, 5, 50, 90);
            this.txtSearch.MaxLength = 40;
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 28);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.Text = "Enter Details";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnsave.BackColor = System.Drawing.Color.DarkGreen;
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnsave.Location = new System.Drawing.Point(495, 490);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(134, 30);
            this.btnsave.TabIndex = 25;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chkDischaeges);
            this.panel1.Controls.Add(this.chkUserManagement);
            this.panel1.Controls.Add(this.chkChangeBilling);
            this.panel1.Controls.Add(this.chkprint);
            this.panel1.Controls.Add(this.chkAddNote);
            this.panel1.Controls.Add(this.chkViewReport);
            this.panel1.Controls.Add(this.chkAssignSurgery);
            this.panel1.Controls.Add(this.chkAssignProc);
            this.panel1.Controls.Add(this.ChkBilling);
            this.panel1.Controls.Add(this.ChkCreateMaster);
            this.panel1.Controls.Add(this.chkPatientTra);
            this.panel1.Controls.Add(this.chkAdmin);
            this.panel1.Controls.Add(this.chkDoctordash);
            this.panel1.Controls.Add(this.ChkAssignTest);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkRegistration);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(87, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 357);
            this.panel1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(535, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 21);
            this.label6.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(159, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 20;
            // 
            // chkDischaeges
            // 
            this.chkDischaeges.AutoSize = true;
            this.chkDischaeges.BackColor = System.Drawing.Color.Transparent;
            this.chkDischaeges.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDischaeges.Location = new System.Drawing.Point(395, 107);
            this.chkDischaeges.Name = "chkDischaeges";
            this.chkDischaeges.Size = new System.Drawing.Size(122, 27);
            this.chkDischaeges.TabIndex = 19;
            this.chkDischaeges.Text = "Discharge";
            this.chkDischaeges.UseVisualStyleBackColor = false;
            // 
            // chkUserManagement
            // 
            this.chkUserManagement.AutoSize = true;
            this.chkUserManagement.BackColor = System.Drawing.Color.Transparent;
            this.chkUserManagement.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUserManagement.Location = new System.Drawing.Point(677, 237);
            this.chkUserManagement.Name = "chkUserManagement";
            this.chkUserManagement.Size = new System.Drawing.Size(199, 27);
            this.chkUserManagement.TabIndex = 18;
            this.chkUserManagement.Text = "User Management";
            this.chkUserManagement.UseVisualStyleBackColor = false;
            // 
            // chkChangeBilling
            // 
            this.chkChangeBilling.AutoSize = true;
            this.chkChangeBilling.BackColor = System.Drawing.Color.Transparent;
            this.chkChangeBilling.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChangeBilling.Location = new System.Drawing.Point(677, 151);
            this.chkChangeBilling.Name = "chkChangeBilling";
            this.chkChangeBilling.Size = new System.Drawing.Size(164, 27);
            this.chkChangeBilling.TabIndex = 17;
            this.chkChangeBilling.Text = "Change Billing";
            this.chkChangeBilling.UseVisualStyleBackColor = false;
            // 
            // chkprint
            // 
            this.chkprint.AutoSize = true;
            this.chkprint.BackColor = System.Drawing.Color.Transparent;
            this.chkprint.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkprint.Location = new System.Drawing.Point(395, 193);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(217, 27);
            this.chkprint.TabIndex = 16;
            this.chkprint.Text = "Prints and Download";
            this.chkprint.UseVisualStyleBackColor = false;
            // 
            // chkAddNote
            // 
            this.chkAddNote.AutoSize = true;
            this.chkAddNote.BackColor = System.Drawing.Color.Transparent;
            this.chkAddNote.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAddNote.Location = new System.Drawing.Point(395, 277);
            this.chkAddNote.Name = "chkAddNote";
            this.chkAddNote.Size = new System.Drawing.Size(126, 27);
            this.chkAddNote.TabIndex = 15;
            this.chkAddNote.Text = "Add Notes";
            this.chkAddNote.UseVisualStyleBackColor = false;
            // 
            // chkViewReport
            // 
            this.chkViewReport.AutoSize = true;
            this.chkViewReport.BackColor = System.Drawing.Color.Transparent;
            this.chkViewReport.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewReport.Location = new System.Drawing.Point(395, 237);
            this.chkViewReport.Name = "chkViewReport";
            this.chkViewReport.Size = new System.Drawing.Size(147, 27);
            this.chkViewReport.TabIndex = 14;
            this.chkViewReport.Text = "View Reports";
            this.chkViewReport.UseVisualStyleBackColor = false;
            // 
            // chkAssignSurgery
            // 
            this.chkAssignSurgery.AutoSize = true;
            this.chkAssignSurgery.BackColor = System.Drawing.Color.Transparent;
            this.chkAssignSurgery.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAssignSurgery.Location = new System.Drawing.Point(395, 151);
            this.chkAssignSurgery.Name = "chkAssignSurgery";
            this.chkAssignSurgery.Size = new System.Drawing.Size(162, 27);
            this.chkAssignSurgery.TabIndex = 13;
            this.chkAssignSurgery.Text = "Assign Surgery";
            this.chkAssignSurgery.UseVisualStyleBackColor = false;
            // 
            // chkAssignProc
            // 
            this.chkAssignProc.AutoSize = true;
            this.chkAssignProc.BackColor = System.Drawing.Color.Transparent;
            this.chkAssignProc.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAssignProc.Location = new System.Drawing.Point(89, 277);
            this.chkAssignProc.Name = "chkAssignProc";
            this.chkAssignProc.Size = new System.Drawing.Size(188, 27);
            this.chkAssignProc.TabIndex = 12;
            this.chkAssignProc.Text = "Assign Procedure";
            this.chkAssignProc.UseVisualStyleBackColor = false;
            // 
            // ChkBilling
            // 
            this.ChkBilling.AutoSize = true;
            this.ChkBilling.BackColor = System.Drawing.Color.Transparent;
            this.ChkBilling.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBilling.Location = new System.Drawing.Point(677, 107);
            this.ChkBilling.Name = "ChkBilling";
            this.ChkBilling.Size = new System.Drawing.Size(84, 27);
            this.ChkBilling.TabIndex = 11;
            this.ChkBilling.Text = "Billing";
            this.ChkBilling.UseVisualStyleBackColor = false;
            // 
            // ChkCreateMaster
            // 
            this.ChkCreateMaster.AutoSize = true;
            this.ChkCreateMaster.BackColor = System.Drawing.Color.Transparent;
            this.ChkCreateMaster.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkCreateMaster.Location = new System.Drawing.Point(677, 193);
            this.ChkCreateMaster.Name = "ChkCreateMaster";
            this.ChkCreateMaster.Size = new System.Drawing.Size(160, 27);
            this.ChkCreateMaster.TabIndex = 10;
            this.ChkCreateMaster.Text = "Create Master";
            this.ChkCreateMaster.UseVisualStyleBackColor = false;
            // 
            // chkPatientTra
            // 
            this.chkPatientTra.AutoSize = true;
            this.chkPatientTra.BackColor = System.Drawing.Color.Transparent;
            this.chkPatientTra.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPatientTra.Location = new System.Drawing.Point(89, 193);
            this.chkPatientTra.Name = "chkPatientTra";
            this.chkPatientTra.Size = new System.Drawing.Size(166, 27);
            this.chkPatientTra.TabIndex = 9;
            this.chkPatientTra.Text = "Patient Transfur";
            this.chkPatientTra.UseVisualStyleBackColor = false;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.chkAdmin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdmin.Location = new System.Drawing.Point(896, 248);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(81, 25);
            this.chkAdmin.TabIndex = 8;
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = false;
            this.chkAdmin.Visible = false;
            // 
            // chkDoctordash
            // 
            this.chkDoctordash.AutoSize = true;
            this.chkDoctordash.BackColor = System.Drawing.Color.Transparent;
            this.chkDoctordash.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoctordash.Location = new System.Drawing.Point(89, 151);
            this.chkDoctordash.Name = "chkDoctordash";
            this.chkDoctordash.Size = new System.Drawing.Size(197, 27);
            this.chkDoctordash.TabIndex = 7;
            this.chkDoctordash.Text = "Doctor Dashboard";
            this.chkDoctordash.UseVisualStyleBackColor = false;
            // 
            // ChkAssignTest
            // 
            this.ChkAssignTest.AutoSize = true;
            this.ChkAssignTest.BackColor = System.Drawing.Color.Transparent;
            this.ChkAssignTest.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAssignTest.Location = new System.Drawing.Point(89, 237);
            this.ChkAssignTest.Name = "ChkAssignTest";
            this.ChkAssignTest.Size = new System.Drawing.Size(127, 27);
            this.ChkAssignTest.TabIndex = 6;
            this.ChkAssignTest.Text = "Assign Test";
            this.ChkAssignTest.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MintCream;
            this.label4.Location = new System.Drawing.Point(87, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Select Employee Access";
            // 
            // chkRegistration
            // 
            this.chkRegistration.AutoSize = true;
            this.chkRegistration.BackColor = System.Drawing.Color.Transparent;
            this.chkRegistration.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRegistration.Location = new System.Drawing.Point(91, 107);
            this.chkRegistration.Name = "chkRegistration";
            this.chkRegistration.Size = new System.Drawing.Size(137, 27);
            this.chkRegistration.TabIndex = 4;
            this.chkRegistration.Text = "Registration";
            this.chkRegistration.UseVisualStyleBackColor = false;
            this.chkRegistration.CheckedChanged += new System.EventHandler(this.chkRegistration_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(391, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Emp ID:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(630, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Visible = false;
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(504, 46);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(100, 20);
            this.txtEmpID.TabIndex = 1;
            this.txtEmpID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 40);
            this.panel2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(50, 5, 50, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = " Employee Access Details";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::Ruby_Hospital.Properties.Resources.icons8_search_50__1_1;
            this.pictureBox3.Location = new System.Drawing.Point(860, 78);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // frmEmployeeLoginAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 532);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSearchBy);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtEmpID);
            this.Controls.Add(this.txtName);
            this.MaximizeBox = false;
            this.Name = "frmEmployeeLoginAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeLoginAccess";
            this.Load += new System.EventHandler(this.frmEmployeeLoginAccess_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox txtSearchBy;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ChkBilling;
        private System.Windows.Forms.CheckBox ChkCreateMaster;
        private System.Windows.Forms.CheckBox chkPatientTra;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.CheckBox chkDoctordash;
        private System.Windows.Forms.CheckBox ChkAssignTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRegistration;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.CheckBox chkChangeBilling;
        private System.Windows.Forms.CheckBox chkprint;
        private System.Windows.Forms.CheckBox chkAddNote;
        private System.Windows.Forms.CheckBox chkViewReport;
        private System.Windows.Forms.CheckBox chkAssignSurgery;
        private System.Windows.Forms.CheckBox chkAssignProc;
        private System.Windows.Forms.CheckBox chkUserManagement;
        private System.Windows.Forms.CheckBox chkDischaeges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}