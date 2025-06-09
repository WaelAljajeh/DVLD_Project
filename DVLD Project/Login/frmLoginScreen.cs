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
using System.IO;

namespace DVLD_Project
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        [Obsolete("That fucntion will be deleted In Next Version")]
        void StoreUserInformationInFile()
        {
            
                
                File.WriteAllText("C:/UserInfoForLogin.txt", txtUsername.Text + "#" + txtPassword.Text+"#"+cbRememberMe.Checked);
            
        }
        [Obsolete("That fucntion will be deleted In Next Version")]
        void GetUserInfoFromFile()
        {
            if(File.Exists("C:\\UserInfoForLogin.txt"))
            {
                string strFileInfo = File.ReadAllText("C:\\UserInfoForLogin.txt");
                string[] UserInformation = strFileInfo.Split('#');
                if (UserInformation.Length > 0 && Convert.ToBoolean(UserInformation[2]))
                {
                    txtUsername.Text = UserInformation[0];
                    txtPassword.Text = UserInformation[1];
                    cbRememberMe.Checked = true;
                }
                else
                {
                    return;
                }
            }
        }
        bool Login()
        {
            clsGlobalSettings.CuurentUser = clsUsers.Find(txtUsername.Text,clsSecurity.ComputeHash(txtPassword.Text));
            if (clsGlobalSettings.CuurentUser != null)
            {
                
                return true;
            }
            return false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtUsername.Text)||String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("There Is Empty Field","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            } 
            if(Login())
            {
                if (clsGlobalSettings.CuurentUser.IsActive)
                {
                    clsGlobalSettings.RememberUsernameandPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    this.Hide();
                    frmMainMenu frmMain = new frmMainMenu(this);
                    frmMain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("That User Is Not Active you can Login In Another User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                clsGlobalSettings.RememberUsernameandPassword("","");
                MessageBox.Show("Invalid Username/Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            if (clsGlobalSettings.GetStoredCredinality(ref Username, ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;

            }
            else
                cbRememberMe.Checked = false;
            
            
        }

        private void frmLoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
