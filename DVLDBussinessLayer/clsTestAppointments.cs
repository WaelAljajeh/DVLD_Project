using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsTestAppointments
    {
        enum enMode { AddNew=1,Update=2};
        enMode _Mode;
        public int TestAppointmentID {  get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public DateTime AppointmentDate {  get; set; }

        public float PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public bool IsLocked {  get; set; }
        public int RetakeTestApplicationID {  get; set; }
        public clsTestAppointments() 
        {
            _Mode = enMode.AddNew;
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID=-1;
            AppointmentDate=DateTime.MinValue;
            PaidFees=0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID= -1;

        }
        public static DataTable GetAllApointmentForThisApp(int LocalDrivingLicenseID, int TestTypeID)
        {
            return clsTestAppointmentsData.GetAllTestAppointments(LocalDrivingLicenseID, TestTypeID);
        }
        private clsTestAppointments(int TestAppointmentID,int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
             _Mode = enMode.Update;
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees= PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked= IsLocked;
            this.RetakeTestApplicationID=RetakeTestApplicationID;
        }
        bool AddNewTestAppointMent()
        {
            TestAppointmentID=clsTestAppointmentsData.AddNewTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees,  CreatedByUserID,  IsLocked, RetakeTestApplicationID);
            return TestAppointmentID != -1;
        }
        bool UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointmentInfo(TestAppointmentID,TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }
        public static bool IsThereActiveAppointment(int LocalDrivingLicenseID,int TestTypeID)
        {
            return clsTestAppointmentsData.IsThereAnActiveAppointment(LocalDrivingLicenseID,TestTypeID);
        }
        public static bool IsThereActiveAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsData.IsThereAnActiveAppointment(TestAppointmentID);
        }
        public static clsTestAppointments Find(int TestAppointmentID)
        {
            int TestTypeID=-1;
            int LocalDrivingLicenseApplicationID=-1;
            DateTime AppointmentDate=DateTime.MinValue;
            float PaidFees=0;
            int CreatedByUserID=-1;
            bool IsLocked=false;
            int RetakeTestApplicationID=-1;
            if (clsTestAppointmentsData.GetTestAppointmentInfo(TestAppointmentID, ref TestTypeID,ref LocalDrivingLicenseApplicationID,ref AppointmentDate,ref PaidFees,ref CreatedByUserID,ref IsLocked,ref RetakeTestApplicationID))
            {
                return new clsTestAppointments(TestAppointmentID,TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID);
            }
            return null;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewTestAppointMent())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return UpdateTestAppointment();
            }
            return false;
        }
       
    }
}
