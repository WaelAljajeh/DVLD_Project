using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmUpdateTestTypes : Form
    {
        clsTestType TestType;
        int TestID = -1;
        public frmUpdateTestTypes(int ID)
        {
            InitializeComponent();
            TestID= ID;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }
        void LoadInfo()
        {
            txtTitle.Text = TestType.TestTypeTitle;
            txtFees.Text = TestType.TestFees.ToString();
            txtDescreption.Text = TestType.TestDescreption;
            lblID.Text = TestID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TestType.TestFees=Convert.ToSingle(txtFees.Text);
            TestType.TestDescreption = txtDescreption.Text;
            TestType.TestTypeTitle = txtTitle.Text;
            if (TestType.UpdateInfoOfTypes())
            {
                MessageBox.Show("Updated Successfuly");
                LoadInfo();

            }

            else
                return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            TestType=clsTestType.Find(TestID);
            LoadInfo();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            };
        }

        private void txtDescreption_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescreption.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Descreption cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            };
        }
    }
}
