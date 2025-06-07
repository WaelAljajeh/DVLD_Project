﻿using System;
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
    public partial class frmShowLicenseHistory : Form
    {
        int _LicenseID = -1;
        public frmShowLicenseHistory(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            ucDrivingLicenseDetails1.LoadDrivingLicenseInfo(_LicenseID);
        }

        private void lblAddUpdatePerson_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
