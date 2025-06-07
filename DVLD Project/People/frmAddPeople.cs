using DVLD_Project.Properties;
using DVLDBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Linq.Expressions;
using DVLD_Project.GlobalClasses;

namespace DVLD_Project
{
    public partial class frmAddPeople : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public DataBackEventHandler DataBackToPersonCard;
        bool MarkForUpdateImage = false;
        bool MarkForDelete=false;
        clsPeople Person;
        int _PersonID;
        string _ImageFullPath="";
        enum enMode { AddNew=0,Update=1}
        enum enGendor { Male=0,Female};
        enMode _Mode;
        public frmAddPeople()
        {
            
            InitializeComponent();
            _Mode = enMode.AddNew;
     
        }
        public frmAddPeople(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
            _Mode = enMode.Update;
        }
        void ResetDefaultValues()
        {
            FillComboBoxInCountries();
            SetMaxAndMinDateValue();
            if (_Mode == enMode.AddNew)
            {
                lblAddUpdatePerson.Text = "Add New Person";
                Person = new clsPeople();
                return;
            }
            else
            {
                Person = clsPeople.Find(_PersonID);
                if (Person == null)
                {
                    MessageBox.Show("Cannot Find Person");
                    this.Close();
                    return;
                }
                lblAddUpdatePerson.Text = "Update Person";
                lblPersonID.Text = _PersonID.ToString();
            }
        }
        void LoadDataInfo()
        {
       
            txtFirstName.Text=Person.FirstName; 
            txtSecondName.Text=Person.SecondName;
            txtThirdName.Text=Person.ThirdName;
            txtLastName.Text=Person.LastName; 
            txtEmail.Text=Person.Email;
            txtNationalNo.Text=Person.NationalNo;
            txtAddress.Text=Person.Address;
            cmbCountry.SelectedIndex=Person.NationalityCountryID;
            if(Person.Gendor==0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked= true;
            }
            txtPhoneNumber.Text=Person.PhoneNumber;
            dateTimeBirth.Value=Person.DateOfBirth;
            if (Person.ImagePath != "")
            {

                pbPersonImage.ImageLocation = Person.ImagePath;
                pbPersonImage.Load(pbPersonImage.ImageLocation);
                
            }
            llRemoveImage.Visible = (Person.ImagePath!="");

        }
        void SetMaxAndMinDateValue()
        {
            DateTime MaxDateTime = DateTime.Now;
            MaxDateTime = MaxDateTime.AddYears(-18);
            DateTime MinDateTime = DateTime.Now.AddYears(-100);
            dateTimeBirth.MaxDate = MaxDateTime;
            dateTimeBirth.MinDate = MinDateTime;

        }
        bool CheckIsNationalExist(string NationalNo)
        {
            return clsPeople.IsPersonExisting(NationalNo);
        }
        bool CheckEmail(string Email)
        {
            bool IsValid = false;
            if (txtEmail.Text=="")
                return true;
            if (Email.EndsWith(".com") && Email.Contains("@"))
            {
                IsValid = true;
            }
            else
                return false;
            for (int i = 0; i < Email.Length; i++)
            { 
                if (Email[i]== '@')
                {
                    if(i!=0&&i!=Email.Length-1)
                    return (char.IsLetter(Email[i + 1]) && char.IsLetter(Email[i - 1]));
                    else
                        return false;
                }
              
            }
            return IsValid;
        }
        void FillComboBoxInCountries()
        {
            DataTable Countries=clsCountries.GetAllCountries();
            cmbCountry.DataSource = Countries; 
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryName";
            cmbCountry.SelectedValue = "Syria";
        }
        private void frmAddPeople_Load(object sender, EventArgs e)
        {
            
            ResetDefaultValues();
            if(_Mode==enMode.Update)
                LoadDataInfo();



        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMale.Checked&&_ImageFullPath=="") 
            pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbFemale.Checked&&_ImageFullPath == "")
                pbPersonImage.Image = Resources.Female_512;

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if ((CheckIsNationalExist(txtNationalNo.Text))||txtNationalNo.Text=="")
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "The National Number is already exist with another Person");
            }
            else
            {

                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckEmail(txtEmail.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Not Valid Email");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void NotEmptyValidation(object sender, CancelEventArgs e)
        {
            if(((TextBox)sender).Text=="")
            {
                //e.Cancel= true;
                errorProvider1.SetError((TextBox)sender, "Empty Field");
            }
            else
            {
                errorProvider1.SetError((TextBox)sender, "");
            }
        }
        //void CreateFolderForImages()
        //{
        //    if (!Directory.Exists("c:/DVLD_Images"))
        //        Directory.CreateDirectory("c:/DVLD_Images");
        //}
        //void ReplaceImage()
        //{
           
        //    File.Copy(openFileDialog1.FileName, _ImageFullPath, true);
            
        //}
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;

            }
          
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            llRemoveImage.Visible = true;
            //pbPersonImage.Image = Image.FromFile(NewFilePath);
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (rbMale.Checked)
            pbPersonImage.Image =Resources.Male_512;
            if(rbFemale.Checked)
                pbPersonImage.Image = Resources.Female_512;
            llRemoveImage.Visible = false;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool _HandlePersonImage()
        {
            
            if (pbPersonImage.ImageLocation != Person.ImagePath)
            {
                if (Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(Person.ImagePath);
                    }

                    catch (IOException)
                    {

                    }
                }
           
            }
            if(pbPersonImage.ImageLocation != null) {
            
                string SourecFile = pbPersonImage.ImageLocation;
                    if (clsUtil.CopyImagetoFile(ref SourecFile))
                    {
                        pbPersonImage.ImageLocation = SourecFile;
                        return true;
                    }
                    else
                        return false;
            }
            
                return true;


        }

        //bool IsTextsValid()
        //{
        //    bool IsValid = false;
        //    if ((!String.IsNullOrEmpty(txtFirstName.Text) && !String.IsNullOrEmpty(txtLastName.Text) && !String.IsNullOrEmpty(txtSecondName.Text)
        //    && !String.IsNullOrEmpty(txtNationalNo.Text) &&  !String.IsNullOrEmpty(txtPhoneNumber.Text))
        //    && !String.IsNullOrEmpty(txtAddress.Text)&&CheckEmail(txtEmail.Text))
        //    {
        //        IsValid = true;
        //    }
        //    if(_Mode==enMode.AddNew)
        //    {
        //        if(CheckIsNationalExist(txtNationalNo.Text))
        //        {
        //            return false;
        //        }
        //    }
        //    return IsValid;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error You Have to Check if there Empty Field or Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage())
                return;
         
            Person.FirstName = txtFirstName.Text;
            Person.LastName=txtLastName.Text;
            Person.Email = txtEmail.Text;
            Person.NationalNo=txtNationalNo.Text;
            Person.Address = txtAddress.Text;
            Person.ThirdName= txtThirdName.Text;
            Person.DateOfBirth = dateTimeBirth.Value;
            Person.SecondName = txtSecondName.Text;
            if (rbMale.Checked)
                Person.Gendor = (int)enGendor.Male;
            else
                Person.Gendor = (int)enGendor.Female;
            
            Person.PhoneNumber= txtPhoneNumber.Text;
         
            Person.ImagePath=pbPersonImage.ImageLocation;
          
            Person.NationalityCountryID=cmbCountry.SelectedIndex;
            if(Person.Save())
            {
                DataBackToPersonCard?.Invoke(this, Person.PersonID);
                if (_Mode == enMode.AddNew)
                    MessageBox.Show(Person.PersonID.ToString() + " Added");
                else
                {
                    MessageBox.Show(Person.PersonID.ToString() + " Updated");
                }
                _Mode = enMode.Update;
                lblAddUpdatePerson.Text = "Update Person";
                lblPersonID.Text = Person.PersonID.ToString();
               
            }
            else
                MessageBox.Show("Error You Have to Check if there Empty Field or Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

     
    }
}
