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
    public partial class ucInternationalDriverLicenseInfo : UserControl
    {
        
        public ucInternationalDriverLicenseInfo()
        {
            InitializeComponent();
        }
        enum enGendor { Male=0,Female=1};
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
        string HandleGendor(enGendor Gendor)
        {

            switch(Gendor)
            {
                case enGendor.Male:
                    pbPersonImage.Image = Properties.Resources.Male_512;
                    return "Male";
                case enGendor.Female:
                    pbPersonImage.Image = Properties.Resources.Female_512;
                    return "Female";



            }
            return "";
        }
        public void LoadDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            clsInternationalLicense internationalLicense=  clsInternationalLicense.Find(InternationalLicenseID);
            if (internationalLicense == null)
            {
                MessageBox.Show("Cannot Find an international Driver License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblInternationalLicenseID.Text= InternationalLicenseID.ToString();
            lblApplicationID.Text=internationalLicense.ApplicationID.ToString();
            lblDriverID.Text=internationalLicense.DriverID.ToString();
            lblLicenseID.Text=internationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblFullName.Text = internationalLicense.ApplicationInfo._PersonInfo.Fullname();
            lblGendor.Text = HandleGendor((enGendor)internationalLicense.ApplicationInfo._PersonInfo.Gendor);
            lblIsActive.Text=internationalLicense.IsActive==true?"Yes":"No";
            lblDateOfBirth.Text=internationalLicense.ApplicationInfo._PersonInfo.DateOfBirth.ToShortDateString();
            lblNationalNo.Text = internationalLicense.ApplicationInfo._PersonInfo.NationalNo;
            lblIssueDate.Text=internationalLicense.IssueDate.ToShortDateString();
            lblExpirationDate.Text=internationalLicense.ExpirationDate.ToShortDateString();
            HandlePersonImage(internationalLicense.ApplicationInfo._PersonInfo.ImagePath);
        }
        private void grpDriverInternationalInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
