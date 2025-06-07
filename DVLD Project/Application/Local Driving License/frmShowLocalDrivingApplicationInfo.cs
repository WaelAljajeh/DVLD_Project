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
    public partial class frmShowLocalDrivingApplicationInfo : Form
    {
        int _LocalDrivingLicenseAppID=-1;
        public frmShowLocalDrivingApplicationInfo(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID=LocalDrivingLicenseAppID;
        }

        private void frmShowLocalDrivingApplicationInfo_Load(object sender, EventArgs e)
        {
            ucDLAPPInfo1.LoadDrivingLicenseAppInfo(_LocalDrivingLicenseAppID);
        }
    }
}
