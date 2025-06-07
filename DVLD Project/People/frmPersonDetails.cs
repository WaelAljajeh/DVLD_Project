using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmPersonDetails : Form
    {
        
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            
            ucPersonDetails1.LoadInfoData(PersonID);
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();

            ucPersonDetails1.LoadInfoData(NationalNo);
        }

        private void ucPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
