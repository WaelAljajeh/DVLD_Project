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
    public partial class frmShowInternationalDriverLicenseInfo : Form
    {
        int _InternationalLicenseID = -1;
        public frmShowInternationalDriverLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID=InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInternationalDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ucInternationalDriverLicenseInfo1.LoadDriverInternationalLicenseInfo(_InternationalLicenseID);
        }
    }
}
