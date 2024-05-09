﻿namespace Ruby_Hospital
{
    partial class frmMJPJAYPatientRegistration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintMJPJAYConsent = new System.Windows.Forms.Button();
            this.DVGMJPJAYAddSurgery = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtpAddedOn = new System.Windows.Forms.DateTimePicker();
            this.lblAddedOn = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPackageAmount = new System.Windows.Forms.TextBox();
            this.txtSubSurgery = new System.Windows.Forms.TextBox();
            this.txtMainCategory = new System.Windows.Forms.TextBox();
            this.txtSurgeryName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbSurgeryName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMainCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDOAdmission = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMJPJAYNO = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblPatientInformation = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVGMJPJAYAddSurgery)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnPrintMJPJAYConsent);
            this.panel1.Controls.Add(this.DVGMJPJAYAddSurgery);
            this.panel1.Controls.Add(this.dtpAddedOn);
            this.panel1.Controls.Add(this.lblAddedOn);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.lblPatientInformation);
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1332, 487);
            this.panel1.TabIndex = 0;
            // 
            // btnPrintMJPJAYConsent
            // 
            this.btnPrintMJPJAYConsent.BackColor = System.Drawing.Color.Maroon;
            this.btnPrintMJPJAYConsent.Enabled = false;
            this.btnPrintMJPJAYConsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintMJPJAYConsent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintMJPJAYConsent.ForeColor = System.Drawing.Color.White;
            this.btnPrintMJPJAYConsent.Location = new System.Drawing.Point(778, 450);
            this.btnPrintMJPJAYConsent.Name = "btnPrintMJPJAYConsent";
            this.btnPrintMJPJAYConsent.Size = new System.Drawing.Size(188, 34);
            this.btnPrintMJPJAYConsent.TabIndex = 200;
            this.btnPrintMJPJAYConsent.Text = "Print MJPJAY Consent Form";
            this.btnPrintMJPJAYConsent.UseVisualStyleBackColor = false;
            this.btnPrintMJPJAYConsent.Visible = false;
            this.btnPrintMJPJAYConsent.Click += new System.EventHandler(this.btnPrintMJPJAYConsent_Click);
            // 
            // DVGMJPJAYAddSurgery
            // 
            this.DVGMJPJAYAddSurgery.AllowUserToAddRows = false;
            this.DVGMJPJAYAddSurgery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DVGMJPJAYAddSurgery.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVGMJPJAYAddSurgery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DVGMJPJAYAddSurgery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVGMJPJAYAddSurgery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnRemove});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DVGMJPJAYAddSurgery.DefaultCellStyle = dataGridViewCellStyle2;
            this.DVGMJPJAYAddSurgery.Location = new System.Drawing.Point(349, 289);
            this.DVGMJPJAYAddSurgery.Name = "DVGMJPJAYAddSurgery";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVGMJPJAYAddSurgery.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DVGMJPJAYAddSurgery.Size = new System.Drawing.Size(679, 155);
            this.DVGMJPJAYAddSurgery.TabIndex = 199;
            this.DVGMJPJAYAddSurgery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DVGMJPJAYAddSurgery_CellClick);
            this.DVGMJPJAYAddSurgery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DVGMJPJAYAddSurgery_CellContentClick);
            this.DVGMJPJAYAddSurgery.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DVGMJPJAYAddSurgery_CellValidated);
            // 
            // btnRemove
            // 
            this.btnRemove.HeaderText = "Remove";
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseColumnTextForButtonValue = true;
            this.btnRemove.Width = 86;
            // 
            // dtpAddedOn
            // 
            this.dtpAddedOn.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpAddedOn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAddedOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAddedOn.Location = new System.Drawing.Point(528, 17);
            this.dtpAddedOn.MaxDate = new System.DateTime(2024, 12, 27, 0, 0, 0, 0);
            this.dtpAddedOn.Name = "dtpAddedOn";
            this.dtpAddedOn.Size = new System.Drawing.Size(86, 23);
            this.dtpAddedOn.TabIndex = 198;
            this.dtpAddedOn.Value = new System.DateTime(2024, 5, 3, 0, 0, 0, 0);
            this.dtpAddedOn.Visible = false;
            // 
            // lblAddedOn
            // 
            this.lblAddedOn.AutoSize = true;
            this.lblAddedOn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddedOn.Location = new System.Drawing.Point(427, 18);
            this.lblAddedOn.Name = "lblAddedOn";
            this.lblAddedOn.Size = new System.Drawing.Size(87, 23);
            this.lblAddedOn.TabIndex = 197;
            this.lblAddedOn.Text = "Added On";
            this.lblAddedOn.Visible = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(620, 450);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(143, 34);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.groupBox1.Controls.Add(this.txtPackageAmount);
            this.groupBox1.Controls.Add(this.txtSubSurgery);
            this.groupBox1.Controls.Add(this.txtMainCategory);
            this.groupBox1.Controls.Add(this.txtSurgeryName);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cmbSurgeryName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbSubCategory);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbMainCategory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDOAdmission);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMJPJAYNO);
            this.groupBox1.Controls.Add(this.lblPhone);
            this.groupBox1.Location = new System.Drawing.Point(42, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1273, 155);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Surgery Details";
            // 
            // txtPackageAmount
            // 
            this.txtPackageAmount.Location = new System.Drawing.Point(1068, 14);
            this.txtPackageAmount.Name = "txtPackageAmount";
            this.txtPackageAmount.Size = new System.Drawing.Size(151, 20);
            this.txtPackageAmount.TabIndex = 199;
            this.txtPackageAmount.Visible = false;
            // 
            // txtSubSurgery
            // 
            this.txtSubSurgery.Location = new System.Drawing.Point(932, 79);
            this.txtSubSurgery.Name = "txtSubSurgery";
            this.txtSubSurgery.Size = new System.Drawing.Size(236, 20);
            this.txtSubSurgery.TabIndex = 198;
            this.txtSubSurgery.Visible = false;
            // 
            // txtMainCategory
            // 
            this.txtMainCategory.Location = new System.Drawing.Point(919, 47);
            this.txtMainCategory.Name = "txtMainCategory";
            this.txtMainCategory.Size = new System.Drawing.Size(236, 20);
            this.txtMainCategory.TabIndex = 197;
            this.txtMainCategory.Visible = false;
            // 
            // txtSurgeryName
            // 
            this.txtSurgeryName.Location = new System.Drawing.Point(966, 117);
            this.txtSurgeryName.Name = "txtSurgeryName";
            this.txtSurgeryName.Size = new System.Drawing.Size(253, 20);
            this.txtSurgeryName.TabIndex = 196;
            this.txtSurgeryName.Visible = false;
            this.txtSurgeryName.TextChanged += new System.EventHandler(this.txtSurgeryName_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(891, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add New";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmbSurgeryName
            // 
            this.cmbSurgeryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSurgeryName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSurgeryName.FormattingEnabled = true;
            this.cmbSurgeryName.Location = new System.Drawing.Point(385, 113);
            this.cmbSurgeryName.Name = "cmbSurgeryName";
            this.cmbSurgeryName.Size = new System.Drawing.Size(495, 26);
            this.cmbSurgeryName.TabIndex = 4;
            this.cmbSurgeryName.SelectedIndexChanged += new System.EventHandler(this.cmbSurgeryName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(299, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 132;
            this.label4.Text = "Surgery";
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubCategory.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Location = new System.Drawing.Point(385, 81);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(495, 26);
            this.cmbSubCategory.TabIndex = 3;
            this.cmbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSubCategory_SelectedIndexChanged);
            this.cmbSubCategory.SelectedValueChanged += new System.EventHandler(this.cmbSubCategory_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(197, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 23);
            this.label3.TabIndex = 130;
            this.label3.Text = "Disease Sub Category";
            // 
            // cmbMainCategory
            // 
            this.cmbMainCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainCategory.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMainCategory.FormattingEnabled = true;
            this.cmbMainCategory.Location = new System.Drawing.Point(387, 49);
            this.cmbMainCategory.Name = "cmbMainCategory";
            this.cmbMainCategory.Size = new System.Drawing.Size(493, 26);
            this.cmbMainCategory.TabIndex = 2;
            this.cmbMainCategory.SelectedIndexChanged += new System.EventHandler(this.cmbMainCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 23);
            this.label2.TabIndex = 128;
            this.label2.Text = "Disease Main Category";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtpDOAdmission
            // 
            this.dtpDOAdmission.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpDOAdmission.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOAdmission.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOAdmission.Location = new System.Drawing.Point(886, 14);
            this.dtpDOAdmission.Name = "dtpDOAdmission";
            this.dtpDOAdmission.Size = new System.Drawing.Size(163, 26);
            this.dtpDOAdmission.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(834, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 126;
            this.label1.Text = "Date";
            // 
            // txtMJPJAYNO
            // 
            this.txtMJPJAYNO.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMJPJAYNO.Location = new System.Drawing.Point(387, 14);
            this.txtMJPJAYNO.MaxLength = 10;
            this.txtMJPJAYNO.Name = "txtMJPJAYNO";
            this.txtMJPJAYNO.Size = new System.Drawing.Size(190, 23);
            this.txtMJPJAYNO.TabIndex = 1;
            this.txtMJPJAYNO.TextChanged += new System.EventHandler(this.txtMJPJAYNO_TextChanged);
            this.txtMJPJAYNO.Leave += new System.EventHandler(this.txtMJPJAYNO_Leave);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(277, 16);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(95, 23);
            this.lblPhone.TabIndex = 124;
            this.lblPhone.Text = "MJPJAY NO";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(45, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(1270, 70);
            this.dataGridView1.TabIndex = 122;
            // 
            // lblPatientInformation
            // 
            this.lblPatientInformation.AutoSize = true;
            this.lblPatientInformation.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientInformation.Location = new System.Drawing.Point(38, 18);
            this.lblPatientInformation.Name = "lblPatientInformation";
            this.lblPatientInformation.Size = new System.Drawing.Size(163, 23);
            this.lblPatientInformation.TabIndex = 121;
            this.lblPatientInformation.Text = "Patient Information";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(0, 524);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1347, 27);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlTop.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.lblHeading);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1347, 31);
            this.pnlTop.TabIndex = 3;
            // 
            // lblHeading
            // 
            this.lblHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHeading.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(7, 1);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(271, 27);
            this.lblHeading.TabIndex = 14;
            this.lblHeading.Text = "MJPJAY Patient Registration";
            this.lblHeading.Click += new System.EventHandler(this.lblHeading_Click);
            // 
            // frmMJPJAYPatientRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1347, 551);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.panel1);
            this.Name = "frmMJPJAYPatientRegistration";
            this.Text = "frmMJPJAYPatientRegistration";
            this.Load += new System.EventHandler(this.frmMJPJAYPatientRegistration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DVGMJPJAYAddSurgery)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblPatientInformation;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMJPJAYNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDOAdmission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMainCategory;
        private System.Windows.Forms.ComboBox cmbSurgeryName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSubCategory;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtSurgeryName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblAddedOn;
        private System.Windows.Forms.DateTimePicker dtpAddedOn;
        private System.Windows.Forms.TextBox txtMainCategory;
        private System.Windows.Forms.TextBox txtSubSurgery;
        private System.Windows.Forms.TextBox txtPackageAmount;
        private System.Windows.Forms.DataGridView DVGMJPJAYAddSurgery;
        private System.Windows.Forms.Button btnPrintMJPJAYConsent;
        private System.Windows.Forms.DataGridViewButtonColumn btnRemove;
    }
}