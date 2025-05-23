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
    public partial class frmPersonLicenseHistory : Form
    {
        //int _LocalDrivingLicenseID = -1;
        //int _AppID = -1;
        int _PersonID = -1;
        public frmPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            
        }
        //public frmPersonLicenseHistory(int ApplicationID,bool App)
        //{
        //    InitializeComponent();
        //    _AppID = ApplicationID;

        //}


        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            //clsLocalDrivingLicenese localDrivingLicenese;
            //clsApplication application;
            //if(_LocalDrivingLicenseID==-1&&_AppID==-1)
            //{
            //    return;
            //}
            //if (_LocalDrivingLicenseID == -1)
            //{
            //    localDrivingLicenese = null;
                
            //}
            //else
            //{
            //    localDrivingLicenese = clsLocalDrivingLicenese.Find(_LocalDrivingLicenseID);
            //    _AppID = localDrivingLicenese.ApplicationID;
            //}
            
            //    application = clsApplication.Find(_AppID);
                ucPersonInfoWithFilter1.LoadPersonInformation(_PersonID);
                ucPersonInfoWithFilter1.FilterEnabled = false;
                ucDriverLicensesHistoryList1.LoadInfoLicense(_PersonID);
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucPersonInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
