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
    public partial class frmApplicationTypesList : Form
    {
        public frmApplicationTypesList()
        {
            InitializeComponent();
        }
        void RefreshList()
        {
            dgvApplicationTypesList.DataSource = clsApplicationTypes.GetAllAppTypes();
            lblRecord.Text = (dgvApplicationTypesList.RowCount - 1).ToString();
            
        }
        private void frmApplicationTypesList_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateAppTypes frmUpdateAppTypes = new frmUpdateAppTypes((int)dgvApplicationTypesList.CurrentRow.Cells[0].Value);
            frmUpdateAppTypes.ShowDialog();
            RefreshList();  
        }
    }
}
