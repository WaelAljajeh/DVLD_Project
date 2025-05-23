using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsApplicationTypes
    {
        public int AppID {  get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationFees { get; set; }
        private clsApplicationTypes(int ID,string Title,float fees) {
            AppID=ID;
            ApplicationTypeTitle=Title;
            ApplicationFees=fees;
        }
        public clsApplicationTypes()
        {
            AppID = -1;
            ApplicationFees = 0;
            ApplicationTypeTitle= string.Empty;
        }
        public static string GetApplicationTypeTitleByID(int AppTypeID)
        {
            return  clsApplicationTypesData.GetApplicationTypeName(AppTypeID);
        }
        public static clsApplicationTypes Find(int ID)
        {
            string title = "";float fees =0;
            if(clsApplicationTypesData.GetApplicationType(ID, ref title, ref fees))
            {
                return new clsApplicationTypes(ID,title,fees);
            }
            return null;
        }
        public static DataTable GetAllAppTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();

        }
        public bool UpdateInfoOfTypes()
        {
            return  clsApplicationTypesData.UpdateApplicationTypes(AppID, ApplicationTypeTitle, ApplicationFees);
        }
        public static float GetApplicationTypePaidFees(int AppTypeID)
        {
            return clsApplicationTypesData.ApplicationTypePaidFees(AppTypeID);
        }
    }
}
