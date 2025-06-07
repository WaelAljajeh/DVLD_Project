using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsApplication
    {
       public enum enMode { AddNew=0,Update=1};
        public enum enAPPStatus { New = 1, Cancelled = 2, Completed };
        public enMode _Mode;
        public clsPeople _PersonInfo { get; set; }
        
        public int ApplicationID { get; set;}
        public int ApplicationPersonID { get; set;}
        public DateTime ApplicationDate {  get; set;}
        public int ApplicationTypeID { get; set; }
        public clsApplicationTypes _ApplicationTypeInfo { get; set;}
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatus {  get; set; }

        public float PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public clsUsers _UserInfo { get; set; }
        public clsApplication()
        {
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = 0;
            ApplicationID = -1;
            ApplicationPersonID = -1;
            LastStatus=DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            _Mode=enMode.AddNew;
            _PersonInfo = null;
        }
        private clsApplication( int applicationID, int applicationPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatus, float paidFees, int createdByUserID)
        {
            _Mode = enMode.Update;
            ApplicationID = applicationID;
            ApplicationPersonID = applicationPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatus = lastStatus;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            _PersonInfo = clsPeople.Find(ApplicationPersonID);
            _UserInfo = clsUsers.Find(CreatedByUserID);
            _ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);
        }
        public static int GetApplicationIDByPersonIDAndStatus(int ApplicationPersonID, byte ApplicationStatus, int ApplicationTypeID)
        {
            return clsApplicationData.GetApplicationIDByPersonID(ApplicationPersonID,ApplicationStatus,ApplicationTypeID);
        }
        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            DateTime applicationDate = DateTime.MinValue; 
            int applicationTypeID = -1;
            byte applicationStatus = 0;
            //int applicationID = -1;
            int applicationPersonID = -1;
            DateTime LastStatus = DateTime.MinValue;
            float paidFees = 0;
            int createdByUserID = -1;
            if (clsApplicationData.GetApplicationByID(ApplicationID, ref applicationPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref LastStatus,ref paidFees, ref createdByUserID))
            {
                return new clsApplication(ApplicationID, applicationPersonID, applicationDate, applicationTypeID, applicationStatus, LastStatus, paidFees, createdByUserID);
            }
            return null;
        }
        bool AddNewApplication()
        {
            ApplicationID = clsApplicationData.AddNewApplication(ApplicationPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatus,PaidFees,CreatedByUserID);
            return ApplicationID != -1;
        }
        bool UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ApplicationID,ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatus, PaidFees, CreatedByUserID);
        }
       public bool DeleteApplication(int AppID)
        {
            return clsApplicationData.DeleteApplication(AppID);
        }
        public bool Cancel()
        {
            return clsApplicationData.UpdateApplicationStatus(ApplicationID, 2);   
        }
        public bool SetCompleted()
        {
            return clsApplicationData.UpdateApplicationStatus(ApplicationID, 3);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (AddNewApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return UpdateApplication();
            }
            return false;
        }
    }
  
}
