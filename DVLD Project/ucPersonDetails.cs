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
    public partial class ucPersonDetails : UserControl
    {
       public int PersonID = -1;
        public DateTime GetPersonDateOfBirth { get { return Convert.ToDateTime(lblDateOfBirth.Text); } }
        public ucPersonDetails()
        {
            InitializeComponent();
            
            
        }

        private void grpPersonDetails_Enter(object sender, EventArgs e)
        {

        }
        string GetGendor(int Gendor)
        {
            if (Gendor == 0)
            {
                pbPersonImage.Image = Properties.Resources.Male_512;
                return "Male";
            }
            else
            {
                pbPersonImage.Image = Properties.Resources.Female_512;
                return "Female";
            }
        }
        public bool LoadInfoData(string NationalNo)
        {
            clsPeople People =clsPeople.Find(NationalNo);
            if (People == null)
            {
                return false;
            }
            LoadData(People); return true;
        }
        public void Reset()
        {
            lblPersonID.Text = "N/A";
            lblNationalNo.Text = "[???]";
            lblEmail.Text = "[???]";
            lblCountry.Text = "[???]";
            lblAddress.Text = "[???]";
            lblFullName.Text = "[???]";
            lblGendor.Text = "[???]";
            lblPhone.Text = "[???]";
            lblDateOfBirth.Text = "[???]";

        }
        public bool LoadInfoData(int _PersonID)
        {
            
            if (_PersonID == -1)
                return false;
            PersonID=_PersonID;
            clsPeople Person = clsPeople.Find(_PersonID);
            if (Person == null)
                return false;
            LoadData(Person);
            return true;
            

        }
        void LoadData(clsPeople Person)
        {
            PersonID = Person.PersonID;
            lblPersonID.Text = Person.PersonID.ToString();
            lblCountry.Text = clsCountries.GetCountryName(Person.NationalityCountryID).ToString();
            lblAddress.Text = Person.Address;
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            lblFullName.Text = Person.Fullname();
            lblGendor.Text = GetGendor(Person.Gendor);
            lblEmail.Text = Person.Email;
            lblPhone.Text = Person.PhoneNumber;
            lblNationalNo.Text = Person.NationalNo;
            if (Person.ImagePath != "")
            {

                if (File.Exists(Person.ImagePath))
                {
                    Stream stream = null;
                    stream = new FileStream(Person.ImagePath, FileMode.Open, FileAccess.Read);


                    pbPersonImage.Image = Image.FromStream(stream);
                    stream.Close();
                }
            }
          
            
        }

        private void ucPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void llEditPerosn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PersonID != -1)
            {
                frmAddPeople frmAddPeople = new frmAddPeople(PersonID);
                frmAddPeople.ShowDialog();
                LoadInfoData(PersonID);
            }
            else
            { MessageBox.Show("You Didn't Select A Person");
                return;
            }

        }

        private void lblCountry_Click(object sender, EventArgs e)
        {

        }
    }
}
