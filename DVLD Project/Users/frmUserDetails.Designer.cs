namespace DVLD_Project
{
    partial class frmUserDetails
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
            this.ucUserInformationCard1 = new DVLD_Project.ucUserInformationCard();
            this.SuspendLayout();
            // 
            // ucUserInformationCard1
            // 
            this.ucUserInformationCard1.Location = new System.Drawing.Point(2, 26);
            this.ucUserInformationCard1.Name = "ucUserInformationCard1";
            this.ucUserInformationCard1.Size = new System.Drawing.Size(914, 524);
            this.ucUserInformationCard1.TabIndex = 0;
            this.ucUserInformationCard1.Load += new System.EventHandler(this.ucUserInformationCard1_Load);
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 588);
            this.Controls.Add(this.ucUserInformationCard1);
            this.Name = "frmUserDetails";
            this.Text = "frmUserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucUserInformationCard ucUserInformationCard1;
    }
}