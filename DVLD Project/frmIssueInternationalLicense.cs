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
    public partial class frmIssueInternationalLicense : Form
    {
        public frmIssueInternationalLicense()
        {
            InitializeComponent();
        }

        private void ucDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }
        clsInternationalLicense _InternationalLicense;
        void LoadDefaultBasinInfo()
        {
            
            if (clsGlobalSettings.CuurentUser != null)
                lblUsername.Text = clsGlobalSettings.CuurentUser.Username.ToString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.ApplicationType).ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
        }
        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
          LoadDefaultBasinInfo();
        }

        private void ucDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblLocalLicenseID.Text = SelectedLicenseID.ToString();
            if (SelectedLicenseID == -1)
                return;
            
            if(ucDriverLicenseWithFilter1.SelectedLicense == null)
            {
                
                return;
            }
            lblLocalLicenseID.Text = ucDriverLicenseWithFilter1.SelectedLicense.LicenseID.ToString();
            llShowLicenseHistory.Enabled = true;
            if (ucDriverLicenseWithFilter1.SelectedLicense.LicenseClass!=3)
            {
                MessageBox.Show("Choose License with Class 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ucDriverLicenseWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("Not Active License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsInternationalLicense.IsInternationalLicenseExistingByPerosnID(ucDriverLicenseWithFilter1.SelectedLicense.ApplicationInfo.ApplicationPersonID))
            {

                _InternationalLicense = clsInternationalLicense.FindByDriverID(ucDriverLicenseWithFilter1.SelectedLicense.DriverID,true);
                
                
                    lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                    lblInternationalAppID.Text = _InternationalLicense.ApplicationID.ToString();
                    llShowLicenseInfo.Enabled = true;
                    btnIssue.Enabled = false;
                    MessageBox.Show("There is already an active international License ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                
            }
           
            btnIssue.Enabled = true;
            


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsUtil.ApplicationType;
            application.ApplicationStatus = (byte)clsApplication.enAPPStatus.Completed;
            application.LastStatus = DateTime.Now;
            application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees(application.ApplicationTypeID);
            application.ApplicationPersonID = ucDriverLicenseWithFilter1.SelectedLicense.ApplicationInfo.ApplicationPersonID;
            if (!application.Save())
                return;
            _InternationalLicense = new clsInternationalLicense();
            _InternationalLicense.ApplicationID=application.ApplicationID;
            _InternationalLicense.ExpirationDate= DateTime.Now.AddYears(1);
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            _InternationalLicense.DriverID = ucDriverLicenseWithFilter1.SelectedLicense.DriverID;
            _InternationalLicense.IsActive = true;
            _InternationalLicense.IssuedUsingLocalLicenseID = ucDriverLicenseWithFilter1.SelectedLicense.LicenseID;
            if (_InternationalLicense.Save())
            {
                lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                MessageBox.Show("Issued Succesfuly");
                llShowLicenseInfo.Enabled = true;
            }
        }
        
            


        

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frmPersonLicense = new frmPersonLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.ApplicationInfo.ApplicationPersonID);
            frmPersonLicense.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalDriverLicenseInfo frmShowInternationalDriverLicenseInfo = new frmShowInternationalDriverLicenseInfo(int.Parse(lblInternationalLicenseID.Text));
            frmShowInternationalDriverLicenseInfo.ShowDialog();
        }
    }
}
