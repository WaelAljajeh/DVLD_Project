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
        clsDetain _Detain;
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
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.ApplicationType).ToString();
            if (_Detain != null)
            {
                lblFineFees.Text = _Detain.FineFees.ToString();
                lblDeitainDate.Text = _Detain.DetainDate.ToShortDateString();
                lblTotalFees.Text = (float.Parse(lblApplicationFees.Text)+float.Parse(lblFineFees.Text)).ToString();
            }
            else
            {
                lblDetainID.Text = "[???]";                
                lblDeitainDate.Text = "[???]";
                lblFineFees.Text = "[???]";
                lblTotalFees.Text= "[???]";
            }
            
            
        }
        private void ucDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _Detain = null;
            int SelectedLicenseID=obj;
            lblLicenseID.Text=SelectedLicenseID.ToString();
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
            if (!clsDetain.IsDetainExistingByLicenseID(SelectedLicenseID,false))
            {
                MessageBox.Show("The Selected License Is Not Detained","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            btnDetain.Enabled = true ;
            _Detain=clsDetain.FindNotRealsedDetainLicenseByLicenseID(SelectedLicenseID);
            lblDetainID.Text=_Detain.DetainID.ToString();
            LoadDefaultBasicInfo();

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
            application.ApplicationPersonID = ucDriverLicenseWithFilter1.SelectedLicense.DriverInfo.PerosnID;
            application.ApplicationTypeID = (int)clsUtil.ApplicationType;
            application.CreatedByUserID = clsGlobalSettings.CuurentUser.UserID;
            application.LastStatus = DateTime.Now;
            application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees((int)clsUtil.ApplicationType);
            if (!application.Save())
            {
                return;
            }
            if (_Detain == null)
                return;
            _Detain.IsReleased = true;
            _Detain.ReleaseDate = DateTime.Now;
            _Detain.ReleasedByUserID=clsGlobalSettings.CuurentUser.UserID ;
            _Detain.ReleaseApplicationID = application.ApplicationID;
            if(_Detain.Save())
            {
                MessageBox.Show("Realsed Succesfuly");
                ucDriverLicenseWithFilter1.UpdateIsDetainValue();
                btnDetain.Enabled = false;
                ucDriverLicenseWithFilter1.FilterEnable= false;
                lblApplicationID.Text=application.ApplicationID.ToString();
                 
                
            }
        }

        private void frmRealseDetainedLicense_Load(object sender, EventArgs e)
        {
            LoadDefaultBasicInfo();
            if(_LicenseID!=-1)
            {
                ucDriverLicenseWithFilter1.LoadLicenseInfo(_LicenseID);
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory(ucDriverLicenseWithFilter1.SelectedLicense.ApplicationInfo.ApplicationPersonID);
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
