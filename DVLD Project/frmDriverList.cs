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
    public partial class frmDriverList : Form
    {
        public frmDriverList()
        {
            InitializeComponent();
        }

        private void frmDriverList_Load(object sender, EventArgs e)
        {
            cmbFilterBy.SelectedIndex = 0;
            dgvDriversList.DataSource=clsDriver.GetDriversTable();
            lblRecord.Text = (dgvDriversList.Rows.Count - 1).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                return;
            DataTable DriverTable = dgvDriversList.DataSource as DataTable;
            if ((cmbFilterBy.SelectedItem.ToString() != "NumberOfActiveLicenses")&&(cmbFilterBy.SelectedItem.ToString()!="DriverID"))
            {
                DriverTable.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} LIKE '%{txtSearch.Text}%'";
                return;
            }
            else
                DriverTable.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} = '{(int.Parse(txtSearch.Text))}'";
            lblRecord.Text = (dgvDriversList.Rows.Count - 1).ToString();
        }

        private void lblAddUpdatePerson_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedItem.ToString() == "DriverID"|| cmbFilterBy.SelectedItem.ToString() == "NumberOfActiveLicenses")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (!char.IsControl(e.KeyChar))
                        e.Handled = true;
                }
            }
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            if (cmbFilterBy.SelectedIndex == 0)
            {
                txtSearch.Visible = false;
                
                return;
            }
            else
                txtSearch.Visible = true;
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory((int)dgvDriversList.CurrentRow.Cells["PersonID"].Value);
            frmShowLicenseHistory.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory((int)dgvDriversList.CurrentRow.Cells["PersonID"].Value);
            frmPersonLicenseHistory.ShowDialog();
        }
    }
}
