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
    public partial class frmDetianLicense : Form
    {
        public frmDetianLicense()
        {
            InitializeComponent();
        }
        clsDetain _Detain;

        private void ucDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID=obj;
            lblLicenseID.Text = SelectedLicenseID.ToString();
            if (SelectedLicenseID == -1)
                return;
            if (ucDriverLicenseWithFilter1.SelectedLicense == null)
                return;
            
            llShowLicenseHistory.Enabled = true;
            if(!ucDriverLicenseWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Choose an active License","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }
            if(ucDriverLicenseWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show("This License is expired", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled=false;
                return;
            }
            if (clsDetain.IsDetainExistingByLicenseID(SelectedLicenseID,false))
            {
                MessageBox.Show("This License is already Detained", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }
            btnDetain.Enabled = true;
            
            
        }
        void LoadBasicDefaultInfo()
        {
            lblUsername.Text=clsGlobalSettings.CuurentUser.Username;
            lblDeitainDate.Text = DateTime.Now.ToShortDateString();
        }

        private void frmDetianLicense_Load(object sender, EventArgs e)
        {
            LoadBasicDefaultInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _Detain=new clsDetain();
            _Detain.DetainDate = DateTime.Now;
            _Detain.IsReleased = false;
            _Detain.LicenseID=ucDriverLicenseWithFilter1.SelectedLicense.LicenseID;
            _Detain.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            _Detain.FineFees = Convert.ToSingle(nudFineFees.Value);
            if(_Detain.Save())
            {
                ucDriverLicenseWithFilter1.FilterEnable = false;
                llShowLicenseInfo.Enabled = true;
                MessageBox.Show("Detained Successfuly");
                ucDriverLicenseWithFilter1.UpdateIsDetainValue();
            }

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.ApplicationInfo.ApplicationPersonID);
            frmPersonLicenseHistory.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.LicenseID);
            frmShowLicenseHistory.ShowDialog();

        }
    }
}
