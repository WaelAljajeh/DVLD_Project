using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsLocalDrivingLicenese
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;
        public int ApplicationID { get; set; }
        public int LocalDrivingLicenseID { get; set; }
        public int LicenseClassID { get; set; }
        public string PersonFullName {  get; set; }
        public string LicenseClassName { get; set; }
        public int PassedTestCount {  get; set; }
        
        public clsApplication ApplicationInfo { get; set; }
        public clsLocalDrivingLicenese()
        {
            ApplicationID = -1;
            LocalDrivingLicenseID= -1;
            LicenseClassID= -1;
            _Mode=enMode.AddNew;
        }
        private clsLocalDrivingLicenese(int localDrivingLicenseID, int applicationID, int licenseClassID)
        {
            _Mode = enMode.Update;
            ApplicationID = applicationID;
            LocalDrivingLicenseID = localDrivingLicenseID;
            LicenseClassID = licenseClassID;
            ApplicationInfo = clsApplication.Find(ApplicationID);
        }
        private clsLocalDrivingLicenese(clsLocalDrivingLicenese localDrivingLicenese,string ClassName,string FullName,int PassedTest)
        {  _Mode = enMode.Update;
            ApplicationID = localDrivingLicenese.ApplicationID;
            LicenseClassID = localDrivingLicenese.LicenseClassID;
            LocalDrivingLicenseID=localDrivingLicenese.LocalDrivingLicenseID ;
            this.LicenseClassName = ClassName;
            this.PersonFullName= FullName;
            this.PassedTestCount = PassedTest;
            ApplicationInfo = clsApplication.Find(ApplicationID);
        }
        public static DataTable GetAllLocalDrivingLiceneses()
        {
            return clsLocalDrivingLiceneseData.GetAllLocalDrivingLicenseTable();
        }
        public static clsLocalDrivingLicenese Find(int localDrivingLicenseID)
        {
            int applicationID = -1;
            int licinenseClassID = -1;
            if (clsLocalDrivingLiceneseData.GetLocalDrivingInfoByID(localDrivingLicenseID, ref applicationID, ref licinenseClassID))
            {
                return new clsLocalDrivingLicenese(localDrivingLicenseID, applicationID, licinenseClassID);
            }
            return null;
        }
        public static clsLocalDrivingLicenese FindByApplicationID(int applicationID)
        {
            int localDrivingLicenseID = -1;
            int licinenseClassID = -1;
            
            if (clsLocalDrivingLiceneseData.GetLocalDrivingInfoByApplicationID(applicationID, ref localDrivingLicenseID, ref licinenseClassID))
            {
                return new clsLocalDrivingLicenese(localDrivingLicenseID, applicationID, licinenseClassID);
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
        public static clsLocalDrivingLicenese GetLocalDrivingIDByInfo(int LocalDrivingLicenseID)
        {
            string PersonFullName = "";
            string ClassName = "";
            int PassedTestCount = 0;
            
            if(clsLocalDrivingLiceneseData.GetLocalDrivingLicenseViewInfo(LocalDrivingLicenseID,ref ClassName,ref PersonFullName,ref PassedTestCount))
            {
                clsLocalDrivingLicenese localDrivingLicenese = clsLocalDrivingLicenese.Find(LocalDrivingLicenseID);
                return new clsLocalDrivingLicenese(localDrivingLicenese, ClassName, PersonFullName, PassedTestCount);
            }
            return null;
        }
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
            return clsLocalDrivingLiceneseData.DeleteLocalDrivingLicense(LocalID);
        }
        public static int GetAllTrialsAppointments(int LocalDrivingLicenseID,int TestTypeID)
        {
            return clsLocalDrivingLiceneseData.GetAllTrialsAppointment(LocalDrivingLicenseID,TestTypeID);
        }
        public bool Save()
        {
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
    }
}
