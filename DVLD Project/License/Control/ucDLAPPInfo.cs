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
    public partial class ucDLAPPInfo : UserControl
    {
        int LicenseClassID = -1;
        public int GetDLAppID { get { return int.Parse(lblDLAPPID.Text); } }
        public string GetClassName { get { return lblLicenseClass.Text; } }
        public string GetPersonFullName { get { return ucApplicationBasicInfo1.GetFullName; } }
        public int GetAppID { get { return ucApplicationBasicInfo1.GetAppID; } }
        public int GetClassID { get { return LicenseClassID; } }
        public int GetPersonID { get { return ucApplicationBasicInfo1.GetPersonID; } }
        public ucDLAPPInfo()
        {
            InitializeComponent();
        }
       void FillApplicationBasicInfo(int ApplicationID)
       {
            ucApplicationBasicInfo1.LoadApplicationBasicInfo(ApplicationID); 
       }
       void FillDrivingLicenseApplicationInfo(int LocalDrivingLicenseAppID)
        {
            clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(LocalDrivingLicenseAppID);
            if (localDrivingLicenese == null)
                return;
            lblDLAPPID.Text= LocalDrivingLicenseAppID.ToString();
            LicenseClassID = localDrivingLicenese.LicenseClassID;
            lblLicenseClass.Text = localDrivingLicenese.LicenseClassName;
            lblPassedTestCount.Text = clsLocalDrivingLicenese.GetPassedTestCount(LocalDrivingLicenseAppID).ToString();
            FillApplicationBasicInfo(localDrivingLicenese.ApplicationID);
            
        }
        public void LoadDrivingLicenseAppInfo(int LocalDrivingLicenseAppID)
        {
            FillDrivingLicenseApplicationInfo(LocalDrivingLicenseAppID);
        }

        private void ucDLAPPInfo_Load(object sender, EventArgs e)
        {

        }

        private void ucApplicationBasicInfo1_Load(object sender, EventArgs e)
        {

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(clsLicense.GetLicenseIDByAppID(GetAppID));
            frmShowLicenseHistory.ShowDialog();
        }
    }
}
