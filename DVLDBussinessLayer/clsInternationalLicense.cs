using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsInternationalLicense:clsApplication
    {
      enum enMode { AddNew=1,Update=2}
        enMode _Mode;
      public int InternationalLicenseID { get; set; }
      //public int ApplicationID { get; set; }
      public int DriverID { get; set; }
      public int IssuedUsingLocalLicenseID { get; set; }
      public DateTime IssueDate { get; set; }
      public DateTime ExpirationDate { get; set; }
      public bool IsActive { get; set; }
      public int CreatedByUserID { get; set; }
      public clsApplication ApplicationInfo { get; }
        public clsInternationalLicense() 
        {
            _Mode = enMode.AddNew;
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.MinValue;
            IsActive = false;
            ExpirationDate = DateTime.MinValue;
            CreatedByUserID = -1;
        }
      private clsInternationalLicense( int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            _Mode = enMode.Update;
            InternationalLicenseID = internationalLicenseID;
            base.ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            base.CreatedByUserID = createdByUserID;
            this.CreatedByUserID = CreatedByUserID;
            //ApplicationInfo = clsApplication.Find(ApplicationID);
        }

      public static DataTable GetInternationalLicensesList()
        {
            return  clsInternationalDrivingLicensesData.GetInternationalList();
        }
      public static DataTable GetInternationalLicensesListPerPerson(int PerosnID)
        {
            return clsInternationalDrivingLicensesData.GetInternationalListPerPerson(PerosnID);
        }
        bool AddNewInternationalLicense()
        {
            InternationalLicenseID = clsInternationalDrivingLicensesData.AddNewInternationalLicense(ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID);
            return InternationalLicenseID != -1;
        }
        bool UpdateInternationalLicense()
        {
            return clsInternationalDrivingLicensesData.UpdateInternationalLicense(InternationalLicenseID,ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);

        }
        public static bool IsInternationalLicenseExistingByLocalLicenseID(int LocalDrivinglicenseID)
        {
            return clsInternationalDrivingLicensesData.IsInternationalLicenseExistingByLocalLicenseID(LocalDrivinglicenseID);
        }
        public static bool IsInternationalLicenseExisting(int InternationalLicenseID)
        {
            return clsInternationalDrivingLicensesData.IsInternationalLicenseExisting(InternationalLicenseID);
        }
        public static bool IsInternationalLicenseExistingByPerosnID(int PersonID)
        { return clsInternationalDrivingLicensesData.IsInternationalLicenseExistingByPerosnID((int)PersonID); }
        public static bool IsInternationalLicenseExistingByAppID(int AppID) 
        { return clsInternationalDrivingLicensesData.IsInternationalLicenseExistingByAppID(AppID); }
        public static clsInternationalLicense Find(int InternationalLicenseID) 
        {
            int applicationID = -1
                , driverID = -1
                 , issuedUsingLocalLicenseID = -1, createdByUserID=-1;
            DateTime issueDate = DateTime.MinValue 
                ,expirationDate =DateTime.MinValue;
            bool isActive = false;
            if(clsInternationalDrivingLicensesData.GetInternationalLicesneInfoByID(InternationalLicenseID,ref applicationID,ref driverID,ref issuedUsingLocalLicenseID,ref issueDate,ref expirationDate,ref isActive,ref createdByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID,applicationID,driverID,issuedUsingLocalLicenseID,issueDate,expirationDate,isActive,createdByUserID);
            }
            return null;
        }
        public static clsInternationalLicense FindByDriverID(int DriverID)
        {
            int applicationID = -1
                , internatinalID = -1
                 , issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.MinValue
                , expirationDate = DateTime.MinValue;
            bool isActive = false;
            if (clsInternationalDrivingLicensesData.GetInternationalLicesneInfoByDriverID(DriverID, ref internatinalID ,ref applicationID, ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
            {
                return new clsInternationalLicense(internatinalID, applicationID, DriverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }
            return null;
            
        }
        public static clsInternationalLicense FindByDriverID(int DriverID,bool IsActive)
        {
            int applicationID = -1
                , internatinalID = -1
                 , issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.MinValue
                , expirationDate = DateTime.MinValue;
            bool isActive = false;
            if (clsInternationalDrivingLicensesData.GetActiveInternationalLicesneInfoByDriverID(DriverID, ref internatinalID, ref applicationID, ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, isActive, ref createdByUserID))
            {
                return new clsInternationalLicense(internatinalID, applicationID, DriverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }
            return null;

        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewInternationalLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return UpdateInternationalLicense();
            }
            return false;
        }
    }
}
