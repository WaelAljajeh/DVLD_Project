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
    public partial class frmUpdateAppTypes : Form
    {
        clsApplicationTypes Apptype;
        int AppID = -1;
        public frmUpdateAppTypes(int ID)
        {
            InitializeComponent();
            AppID= ID;
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
            txtTitle.Text = Apptype.ApplicationTypeTitle;
            txtFees.Text = Apptype.ApplicationFees.ToString();
            lblID.Text = AppID.ToString();
        }
        private void frmUpdateAppTypes_Load(object sender, EventArgs e)
        {
            Apptype=clsApplicationTypes.Find(AppID);
            LoadInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Apptype.ApplicationFees = Convert.ToSingle(txtFees.Text);
            Apptype.ApplicationTypeTitle = txtTitle.Text;
            
            if (Apptype.UpdateInfoOfTypes())
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

        private void txtFees_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
