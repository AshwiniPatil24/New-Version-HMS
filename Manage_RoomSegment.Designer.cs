namespace Ruby_Hospital
{
    partial class Manage_RoomSegment
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
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNursingCharges = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomCharges = new System.Windows.Forms.TextBox();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchName
            // 
            this.txtSearchName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtSearchName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchName.Location = new System.Drawing.Point(669, 159);
            this.txtSearchName.Multiline = true;
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(245, 29);
            this.txtSearchName.TabIndex = 89;
            this.txtSearchName.Text = "Enter Room Segment";
            this.txtSearchName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearchName_MouseClick);
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            this.txtSearchName.Enter += new System.EventHandler(this.txtSearchName_Enter);
            this.txtSearchName.Leave += new System.EventHandler(this.txtSearchName_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 23);
            this.label3.TabIndex = 88;
            this.label3.Text = "Search By Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsave.BackColor = System.Drawing.Color.DarkGreen;
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnsave.Location = new System.Drawing.Point(563, 528);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(104, 39);
            this.btnsave.TabIndex = 92;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackColor = System.Drawing.Color.Maroon;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(698, 529);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 39);
            this.btnDelete.TabIndex = 93;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.groupBox1.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNursingCharges);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRoomCharges);
            this.groupBox1.Controls.Add(this.txtRoomName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1346, 251);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtDate
            // 
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDate.Location = new System.Drawing.Point(551, 169);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(129, 27);
            this.txtDate.TabIndex = 88;
            this.txtDate.Value = new System.DateTime(2023, 6, 30, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(440, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 87;
            this.label8.Text = "Added On";
            // 
            // txtNursingCharges
            // 
            this.txtNursingCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNursingCharges.ForeColor = System.Drawing.Color.Gray;
            this.txtNursingCharges.Location = new System.Drawing.Point(550, 122);
            this.txtNursingCharges.MaxLength = 10;
            this.txtNursingCharges.Multiline = true;
            this.txtNursingCharges.Name = "txtNursingCharges";
            this.txtNursingCharges.Size = new System.Drawing.Size(366, 29);
            this.txtNursingCharges.TabIndex = 86;
            this.txtNursingCharges.Text = "Enter Nursing Charges";
            this.txtNursingCharges.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNursingCharges_MouseClick);
            this.txtNursingCharges.Enter += new System.EventHandler(this.txtNursingCharges_Enter);
            this.txtNursingCharges.Leave += new System.EventHandler(this.txtNursingCharges_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 85;
            this.label2.Text = "Nursing Charge";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtRoomCharges
            // 
            this.txtRoomCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoomCharges.ForeColor = System.Drawing.Color.Gray;
            this.txtRoomCharges.Location = new System.Drawing.Point(550, 74);
            this.txtRoomCharges.MaxLength = 10;
            this.txtRoomCharges.Multiline = true;
            this.txtRoomCharges.Name = "txtRoomCharges";
            this.txtRoomCharges.Size = new System.Drawing.Size(366, 29);
            this.txtRoomCharges.TabIndex = 82;
            this.txtRoomCharges.Text = "Enter Room Segment Charges";
            this.txtRoomCharges.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRoomCharges_MouseClick);
            this.txtRoomCharges.Enter += new System.EventHandler(this.txtRoomCharges_Enter);
            this.txtRoomCharges.Leave += new System.EventHandler(this.txtRoomCharges_Leave);
            // 
            // txtRoomName
            // 
            this.txtRoomName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoomName.ForeColor = System.Drawing.Color.Gray;
            this.txtRoomName.Location = new System.Drawing.Point(550, 26);
            this.txtRoomName.MaxLength = 30;
            this.txtRoomName.Multiline = true;
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(366, 29);
            this.txtRoomName.TabIndex = 81;
            this.txtRoomName.Text = "Enter the Room Segment Name";
            this.txtRoomName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRoomName_MouseClick);
            this.txtRoomName.Enter += new System.EventHandler(this.txtRoomName_Enter);
            this.txtRoomName.Leave += new System.EventHandler(this.txtRoomName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 21);
            this.label4.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(464, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Charge";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(411, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Room Segment";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::Ruby_Hospital.Properties.Resources.icons8_search_50__1_1;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(920, 159);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 90;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 38);
            this.panel2.TabIndex = 16;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(75, 7, 75, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Room Segment";
            // 
            // Manage_RoomSegment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manage_RoomSegment";
            this.Text = "Master_RoomSegment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Manage_RoomSegment_NursingCharges_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRoomCharges;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNursingCharges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Button btnDelete;
    }
}