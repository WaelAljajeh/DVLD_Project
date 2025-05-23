using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsLicense
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;
        public enum enIssueReasons { FirstTime = 1, Renew = 2, Replacement_For_Damaged = 3 ,Replacement_For_Lost=4};
        public static enIssueReasons IssueReasons;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public clsDriver DriverInfo {get;}
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public string Notes {  get; set; }
        public float PaidFees {  get; set; }
        public bool IsActive {  get; set; }
        public int IssueReason {  get; set; }
        public int CreatedByUserID {  get; set; }
        public clsApplication ApplicationInfo { get; }
        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueReason = -1;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = "";
            IsActive= false;
            CreatedByUserID= -1;
            _Mode=enMode.AddNew;
            PaidFees = 0;
            DriverInfo = null;
        }
        private clsLicense(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive, int issueReason, int createdByUserID)
        {
            _Mode = enMode.Update;
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            ApplicationInfo = clsApplication.Find(ApplicationID);
            DriverInfo = clsDriver.Find(DriverID);
        }
        public static  clsLicense Find(int LicenseID)
        {
            int applicationID=-1;
            int driverID = -1;
            int licenseClass = -1;
            DateTime issueDate=DateTime.MinValue;
            DateTime expirationDate =DateTime.MinValue;
            string notes="";
            float paidFees=0; bool isActive=false; int issueReason=-1; int createdByUserID=-1;
            if(clsLicenseData.GetDrivingLicenseInfoBy(LicenseID,ref applicationID,ref driverID,ref licenseClass,ref issueDate,ref expirationDate,ref notes,ref paidFees,ref isActive,ref issueReason,ref createdByUserID))
            {
                return new clsLicense(LicenseID, applicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidFees, isActive, issueReason, createdByUserID);
            }
            return null;
        }
        public bool IsLicenseExpired()
        {

            return DateTime.Now>ExpirationDate;
        }
        public static int GetLicenseIDByAppID(int appID)
        {
            return clsLicenseData.GetLicenseIDByApplicationID(appID);
        }
        public static DataTable GetDriverLicenseHistoryList(int AppPersonID)
        {
            return clsLicenseData.GetLicenseInfo(AppPersonID);
        }
        public static bool IsLicenseExisting(int LicensesID)
        {
            return clsLicenseData.IsLicenseExisting(LicensesID);
        }
        public static bool IsLicenseExistingByAppID(int AppID)
        {
            return clsLicenseData.IsLicenseExistingByAppID(AppID);
        }
        bool AddNewLicense()
        {
         LicenseID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
         return LicenseID != -1;
        }
        bool UpdateLicense()
        {
            return clsLicenseData.UpdateLocalDrivingLicence( LicenseID, ApplicationID,  DriverID, LicenseClass, IssueDate,  ExpirationDate, Notes,  PaidFees,IsActive ,IssueReason,CreatedByUserID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return UpdateLicense();
            }
            return false;
        }
    }
}
