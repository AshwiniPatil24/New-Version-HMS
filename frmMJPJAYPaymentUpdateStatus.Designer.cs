namespace Ruby_Hospital
{
    partial class frmMJPJAYPaymentUpdateStatus
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFillOPD = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtpartial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbReceived = new System.Windows.Forms.CheckBox();
            this.chbPartial = new System.Windows.Forms.CheckBox();
            this.pnlTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlTop.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.lblFillOPD);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(823, 32);
            this.pnlTop.TabIndex = 3;
            // 
            // lblFillOPD
            // 
            this.lblFillOPD.BackColor = System.Drawing.Color.Transparent;
            this.lblFillOPD.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFillOPD.ForeColor = System.Drawing.Color.White;
            this.lblFillOPD.Location = new System.Drawing.Point(7, 3);
            this.lblFillOPD.Name = "lblFillOPD";
            this.lblFillOPD.Size = new System.Drawing.Size(235, 27);
            this.lblFillOPD.TabIndex = 14;
            this.lblFillOPD.Text = "MJPJAY Payment ";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(0, 425);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(823, 25);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkGreen;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(320, 332);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 34);
            this.btnUpdate.TabIndex = 247;
            this.btnUpdate.Text = "Submit";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Ruby_Hospital.Properties.Resources.bg;
            this.groupBox1.Controls.Add(this.txtpartial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chbReceived);
            this.groupBox1.Controls.Add(this.chbPartial);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(176, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Payment Status";
            // 
            // txtpartial
            // 
            this.txtpartial.Location = new System.Drawing.Point(336, 67);
            this.txtpartial.Name = "txtpartial";
            this.txtpartial.Size = new System.Drawing.Size(100, 31);
            this.txtpartial.TabIndex = 4;
            this.txtpartial.Text = "0";
            this.txtpartial.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Partial";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(171, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Received";
            // 
            // chbReceived
            // 
            this.chbReceived.AutoSize = true;
            this.chbReceived.BackColor = System.Drawing.Color.Transparent;
            this.chbReceived.Location = new System.Drawing.Point(150, 72);
            this.chbReceived.Name = "chbReceived";
            this.chbReceived.Size = new System.Drawing.Size(15, 14);
            this.chbReceived.TabIndex = 0;
            this.chbReceived.UseVisualStyleBackColor = false;
            this.chbReceived.CheckedChanged += new System.EventHandler(this.chbReceived_CheckedChanged);
            // 
            // chbPartial
            // 
            this.chbPartial.AutoSize = true;
            this.chbPartial.BackColor = System.Drawing.Color.Transparent;
            this.chbPartial.Location = new System.Drawing.Point(336, 30);
            this.chbPartial.Name = "chbPartial";
            this.chbPartial.Size = new System.Drawing.Size(15, 14);
            this.chbPartial.TabIndex = 1;
            this.chbPartial.UseVisualStyleBackColor = false;
            this.chbPartial.Visible = false;
            this.chbPartial.CheckedChanged += new System.EventHandler(this.chbPartial_CheckedChanged);
            // 
            // frmMJPJAYPaymentUpdateStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMJPJAYPaymentUpdateStatus";
            this.Text = "frmMJPJAYPaymentUpdateStatus";
            this.Load += new System.EventHandler(this.frmMJPJAYPaymentUpdateStatus_Load);
            this.pnlTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbReceived;
        private System.Windows.Forms.CheckBox chbPartial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFillOPD;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TextBox txtpartial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
    }
}