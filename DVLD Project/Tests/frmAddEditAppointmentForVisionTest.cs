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
            ucVisionTest1.TestTypeID = clsTestType.TestType;
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
            ucVisionTest1.TestTypeID = clsTestType.TestType;
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
                clsApplicationTypes.ApplicationType = clsApplicationTypes.enApplicationType.Retake_Test;
                ucRetakeTestInfo1.LoadRetakeData(TestAppointment.RetakeTestApplicationID, clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType), TestAppointment.PaidFees);
                ucRetakeTestInfo1.Enabled = true;
            }
            else
                ucRetakeTestInfo1.Enabled = false;

            
            
            
        }
        private void frmAddEditAppointmentForVisionTest_Load(object sender, EventArgs e)
        {

            
            ucRetakeTestInfo1.Enabled = false;
            ucVisionTest1.LoadVisionTest(_LocalDrivingLicenseID);
            if (clsApplicationTypes.ApplicationType == clsApplicationTypes.enApplicationType.Retake_Test)
            { 
                ucRetakeTestInfo1.Enabled = true;
                ucRetakeTestInfo1.SetFees(clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType),ucVisionTest1.GetFees);
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
            //Done
            int RetakeTestID = -1;
            clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(_LocalDrivingLicenseID);
            clsApplication application = new clsApplication();//.FindBaseApplication(localDrivingLicenese.ApplicationID);
            application.ApplicationTypeID = (int)clsApplicationTypes.ApplicationType;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = localDrivingLicenese.ApplicationStatus;
            application.ApplicationPersonID=localDrivingLicenese.ApplicationPersonID;
            application.CreatedByUserID=clsGlobalSettings.CuurentUser.UserID;
            application.LastStatus = localDrivingLicenese.LastStatus;
            application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.enApplicationType.Retake_Test);
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
            if (_Mode==enMode.AddNew&&clsApplicationTypes.ApplicationType == clsApplicationTypes.enApplicationType.Retake_Test)
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
