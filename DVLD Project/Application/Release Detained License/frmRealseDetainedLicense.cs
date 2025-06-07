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
    public partial class frmRealseDetainedLicense : Form
    {
        //clsDetain _Detain;
        int _LicenseID = -1;
        public frmRealseDetainedLicense()
        {
            InitializeComponent();
        }
        public frmRealseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void LoadDefaultBasicInfo()
        {
            lblUsername.Text=clsGlobalSettings.CuurentUser.Username;
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType).ToString();
            if (_LicenseID != -1 && ucDriverLicenseWithFilter1.SelectedLicense.DetainInfo != null)
            {
                lblFineFees.Text = ucDriverLicenseWithFilter1.SelectedLicense.DetainInfo.FineFees.ToString();
                lblDeitainDate.Text = ucDriverLicenseWithFilter1.SelectedLicense.DetainInfo.DetainDate.ToShortDateString();
                lblTotalFees.Text = (float.Parse(lblApplicationFees.Text) + float.Parse(lblFineFees.Text)).ToString();
            }
            else
            {
                lblDetainID.Text = "[???]";
                lblDeitainDate.Text = "[???]";
                lblFineFees.Text = "[???]";
                lblTotalFees.Text = "[???]";
            }
            
            
        }
        private void ucDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
           // _Detain = null;
            
            int SelectedLicenseID=obj;
            lblLicenseID.Text=SelectedLicenseID.ToString();
            _LicenseID = SelectedLicenseID;
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if (SelectedLicenseID == -1)
            {
                return;
            }
            if(ucDriverLicenseWithFilter1.SelectedLicense==null)
            {            
                return;
            }
            llShowLicenseHistory.Enabled = true;
            LoadDefaultBasicInfo();
            if (!ucDriverLicenseWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("The Selected License Is Not Detained","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            btnDetain.Enabled = true ;
            //_Detain=clsDetain.FindNotRealsedDetainLicenseByLicenseID(SelectedLicenseID);
            lblDetainID.Text=ucDriverLicenseWithFilter1.SelectedLicense.DetainInfo.DetainID.ToString();
            LoadDefaultBasicInfo();

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            int ApplicationID = -1;
            bool IsReleased = ucDriverLicenseWithFilter1.SelectedLicense.ReleaseDetainedLicense(clsGlobalSettings.CuurentUser.UserID, ref ApplicationID);
            lblApplicationID.Text = ApplicationID.ToString();
            if(!IsReleased)
            {
                MessageBox.Show("Failed To Relase Detianed License","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            MessageBox.Show("Released Succesfuly");
            btnDetain.Enabled = false;
            ucDriverLicenseWithFilter1.FilterEnable = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void frmRealseDetainedLicense_Load(object sender, EventArgs e)
        {
            LoadDefaultBasicInfo();
            if(_LicenseID!=-1)
            {
                ucDriverLicenseWithFilter1.LoadLicenseInfo(_LicenseID);
                ucDriverLicenseWithFilter1_OnLicenseSelected(_LicenseID);
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.DriverInfo.PerosnID);
            frmPersonLicenseHistory.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.LicenseID);
            frmShowLicenseHistory.ShowDialog();
        }

        private void ucDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
