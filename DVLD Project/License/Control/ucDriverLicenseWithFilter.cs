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
    public partial class ucDriverLicenseWithFilter : UserControl
    {
        
        public ucDriverLicenseWithFilter()
        {
            InitializeComponent();
        }
        private int _LicenseID {  get; set; }
        public clsLicense SelectedLicense { get { return ucDrivingLicenseDetails1.SelectedLicense; } }
        public event Action<int> OnLicenseSelected;
        public bool FilterEnable { get { return grpFilter.Enabled; } set {  grpFilter.Enabled = value; } }
       
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            { handler(LicenseID); }
        }
        public void UpdateIsDetainValue()
        {
            ucDrivingLicenseDetails1.UpdateIsDetainValue(SelectedLicense.LicenseID);
        }
        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text == "")
            { 
                MessageBox.Show("Cannot Be Empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return; 
            }
            ucDrivingLicenseDetails1.LoadDrivingLicenseInfo(int.Parse(txtFilter.Text));
        }
        public void LoadLicenseInfo(int LicenseID)
        {
            txtFilter.Text = LicenseID.ToString();
            FilterEnable = false;
            pbSearch_Click(null, null);


        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (!char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            if(e.KeyChar ==(char)Keys.Enter)
            {
                pbSearch_Click(null, null);   
            }
        }
        public void FilterFoucse()
        {
            txtFilter.Focus();
        }
        private void ucDriverLicenseWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void ucDrivingLicenseDetails1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;
            if (OnLicenseSelected != null &&FilterEnable)
            {
                LicenseSelected(_LicenseID);
            }
          
            


        }

        private void ucDrivingLicenseDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
