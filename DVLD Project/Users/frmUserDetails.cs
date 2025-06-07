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
    public partial class frmUserDetails : Form
    {
        int _UserID = -1;
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void ucUserInformationCard1_Load(object sender, EventArgs e)
        {

        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            ucUserInformationCard1.LoadUserInfoByUserID(_UserID);
        }
    }
}
