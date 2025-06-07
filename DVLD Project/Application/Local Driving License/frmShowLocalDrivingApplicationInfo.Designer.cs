namespace DVLD_Project
{
    partial class frmShowLocalDrivingApplicationInfo
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
            this.ucDLAPPInfo1 = new DVLD_Project.ucDLAPPInfo();
            this.SuspendLayout();
            // 
            // ucDLAPPInfo1
            // 
            this.ucDLAPPInfo1.Location = new System.Drawing.Point(-1, 4);
            this.ucDLAPPInfo1.Name = "ucDLAPPInfo1";
            this.ucDLAPPInfo1.Size = new System.Drawing.Size(941, 551);
            this.ucDLAPPInfo1.TabIndex = 0;
            // 
            // frmShowLocalDrivingApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 551);
            this.Controls.Add(this.ucDLAPPInfo1);
            this.Name = "frmShowLocalDrivingApplicationInfo";
            this.Text = "frmShowLocalDrivingApplicationInfo";
            this.Load += new System.EventHandler(this.frmShowLocalDrivingApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucDLAPPInfo ucDLAPPInfo1;
    }
}