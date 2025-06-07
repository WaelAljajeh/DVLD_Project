namespace DVLD_Project
{
    partial class frmDetainedLicenseList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetainLicensesList = new System.Windows.Forms.DataGridView();
            this.lblAddUpdatePerson = new System.Windows.Forms.Label();
            this.cmbActiveList = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.cmsDetainInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pbDetain = new System.Windows.Forms.PictureBox();
            this.pbRealseDetain = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SLHStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLicensesList)).BeginInit();
            this.cmsDetainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRealseDetain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetainLicensesList
            // 
            this.dgvDetainLicensesList.AllowUserToAddRows = false;
            this.dgvDetainLicensesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainLicensesList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDetainLicensesList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainLicensesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetainLicensesList.ColumnHeadersHeight = 20;
            this.dgvDetainLicensesList.ContextMenuStrip = this.cmsDetainInfo;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetainLicensesList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetainLicensesList.EnableHeadersVisualStyles = false;
            this.dgvDetainLicensesList.Location = new System.Drawing.Point(5, 297);
            this.dgvDetainLicensesList.Margin = new System.Windows.Forms.Padding(30);
            this.dgvDetainLicensesList.MultiSelect = false;
            this.dgvDetainLicensesList.Name = "dgvDetainLicensesList";
            this.dgvDetainLicensesList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainLicensesList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetainLicensesList.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetainLicensesList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetainLicensesList.RowTemplate.Height = 26;
            this.dgvDetainLicensesList.Size = new System.Drawing.Size(1519, 434);
            this.dgvDetainLicensesList.TabIndex = 56;
            // 
            // lblAddUpdatePerson
            // 
            this.lblAddUpdatePerson.AutoSize = true;
            this.lblAddUpdatePerson.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdatePerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdatePerson.Location = new System.Drawing.Point(619, 233);
            this.lblAddUpdatePerson.Name = "lblAddUpdatePerson";
            this.lblAddUpdatePerson.Size = new System.Drawing.Size(328, 34);
            this.lblAddUpdatePerson.TabIndex = 58;
            this.lblAddUpdatePerson.Text = "List Detained Licenses";
            // 
            // cmbActiveList
            // 
            this.cmbActiveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActiveList.FormattingEnabled = true;
            this.cmbActiveList.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbActiveList.Location = new System.Drawing.Point(255, 257);
            this.cmbActiveList.Name = "cmbActiveList";
            this.cmbActiveList.Size = new System.Drawing.Size(150, 24);
            this.cmbActiveList.TabIndex = 64;
            this.cmbActiveList.SelectedIndexChanged += new System.EventHandler(this.cmbActiveList_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(255, 258);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 24);
            this.txtSearch.TabIndex = 63;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None",
            "DetainID",
            "IsReleased",
            "NationalNo",
            "FullName",
            "ReleaseApplicationID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(99, 258);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(150, 24);
            this.cmbFilterBy.TabIndex = 62;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 61;
            this.label2.Text = "Filter By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 752);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 21);
            this.label4.TabIndex = 66;
            this.label4.Text = "#Records :";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(112, 753);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(19, 21);
            this.lblRecord.TabIndex = 65;
            this.lblRecord.Text = "0";
            // 
            // cmsDetainInfo
            // 
            this.cmsDetainInfo.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsDetainInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.SLHStripMenuItem,
            this.showLicenseHistoryToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.cmsDetainInfo.Name = "cmsPeople";
            this.cmsDetainInfo.Size = new System.Drawing.Size(344, 190);
            this.cmsDetainInfo.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDetainInfo_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(340, 6);
            // 
            // pbDetain
            // 
            this.pbDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbDetain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDetain.Image = global::DVLD_Project.Properties.Resources.Detain_64;
            this.pbDetain.Location = new System.Drawing.Point(1395, 211);
            this.pbDetain.Name = "pbDetain";
            this.pbDetain.Size = new System.Drawing.Size(113, 84);
            this.pbDetain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDetain.TabIndex = 60;
            this.pbDetain.TabStop = false;
            this.pbDetain.Click += new System.EventHandler(this.pbDetain_Click);
            // 
            // pbRealseDetain
            // 
            this.pbRealseDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbRealseDetain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRealseDetain.Image = global::DVLD_Project.Properties.Resources.Release_Detained_License_641;
            this.pbRealseDetain.Location = new System.Drawing.Point(1276, 211);
            this.pbRealseDetain.Name = "pbRealseDetain";
            this.pbRealseDetain.Size = new System.Drawing.Size(113, 84);
            this.pbRealseDetain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRealseDetain.TabIndex = 59;
            this.pbRealseDetain.TabStop = false;
            this.pbRealseDetain.Click += new System.EventHandler(this.pbRealseDetain_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(606, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDetailsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(343, 38);
            this.showDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // SLHStripMenuItem
            // 
            this.SLHStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SLHStripMenuItem.Image = global::DVLD_Project.Properties.Resources.License_View_321;
            this.SLHStripMenuItem.Name = "SLHStripMenuItem";
            this.SLHStripMenuItem.Size = new System.Drawing.Size(343, 38);
            this.SLHStripMenuItem.Text = "Show License Details";
            this.SLHStripMenuItem.Click += new System.EventHandler(this.SLHStripMenuItem_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseHistoryToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonLicenseHistory_32;
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(343, 38);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            this.releaseDetainedLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Release_Detained_License_321;
            this.releaseDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(343, 38);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // frmDetainedLicenseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 782);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.cmbActiveList);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbDetain);
            this.Controls.Add(this.pbRealseDetain);
            this.Controls.Add(this.lblAddUpdatePerson);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvDetainLicensesList);
            this.Name = "frmDetainedLicenseList";
            this.Text = "frmDetainedLicenseList";
            this.Load += new System.EventHandler(this.frmDetainedLicenseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainLicensesList)).EndInit();
            this.cmsDetainInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDetain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRealseDetain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetainLicensesList;
        private System.Windows.Forms.Label lblAddUpdatePerson;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbRealseDetain;
        private System.Windows.Forms.PictureBox pbDetain;
        private System.Windows.Forms.ComboBox cmbActiveList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.ContextMenuStrip cmsDetainInfo;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SLHStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}