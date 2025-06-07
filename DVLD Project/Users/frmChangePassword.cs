using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmChangePassword : Form
    {
        int _UserID = -1;
        clsUsers _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID=UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(CheckTexts())
            {
                _User.Password=txtPassword.Text;
                if(_User.Save())
                MessageBox.Show("Password Changed Succesfuly");
                else
                    MessageBox.Show("Cannot Be Changed");


                return;
            }
            else
                MessageBox.Show("Invalid Password or Current Password or Not Confirmed Password");

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User=clsUsers.Find(_UserID);
           
            if (_User == null)
            {
                MessageBox.Show("Invalid User");
                this.Close();
                return;
            }
            ucUserInformationCard1.LoadUserInfoByUserID(_User.UserID);


        }
        bool CheckCurrentPassword()
        {
            if (txtCurrentPassword.Text == "")
            { 
                errorProvider1.SetError(txtCurrentPassword, "Cannot Be Empty"); 
                return false;
            }
            if (txtCurrentPassword.Text != clsGlobalSettings.CuurentUser.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, "Invalid Current Password");
                return false;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, "");
            return true;
            
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
          
            CheckCurrentPassword();

        }
        bool CheckNewPassword()
        {
            if (txtPassword.Text == "")
            { errorProvider1.SetError(txtPassword, "Cannot Be Empty");
                return false;
            }
            else
                errorProvider1.SetError(txtPassword, "");
            return true;
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            CheckNewPassword();
        }
        bool CheckConfirmPassword()
        {
            if (txtConfirmPassowrd.Text == "")
            {
                errorProvider1.SetError(txtConfirmPassowrd, "Cannot Be Empty");
                return false;
            }
            else
                errorProvider1.SetError(txtConfirmPassowrd, "");
            if(txtConfirmPassowrd.Text!=txtPassword.Text)
            {

                errorProvider1.SetError(txtConfirmPassowrd, "Not Match To Password");
                return false;
            }
            return true;
        }
        bool CheckTexts()
        {
            return (CheckConfirmPassword() && CheckCurrentPassword() && CheckNewPassword()); 
        }
                
            
        private void txtConfirmPassowrd_Validating(object sender, CancelEventArgs e)
        {
            CheckConfirmPassword();
        }
    }
    
}
