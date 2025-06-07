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
using static DVLDBussinessLayer.clsTestType;

namespace DVLD_Project
{
    public partial class ucVisionTest : UserControl
    {
        public ucVisionTest()
        {
            InitializeComponent();
        }
        int _LocalDrivingLicenseID=-1;
        private clsTestType.enTestType _TestTypeID { get; set; }
        public bool DateEnabled { set { dateTimeApp.Enabled = value; } }
      
        public float GetFees { get { return Convert.ToSingle(lblFees.Text); } }
        public DateTime AppointmentDate { get { return dateTimeApp.Value; } set { dateTimeApp.MinDate = value; dateTimeApp.Value = value; }  }
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; } 
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            pbTestImage.Image = Properties.Resources.Vision_512;
                            grpVisionTest.Text = "Vision Test";
                            break;
                        }
                    case clsTestType.enTestType.WrittenTest:
                        pbTestImage.Image = Properties.Resources.Written_Test_512;
                        grpVisionTest.Text = "Written Test";
                        break;
                    case clsTestType.enTestType.StreetTest:
                        pbTestImage.Image = Properties.Resources.driving_test_512;
                        grpVisionTest.Text = "Street Test";
                        break;

                }
            }
        }
        void SetTestType(clsTestType.enTestType TestType)
        {
            

            
        }
        public void LoadVisionTest(int LocalDrivingLicenseID)
        {
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(LocalDrivingLicenseID);
            SetMinValueForDate();
            if (localDrivingLicenese == null)
                return;
            lblFullName.Text=localDrivingLicenese.PersonFullName;
            lblDLAPPID.Text = localDrivingLicenese.LocalDrivingLicenseID.ToString();
            lblLicenseClassName.Text = localDrivingLicenese.LicenseClassName;
            lblTrial.Text = clsLocalDrivingLicenese.GetAllTrialsAppointments(LocalDrivingLicenseID,(int)clsTestType.TestType).ToString();
            lblFees.Text = clsTestType.GetTestTypeFees((int)_TestTypeID).ToString();
            panel1.Visible = false;
            lblDateTime.Visible = false;
           
        }

        public void SetTestID(int TestID)
        {
            lblTestID.Text=TestID.ToString();
        }
        public void LoadVisionTestForTakingTest(int LocalDrivingLicenseID,int TestID)
        {
            LoadVisionTest(LocalDrivingLicenseID);
            panel1.Visible = true;
            dateTimeApp.Visible = false;
            lblDateTime.Visible = true;
            lblDateTime.Text=dateTimeApp.Value.ToShortDateString();
            if (TestID != -1)
                lblTestID.Text = TestID.ToString();
            else
                lblTestID.Text = "Not Taken Yet";
        }
        private void grpVisionTest_Enter(object sender, EventArgs e)
        {
           
        }
        void SetMinValueForDate()
        {
            if(clsApplicationTypes.ApplicationType==clsApplicationTypes.enApplicationType.Retake_Test)
            {
                if(_LocalDrivingLicenseID!=-1)
                dateTimeApp.MinDate = clsTestAppointments.GetLastTestAppointment(_LocalDrivingLicenseID, (int)clsTestType.TestType).AppointmentDate;
            }
            dateTimeApp.MinDate = DateTime.Now;
        }
        private void ucVisionTest_Load(object sender, EventArgs e)
        {
            //SetTestType(TestTypeID);
            SetMinValueForDate();
        }
    }
}
