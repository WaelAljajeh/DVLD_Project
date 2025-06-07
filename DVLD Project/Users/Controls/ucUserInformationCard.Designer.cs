namespace DVLD_Project
{
    partial class ucUserInformationCard
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
            this.ucPersonDetails1 = new DVLD_Project.ucPersonDetails();
            this.grpLogininfo = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpLogininfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPersonDetails1
            // 
            this.ucPersonDetails1.Location = new System.Drawing.Point(0, 0);
            this.ucPersonDetails1.Name = "ucPersonDetails1";
            this.ucPersonDetails1.Size = new System.Drawing.Size(947, 417);
            this.ucPersonDetails1.TabIndex = 0;
            this.ucPersonDetails1.Load += new System.EventHandler(this.ucPersonDetails1_Load);
            // 
            // grpLogininfo
            // 
            this.grpLogininfo.Controls.Add(this.lblIsActive);
            this.grpLogininfo.Controls.Add(this.label2);
            this.grpLogininfo.Controls.Add(this.lblUsername);
            this.grpLogininfo.Controls.Add(this.label8);
            this.grpLogininfo.Controls.Add(this.lblUserID);
            this.grpLogininfo.Controls.Add(this.label3);
            this.grpLogininfo.Location = new System.Drawing.Point(3, 437);
            this.grpLogininfo.Name = "grpLogininfo";
            this.grpLogininfo.Size = new System.Drawing.Size(938, 106);
            this.grpLogininfo.TabIndex = 1;
            this.grpLogininfo.TabStop = false;
            this.grpLogininfo.Text = "Login Information";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.Location = new System.Drawing.Point(728, 54);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(60, 22);
            this.lblIsActive.TabIndex = 40;
            this.lblIsActive.Text = "?????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(607, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 39;
            this.label2.Text = "Is Active :";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(435, 54);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 22);
            this.lblUsername.TabIndex = 38;
            this.lblUsername.Text = "?????";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(300, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 22);
            this.label8.TabIndex = 37;
            this.label8.Text = "Username :";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(141, 54);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(60, 22);
            this.lblUserID.TabIndex = 36;
            this.lblUserID.Text = "?????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 31;
            this.label3.Text = "UserID :";
            // 
            // ucUserInformationCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpLogininfo);
            this.Controls.Add(this.ucPersonDetails1);
            this.Name = "ucUserInformationCard";
            this.Size = new System.Drawing.Size(944, 549);
            this.Load += new System.EventHandler(this.ucUserInformationCard_Load);
            this.grpLogininfo.ResumeLayout(false);
            this.grpLogininfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucPersonDetails ucPersonDetails1;
        private System.Windows.Forms.GroupBox grpLogininfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label8;
    }
}
