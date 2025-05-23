using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ucDriverLicensesHistoryList : UserControl
    {
        public ucDriverLicensesHistoryList()
        {
            InitializeComponent();
        }
       void LoadLocalLicenses(int AppPersonID)
        {
            dgvLocalList.DataSource=clsLicense.GetDriverLicenseHistoryList(AppPersonID);
            
            lblRecord.Text = (dgvLocalList.RowCount).ToString();
            
        }
        void LoadInternationalLicense(int AppPersonID)
        {
        dgvInternationalList.DataSource=clsInternationalLicense.GetInternationalLicensesListPerPerson(AppPersonID);
            
            lblInternationalRecord.Text = (dgvInternationalList.RowCount).ToString();
         }
        public void LoadInfoLicense(int AppPersonID)
        {
            LoadLocalLicenses(AppPersonID);
            LoadInternationalLicense(AppPersonID);
        }
        private void grbDriverLicenses_Enter(object sender, EventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory((int)dgvLocalList.CurrentRow.Cells[0].Value);
            frmShowLicenseHistory.ShowDialog();
        }

        private void ucDriverLicensesHistoryList_Load(object sender, EventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowInternationalDriverLicenseInfo frmShowInternationalDriverLicenseInfo = new frmShowInternationalDriverLicenseInfo((int)dgvInternationalList.CurrentRow.Cells[0].Value);
            frmShowInternationalDriverLicenseInfo.ShowDialog();
        }
    }
}
