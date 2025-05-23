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
using static DVLDBussinessLayer.clsTestType;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project
{
    public partial class frmLocalDrivingLicenseList : Form
    {
        public frmLocalDrivingLicenseList()
        {
            InitializeComponent();
        }
       
        void RefreshList()
        {

            dgvLocalDrivingListList.DataSource = clsLocalDrivingLicenese.GetAllLocalDrivingLiceneses();

        }
        void CancelledApplicationEnablity(bool Enable)
        {
            editToolStripMenuItem.Enabled = Enable;
            deleteToolStripMenuItem.Enabled = Enable;
            issueDrivingLicenseToolStripMenuItem.Enabled = Enable;
            SLHStripMenuItem.Enabled = Enable;
            CancelToolStripMenuItem.Enabled = Enable;
            sechduleTestsToolStripMenuItem.Enabled= Enable;


        }
        private void frmLocalDrivingLicenseList_Load(object sender, EventArgs e)
        {
            SLHStripMenuItem.Enabled = false;
            cmbFilterBy.SelectedIndex = 0;
            RefreshList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivinglicenseID = (int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenese LocalDrivingLicense =clsLocalDrivingLicenese.Find(LocalDrivinglicenseID);
            clsApplication application = clsApplication.Find(LocalDrivingLicense.ApplicationID);
            if (MessageBox.Show("Do you want to Delete this application", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (LocalDrivingLicense.DeleteLocalDrivingLicense(LocalDrivinglicenseID) && application.DeleteApplication(application.ApplicationID))
                {
                    MessageBox.Show("Deleted Succesfuly");
                }
                else
                    MessageBox.Show("Cannot Be Deleted");
            }
        }
        bool IsAppStatusNotCompleted(int ApplicationStatus)
        { return ApplicationStatus != (int)clsApplication.enAPPStatus.Completed; }
        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivinglicenseID = (int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(LocalDrivinglicenseID);

            clsApplication application = clsApplication.Find(localDrivingLicenese.ApplicationID);
            if (IsAppStatusNotCompleted(application.ApplicationStatus))
            {
                application.ApplicationStatus = (int)clsApplication.enAPPStatus.Cancelled;
                application.LastStatus = DateTime.Now;
                if (MessageBox.Show("Do you really want to Cancel The Application", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (application.Save())
                    {
                        MessageBox.Show("Application Cancelled Succesfuly");
                        RefreshList();
                    }
                }

            }
            else
                MessageBox.Show("It Cannot Be Cancelled","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == cmbFilterBy.FindString("LocalDrivingLicenseApplicationID"))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (!char.IsControl(e.KeyChar))
                        e.Handled = true;

                }
            }
        }
        bool IsTestPassed(clsTestType.enTestType TestType)
        {
           return clsTest.IsTestPassed((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value, (int)TestType);
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            if(cmbFilterBy.SelectedIndex==0)
            {
                txtSearch.Visible = false;
            }
            else
            {
                txtSearch.Visible=true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                return;
            DataTable LocalDrivingLicense=dgvLocalDrivingListList.DataSource as DataTable;
            if (cmbFilterBy.SelectedIndex == cmbFilterBy.FindString("LocalDrivingLicenseApplicationID"))
            {
                LocalDrivingLicense.DefaultView.RowFilter = $"LocalDrivingLicenseApplicationID='{txtSearch.Text}'";

            }
            else
                LocalDrivingLicense.DefaultView.RowFilter = $"{cmbFilterBy.SelectedItem} like '%{txtSearch.Text}%'";

        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.TestType = clsTestType.enTestType.VisionTest;
            frmVisionTest visionTest = new frmVisionTest((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value);
            visionTest.ShowDialog();
            RefreshList();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.TestType = clsTestType.enTestType.WrittenTest;
            frmVisionTest visionTest = new frmVisionTest((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value);
            visionTest.ShowDialog();
            RefreshList();

        }
        void HandleEnabiltyMenuItem()
        {
            bool VisionTest = IsTestPassed(clsTestType.enTestType.VisionTest);
            bool WrittenTest = IsTestPassed(clsTestType.enTestType.WrittenTest);
            bool StreetTest = IsTestPassed(clsTestType.enTestType.StreetTest);
            visionTestToolStripMenuItem.Enabled = !VisionTest;
            writtenTestToolStripMenuItem.Enabled = VisionTest && !WrittenTest;
            streetTestToolStripMenuItem.Enabled = WrittenTest && !StreetTest;
            if(StreetTest)
            {
                EnableIssueDrivingLicenseItem(true);
                return;
            }
            EnableIssueDrivingLicenseItem(false);
        }
        void EnableIssueDrivingLicenseItem(bool Enable)
        {
            issueDrivingLicenseToolStripMenuItem.Enabled = Enable;
            
            sechduleTestsToolStripMenuItem.Enabled=!Enable;
        }
        void CompletedApplicationEnabilty()
        {
            CancelledApplicationEnablity(false);
            SLHStripMenuItem.Enabled = true;
        }
        void ResetItemEnabiltytoDefalut()
        {
            CancelledApplicationEnablity(true); SLHStripMenuItem.Enabled = false;
        }
        private void cmsApplicationInfo_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLocalDrivingListList.CurrentRow.Cells[dgvLocalDrivingListList.ColumnCount - 1].Value.ToString() == clsApplication.enAPPStatus.Cancelled.ToString())
            {
                CancelledApplicationEnablity(false);
                return;
            }

            else if (dgvLocalDrivingListList.CurrentRow.Cells[dgvLocalDrivingListList.ColumnCount - 1].Value.ToString() == clsApplication.enAPPStatus.Completed.ToString())
            {
                CompletedApplicationEnabilty();
                return;
            }
            else
            {
                ResetItemEnabiltytoDefalut();
                HandleEnabiltyMenuItem();
            }

        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            clsTestType.TestType = clsTestType.enTestType.StreetTest;
            frmVisionTest visionTest = new frmVisionTest((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value);
            visionTest.ShowDialog();
            RefreshList();
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicense.IssueReasons = clsLicense.enIssueReasons.FirstTime;
            frmIssueDrivingLicense frmIssueDrivingLicense = new frmIssueDrivingLicense((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value);
            frmIssueDrivingLicense.ShowDialog();
            RefreshList();
        }

        private void SLHStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenese localDrivingLicenese=clsLocalDrivingLicenese.Find((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value);
            int LicenseID = clsLicense.GetLicenseIDByAppID(localDrivingLicenese.ApplicationID);
            frmShowLicenseHistory frmShowLicenseHistory = new frmShowLicenseHistory(LicenseID);
            frmShowLicenseHistory.ShowDialog();
            RefreshList();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsLocalDrivingLicenese.Find((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value).ApplicationInfo.ApplicationPersonID;
            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory(PersonID);
            frmPersonLicenseHistory.ShowDialog();
            RefreshList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalDrivingApplicationInfo frmShowLocalDriving = new frmShowLocalDrivingApplicationInfo((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value);
            frmShowLocalDriving.ShowDialog();
            RefreshList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditApplications frmAddEdit = new frmAddEditApplications((int)dgvLocalDrivingListList.CurrentRow.Cells[0].Value);
            frmAddEdit.ShowDialog();
            RefreshList();
            
        }

        private void pbLocaLlDriver_Click(object sender, EventArgs e)
        {
            frmAddEditApplications frmAddEditApplications = new frmAddEditApplications(-1);
            frmAddEditApplications.ShowDialog();
        }
    }
}
