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
        int _DriverID = -1;
        clsDriver _Driver;
        DataTable _dtLoaclList;
        DataTable _dtInternationalList;
        public ucDriverLicensesHistoryList()
        {
            InitializeComponent();
        }
       void LoadLocalLicenses()
        {
            _dtLoaclList = clsDriver.GetLicense(_Driver.PerosnID);
            dgvLocalList.DataSource=_dtLoaclList;
            
            lblRecord.Text = (dgvLocalList.RowCount).ToString();
            
        }
        void LoadInternationalLicense()
        {
            _dtInternationalList=clsDriver.GetInternationalLicense(_Driver.PerosnID);
            dgvInternationalList.DataSource = _dtInternationalList;
            
            lblInternationalRecord.Text = (dgvInternationalList.RowCount).ToString();
         }
        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.Find(_DriverID);
            if (_Driver == null)
            {
                MessageBox.Show("There Is No Dirver with that DriverID= "+_DriverID);
                return;
            }
            LoadLocalLicenses();
            LoadInternationalLicense();
        }
        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver == null)
            {
                MessageBox.Show("There Is No Dirver linked with that PersonID= " + PersonID);
                return;
            }
            _DriverID = _Driver.DriverID;
            LoadLocalLicenses();
            LoadInternationalLicense();
        }
        public void Clear()
        {
            _dtLoaclList.Clear();
            _dtInternationalList.Clear();
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
