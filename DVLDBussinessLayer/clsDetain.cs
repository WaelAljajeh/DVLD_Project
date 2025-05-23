using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLDBussinessLayer
{
    public class clsDetain
    {
        enum enMode { AddNew=1,Update=2}
        enMode _Mode;
        public int  DetainID { get; set; }
        public int  LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int   CreatedByUserID {  get; set; }
        public bool   IsReleased {  get; set; }
        public DateTime ReleaseDate {  get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
        
        public static DataTable GetDetainedLicenseList()
        {
            return clsDetainData.GetDetainedList();
        }
        public clsDetain() 
        {
            _Mode = enMode.AddNew;
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

        }
        private clsDetain(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            _Mode = enMode.Update;
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
        }
        bool AddNewDetainLicense()
        {
            DetainID = clsDetainData.AddNewDetainLicense(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID);
            return DetainID != -1;
        }
        bool UpdateDetainLicense()
        {
            return clsDetainData.UpdateDetainedLicenseInformation(DetainID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            
        }
        public static bool IsDetainExistingByDetianID(int DetianID)
        {
            return  clsDetainData.IsDetainLicenseExistingByDetainID(DetianID);
        }
        public static bool IsDetainExistingByLicenseID(int LicenseID)
        {
            return clsDetainData.IsDetainLicenseExistingByLicenseID(LicenseID);
        }
        public static bool IsDetainExistingByLicenseID(int LicenseID,bool IsRealsed)
        {
            return clsDetainData.IsDetainLicenseExistingByLicenseID(LicenseID, IsRealsed);
        }
        public static clsDetain FindByDetianID(int DetainID)
        {
            int licenseID = -1, createdByUserID = -1, releaseApplicationID = -1, releasedByUserID = -1;
            DateTime detainDate=DateTime.MinValue, releaseDate = DateTime.MinValue;
            float fineFees=0;
            bool isReleased = false;
            if(clsDetainData.GetDetainLicenseByDetainID(DetainID,ref licenseID,ref detainDate,ref fineFees,ref createdByUserID,ref isReleased,ref releaseDate,ref releasedByUserID,ref releaseApplicationID))
            {
                return new clsDetain(DetainID, licenseID, detainDate,fineFees,createdByUserID,isReleased,releaseDate,releasedByUserID,releaseApplicationID);
            }
            return null;

        }
        public static clsDetain FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, createdByUserID = -1, releaseApplicationID = -1, releasedByUserID = -1;
            DateTime detainDate = DateTime.MinValue, releaseDate = DateTime.MinValue;
            float fineFees = 0;
            bool isReleased = false;
            if (clsDetainData.GetDetainLicenseByLicenseID(LicenseID, ref DetainID, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetain(DetainID, LicenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            return null;

        }
        public static clsDetain FindNotRealsedDetainLicenseByLicenseID(int LicenseID)
        {
            int DetainID = -1, createdByUserID = -1, releaseApplicationID = -1, releasedByUserID = -1;
            DateTime detainDate = DateTime.MinValue, releaseDate = DateTime.MinValue;
            float fineFees = 0;
            bool isReleased = false;
            if (clsDetainData.GetNotReleaseDetainLicenseByLicenseID(LicenseID, ref DetainID, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetain(DetainID, LicenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            return null;

        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (AddNewDetainLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return UpdateDetainLicense();
            }
            return false;
        }
    }
}
