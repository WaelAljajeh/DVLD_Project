using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsLocalDrivingLicenese:clsApplication
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;
        //public int ApplicationID { get; set; }
        public int LocalDrivingLicenseID { get; set; }
        public int LicenseClassID { get; set; }
        public string PersonFullName { get { return this._PersonInfo.Fullname(); } }
        public string LicenseClassName { get; set; }
        
        public int PassedTestCount {  get; set; }
        public clsLicenesClasses LicenseClassInfo { get; set; }
        
        public clsLocalDrivingLicenese()
        {
            ApplicationID = -1;
            LocalDrivingLicenseID= -1;
            LicenseClassID= -1;
            _Mode=enMode.AddNew;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationStatus = 0;
            this.ApplicationPersonID = -1;
            this.ApplicationTypeID = -1;
            this.CreatedByUserID = -1;
            this.LastStatus = DateTime.MinValue;
            this.PaidFees = 0;
            this.PassedTestCount = 0;
        }
        private clsLocalDrivingLicenese(int localDrivingLicenseID, int applicationID,int licenseClassID,DateTime applicationDate,int applicationPersonID,byte applicationStatus,int applicationTypeID,int createdByUserID,DateTime LastStatus,float PaidFees)
        {
            this.LocalDrivingLicenseID = localDrivingLicenseID;
            this.ApplicationID = applicationID;
            this.LicenseClassID = licenseClassID;
            this.ApplicationDate = applicationDate;
            this.ApplicationPersonID = applicationPersonID;
            this.ApplicationStatus = applicationStatus;
            this.CreatedByUserID = createdByUserID;
            this.LastStatus = LastStatus;
            this.ApplicationTypeID= applicationTypeID;
            this.PaidFees= PaidFees;
            _Mode = enMode.Update;
            _PersonInfo = clsPeople.Find(ApplicationPersonID);
            _UserInfo = clsUsers.Find(CreatedByUserID);
            _ApplicationTypeInfo=clsApplicationTypes.Find(ApplicationTypeID);
            LicenseClassInfo=clsLicenesClasses.Find(LicenseClassID);


        }
        //private clsLocalDrivingLicenese(int localDrivingLicenseID, int applicationID, int licenseClassID)
        //{
        //    _Mode = enMode.Update;
        //    ApplicationID = applicationID;
        //    LocalDrivingLicenseID = localDrivingLicenseID;
        //    LicenseClassID = licenseClassID;
        //}
        //private clsLocalDrivingLicenese(clsLocalDrivingLicenese localDrivingLicenese,string ClassName,string FullName,int PassedTest)
        //{  _Mode = enMode.Update;
        //    ApplicationID = localDrivingLicenese.ApplicationID;
        //    LicenseClassID = localDrivingLicenese.LicenseClassID;
        //    LocalDrivingLicenseID=localDrivingLicenese.LocalDrivingLicenseID ;
        //    this.LicenseClassName = ClassName;
        //    this.PersonFullName= FullName;
        //    this.PassedTestCount = PassedTest;
        //}
        public static DataTable GetAllLocalDrivingLiceneses()
        {
            return clsLocalDrivingLiceneseData.GetAllLocalDrivingLicenseTable();
        }
        public static clsLocalDrivingLicenese Find(int localDrivingLicenseID)
        {
            int applicationID = -1;
            int licinenseClassID = -1;
            bool IsFound = (clsLocalDrivingLiceneseData.GetLocalDrivingInfoByID(localDrivingLicenseID, ref applicationID, ref licinenseClassID));
            if(IsFound)
            {
                clsApplication application=clsApplication.FindBaseApplication(applicationID);
                if (application == null)
                    return null;
                return new clsLocalDrivingLicenese(localDrivingLicenseID, applicationID, licinenseClassID, application.ApplicationDate, application.ApplicationPersonID, application.ApplicationStatus, application.ApplicationTypeID, application.CreatedByUserID, application.LastStatus, application.PaidFees);
            }
            return null;
        }
        public static clsLocalDrivingLicenese FindByApplicationID(int applicationID)
        {
            int localDrivingLicenseID = -1;
            int licinenseClassID = -1;

            bool IsFound = (clsLocalDrivingLiceneseData.GetLocalDrivingInfoByApplicationID(applicationID, ref localDrivingLicenseID, ref licinenseClassID));
            
            if(IsFound)
            {
                clsApplication application= clsApplication.FindBaseApplication(applicationID); if (application == null) return null;
                return new clsLocalDrivingLicenese(localDrivingLicenseID, applicationID, licinenseClassID, application.ApplicationDate, application.ApplicationPersonID, application.ApplicationStatus, application.ApplicationTypeID, application.CreatedByUserID, application.LastStatus, application.PaidFees);
            }
            return null;
        }
        public static int GetPersonHaveActiveApplicationWithSameClass(int AppPersonID, int AppTypeID, int LicenseClassID)
        {
            return clsLocalDrivingLiceneseData.GetActivateApplicationWithSameClass(AppPersonID,AppTypeID,LicenseClassID);
        }
        public static bool IsPersonHaveActiveApplicationWithSameClass(int AppPersonID,int AppTypeID,int LicenseClassID)
        {
            return clsLocalDrivingLiceneseData.IsPersonHaveApplicationWithSameClass(AppPersonID, AppTypeID, LicenseClassID);
        }
        //public static clsLocalDrivingLicenese GetLocalDrivingIDByInfo(int LocalDrivingLicenseID)
        //{
        //    string PersonFullName = "";
        //    string ClassName = "";
        //    int PassedTestCount = 0;
            
        //    if(clsLocalDrivingLiceneseData.GetLocalDrivingLicenseViewInfo(LocalDrivingLicenseID,ref ClassName,ref PersonFullName,ref PassedTestCount))
        //    {
        //        clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(LocalDrivingLicenseID);
        //        return new clsLocalDrivingLicenese(localDrivingLicenese, ClassName, PersonFullName, PassedTestCount);
        //    }
        //    return null;
        //}
        bool AddNewLocalDriving()
        {
            LocalDrivingLicenseID = clsLocalDrivingLiceneseData.AddNewLocalDrivingLicense(ApplicationID,LicenseClassID);
            return LocalDrivingLicenseID != -1;
        }
        bool UpdateLocalDriving()
        {
            return clsLocalDrivingLiceneseData.UpdateLocalDrivingLicence(LocalDrivingLicenseID, LicenseClassID);
        }
        public bool DeleteLocalDrivingLicense(int LocalID)
        {

            if (clsLocalDrivingLiceneseData.DeleteLocalDrivingLicense(LocalID))
            {
                bool DeleteApp = base.DeleteApplication(ApplicationID);
                if (DeleteApp)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public static int GetAllTrialsAppointments(int LocalDrivingLicenseID,int TestTypeID)
        {
            return clsLocalDrivingLiceneseData.GetAllTrialsAppointment(LocalDrivingLicenseID,TestTypeID);
        }
        public bool Save()
        {
            base._Mode = (clsApplication.enMode)_Mode;
            if (!base.Save())
            {
                return false;
            }
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewLocalDriving())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return UpdateLocalDriving();
            }
            return false;
        }
        public static int GetPassedTestCount(int LocalDrivingLicenseID)
        {
            return clsTest.GetTestPassedCount(LocalDrivingLicenseID);
        }
        public bool IslicenseExist()
        {
            return clsLicense.IsLicenseExistingByAppID(ApplicationID);
        }
        public bool PassedAllTest()
        {
            return clsTest.PassedAllTests(LocalDrivingLicenseID);
        }
        public int IssueDrivingLicenseApplicationFirstTime(string Notes,int CreatedByUserID)
        {
            int DriverID = -1;
            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicationPersonID);
            if(Driver==null)
            {
                Driver = new clsDriver();
                Driver.PerosnID = ApplicationPersonID;
                Driver.CreatedDate = DateTime.Now;
                Driver.CreatedByUserID=CreatedByUserID;
                if (Driver.AddDriver())
                {
                    DriverID = Driver.DriverID;
                }
                else
                    return -1;
            }
            else
                DriverID=Driver.DriverID;
            clsLicense License = new clsLicense();
            License.DriverID = DriverID;
            License.LicenseClass = LicenseClassID;
            License.ApplicationID = ApplicationID;
            License.CreatedByUserID = CreatedByUserID;
            License.ExpirationDate=DateTime.Now.AddYears(LicenseClassInfo.DefaultValidityLength);
            License.IsActive = true;
            License.IssueDate = DateTime.Now;
            License.IssueReason = (int)clsLicense.enIssueReasons.FirstTime;
            License.Notes = Notes;
            License.PaidFees = LicenseClassInfo.ClassFees;
            if(License.Save())
            {
                this.SetCompleted();
                return License.LicenseID;

            }
            return -1;

        }
    }
}
