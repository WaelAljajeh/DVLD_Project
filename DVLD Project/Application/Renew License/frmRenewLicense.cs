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
    public partial class frmRenewLicense : Form
    {
       
        public frmRenewLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void LoadDefaultBasinInfo()
        {

            if (clsGlobalSettings.CuurentUser != null)
                lblUsername.Text = clsGlobalSettings.CuurentUser.Username.ToString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType).ToString();
            //lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppDate.Text = DateTime.Now.ToShortDateString();
        }
        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            LoadDefaultBasinInfo();
        }

        private void ucDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseInfo.Enabled = (SelectedLicenseID != -1);
            if (SelectedLicenseID == -1)
            {
                btnRenew.Enabled = false;
                return; 
            }
            lblLicenseFees.Text = ucDriverLicenseWithFilter1.SelectedLicense.PaidFees.ToString();
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblTotalFees.Text=(float.Parse(lblApplicationFees.Text)+float.Parse(lblLicenseFees.Text)).ToString();
            llShowLicenseInfo.Enabled = true;
            if (!ucDriverLicenseWithFilter1.SelectedLicense.IsActive)
            {
                btnRenew.Enabled = false;
                MessageBox.Show("The Selected License Is unActive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ucDriverLicenseWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                btnRenew.Enabled = false;
                MessageBox.Show($"Selected License Is not Yet Expired it will be expired in : {ucDriverLicenseWithFilter1.SelectedLicense.ExpirationDate}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            btnRenew.Enabled = true;
            
           
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            //clsApplication application = new clsApplication();
            //application.ApplicationDate = DateTime.Now;
            //application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
            //application.ApplicationPersonID=ucDriverLicenseWithFilter1.SelectedLicense.DriverInfo.PerosnID;
            //application.ApplicationTypeID = (int)clsApplicationTypes.ApplicationType;
            //application.CreatedByUserID=clsGlobalSettings.CuurentUser.UserID;
            //application.LastStatus = DateTime.Now;
            //application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType);
            //if(!application.Save())
            //{
            //    return;
            //}
            //clsLicense license = new clsLicense();
            //license.ApplicationID = application.ApplicationID;
            //license.Notes = txtNotes.Text;
            //license.IsActive=true;
            //license.CreatedByUserID = application.CreatedByUserID;
            //license.DriverID = ucDriverLicenseWithFilter1.SelectedLicense.DriverID;
            //license.ExpirationDate = DateTime.Now.AddYears(10);
            //license.IssueDate = DateTime.Now;
            //license.IssueReason = (int)clsLicense.enIssueReasons.Renew;
            //license.LicenseClass = ucDriverLicenseWithFilter1.SelectedLicense.LicenseClass;
            //license.PaidFees = ucDriverLicenseWithFilter1.SelectedLicense.PaidFees;
            //ucDriverLicenseWithFilter1.SelectedLicense.IsActive = false;
            clsLicense NewLicense = ucDriverLicenseWithFilter1.SelectedLicense.RenewLicense(txtNotes.Text.Trim(),clsGlobalSettings.CuurentUser.UserID);
            if(NewLicense!=null)
            {
                MessageBox.Show("Renewed Successfuly");
                lblRenewAppID.Text = NewLicense.ApplicationID.ToString();
                lblRenewdLicenseID.Text= NewLicense.LicenseID.ToString();
                llShowNewLicenseInfo.Enabled = true;
                btnRenew.Enabled = false;
                ucDriverLicenseWithFilter1.FilterEnable = false;
                ucDriverLicenseWithFilter1.LoadLicenseInfo(ucDriverLicenseWithFilter1.SelectedLicense.LicenseID);
            }

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.LicenseID);
            frmShowLicenseHistory.ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(int.Parse(lblRenewdLicenseID.Text));
            frmShowLicenseHistory.ShowDialog();
        }

        private void grbApplicationInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
