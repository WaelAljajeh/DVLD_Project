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
        int _PersonID = -1;     
        public frmPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;   
            
        }
        public frmPersonLicenseHistory()
        {
            InitializeComponent();
        }



        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
                  
                if(_PersonID==-1)
                {
                ucPersonInfoWithFilter1.FilterEnabled = true;
                ucPersonInfoWithFilter1.FilterFoucs();
                return;
                }
                ucPersonInfoWithFilter1.LoadPersonInformation(_PersonID);
                ucPersonInfoWithFilter1.FilterEnabled = false;
                ucDriverLicensesHistoryList1.LoadInfoByPersonID(_PersonID);
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                ucDriverLicensesHistoryList1.Clear();
            }
            else
                ucDriverLicensesHistoryList1.LoadInfoByPersonID(_PersonID);
        }
    }
}
