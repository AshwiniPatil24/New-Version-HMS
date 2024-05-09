namespace Ruby_Hospital
{
    partial class Master_RoomNumber
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoOFBeds = new System.Windows.Forms.TextBox();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.btnDelete.Location = new System.Drawing.Point(730, 523);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 38);
            this.btnDelete.TabIndex = 100;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnsave.Location = new System.Drawing.Point(607, 523);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(96, 38);
            this.btnsave.TabIndex = 99;
            this.btnsave.Text = "Add";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.groupBox1.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNoOFBeds);
            this.groupBox1.Controls.Add(this.txtRoomName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.groupBox1.Location = new System.Drawing.Point(-4, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1378, 296);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDate.Location = new System.Drawing.Point(609, 195);
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
            this.label8.Location = new System.Drawing.Point(507, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 87;
            this.label8.Text = "Added On";
            // 
            // txtNoOFBeds
            // 
            this.txtNoOFBeds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoOFBeds.Enabled = false;
            this.txtNoOFBeds.ForeColor = System.Drawing.Color.Gray;
            this.txtNoOFBeds.Location = new System.Drawing.Point(609, 139);
            this.txtNoOFBeds.MaxLength = 10;
            this.txtNoOFBeds.Multiline = true;
            this.txtNoOFBeds.Name = "txtNoOFBeds";
            this.txtNoOFBeds.Size = new System.Drawing.Size(366, 29);
            this.txtNoOFBeds.TabIndex = 82;
            // 
            // txtRoomName
            // 
            this.txtRoomName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoomName.Enabled = false;
            this.txtRoomName.ForeColor = System.Drawing.Color.Gray;
            this.txtRoomName.Location = new System.Drawing.Point(609, 81);
            this.txtRoomName.MaxLength = 30;
            this.txtRoomName.Multiline = true;
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(366, 29);
            this.txtRoomName.TabIndex = 81;
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
            this.label6.Location = new System.Drawing.Point(462, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Number Of Beds";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(470, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Room Segment";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::Ruby_Hospital.Properties.Resources.icons8_search_50__1_1;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(935, 99);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 97;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtSearchName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchName.Location = new System.Drawing.Point(665, 99);
            this.txtSearchName.Multiline = true;
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(264, 29);
            this.txtSearchName.TabIndex = 96;
            this.txtSearchName.Text = "Enter Room Segment";
            this.txtSearchName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearchName_MouseClick);
            this.txtSearchName.Enter += new System.EventHandler(this.txtSearchName_Enter);
            this.txtSearchName.Leave += new System.EventHandler(this.txtSearchName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(483, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 23);
            this.label3.TabIndex = 95;
            this.label3.Text = "Search By Name";
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
            this.panel2.TabIndex = 94;
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
            this.label1.Size = new System.Drawing.Size(205, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bed Number";
            // 
            // Master_RoomNumber
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
            this.Name = "Master_RoomNumber";
            this.Text = "Master_RoomNumber";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNoOFBeds;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}