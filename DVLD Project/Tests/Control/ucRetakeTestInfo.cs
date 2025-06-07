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
    public partial class ucRetakeTestInfo : UserControl
    {
       
        public ucRetakeTestInfo()
        {
            InitializeComponent();
        }
        public void SetRetakeTestID(int RetakeTestApplicationID)
        {
          lblRetakeID.Text= RetakeTestApplicationID.ToString();
        }
        public void SetFees(float Retakefees,float AppFees)
        {
            lblRetakeTestFees.Text= Retakefees.ToString();
            float TotalFees = AppFees + Retakefees;
            lblTotalFees.Text= TotalFees.ToString();    

        }
        public void LoadRetakeData(int RetakeTestApplicationID, float Retakefees, float AppFees)
        {
            SetRetakeTestID (RetakeTestApplicationID);
            SetFees (Retakefees, AppFees);
        }
        private void grpRetakeTestInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ucRetakeTestInfo_Load(object sender, EventArgs e)
        {
            lblTotalFees.Text = clsTestType.GetTestTypeFees((int)clsTestType.TestType).ToString();
        }
    }
}
