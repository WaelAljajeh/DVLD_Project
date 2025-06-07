namespace DVLD_Project
{
    partial class frmAddEditAppointmentForVisionTest
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTestPassed = new System.Windows.Forms.Label();
            this.ucRetakeTestInfo1 = new DVLD_Project.ucRetakeTestInfo();
            this.ucVisionTest1 = new DVLD_Project.ucVisionTest();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Project.Properties.Resources.Save_322;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(610, 801);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 31);
            this.btnSave.TabIndex = 78;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(297, 854);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 31);
            this.btnClose.TabIndex = 79;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblTestPassed
            // 
            this.lblTestPassed.AutoSize = true;
            this.lblTestPassed.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestPassed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTestPassed.Location = new System.Drawing.Point(120, 163);
            this.lblTestPassed.Name = "lblTestPassed";
            this.lblTestPassed.Size = new System.Drawing.Size(493, 34);
            this.lblTestPassed.TabIndex = 81;
            this.lblTestPassed.Text = "Person Is Already Sat for this Test";
            this.lblTestPassed.Visible = false;
            // 
            // ucRetakeTestInfo1
            // 
            this.ucRetakeTestInfo1.Location = new System.Drawing.Point(2, 661);
            this.ucRetakeTestInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ucRetakeTestInfo1.Name = "ucRetakeTestInfo1";
            this.ucRetakeTestInfo1.Size = new System.Drawing.Size(716, 133);
            this.ucRetakeTestInfo1.TabIndex = 77;
            this.ucRetakeTestInfo1.Load += new System.EventHandler(this.ucRetakeTestInfo1_Load);
            // 
            // ucVisionTest1
            // 
            this.ucVisionTest1.AppointmentDate = new System.DateTime(2025, 4, 21, 0, 21, 34, 605);
            this.ucVisionTest1.Location = new System.Drawing.Point(2, 3);
            this.ucVisionTest1.Name = "ucVisionTest1";
            this.ucVisionTest1.Size = new System.Drawing.Size(752, 829);
            this.ucVisionTest1.TabIndex = 80;
            this.ucVisionTest1.Load += new System.EventHandler(this.ucVisionTest1_Load);
            // 
            // frmAddEditAppointmentForVisionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 897);
            this.Controls.Add(this.lblTestPassed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ucRetakeTestInfo1);
            this.Controls.Add(this.ucVisionTest1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmAddEditAppointmentForVisionTest";
            this.Text = "frmAddEditAppointmentForVisionTest";
            this.Load += new System.EventHandler(this.frmAddEditAppointmentForVisionTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private ucRetakeTestInfo ucRetakeTestInfo1;
        private ucVisionTest ucVisionTest1;
        private System.Windows.Forms.Label lblTestPassed;
    }
}