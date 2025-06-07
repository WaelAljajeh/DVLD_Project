using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmPeopleList : Form
    {
        public frmPeopleList()
        {
            InitializeComponent();
        }
        DataTable dtPeopleList = clsPeople.GetAllPeopleTable();

        void RefreshList()
        {
            dgvPeopleList.DataSource = dtPeopleList;

            lblRecord.Text = (dgvPeopleList.RowCount).ToString();
        }
        private void frmPeopleList_Load(object sender, EventArgs e)
        {

            cmbFilterBy.SelectedIndex = 0;
            RefreshList();
        }

        private void pbAddPerson_MouseHover(object sender, EventArgs e)
        {
            pbAddPerson.BackColor = SystemColors.ControlDark;
        }

        private void pbAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPeople frmAddPeople = new frmAddPeople();
            frmAddPeople.ShowDialog();
            RefreshList();
        }

        private void pbAddPerson_MouseLeave(object sender, EventArgs e)
        {
            pbAddPerson.BackColor = SystemColors.ButtonHighlight;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvPeopleList.CurrentRow.Cells.Count > 0)
            {
                frmAddPeople frmAddPeople = new frmAddPeople((int)dgvPeopleList.CurrentRow.Cells[0].Value);
                frmAddPeople.ShowDialog();
                RefreshList();
            }


        }
        void FilteringPeople()
        {

            if (txtSearch.Text.Trim() == ""||cmbFilterBy.SelectedIndex == 0)
            {

                dtPeopleList.DefaultView.RowFilter = "";
                
                lblRecord.Text = dtPeopleList.Rows.Count.ToString();
                return;

            }
            //DataTable PeopleTable = (DataTable)dgvPeopleList.DataSource;
            
            if (cmbFilterBy.SelectedItem.ToString() == "Gendor")
            {
                dtPeopleList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = '{cmbGendorList.Text}'";
                lblRecord.Text = (dgvPeopleList.RowCount).ToString();
                return;
            }
            if (cmbFilterBy.SelectedItem.ToString() != "PersonID")
                dtPeopleList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} LIKE '%{txtSearch.Text}%'";
            else
                dtPeopleList.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = '{(int.Parse(txtSearch.Text))}'";
            lblRecord.Text = (dgvPeopleList.RowCount).ToString();

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            FilteringPeople();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cmbFilterBy.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if(!char.IsControl(e.KeyChar))
                    e.Handled = true;
                }
            }
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFilterBy.SelectedIndex == 0)
            {
                txtSearch.Text = "";
                txtSearch.Visible = false;
                cmbGendorList.Visible = false;
                //dtPeopleList.DefaultView.RowFilter = "";
                return;
            }
            if(cmbFilterBy.SelectedItem.ToString()=="Gendor")
            {
                txtSearch.Visible = false;
                cmbGendorList.Visible = true;
               
            }
            else
            {
                txtSearch.Visible = true; txtSearch.Focus();
                cmbGendorList.Visible = false;
            }
        }

        private void cmbGendorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilteringPeople();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPersonDetails = new frmPersonDetails((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frmPersonDetails.ShowDialog();
            RefreshList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddPeople frmAddPeople = new frmAddPeople(-1);
            frmAddPeople.ShowDialog();
            RefreshList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPeople Person = clsPeople.Find((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeopleList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPeople.DeletePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Successfuly");
                    if(Person.ImagePath!="")
                    File.Delete(Person.ImagePath);
                    Person = null;
                }
                else
                {
                    MessageBox.Show("Cannot Be Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshList();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Impelemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) ;
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Impelemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
