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
    public partial class frmAddEditApplications : Form
    {
        enum enMode { AddNew=1,Update=2 };
        
        enMode _Mode;
        clsApplication application;
        clsLocalDrivingLicenese LocalDrivingLicenese;
        int ApplicationPersonID = -1;
        int LocalDrivingLicenseID =  -1;
        bool IsPersonSelected = false;
        DataView LicenesClasses;
        public frmAddEditApplications(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            if (LocalDrivingLicenseID == -1)
                _Mode = enMode.AddNew;
             else
                _Mode = enMode.Update;
             this.LocalDrivingLicenseID=LocalDrivingLicenseID;
        }
        void LoadLiceneseClasses()
        {
            LicenesClasses = clsLicenesClasses.GetAllLiceneseClassesName().DefaultView;
            cmbLicenesClassName.DataSource = LicenesClasses;
            cmbLicenesClassName.DisplayMember = "ClassName";
            cmbLicenesClassName.ValueMember = "ClassName";
            if (_Mode == enMode.AddNew)
            {
                cmbLicenesClassName.SelectedIndex = cmbLicenesClassName.FindString("Class 3 - Ordinary driving license");
            }
            else
                cmbLicenesClassName.SelectedIndex=LocalDrivingLicenese.LicenseClassID-1;
        }
        void LoadInfoForAddingApplication()
        {
            
            lblCreatedBy.Text = clsGlobalSettings.CuurentUser.Username.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            LoadLiceneseClasses();
            lblAppFees.Text = clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.enApplicationType.New_License).ToString();
        }
        void LoadAppInfo()
        {
         if(_Mode==enMode.AddNew)
         {
                LoadInfoForAddingApplication();
                LocalDrivingLicenese=new clsLocalDrivingLicenese();
                application=new clsApplication();
                return;
         }
            
            LocalDrivingLicenese = clsLocalDrivingLicenese.Find(LocalDrivingLicenseID);
            application = clsApplication.Find(LocalDrivingLicenese.ApplicationID);
            ucPersonInfoWithFilter1.LoadPersonInformation(application.ApplicationPersonID);
            ucPersonInfoWithFilter1.FilterEnabled = false;
            btnSave.Enabled = true;
            ucPersonInfoWithFilter1.FillSearchingTextWithPersonIDValue(application.ApplicationPersonID);
            clsUsers user = clsUsers.Find(application.CreatedByUserID);
            lblCreatedBy.Text = user.Username;
            lblApplicationID.Text=application.ApplicationID.ToString();
            lblAddUpdateApp.Text = "Update Application Info";
            lblApplicationDate.Text = application.ApplicationDate.ToShortDateString();
            lblAppFees.Text=application.PaidFees.ToString();
            LoadLiceneseClasses();


        }
        
        private void frmAddEditApplications_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            LoadAppInfo(); 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MoveToApplicationTapPage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            ApplicationPersonID=obj;
            IsPersonSelected=true;
        }
        void MoveToApplicationTapPage()
        {
            if (IsPersonSelected)
            {
                tbAddEditApp.SelectedTab = tpApplicationInfo;
                btnSave.Enabled = true;
            }
        }
        private void tbAddEditApp_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !IsPersonSelected;
        }
        bool SaveapplicationInfo()
        {
            
            application.ApplicationDate = DateTime.Now;
            application.ApplicationPersonID = ApplicationPersonID;
            application.CreatedByUserID=clsGlobalSettings.CuurentUser.UserID;
            application.LastStatus = DateTime.Now;
            application.ApplicationTypeID = (int)clsUtil.enApplicationType.New_License;
            application.ApplicationStatus = (byte)clsApplication.enAPPStatus.New;
            
            application.PaidFees=clsApplicationTypes.GetApplicationTypePaidFees(application.ApplicationTypeID);
            return application.Save();
        }
        bool SaveLocalDrivingLicenseInfo()
        {
           // clsLocalDrivingLicenese localDrivingLicenese = new clsLocalDrivingLicenese();
            LocalDrivingLicenese.ApplicationID = application.ApplicationID;
            LocalDrivingLicenese.LicenseClassID=cmbLicenesClassName.SelectedIndex+1;
            return LocalDrivingLicenese.Save();
        }
        bool IsApplicationStatusCompleted()
        {
            return application.ApplicationStatus == (int)clsApplication.enAPPStatus.Completed;
        }
        int GetPersonHaveApplicationWithSameClass()
        {
            // clsApplication App=clsApplication.
            return clsLocalDrivingLicenese.GetPersonHaveActiveApplicationWithSameClass(ApplicationPersonID,(int)clsUtil.enApplicationType.New_License,cmbLicenesClassName.SelectedIndex+1);
        }
        bool IsValidAge()
        {
            int PersonAge = DateTime.Now.Year-ucPersonInfoWithFilter1.GetDateOfBirth.Year;
            if (DateTime.Now.Month<= ucPersonInfoWithFilter1.GetDateOfBirth.Month&&DateTime.Now.Day<ucPersonInfoWithFilter1.GetDateOfBirth.Day)
            {
                PersonAge--;
            }
            return PersonAge>=clsLicenesClasses.GetMinimumAgeByID(cmbLicenesClassName.SelectedIndex+1);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {


            
            int AppID = GetPersonHaveApplicationWithSameClass();

            if (!IsValidAge())
            {
                MessageBox.Show($"Not Valid Age at least age for this Class is " + clsLicenesClasses.GetMinimumAgeByID(cmbLicenesClassName.SelectedIndex + 1).ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (AppID != -1)
            {
                if (clsLicense.IsLicenseExistingByAppID(AppID))
                {
                    MessageBox.Show("Have already License With this Class","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if (AppID==-1)
            {
                {
                    if (SaveapplicationInfo() && SaveLocalDrivingLicenseInfo())
                    {
                        MessageBox.Show("Sucsses");
                        lblApplicationID.Text = LocalDrivingLicenese.LocalDrivingLicenseID.ToString();
                        lblAddUpdateApp.Text = "Update Application Info";
                        ucPersonInfoWithFilter1.FilterEnabled = false;
                    }
                }
            }
            else
                MessageBox.Show($"Choose another license Class The Person already have an active Application with ID={AppID} ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
