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
        public clsDriver DriverInfo { get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public string Notes {  get; set; }
        public float PaidFees {  get; set; }
        public bool IsActive {  get; set; }
        public int IssueReason {  get; set; }
        public int CreatedByUserID {  get; set; }
        
        public clsLicenesClasses LicenesClassesInfo { get; set; }
        public clsApplication ApplicationInfo { get; set; }
        public clsDetain DetainInfo { get; set; }
        public bool IsDetained { get { return clsDetain.IsDetainExistingByLicenseID(this.LicenseID,false); } }
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
            ApplicationInfo = clsApplication.FindBaseApplication(ApplicationID);
            DriverInfo = clsDriver.Find(DriverID);
            LicenesClassesInfo = clsLicenesClasses.Find(LicenseClass);
            DetainInfo=clsDetain.FindByLicenseID(LicenseID);
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

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }
        public bool DeactivateCurrentLicense()
        {
            return (clsLicenseData.DeactivateLicense(this.LicenseID));
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
        public clsLicense RenewLicense(string Notes,int CreatedByUserID)
        {
            clsApplication application = new clsApplication();
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
            application.ApplicationPersonID = this.DriverInfo.PerosnID;
            application.ApplicationTypeID = (int)clsApplicationTypes.ApplicationType;
            application.CreatedByUserID = CreatedByUserID;
            application.LastStatus = DateTime.Now;
            application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType);
            if (!application.Save())
            {
                return null;
            }
            clsLicense license = new clsLicense();
            license.ApplicationID = application.ApplicationID;
            license.Notes = Notes;
            license.IsActive = true;
            license.CreatedByUserID = application.CreatedByUserID;
            license.DriverID = this.DriverID;
            int DefaultValidityLength=this.LicenesClassesInfo.DefaultValidityLength;
            license.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            license.IssueDate = DateTime.Now;
            license.IssueReason = (int)clsLicense.enIssueReasons.Renew;
            license.LicenseClass = this.LicenseClass;
            license.PaidFees = this.LicenesClassesInfo.ClassFees;
            if(!license.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();
            return license;
        }
        public clsLicense Replacement(int CreatedByUserID)
        {

            clsApplication application = new clsApplication();
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
            application.ApplicationPersonID = DriverInfo.PerosnID;
            application.ApplicationTypeID = (int)clsApplicationTypes.ApplicationType;
            application.CreatedByUserID = CreatedByUserID;
            application.LastStatus = DateTime.Now;
            application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType);
            if (!application.Save())
            {
                return null;
            }
            clsLicense license = new clsLicense();
            license.ApplicationID = application.ApplicationID;
            license.Notes = Notes;
            license.IsActive = true;
            license.CreatedByUserID = CreatedByUserID;
            license.DriverID = DriverID;
            license.ExpirationDate =ExpirationDate;
            license.IssueDate = DateTime.Now;
            license.IssueReason = (int)clsLicense.IssueReasons;
            license.LicenseClass = LicenseClass;
            license.PaidFees = 0;
            if(!license.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();
            return license;
            
        }
        public int Detian(float Fine,int UserID)
        {
          clsDetain _Detain = new clsDetain();
            _Detain.DetainDate = DateTime.Now;
            _Detain.IsReleased = false;
            _Detain.LicenseID = this.LicenseID;
            _Detain.CreatedByUserID = UserID;
            _Detain.FineFees = Fine;
            if (!_Detain.Save())
            {
                return -1;
                //  ucDriverLicenseWithFilter1.FilterEnable = false;
                //   llShowLicenseInfo.Enabled = true;
                //  MessageBox.Show("Detained Successfuly");
                //  ucDriverLicenseWithFilter1.UpdateIsDetainValue();
                //   Convert.ToSingle(nudFineFees.Value);
            }
            return _Detain.DetainID;

        }
        public bool ReleaseDetainedLicense(int CreatedByUserID,ref int ApplicationID)
        {

            
            clsApplication application = new clsApplication();
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = (int)clsApplication.enAPPStatus.Completed;
            application.ApplicationPersonID = this.DriverInfo.PerosnID;
            application.ApplicationTypeID = (int)clsApplicationTypes.ApplicationType;
            application.CreatedByUserID = CreatedByUserID;
            application.LastStatus = DateTime.Now;
            application.PaidFees = clsApplicationTypes.GetApplicationTypePaidFees((int)clsApplicationTypes.ApplicationType);
            if (!application.Save())
            {
                return false;
            }
            ApplicationID = application.ApplicationID;
            return this.DetainInfo.ReleaseDetainedLicense(CreatedByUserID,ApplicationID);
            
        }
    }
}
