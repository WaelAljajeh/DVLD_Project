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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }
        

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleList frmPeopleList = new frmPeopleList();
            frmPeopleList.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList frmUsersList = new frmUsersList();
            frmUsersList.ShowDialog();
        }

        private void cuurentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUserDetails = new frmUserDetails(clsGlobalSettings.CuurentUser.UserID);
            frmUserDetails.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CuurentUser = null;
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword();
            frmChangePassword.ShowDialog();
        }

        private void mangeapptypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypesList frmApplicationTypesList = new frmApplicationTypesList();
            frmApplicationTypesList.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mangeTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypesList frmTestTypesList = new frmTestTypesList();
            frmTestTypesList.ShowDialog();
        }

        private void localDrivingLiceneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmAddEditApplications frmAddEditApplications = new frmAddEditApplications(-1);
            frmAddEditApplications.ShowDialog();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseList frmLocalDrivingLicenseList = new frmLocalDrivingLicenseList();
            frmLocalDrivingLicenseList.ShowDialog();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DrivertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverList frmDriverList = new frmDriverList();
            frmDriverList.ShowDialog();
        }

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUtil.ApplicationType = clsUtil.enApplicationType.International_Licenese;
            frmIssueInternationalLicense frmIssueInternationalLicense=new frmIssueInternationalLicense();
            frmIssueInternationalLicense.ShowDialog();

        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDriverLicenseList frmInternationalDriverLicenseList = new frmInternationalDriverLicenseList(); 
            frmInternationalDriverLicenseList.ShowDialog();
        }

        private void drivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUtil.ApplicationType = clsUtil.enApplicationType.Renew;
            
            frmRenewLicense frmRenewLicense = new frmRenewLicense();
            frmRenewLicense.ShowDialog();
        }

        private void replacementDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementDamagedOrLostLicense frmReplacementDamagedOrLostLicense = new frmReplacementDamagedOrLostLicense();
            frmReplacementDamagedOrLostLicense.ShowDialog();    
        }

        private void mangeDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicenseList frmDetainedLicenseList = new frmDetainedLicenseList();
            frmDetainedLicenseList.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetianLicense frmDetianLicense = new frmDetianLicense();
            frmDetianLicense.ShowDialog();
        }

        private void realeseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUtil.ApplicationType=clsUtil.enApplicationType.Realease_Detain_License;
           frmRealseDetainedLicense frmRealseDetainedLicense=new frmRealseDetainedLicense();
            frmRealseDetainedLicense.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUtil.ApplicationType = clsUtil.enApplicationType.Realease_Detain_License;
            frmRealseDetainedLicense frmRealseDetainedLicense = new frmRealseDetainedLicense();
            frmRealseDetainedLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseList frmLocalDrivingLicenseList = new frmLocalDrivingLicenseList();
            frmLocalDrivingLicenseList.ShowDialog();
        }
    }
}
