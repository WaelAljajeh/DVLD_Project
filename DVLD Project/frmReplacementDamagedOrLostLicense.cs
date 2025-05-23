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
                clsUtil.ApplicationType = clsUtil.enApplicationType.Replace_Damaged_License;
                clsLicense.IssueReasons = clsLicense.enIssueReasons.Replacement_For_Damaged;

            }
            else
            {
                clsUtil.ApplicationType = clsUtil.enApplicationType.Replace_Lost_License;
                clsLicense.IssueReasons = clsLicense.enIssueReasons.Replacement_For_Lost;
            }
            
        }
        void SetApplicationFees()
        {
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.ApplicationType).ToString();
        }
        void LoadBasicInfo()
        {
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
            clsApplication application = new clsApplication();
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
            application.ApplicationPersonID = ucDriverLicenseWithFilter1.SelectedLicense.DriverInfo.PerosnID;
            application.ApplicationTypeID = (int)clsUtil.ApplicationType;
            application.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            application.LastStatus = DateTime.Now;
            application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.ApplicationType);
            if (!application.Save())
            {
                return;
            }
            clsLicense license = new clsLicense();
            license.ApplicationID = application.ApplicationID;
            license.Notes = "";
            license.IsActive = true;
            license.CreatedByUserID = application.CreatedByUserID;
            license.DriverID = ucDriverLicenseWithFilter1.SelectedLicense.DriverID;
            license.ExpirationDate = DateTime.Now.AddYears(10);
            license.IssueDate = DateTime.Now;
            license.IssueReason = (int)clsLicense.IssueReasons;
            license.LicenseClass = ucDriverLicenseWithFilter1.SelectedLicense.LicenseClass;
            license.PaidFees = ucDriverLicenseWithFilter1.SelectedLicense.PaidFees;
            ucDriverLicenseWithFilter1.SelectedLicense.IsActive = false;

            if (ucDriverLicenseWithFilter1.SelectedLicense.Save() && license.Save())
            {
                MessageBox.Show("Renewed Successfuly");
                lblReplacementAppID.Text = application.ApplicationID.ToString();
                lblReplacemetnLicenseID.Text = license.LicenseID.ToString();
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
    }
}
