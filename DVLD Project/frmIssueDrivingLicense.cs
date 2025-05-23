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
    public partial class frmIssueDrivingLicense : Form
    {
        int _LocalDrivingLicenseID;
        public frmIssueDrivingLicense(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(AddNewLicense())
            {
                MessageBox.Show("Success");
            }
        }
        int AddNewDriver()
        {
            clsDriver Driver;
            if (clsDriver.IsDriverExistingByPersonID(ucDLAPPInfo1.GetPersonID))
            {
                 Driver=clsDriver.FindByPersonID(ucDLAPPInfo1.GetPersonID);
                 return Driver.DriverID;
            }
            else
            {
                Driver=new clsDriver();
                Driver.PerosnID = ucDLAPPInfo1.GetPersonID;
                Driver.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
                Driver.CreatedDate = DateTime.Now;
                if (Driver.AddDriver())
                {
                    return Driver.DriverID;
                }
            }
         
            return -1;
        }
        bool AddNewLicense()
        {
            int DriverID = AddNewDriver();
            if (DriverID == -1)
                return false;

            clsLicense license = new clsLicense();
            license.DriverID= DriverID;
            license.ApplicationID = ucDLAPPInfo1.GetAppID;
            license.IsActive = true;
            license.LicenseClass = ucDLAPPInfo1.GetClassID;
            license.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            license.Notes=txtNotes.Text;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = license.IssueDate.AddYears(clsLicenesClasses.GetValidityLength(license.LicenseClass));
            license.IssueReason = (int)clsLicense.IssueReasons;
            license.PaidFees = clsLicenesClasses.GetClassFeesByID(license.LicenseClass);
            if(license.Save())
            {
                clsApplication application = clsApplication.Find(license.ApplicationID);
                application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
                application.LastStatus = DateTime.Now;
                if(application.Save())
                return true; 
            }
            return false;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ucDLAPPInfo1.LoadDrivingLicenseAppInfo(_LocalDrivingLicenseID);
        }
    }
}
