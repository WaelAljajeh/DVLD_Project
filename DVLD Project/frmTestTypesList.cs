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
    public partial class frmTestTypesList : Form
    {
        public frmTestTypesList()
        {
            InitializeComponent();
        }
        void RefreshList()
        {
            dgvTestTypesList.DataSource = clsTestType.GetAllAppTypes();
            lblRecord.Text = (dgvTestTypesList.RowCount - 1).ToString();
        }
        private void frmTestTypesList_Load(object sender, EventArgs e)
        {
            
            RefreshList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frmUpdateTestTypes = new frmUpdateTestTypes((int)dgvTestTypesList.CurrentRow.Cells[0].Value);
            frmUpdateTestTypes.ShowDialog();
            RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
