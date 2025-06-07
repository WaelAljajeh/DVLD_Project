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
    public partial class frmReplacementDamagedOrLostLicense : Form
    {
        public frmReplacementDamagedOrLostLicense()
        {
            InitializeComponent();
        }
        void HandleApplicationTypeHaveChoosen()
        {
            if (rbDamaged.Checked)
            {
                clsApplicationTypes.ApplicationType = clsApplicationTypes.enApplicationType.Replace_Damaged_License;
                clsLicense.IssueReasons = clsLicense.enIssueReasons.Replacement_For_Damaged;

            }
            else
            {
                clsApplicationTypes .ApplicationType = clsApplicationTypes.enApplicationType.Replace_Lost_License;
                clsLicense.IssueReasons = clsLicense.enIssueReasons.Replacement_For_Lost;
            }
            
        }
        void SetApplicationFees()
        {
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType).ToString();
        }
        void LoadBasicInfo()
        {
            ucDriverLicenseWithFilter1.FilterFoucse();
            HandleApplicationTypeHaveChoosen();
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            SetApplicationFees();
            lblUsername.Text = clsGlobalSettings.CuurentUser.Username;
        }
        private void frmReplacementDamagedOrLostLicense_Load(object sender, EventArgs e)
        {
            LoadBasicInfo();
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            HandleApplicationTypeHaveChoosen();
            SetApplicationFees();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectLicenseID = obj;
            if (SelectLicenseID == -1) 
            {
                btnReplacement.Enabled = false;
                return; }
            lblOldLicenseID.Text = SelectLicenseID.ToString();
            llShowLicenseInfo.Enabled = true;
            if(!ucDriverLicenseWithFilter1.SelectedLicense.IsActive)
            {
                btnReplacement.Enabled = false;
                MessageBox.Show("this License unActive Choose one Active","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            btnReplacement.Enabled = true;
            
        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            clsLicense NewLicense = ucDriverLicenseWithFilter1.SelectedLicense.Replacement(clsGlobalSettings.CuurentUser.UserID);
            if(NewLicense!=null)
            { 
                MessageBox.Show("Renewed Successfuly");
                lblReplacementAppID.Text = NewLicense.ApplicationID.ToString();
                lblReplacemetnLicenseID.Text = NewLicense.LicenseID.ToString();
                llShowNewLicenseInfo.Enabled = true;
                btnReplacement.Enabled = false;
                grpReplacmentFor.Enabled = false;

            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.LicenseID);
            frmShowLicenseHistory.ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(int.Parse(lblReplacemetnLicenseID.Text));
            frmShowLicenseHistory.ShowDialog();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            HandleApplicationTypeHaveChoosen();
            SetApplicationFees();
        }
    }
}
