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
    public partial class ucApplicationBasicInfo : UserControl
    {
        clsApplication Application;
        public ucApplicationBasicInfo()
        {
            InitializeComponent();
        }
        public string GetFullName { get { return (lblFullName.Text); } }
        public int GetAppID { get { return Application.ApplicationID; } }
        public int GetPersonID { get { return Application.ApplicationPersonID; } }

        private void grpApplicationBasicInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ucApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadApplicationBasicInfo(int ApplicationInfoID)
        {
             Application= clsApplication.Find(ApplicationInfoID);
            if (Application==null)
            {
                return;
            }
            clsPeople Person = clsPeople.Find(Application.ApplicationPersonID);
            clsUsers User = clsUsers.Find(Application.CreatedByUserID);
            lblAppID.Text = Application.ApplicationID.ToString();
            lblAPPTYPE.Text = clsApplicationTypes.GetApplicationTypeTitleByID(Application.ApplicationTypeID);
            lblStatus.Text = ((clsApplication.enAPPStatus)Application.ApplicationStatus).ToString();
            lblFullName.Text = Person.Fullname();
            lblStatusDate.Text = Application.LastStatus.ToShortDateString();
            lblAppDate.Text = Application.ApplicationDate.ToShortDateString();
            lblUsername.Text = User.Username.ToString();
            lblFees.Text = Application.PaidFees.ToString();
            
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frmPersonDetails = new frmPersonDetails(Application.ApplicationPersonID);
            frmPersonDetails.ShowDialog();
        }
    }
}
