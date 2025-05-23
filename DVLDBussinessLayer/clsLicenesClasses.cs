using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsLicenesClasses
    {
        public static DataTable GetAllLiceneseClassesName()
        {
            return clsLicenesesClassData.GetAllLicensesClassesName();
        }
        public static string GetClassNameByID(int ID)
        {
            return clsLicenesesClassData.GetClassNameByID(ID);
        }
        public static float GetClassFeesByID(int ID)
        {
            return  clsLicenesesClassData.GetPaidFeesForClassByID(ID);
        }
        public static int GetMinimumAgeByID(int ID)
        {
            return clsLicenesesClassData.GetMinimumAgeByID(ID);
        }
        public static int GetValidityLength(int ID)
        {
            return clsLicenesesClassData.GetValidityLength(ID);
        }
    }
}
