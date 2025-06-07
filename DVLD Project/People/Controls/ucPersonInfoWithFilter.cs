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
    public partial class ucPersonInfoWithFilter : UserControl
    {
        public ucPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        public bool FilterEnabled {
            get {  return (grpFilter.Enabled); } 
            set{ grpFilter.Enabled = value; } }
        public DateTime GetDateOfBirth
        {
            get {
                return ucPersonDetails1
                    .GetPersonDateOfBirth;
            }
        }
        public clsPeople GetPersonInfo { get { return clsPeople.Find(ucPersonDetails1.PersonID); } }
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int>handler=OnPersonSelected;
            if(handler != null)
            {  handler(PersonID); }
        }
        void SearchForPerson()
        {
            bool IsPersonSelected = false;
            if (cmbFilterBy.SelectedItem.ToString() == "PersonID")
            {
                int _PersonID = -1;
                if (int.TryParse(txtFilter.Text, out int result))
                {
                    _PersonID = result;
                }
                if (ucPersonDetails1.LoadInfoData(_PersonID))
                {
                    IsPersonSelected = true;
                }
                else
                {
                    MessageBox.Show("Cannot Find a Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ucPersonDetails1.Reset();


                }
            }
            else
            {
                if (ucPersonDetails1.LoadInfoData(txtFilter.Text))
                {
                    IsPersonSelected = true;
                }
                else
                {
                    MessageBox.Show("Cannot Find a Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ucPersonDetails1.Reset();
                }
            }
            if (OnPersonSelected != null && IsPersonSelected)
            {
                OnPersonSelected(ucPersonDetails1.PersonID);
            }
        }
        private void pbSearch_Click(object sender, EventArgs e)
        {
            SearchForPerson();
        }
        public void FillSearchingTextWithPersonIDValue(int PersonID)
        {
            txtFilter.Text = PersonID.ToString();
        }
        public void LoadPersonInformation(int PersonID)
        {
            bool IsPersonSelected = false;
            if(ucPersonDetails1.LoadInfoData(PersonID))
            {
                IsPersonSelected = true;
            }
            if (OnPersonSelected != null && IsPersonSelected)
            {
                OnPersonSelected(ucPersonDetails1.PersonID);
            }
        }
       

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    if (!char.IsControl(e.KeyChar))
                        e.Handled = true;
                }
                if (e.KeyChar == (char)Keys.Enter)
                {
                    pbSearch_Click(null, null);
                }
            }
        }
        public void FilterFoucs()
        {
            txtFilter.Focus();
        }
        private void ucPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cmbFilterBy.SelectedIndex = 0;
        }

        private void ucPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void pbAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPeople AddPeople = new frmAddPeople();
            AddPeople.DataBackToPersonCard += Form_AddPerson_PersonID;
            AddPeople.ShowDialog();
        }
        private void Form_AddPerson_PersonID(object sender,int PersonID)
        {
            cmbFilterBy.SelectedIndex = 0;
            txtFilter.Text = PersonID.ToString();
            SearchForPerson();
        }

        private void grpFilter_Enter(object sender, EventArgs e)
        {

        }
    }
}
