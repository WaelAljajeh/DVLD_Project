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
    public partial class frmAddEditUser : Form
    {
        clsUsers Users;
        int PersonID = -1;
        int _UserID=-1;
        bool IsPersonSelected = false;
        enum enMode { AddNew=0,Update=1};
        enMode _Mode;
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            if(UserID==-1)
                _Mode=enMode.AddNew;
            else
                _Mode=enMode.Update;
            _UserID= UserID;
        }
        void LoadPersonAndUserInformation()
        {
            if(_Mode==enMode.AddNew)
            {
                lblAddUpdateUser.Text = "Add New User";
                Users=new clsUsers();
                return;
            }
            
            lblAddUpdateUser.Text = "Update User";
            Users=clsUsers.Find(_UserID);
            if (Users == null)
            { 
                MessageBox.Show("Cannot Find a User","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return; 
            }
            
            IsPersonSelected = true;
            btnSave.Enabled = true;
            lblUserID.Text = Users.UserID.ToString();
            PersonID =Users.PersonID;
            ucPersonInfoWithFilter1.FilterEnabled = false;
            ucPersonInfoWithFilter1.FillSearchingTextWithPersonIDValue(PersonID);
            ucPersonInfoWithFilter1.LoadPersonInformation(Users.PersonID);
            txtUsername.Text=Users.Username;
            txtPassword.Text=Users.Password;
            txtConfirmPassowrd.Text = Users.Password;
            cbIsActive.Checked = Users.IsActive;

        }

        private void ucPersonInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void tbAddUser_Selecting(object sender, TabControlCancelEventArgs e)
        {

            e.Cancel = !IsPersonSelected;
        }

        void MoveToTheUserTap()
        {
            tbAddUser.SelectedTab = tpLoginInfo;
            btnSave.Enabled = true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (PersonID != -1)
            {
                if (!clsUsers.IsUserExistingByPersonID(PersonID)&&_Mode==enMode.AddNew)
                {
                    
                    MoveToTheUserTap();
                }
                else if(_Mode==enMode.Update)
                    MoveToTheUserTap();
                else
                {
                    MessageBox.Show("The Person Selected already Have a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Select A Person First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ucPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            PersonID = obj;
            IsPersonSelected = true;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            LoadPersonAndUserInformation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotEmptyTexts(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                errorProvider1.SetError((TextBox)sender, "This Field Cannot be Empty");
            }
            else
                errorProvider1.SetError((TextBox)sender, "");

        }
        bool IsTextsValid()
        {
            return !String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text) &&
                !String.IsNullOrEmpty(txtConfirmPassowrd.Text)&&txtConfirmPassowrd.Text==txtPassword.Text&&(_Mode==enMode.AddNew?(!clsUsers.IsUserExisting(txtUsername.Text)):(clsUsers.IsUserExisting(txtUsername.Text)?Users.Username==txtUsername.Text:true));
        }

        private void txtConfirmPassowrd_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassowrd.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassowrd, "Invalid Confirmation of Password");
            }
            else
                errorProvider1.SetError(txtConfirmPassowrd, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsTextsValid())
            {

                Users.PersonID = PersonID;
                Users.Username = txtUsername.Text;
                Users.Password = clsSecurity.ComputeHash(txtPassword.Text);
                Users.IsActive = cbIsActive.Checked;
                if (Users.Save())
                {
                    lblAddUpdateUser.Text = "Update User";
                    lblUserID.Text = Users.UserID.ToString();
                    ucPersonInfoWithFilter1.FilterEnabled = false;
                    if (_Mode == enMode.AddNew)
                        MessageBox.Show("Added Succesfuly");
                    else
                        MessageBox.Show("Updated Succesfuly");
                    _Mode = enMode.Update;

                }
            }
            else
                MessageBox.Show("There is Invalid Or Empty Field");
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                errorProvider1.SetError((TextBox)sender, "This Field Cannot be Empty");
            }
            else
                errorProvider1.SetError((TextBox)sender, "");
            if (clsUsers.IsUserExisting(txtUsername.Text)&&_Mode==enMode.AddNew) 
            {
                errorProvider1.SetError((TextBox)sender, "Username already Existing");
            }
            else
                errorProvider1.SetError((TextBox)sender, "");

        }
    }
    
}

