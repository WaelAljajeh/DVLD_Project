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
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }
        void RefreshList()
        {
            dgvUserList.DataSource = clsUsers.GetAllUsersTable();
            lblRecord.Text = (dgvUserList.RowCount - 1).ToString();
            FilteringBy();
        }
        private void frmUsersList_Load(object sender, EventArgs e)
        {
            cmbFilterBy.SelectedIndex= 0;
            txtSearch.Visible = false;
            RefreshList();
           
        }
        void FilteringBy()
        {
           
            DataTable UserList = (DataTable)dgvUserList.DataSource;
            if (cmbFilterBy.SelectedIndex == 0) { return; }
            if (cmbFilterBy.SelectedItem.ToString() == "IsActive")
            {
               
                switch(cmbActiveList.SelectedItem.ToString())
                {
                    case "All":
                        UserList.DefaultView.RowFilter = "";
                        return;
                    case "Yes":
                        UserList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = {true}";
                        break;
                    case "No":
                        UserList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = {false}";
                        break;

                }
               
                
            }
           else if ((cmbFilterBy.SelectedItem.ToString() == "PersonID")||(cmbFilterBy.SelectedItem.ToString()=="UserID"))
                UserList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = '{(int.Parse(txtSearch.Text))}'";
            else
                UserList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} LIKE '%{txtSearch.Text}%'";
             
            lblRecord.Text = (dgvUserList.RowCount - 1).ToString();

        }

        private void pbAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser(-1);
            frmAddEditUser.ShowDialog();
            RefreshList();
        }

        private void pbAddUser_MouseHover(object sender, EventArgs e)
        {
            pbAddUser.BackColor = Color.DimGray;
        }

        private void pbAddUser_MouseLeave(object sender, EventArgs e)
        {
            pbAddUser.BackColor = SystemColors.Control;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUserList.CurrentRow.Cells[0].Value;
            if (clsGlobalSettings.CuurentUser.UserID == UserID)
            {
                MessageBox.Show("Cannot Be Updated The User in User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
                frmAddEditUser frmAddEditUser = new frmAddEditUser(UserID);
                frmAddEditUser.ShowDialog();
                RefreshList();
            
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUserDetails = new frmUserDetails((int)dgvUserList.CurrentRow.Cells[0].Value);
            frmUserDetails.ShowDialog();
            RefreshList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser(-1);
            frmAddEditUser.ShowDialog();
            RefreshList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUserList.CurrentRow.Cells[0].Value;
            if (clsGlobalSettings.CuurentUser.UserID==UserID)
            {
                MessageBox.Show("Cannot Be Deleted The User in User","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;  
            }
            if (MessageBox.Show("Are you sure you want to delete User [" + UserID + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUsers.Delete(UserID))
                {
                    MessageBox.Show("Deleted Successfuly");
                    RefreshList();
                }
                else
                {
                    MessageBox.Show("Cannot Be Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == 0)
            {
                txtSearch.Visible = false;
                cmbActiveList.Visible = false;
                return;
            }
            if (cmbFilterBy.SelectedItem.ToString() == "IsActive")
            {
                cmbActiveList.SelectedIndex = 0;
                txtSearch.Visible = false;
                cmbActiveList.Visible = true;

            }
            else
            {
                txtSearch.Text = "";
                txtSearch.Visible = true; txtSearch.Focus();
                cmbActiveList.Visible = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                return;
            FilteringBy();
        }

        private void cmbActiveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilteringBy();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedItem.ToString() == "PersonID"|| cmbFilterBy.SelectedItem.ToString() == "UserID")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (!char.IsControl(e.KeyChar))
                        e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
