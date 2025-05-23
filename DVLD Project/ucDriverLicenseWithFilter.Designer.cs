namespace DVLD_Project
{
    partial class ucDriverLicenseWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucDrivingLicenseDetails1 = new DVLD_Project.ucDrivingLicenseDetails();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.pbSearch);
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Controls.Add(this.label2);
            this.grpFilter.Location = new System.Drawing.Point(3, 3);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(990, 103);
            this.grpFilter.TabIndex = 2;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // pbSearch
            // 
            this.pbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSearch.Image = global::DVLD_Project.Properties.Resources.LocalDriving_License;
            this.pbSearch.Location = new System.Drawing.Point(573, 57);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(59, 34);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 10;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(133, 63);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(417, 24);
            this.txtFilter.TabIndex = 9;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "License ID :";
            // 
            // ucDrivingLicenseDetails1
            // 
            this.ucDrivingLicenseDetails1.Location = new System.Drawing.Point(0, 138);
            this.ucDrivingLicenseDetails1.Name = "ucDrivingLicenseDetails1";
            this.ucDrivingLicenseDetails1.Size = new System.Drawing.Size(993, 440);
            this.ucDrivingLicenseDetails1.TabIndex = 0;
            this.ucDrivingLicenseDetails1.OnLicenseSelected += new System.Action<int>(this.ucDrivingLicenseDetails1_OnLicenseSelected);
            this.ucDrivingLicenseDetails1.Load += new System.EventHandler(this.ucDrivingLicenseDetails1_Load);
            // 
            // ucDriverLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.ucDrivingLicenseDetails1);
            this.Name = "ucDriverLicenseWithFilter";
            this.Size = new System.Drawing.Size(999, 578);
            this.Load += new System.EventHandler(this.ucDriverLicenseWithFilter_Load);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDrivingLicenseDetails ucDrivingLicenseDetails1;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
    }
}
