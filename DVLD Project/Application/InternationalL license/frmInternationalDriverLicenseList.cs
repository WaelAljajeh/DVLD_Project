using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmInternationalDriverLicenseList : Form
    {
        clsDriver _Driver;
        public frmInternationalDriverLicenseList()
        {
            InitializeComponent();
        }
        void RefreshList()
        {
            dgvInternationalDrivingListList.DataSource = clsInternationalLicense.GetInternationalLicensesList();
            lblRecord.Text=dgvInternationalDrivingListList.RowCount.ToString();
        }
        private void frmInternationalDriverLicenseList_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbAddInternationalDriver_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense frmIssueInternationalLicense=new frmIssueInternationalLicense();
            frmIssueInternationalLicense.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            _Driver = clsDriver.Find((int)dgvInternationalDrivingListList.CurrentRow.Cells["DriverID"].Value);   
            frmPersonDetails frmPersonDetails = new frmPersonDetails(_Driver.PerosnID);
            frmPersonDetails.ShowDialog();
        }

        private void SLHStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmShowInternationalDriverLicenseInfo frmShowInternationalDriverLicenseInfo  = new frmShowInternationalDriverLicenseInfo((int)dgvInternationalDrivingListList.CurrentRow.Cells[0].Value);
            frmShowInternationalDriverLicenseInfo.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory(clsApplication.FindBaseApplication((int)dgvInternationalDrivingListList.CurrentRow.Cells["ApplicationID"].Value).ApplicationPersonID);
            frmPersonLicenseHistory.ShowDialog();
        }
    }
}
