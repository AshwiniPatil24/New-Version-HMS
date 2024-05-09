
namespace Ruby_Hospital
{
    partial class Lab_And_Radiology_Billing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lab_And_Radiology_Billing));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Lab_Billing = new System.Windows.Forms.TabPage();
            this.labbilling = new System.Windows.Forms.DataGridView();
            this.Radiology_billing = new System.Windows.Forms.TabPage();
            this.radiologybilling = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Lab_Billing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labbilling)).BeginInit();
            this.Radiology_billing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radiologybilling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 119);
            this.panel1.Name = "panel1";

            this.panel1.Size = new System.Drawing.Size(1198, 478);

           

            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Lab_Billing);
            this.tabControl1.Controls.Add(this.Radiology_billing);
            this.tabControl1.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(54, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(150, 15);
            this.tabControl1.SelectedIndex = 0;

            this.tabControl1.Size = new System.Drawing.Size(1090, 441);

          

            this.tabControl1.TabIndex = 1;
            // 
            // Lab_Billing
            // 
            this.Lab_Billing.Controls.Add(this.labbilling);
            this.Lab_Billing.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Billing.Location = new System.Drawing.Point(4, 56);
            this.Lab_Billing.Name = "Lab_Billing";
            this.Lab_Billing.Padding = new System.Windows.Forms.Padding(3);

            this.Lab_Billing.Size = new System.Drawing.Size(1082, 381);

            this.Lab_Billing.TabIndex = 0;
            this.Lab_Billing.Text = "   Lab Billing    ";
            this.Lab_Billing.UseVisualStyleBackColor = true;
            // 
            // labbilling
            // 
            this.labbilling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.labbilling.BackgroundColor = System.Drawing.Color.White;
            this.labbilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.labbilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labbilling.Location = new System.Drawing.Point(3, 3);
            this.labbilling.Name = "labbilling";
            this.labbilling.RowHeadersWidth = 45;

            this.labbilling.Size = new System.Drawing.Size(1076, 375);

            this.labbilling.TabIndex = 1;
            this.labbilling.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.labbilling_CellClick);
            this.labbilling.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.labbilling_CellContentClick);
            // 
            // Radiology_billing
            // 
            this.Radiology_billing.Controls.Add(this.radiologybilling);
            this.Radiology_billing.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.Radiology_billing.Location = new System.Drawing.Point(4, 56);
            this.Radiology_billing.Name = "Radiology_billing";
            this.Radiology_billing.Padding = new System.Windows.Forms.Padding(3);

            this.Radiology_billing.Size = new System.Drawing.Size(1082, 381);

            this.Radiology_billing.TabIndex = 1;
            this.Radiology_billing.Text = "Radiology Billing";
            this.Radiology_billing.UseVisualStyleBackColor = true;
            // 
            // radiologybilling
            // 
            this.radiologybilling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.radiologybilling.BackgroundColor = System.Drawing.Color.White;
            this.radiologybilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.radiologybilling.DefaultCellStyle = dataGridViewCellStyle1;
            this.radiologybilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radiologybilling.Location = new System.Drawing.Point(3, 3);
            this.radiologybilling.Name = "radiologybilling";

            this.radiologybilling.ReadOnly = true;
            this.radiologybilling.Size = new System.Drawing.Size(1076, 375);

            this.radiologybilling.TabIndex = 0;
            this.radiologybilling.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.radiologybilling_CellClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Ruby_Hospital.Properties.Resources._264294910_108862081637008_8238947895213189007_n_removebg_preview;

            this.pictureBox2.Location = new System.Drawing.Point(1377, 10);

            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(168, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 81;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl;

            this.pictureBox7.Location = new System.Drawing.Point(12, 56);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(1198, 57);

            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 82;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 28);
            this.label1.TabIndex = 83;
            this.label1.Text = "Lab and Radiology ";
            // 

            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1222, 40);
            this.panel2.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Century", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(50, 5, 50, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lab and Radiology Bill";

            // 
            // Lab_And_Radiology_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;

            this.ClientSize = new System.Drawing.Size(1222, 609);
            this.Controls.Add(this.panel2);

            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lab_And_Radiology_Billing";
            this.ShowIcon = false;
            this.Text = "Lab_And_Radiology_Billing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Lab_And_Radiology_Billing_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Lab_Billing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.labbilling)).EndInit();
            this.Radiology_billing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radiologybilling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Lab_Billing;
        private System.Windows.Forms.DataGridView labbilling;
        private System.Windows.Forms.TabPage Radiology_billing;
        private System.Windows.Forms.DataGridView radiologybilling;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}