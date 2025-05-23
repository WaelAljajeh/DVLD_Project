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
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID = -1;
        int _TestID = -1;
        clsTestAppointments testAppointments;
        public frmTakeTest(int TestAppointmentID, int TestID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestID=TestID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            rbPass.Checked = true;
            testAppointments = clsTestAppointments.Find(_TestAppointmentID);
            int _LocalDrivingLicenseID=testAppointments.LocalDrivingLicenseApplicationID;
            ucVisionTest1.LoadVisionTestForTakingTest(_LocalDrivingLicenseID, _TestID);
        }
        void UpdateApplicationStatus(clsApplication.enAPPStatus AppStatus)
        {
            clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(testAppointments.LocalDrivingLicenseApplicationID);
            clsApplication application = clsApplication.Find(localDrivingLicenese.ApplicationID);
            application.ApplicationStatus = (byte)AppStatus;
            application.Save();



        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
                clsTest Test = new clsTest();
            Test.TestAppointmentID = _TestAppointmentID;
            Test.Notes = txtNotes.Text;
            Test.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            Test.TestResult = rbPass.Checked;
            testAppointments.IsLocked = true;
            if(Test.AddNewTest()&&testAppointments.Save())
            {
                MessageBox.Show("Success");
                ucVisionTest1.SetTestID(Test.TestID);
                btnSave.Enabled = false;
                
              

            }

        }
    }
}
