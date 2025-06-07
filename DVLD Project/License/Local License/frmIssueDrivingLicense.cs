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
        clsLocalDrivingLicenese _LocalDrivingLicenseApplication;
        public frmIssueDrivingLicense(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueDrivingLicenseApplicationFirstTime(txtNotes.Text.Trim(),clsGlobalSettings.CuurentUser.UserID);
            if(LicenseID!=-1)
            {
                MessageBox.Show($"Success With LicenseID {LicenseID}");
            }
        }
        //int AddNewDriver()
        //{
        //    clsDriver Driver;
        //    if (clsDriver.IsDriverExistingByPersonID(ucDLAPPInfo1.GetPersonID))
        //    {
        //         Driver=clsDriver.FindByPersonID(ucDLAPPInfo1.GetPersonID);
        //         return Driver.DriverID;
        //    }
        //    else
        //    {
        //        Driver=new clsDriver();
        //        Driver.PerosnID = ucDLAPPInfo1.GetPersonID;
        //        Driver.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
        //        Driver.CreatedDate = DateTime.Now;
        //        if (Driver.AddDriver())
        //        {
        //            return Driver.DriverID;
        //        }
        //    }
         
        //    return -1;
        //}
        //bool AddNewLicense()
        //{
        //    int DriverID = AddNewDriver();
        //    if (DriverID == -1)
        //        return false;

        //    clsLicense license = new clsLicense();
        //    license.DriverID= DriverID;
        //    license.ApplicationID = ucDLAPPInfo1.GetAppID;
        //    license.IsActive = true;
        //    license.LicenseClass = ucDLAPPInfo1.GetClassID;
        //    license.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
        //    license.Notes=txtNotes.Text;
        //    license.IssueDate = DateTime.Now;
        //    license.ExpirationDate = license.IssueDate.AddYears(clsLicenesClasses.GetValidityLength(license.LicenseClass));
        //    license.IssueReason = (int)clsLicense.IssueReasons;
        //    license.PaidFees = clsLicenesClasses.GetClassFeesByID(license.LicenseClass);
        //    if(license.Save())
        //    {
        //        //Edit
        //        clsApplication application = clsApplication.FindBaseApplication(license.ApplicationID);
        //        application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
        //        application.LastStatus = DateTime.Now;
        //        if(application.Save())
        //        return true; 
        //    }
        //    return false;
        //}

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication=clsLocalDrivingLicenese.Find(_LocalDrivingLicenseID);
            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("Cannot Be Null");
                this.Close();
                return;
            }
            if(!_LocalDrivingLicenseApplication.PassedAllTest())
            {
                MessageBox.Show("You Should Pass all tests");
                this.Close();
                return;
            }
            //edit it
            if (_LocalDrivingLicenseApplication.IslicenseExist())
            {
                MessageBox.Show("There is An Active License for this Person");
                this.Close();
                return;
            }
            //edit it
            ucDLAPPInfo1.LoadDrivingLicenseAppInfo(_LocalDrivingLicenseID);
        }
    }
}
