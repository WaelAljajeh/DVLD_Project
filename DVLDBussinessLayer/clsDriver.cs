using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsDriver
    {
       public int DriverID {  get; set; }
       public int PerosnID {  get; set; }
       public int CreatedByUserID {  get; set; }
       public DateTime CreatedDate {  get; set; }
       
        public clsPeople PersonInfo { get; }
       public clsDriver() 
       {
            DriverID= -1;
            PerosnID= -1;
            CreatedByUserID= -1;
            CreatedDate=DateTime.Now;
            PersonInfo=null;
       }
       private clsDriver(int driverID, int perosnID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PerosnID = perosnID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            PersonInfo = clsPeople.Find(PerosnID);
        }
        public static bool IsDriverExisting(int DriverID)
        {
            return clsDriverData.IsDriverExisting(DriverID);
        }
        public bool AddDriver()
        {
            DriverID=clsDriverData.AddNewDriver(PerosnID,CreatedByUserID,CreatedDate);
            return DriverID != -1;
        }
        public static clsDriver Find(int DriverID) 
        {
            int PersonID = -1,CreatedByUserID=-1;
            DateTime CreatedDate=DateTime.MinValue;
            if(clsDriverData.GetDriverInfoBy(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate))
            {
                return new clsDriver(DriverID,PersonID,CreatedByUserID,CreatedDate);
            }
            return null;

        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;

        }
        public static bool IsDriverExistingByPersonID(int PersonID)
        {
            return clsDriverData.IsDriverExistingByPersonID(PersonID);
        }
        public static DataTable GetDriversTable()
        {
            return clsDriverData.GetAllDriversInfo();
        }
    }
}
