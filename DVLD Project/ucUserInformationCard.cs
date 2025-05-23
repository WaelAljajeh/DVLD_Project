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
    public partial class ucUserInformationCard : UserControl
    {
        public ucUserInformationCard()
        {
            InitializeComponent();
        }
       public void LoadUserInfoByUserID(int UserID)
        {
            if (UserID == -1)
            {
                return;
            }
            clsUsers users = clsUsers.Find(UserID);
            if (users == null)
            {
                
                return;
            }
            ucPersonDetails1.LoadInfoData(users.PersonID);
            lblUsername.Text = users.Username;
            lblUserID.Text = UserID.ToString();
            switch(users.IsActive)
            {
                case true:
                    lblIsActive.Text = "Yes";
                    break;
                case false:
                    lblIsActive.Text = "No";
                    break;
            }

        }
        private void ucUserInformationCard_Load(object sender, EventArgs e)
        {

        }

        private void ucPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
