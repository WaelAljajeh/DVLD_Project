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
    public partial class frmAddEditAppointmentForVisionTest : Form
    {
        clsTestAppointments TestAppointment;
        int _TestAppointmentID=-1;
        int _LocalDrivingLicenseID = -1;
        enum enMode { AddNew=1,Update=2};
        enMode _Mode;
        public frmAddEditAppointmentForVisionTest(int TestAppointmentID, int LocalDrivingLicenseID)
        {
            InitializeComponent();
            if (TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
        }
        public frmAddEditAppointmentForVisionTest(int TestAppointmentID, int LocalDrivingLicenseID,bool IsTestPassed)
        {
            InitializeComponent();
            if (TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            ucVisionTest1.DateEnabled=!IsTestPassed;
            btnSave.Enabled=!IsTestPassed;
            lblTestPassed.Visible=IsTestPassed;
        }
        void LoadAppointmentInfoData()
        {
            if(_Mode==enMode.AddNew)
            {
                TestAppointment=new clsTestAppointments();
                return;
                
            }
            TestAppointment = clsTestAppointments.Find(_TestAppointmentID);
            ucVisionTest1.AppointmentDate=TestAppointment.AppointmentDate;
            if (TestAppointment.RetakeTestApplicationID != -1)
            {
                clsUtil.ApplicationType = clsUtil.enApplicationType.Retake_Test;
                ucRetakeTestInfo1.LoadRetakeData(TestAppointment.RetakeTestApplicationID, clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.ApplicationType), TestAppointment.PaidFees);
                ucRetakeTestInfo1.Enabled = true;
            }
            else
                ucRetakeTestInfo1.Enabled = false;

            
            
            
        }
        private void frmAddEditAppointmentForVisionTest_Load(object sender, EventArgs e)
        {

            
            ucRetakeTestInfo1.Enabled = false;
            ucVisionTest1.LoadVisionTest(_LocalDrivingLicenseID);
            if (clsUtil.ApplicationType == clsUtil.enApplicationType.Retake_Test)
            { 
                ucRetakeTestInfo1.Enabled = true;
                ucRetakeTestInfo1.SetFees(clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.ApplicationType),ucVisionTest1.GetFees);
            }
            this.Height = 800;
            this.Top = 0;
            LoadAppointmentInfoData();
        }

        private void ucVisionTest1_Load(object sender, EventArgs e)
        {

        }
        int UpdateTypeInApplication()
        {
            int RetakeTestID = -1;
            clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(_LocalDrivingLicenseID);
            clsApplication application = clsApplication.Find(localDrivingLicenese.ApplicationID);
            application.ApplicationTypeID = (int)clsUtil.ApplicationType;
            if (application.Save())
            {
                ucRetakeTestInfo1.SetRetakeTestID(application.ApplicationID);
                RetakeTestID = application.ApplicationID;
            }
            return RetakeTestID;
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            int RetakeTestID=-1;
            if (clsUtil.ApplicationType == clsUtil.enApplicationType.Retake_Test)
            {
                RetakeTestID=UpdateTypeInApplication();
            }
            TestAppointment.TestTypeID = (int)clsTestType.TestType;
            TestAppointment.RetakeTestApplicationID = RetakeTestID;
            TestAppointment.PaidFees = clsTestType.GetTestTypeFees(TestAppointment.TestTypeID);
            TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseID;
            TestAppointment.AppointmentDate = ucVisionTest1.AppointmentDate;
            TestAppointment.CreatedByUserID=clsGlobalSettings.CuurentUser.UserID;
            if(TestAppointment.Save())
            {
                MessageBox.Show("Succes");
                _Mode = enMode.Update;
               
            }
            
        }

        private void ucRetakeTestInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
