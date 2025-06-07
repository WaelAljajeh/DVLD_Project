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
    public partial class frmVisionTest : Form
    {
        int _LocalDrivingLicenseID = -1;
        public frmVisionTest(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID=LocalDrivingLicenseID;
        }
        void SetTestType()
        {
            switch (clsTestType.TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        pbTestImage.Image = Properties.Resources.Vision_512;
                        lblTestText.Text = "Vision Test Appointment";
                        return;
                    }
                case clsTestType.enTestType.WrittenTest:
                    pbTestImage.Image = Properties.Resources.Written_Test_512;
                    lblTestText.Text = "Written Test Appointment";
                    return;
                case clsTestType.enTestType.StreetTest:
                    pbTestImage.Image = Properties.Resources.driving_test_512;
                    lblTestText.Text = "Street Test Appointment";
                    return;

            }
        }
        void RefreshList()
        {
            dgvAppointmentList.DataSource = clsTestAppointments.GetAllApointmentForThisApp(_LocalDrivingLicenseID,(int)clsTestType.TestType);
            lblRecord.Text = (dgvAppointmentList.RowCount-1).ToString();
        }
        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            SetTestType();
            ucDLAPPInfo1.LoadDrivingLicenseAppInfo(_LocalDrivingLicenseID);
            this.Height = 1200;
            this.Top = 0;
            RefreshList();  
        }

        private void ucDLAPPInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool IsTestPassed(int TestAppointmentID)
        {
            return clsTest.IsTestPassed(TestAppointmentID);
        }
        bool IsTestPassed(clsTestType.enTestType TestType)
        {
            return clsTest.IsTestPassed(_LocalDrivingLicenseID,(int)TestType);
        }
        private void pbAddAppointment_Click(object sender, EventArgs e)
        {
            clsApplicationTypes.ApplicationType = clsApplicationTypes.enApplicationType.New_License;
            if (clsTestAppointments.IsThereActiveAppointment(_LocalDrivingLicenseID,(int)clsTestType.TestType))
            {
                MessageBox.Show("There already an active appointment for this License","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (IsTestPassed(clsTestType.TestType))
            {
                MessageBox.Show("There Person Is Already sat for this test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(!clsTestAppointments.IsThereActiveAppointment(_LocalDrivingLicenseID, (int)clsTestType.TestType) && !IsTestPassed(clsTestType.TestType))
            {
                if(dgvAppointmentList.RowCount>0)
                clsApplicationTypes.ApplicationType = clsApplicationTypes.enApplicationType.Retake_Test;
                
            }
            frmAddEditAppointmentForVisionTest appointmentForVisionTest=new frmAddEditAppointmentForVisionTest(-1,_LocalDrivingLicenseID);
            appointmentForVisionTest.ShowDialog();
            RefreshList();
        }

        bool IsThereActiveAppointmentByID( int TestAppointmentID)
        {
            return clsTestAppointments.IsThereActiveAppointment(TestAppointmentID);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool SatforTest = (IsThereActiveAppointmentByID((int)(dgvAppointmentList.CurrentRow.Cells[0].Value)));
            
            frmAddEditAppointmentForVisionTest editAppointmentForVisionTest = new frmAddEditAppointmentForVisionTest((int)dgvAppointmentList.CurrentRow.Cells[0].Value,_LocalDrivingLicenseID,!SatforTest);
            editAppointmentForVisionTest.ShowDialog();
            RefreshList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!IsThereActiveAppointmentByID((int)(dgvAppointmentList.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("Already Sat for Test","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                frmTakeTest test = new frmTakeTest((int)dgvAppointmentList.CurrentRow.Cells[0].Value, -1);
                test.ShowDialog();
                return;
            }
            frmTakeTest takeTest = new frmTakeTest((int)dgvAppointmentList.CurrentRow.Cells[0].Value,-1);
            takeTest.ShowDialog();
            RefreshList();
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }
    }
}
