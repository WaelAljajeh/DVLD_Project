using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsPeople
    {
        enum enMode {Add=0,Update=1}
        enMode _Mode;
       public int PersonID {  get; set; }
       public string NationalNo { get; set; }
       public string FirstName {  get; set; }
       public string SecondName {  get; set; }
       public string ThirdName {  get; set; }
       public string LastName { get; set; }

       public DateTime DateOfBirth {  get; set; }  
       public byte Gendor {  get; set; } 
       public string Address {  get; set; }
       public string Email {  get; set; }
       public string PhoneNumber {  get; set; }
       public int NationalityCountryID {  get; set; }  
       public string ImagePath {  get; set; }
       public string Fullname()
        { return FirstName+" "+SecondName+" "+ThirdName+" "+LastName;}

       public clsPeople() 
       {
            _Mode = enMode.Add;
            PersonID = -1;
            FirstName = "";
            LastName = "";
            ThirdName = "";
            SecondName = "";
            DateOfBirth= DateTime.MinValue;
            Gendor = 0;
            Address = "";
            Email = "";
            PhoneNumber = "";
            NationalityCountryID = -1;
            ImagePath = "";

       }
       private clsPeople(int PersonID, string NationalNo, string FirstName, string SecondName
  , string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address
            , string Email, string PhoneNumber, int NationalityCountryID, string ImagePath)
        {
            _Mode = enMode.Update;
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ThirdName = ThirdName;
            this.SecondName = SecondName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.NationalityCountryID= NationalityCountryID;
            this.ImagePath = ImagePath;
        }
        bool AddNewPerson()
        {
            PersonID=clsPeopleData.AddNewPerson(NationalNo,FirstName,SecondName
  , ThirdName, LastName,DateOfBirth,Gendor,Address
            , Email,PhoneNumber,NationalityCountryID,ImagePath);
            return PersonID != -1;
        }
        bool UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(PersonID,NationalNo, FirstName, SecondName
  , ThirdName, LastName, DateOfBirth, Gendor, Address
            , Email, PhoneNumber, NationalityCountryID, ImagePath);
        }
        public static clsPeople Find(int PersonID)
        {
            string NationalNo = "",FirstName="",LastName="",SecondName="",ThirdName="",Address="",Email="",PhoneNumber="",ImagePath="";
            int NationalityCountryID = -1;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            if (clsPeopleData.GetPersonInfoByID(PersonID,ref NationalNo, ref FirstName,ref SecondName
  , ref ThirdName, ref LastName,ref DateOfBirth,ref Gendor,ref Address
            ,ref Email,ref PhoneNumber,ref NationalityCountryID,ref ImagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName
  , ThirdName, LastName, DateOfBirth, Gendor, Address
            , Email, PhoneNumber, NationalityCountryID, ImagePath);
            }
            return null;
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
            
        }
       public static clsPeople Find(string NationalNo)
        {
            string FirstName = "", LastName = "", SecondName = "", ThirdName = "", Address = "", Email = "", PhoneNumber = "", ImagePath = "";
            int NationalityCountryID = -1,PersonID=-1;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            if (clsPeopleData.GetPersonInfoByNationalNo(NationalNo,ref PersonID, ref FirstName, ref SecondName
  , ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address
            , ref Email, ref PhoneNumber, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName
  , ThirdName, LastName, DateOfBirth, Gendor, Address
            , Email, PhoneNumber, NationalityCountryID, ImagePath);
            }
            return null;
        }
       public static DataTable GetAllPeopleTable()
        {
            return clsPeopleData.GetAllPeople();
        }
        public static bool IsPersonExisting(int PersonID) 
        {
            return clsPeopleData.IsPersonExistingByID(PersonID);
        }
        public static bool IsPersonExisting(string NationalNo)
        {
            return clsPeopleData.IsPersonExistingByNationalNo(NationalNo);
        }
       public bool Save()
        {
            switch(_Mode)
            {
                case enMode.Add:
                    if(AddNewPerson())
                    {
                        _Mode=enMode.Update;
                        return true;
                    }
                    else
                    return false;
                case enMode.Update:
                    return UpdatePerson();
            }
            return false;
        }

    }
}
