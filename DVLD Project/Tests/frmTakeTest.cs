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
        //clsTestAppointments testAppointments;
        clsTest Test;
        public frmTakeTest(int TestAppointmentID, int TestID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestID=TestID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {

            rbPass.Checked = true;
            //btnSave.Enabled = _TestAppointmentID == -1;
            if(_TestID!=-1)
            {
                clsTest Test = clsTest.Find(_TestID);
                panel1.Enabled = false;
                if (Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                rbPass.Enabled = false;
                rbFail.Enabled=false;
            }
            else
                Test=new clsTest();
            clsTestAppointments testAppointments = clsTestAppointments.Find(_TestAppointmentID);
           int _LocalDrivingLicenseID=testAppointments.LocalDrivingLicenseApplicationID;
            ucVisionTest1.LoadVisionTestForTakingTest(_LocalDrivingLicenseID, _TestID);
        }
        void UpdateApplicationStatus()
        {
            //Done
            clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(Test.TestAppointmentInfo.LocalDrivingLicenseApplicationID);
            localDrivingLicenese.SetCompleted();



        }
        private void btnSave_Click(object sender, EventArgs e)
        {

           
            
            Test.TestAppointmentID = _TestAppointmentID;
            Test.Notes = txtNotes.Text;
            Test.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            Test.TestResult = rbPass.Checked;
            //testAppointments.IsLocked = true;
            if(Test.Save())
            {
                MessageBox.Show("Success");
                ucVisionTest1.SetTestID(Test.TestID);

                //Test.TestAppointmentInfo=clsTestAppointments.Find(Test.TestAppointmentID);
                //if(Test.TestAppointmentInfo.TestTypeID==(int)clsTestType.enTestType.StreetTest)
                //UpdateApplicationStatus();
                //btnSave.Enabled = false;
                panel1.Enabled = false;
               // _Mode = enMode.Update;
                
              

            }

        }
    }
}
