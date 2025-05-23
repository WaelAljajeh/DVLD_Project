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
        enMode _Mode;
        public frmAddPeople(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
            if (PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }
        void LoadImage()
        {
            _ImageFullPath = Person.ImagePath;
            if (File.Exists(_ImageFullPath))
            {
                Stream stream = null;
                stream = new FileStream(_ImageFullPath, FileMode.Open, FileAccess.Read);
                pbPersonImage.Image = Image.FromStream(stream);
                stream.Close();
            }
            else
            {
                _ImageFullPath = "";
                return;
            }
            llRemoveImage.Visible = true;
         
        }
        void LoadDataInfo()
        {
            FillComboBoxInCountries();
            SetMaxAndMinDateValue();
            if (_Mode == enMode.AddNew)
            {
                lblAddUpdatePerson.Text = "Add New Person";
                Person = new clsPeople();
                return;
            }
            Person = clsPeople.Find(_PersonID);
            if(Person==null)
            {
                MessageBox.Show("Cannot Find Person");
                this.Close();
                return;
            }
            lblAddUpdatePerson.Text = "Update Person";
            lblPersonID.Text= _PersonID.ToString();
            txtFirstName.Text=Person.FirstName; 
            txtSecondName.Text=Person.SecondName;
            txtThirdName.Text=Person.ThirdName;
            txtLastName.Text=Person.LastName; 
            txtEmail.Text=Person.Email;
            txtNationalNo.Text=Person.NationalNo;
            txtAddress.Text=Person.Address;
            cmbCountry.SelectedIndex= cmbCountry.FindString(clsCountries.GetCountryName(Person.NationalityCountryID)); 
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
                LoadImage();
            }

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
            cmbCountry.ValueMember = "CountryID";
            cmbCountry.SelectedIndex=cmbCountry.FindString("Syria");
        }
        private void frmAddPeople_Load(object sender, EventArgs e)
        {
            CreateFolderForImages();
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
        void CreateFolderForImages()
        {
            if (!Directory.Exists("c:/DVLD_Images"))
                Directory.CreateDirectory("c:/DVLD_Images");
        }
        void ReplaceImage()
        {
          
                File.Copy(openFileDialog1.FileName, _ImageFullPath, true);
            
        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            string extension ;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(_Mode==enMode.Update&&File.Exists(_ImageFullPath))
                {
                    pbPersonImage.Image=Image.FromFile(openFileDialog1.FileName);
                    MarkForUpdateImage = true;
                    
                    return;
                }
                extension = Path.GetExtension(openFileDialog1.FileName);
                Guid messageId = System.Guid.NewGuid();
                _ImageFullPath = "c:/DVLD_Images/" + messageId+extension;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbPersonImage.Image=Image.FromFile(openFileDialog1.FileName);
                File.Copy(openFileDialog1.FileName, _ImageFullPath);
                llRemoveImage.Visible = true;

            }
            else if(pbPersonImage.Image==null)
            {
                _ImageFullPath = "";
                llRemoveImage.Visible = false;
            }
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            llRemoveImage.Visible = true;
            //pbPersonImage.Image = Image.FromFile(NewFilePath);
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pbPersonImage.Image != null)
            {
                pbPersonImage.Image.Dispose();
                pbPersonImage.Image = null;
            }
            if (rbMale.Checked)
            pbPersonImage.Image =Resources.Male_512;
            if(rbFemale.Checked)
                pbPersonImage.Image = Resources.Female_512;
            llRemoveImage.Visible = false;
            _ImageFullPath = "";
            MarkForDelete = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool IsTextsValid()
        {
            bool IsValid = false;
            if ((!String.IsNullOrEmpty(txtFirstName.Text) && !String.IsNullOrEmpty(txtLastName.Text) && !String.IsNullOrEmpty(txtSecondName.Text)
            && !String.IsNullOrEmpty(txtNationalNo.Text) &&  !String.IsNullOrEmpty(txtPhoneNumber.Text))
            && !String.IsNullOrEmpty(txtAddress.Text)&&CheckEmail(txtEmail.Text))
            {
                IsValid = true;
            }
            if(_Mode==enMode.AddNew)
            {
                if(CheckIsNationalExist(txtNationalNo.Text))
                {
                    return false;
                }
            }
            return IsValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!IsTextsValid())
            {
                MessageBox.Show("Error You Have to Check if there Empty Field or Not Valid","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Person.FirstName = txtFirstName.Text;
            Person.LastName=txtLastName.Text;
            Person.Email = txtEmail.Text;
            Person.NationalNo=txtNationalNo.Text;
            Person.Address = txtAddress.Text;
            Person.ThirdName= txtThirdName.Text;
            Person.DateOfBirth = dateTimeBirth.Value;
            Person.SecondName = txtSecondName.Text;
            if (rbMale.Checked)
                Person.Gendor = 0;
            else
                Person.Gendor = 1;
            
            Person.PhoneNumber= txtPhoneNumber.Text;
            if (MarkForDelete&&_Mode==enMode.Update)
            {
                if (File.Exists(Person.ImagePath))
                {
                     
                     File.Delete(Person.ImagePath.Trim());
                    Person.ImagePath = "";
                }
            }
            if (MarkForUpdateImage && _Mode == enMode.Update)
            {
                ReplaceImage();
            }
            Person.ImagePath=_ImageFullPath;
          
            Person.NationalityCountryID=(int)cmbCountry.SelectedValue;
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

        private void grbPersonInfoAdd_Enter(object sender, EventArgs e)
        {

        }
    }
}
