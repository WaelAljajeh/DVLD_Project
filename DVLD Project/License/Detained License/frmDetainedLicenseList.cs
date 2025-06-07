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
    public partial class frmDetainedLicenseList : Form
    {
        public frmDetainedLicenseList()
        {
            InitializeComponent();
        }
        //clsDetain _Detain;
        void ChangeListHeaders()
        {
            dgvDetainLicensesList.Columns["DetainID"].HeaderText= "D.ID";
            dgvDetainLicensesList.Columns["LicenseID"].HeaderText = "L.ID";
            dgvDetainLicensesList.Columns["IsReleased"].HeaderText = "Is Released";
            dgvDetainLicensesList.Columns["NationalNo"].HeaderText = "N.No";
            dgvDetainLicensesList.Columns["ReleaseDate"].HeaderText = "Release Date";
            dgvDetainLicensesList.Columns["FullName"].HeaderText = "Full Name";
            dgvDetainLicensesList.Columns["FineFees"].HeaderText = "Fine Fees";
            dgvDetainLicensesList.Columns["ReleaseApplicationID"].HeaderText = "Release App.ID";


        }
        void RefreshList()
        {
            dgvDetainLicensesList.DataSource=clsDetain.GetDetainedLicenseList();
            lblRecord.Text = (dgvDetainLicensesList.RowCount).ToString();
        }
        private void frmDetainedLicenseList_Load(object sender, EventArgs e)
        {
            RefreshList();
            ChangeListHeaders();
            //cmbActiveList.SelectedIndex = 0;
            cmbFilterBy.SelectedIndex=0;
        }

        private void pbDetain_Click(object sender, EventArgs e)
        {
            frmDetianLicense frmDetianLicense = new frmDetianLicense();
            frmDetianLicense.ShowDialog();
            RefreshList();
        }

        private void pbRealseDetain_Click(object sender, EventArgs e)
        {
            clsApplicationTypes.ApplicationType = clsApplicationTypes.enApplicationType.Realease_Detain_License;
            frmRealseDetainedLicense frmRealseDetainedLicense=new frmRealseDetainedLicense();
            frmRealseDetainedLicense.ShowDialog();
            RefreshList();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedItem.ToString() == "DetainID" || cmbFilterBy.SelectedItem.ToString() == "ReleaseApplicationID")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (!char.IsControl(e.KeyChar))
                        e.Handled = true;
                }
            }
        }
        void FilteryBy()
        {
            if (txtSearch.Text == "")
                return;
            DataTable DetainedList = (DataTable)dgvDetainLicensesList.DataSource;
            if (cmbFilterBy.SelectedIndex==0) { return; }
            if (cmbFilterBy.SelectedItem.ToString() == "IsReleased")
            {

                switch (cmbActiveList.SelectedItem.ToString())
                {
                    case "All":
                        DetainedList.DefaultView.RowFilter = "";
                        return;
                    case "Yes":
                        DetainedList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = {true}";
                        break;
                    case "No":
                        DetainedList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = {false}";
                        break;

                }


            }
            else if ((cmbFilterBy.SelectedItem.ToString() == "DetainID") || (cmbFilterBy.SelectedItem.ToString() == "ReleaseApplicationID"))
                DetainedList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = '{(int.Parse(txtSearch.Text))}'";
            else
                DetainedList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} LIKE '%{txtSearch.Text}%'";

            lblRecord.Text = (dgvDetainLicensesList.RowCount).ToString();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbFilterBy.SelectedIndex == 0)
            {
                txtSearch.Visible = false;
                cmbActiveList.Visible = false;
                return;
            }
            else if (cmbFilterBy.SelectedItem.ToString() == "IsReleased")
            {
                cmbActiveList.SelectedIndex = 0;
                txtSearch.Visible = false;
                cmbActiveList.Visible = true;
                return;

            }
            txtSearch.Visible = true;
            txtSearch.Text = "";
            txtSearch.Focus();
            cmbActiveList.Visible = false;


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilteryBy();
        }

        private void cmbActiveList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            FilteryBy();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clsApplication application = clsApplication.FindBaseApplication((int)dgvDetainLicensesList.CurrentRow.Cells["ReleaseApplicationID"].Value);
            frmPersonDetails frmPersonDetails = new frmPersonDetails(clsLicense.Find((int)dgvDetainLicensesList.CurrentRow.Cells[1].Value).DriverInfo.PerosnID);
            frmPersonDetails.ShowDialog();
            RefreshList();
        }

        private void SLHStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainLicensesList.CurrentRow.Cells["LicenseID"].Value;
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(LicenseID);
            frmShowLicenseHistory.ShowDialog();
            RefreshList();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory(clsLicense.Find((int)dgvDetainLicensesList.CurrentRow.Cells[1].Value).DriverInfo.PerosnID);
            frmPersonLicenseHistory.ShowDialog();
            RefreshList();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplicationTypes.ApplicationType = clsApplicationTypes.enApplicationType.Realease_Detain_License;
            int LicenseID = (int)dgvDetainLicensesList.CurrentRow.Cells["LicenseID"].Value;
            frmRealseDetainedLicense frmRealseDetainedLicense= new frmRealseDetainedLicense(LicenseID);
            frmRealseDetainedLicense.ShowDialog();
            RefreshList();
        }

        private void cmsDetainInfo_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = (!(bool)dgvDetainLicensesList.CurrentRow.Cells["IsReleased"].Value);
            

        }
    }
}
