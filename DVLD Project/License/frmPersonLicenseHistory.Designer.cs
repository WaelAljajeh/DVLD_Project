namespace DVLD_Project
{
    partial class frmPersonLicenseHistory
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
            this.lblAddUpdatePerson = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucDriverLicensesHistoryList1 = new DVLD_Project.ucDriverLicensesHistoryList();
            this.ucPersonInfoWithFilter1 = new DVLD_Project.ucPersonInfoWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddUpdatePerson
            // 
            this.lblAddUpdatePerson.AutoSize = true;
            this.lblAddUpdatePerson.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdatePerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdatePerson.Location = new System.Drawing.Point(669, 9);
            this.lblAddUpdatePerson.Name = "lblAddUpdatePerson";
            this.lblAddUpdatePerson.Size = new System.Drawing.Size(242, 34);
            this.lblAddUpdatePerson.TabIndex = 60;
            this.lblAddUpdatePerson.Text = "Licenses History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(67, 222);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 278);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_322;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(1243, 968);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 37);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucDriverLicensesHistoryList1
            // 
            this.ucDriverLicensesHistoryList1.Location = new System.Drawing.Point(12, 617);
            this.ucDriverLicensesHistoryList1.Name = "ucDriverLicensesHistoryList1";
            this.ucDriverLicensesHistoryList1.Size = new System.Drawing.Size(1365, 345);
            this.ucDriverLicensesHistoryList1.TabIndex = 62;
            // 
            // ucPersonInfoWithFilter1
            // 
            this.ucPersonInfoWithFilter1.FilterEnabled = true;
            this.ucPersonInfoWithFilter1.Location = new System.Drawing.Point(402, 46);
            this.ucPersonInfoWithFilter1.Name = "ucPersonInfoWithFilter1";
            this.ucPersonInfoWithFilter1.Size = new System.Drawing.Size(992, 565);
            this.ucPersonInfoWithFilter1.TabIndex = 0;
            this.ucPersonInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ucPersonInfoWithFilter1_OnPersonSelected);
            // 
            // frmPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 1054);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucDriverLicensesHistoryList1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAddUpdatePerson);
            this.Controls.Add(this.ucPersonInfoWithFilter1);
            this.Name = "frmPersonLicenseHistory";
            this.Text = "frmPersonLicenseHistory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPersonInfoWithFilter ucPersonInfoWithFilter1;
        private System.Windows.Forms.Label lblAddUpdatePerson;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ucDriverLicensesHistoryList ucDriverLicensesHistoryList1;
        private System.Windows.Forms.Button btnClose;
    }
}