using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ucDrivingLicenseDetails : UserControl
    {
        enum enActive{ No=0,Yes=1}
        enum enGendor { Male=0,Female=1}
        clsLicense license;
        public clsLicense SelectedLicense { get { return license; } }
      

        public ucDrivingLicenseDetails()
        {
            InitializeComponent();
        }
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            { handler(LicenseID); }
        }

        private void grpDrivingLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
        void HandleGendor(byte Gendor)
        {
            enGendor gendor = (enGendor)Gendor;
            lblGendor.Text = gendor.ToString();
            switch (gendor)
            {
                case enGendor.Male:
                    pbPersonImage.Image = Properties.Resources.Male_512;
                    return;
                case enGendor.Female:
                    pbPersonImage.Image = Properties.Resources.Female_512;
                    return;

            }
            
        }
        void HandlePersonImage(string ImagePath)
        {
            if (ImagePath != "")
            {

                if (File.Exists(ImagePath))
                {
                    Stream stream = null;
                    stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);


                    pbPersonImage.Image = Image.FromStream(stream);
                    stream.Close();
                }
            }
        }
        void GetPersonInfo(int PersonID)
        {
            clsPeople Person = clsPeople.Find(PersonID);
            lblFullName.Text = Person.Fullname();
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            lblNationalNo.Text = Person.NationalNo.ToString();
            HandleGendor(Person.Gendor);
            HandlePersonImage(Person.ImagePath);

        }
        string GetIsDetianLabelValue(int LicenseID)
        {
            return license.IsDetained?"Yes":"No";
        }
        public void UpdateIsDetainValue(int LicenseID)
        {
           lblIsDetain.Text= GetIsDetianLabelValue(LicenseID);
        }
        public void LoadDrivingLicenseInfo(int LicenseID)
        {
             license = clsLicense.Find(LicenseID);
            if (license == null) 
            {
                LicenseSelected(-1);
                MessageBox.Show("Cannot Find a License","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return; 
            }
            lblClassName.Text=license.LicenesClassesInfo.ClassName;
            lblIssueDate.Text=license.IssueDate.ToShortDateString();
            lblExpirationDate.Text=license.ExpirationDate.ToShortDateString();
            lblDriverID.Text=license.DriverID.ToString();
            lblLicenseID.Text=license.LicenseID.ToString();
            lblIssueReason.Text = ((clsLicense.enIssueReasons)license.IssueReason).ToString();
            lblIsActive.Text=license.IsActive?"Yes":"No";
            lblIsDetain.Text=GetIsDetianLabelValue(LicenseID);
            lblNotes.Text=(license.Notes.ToString() == "")
                ? "No Notes": license.Notes.ToString();
            lblFullName.Text = license.DriverInfo.PersonInfo.Fullname();
            lblGendor.Text = license.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblNationalNo.Text = license.DriverInfo.PersonInfo.NationalNo;
            lblDateOfBirth.Text = license.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            HandlePersonImage(license.DriverInfo.PersonInfo.ImagePath) ;
            //GetPersonInfo(license.ApplicationInfo.ApplicationPersonID);
            if(OnLicenseSelected!=null)
            {
                LicenseSelected(LicenseID);
            }




        }
        private void ucDrivingLicenseDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
