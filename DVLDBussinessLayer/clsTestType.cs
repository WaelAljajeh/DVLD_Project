using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsTestType
    {
        public enum enTestType { VisionTest=1,WrittenTest=2,StreetTest=3};
        public static enTestType TestType;
        public enTestType TestID { get; set; }
        public string TestTypeTitle { get; set; }
        public float TestFees { get; set; }
        public string TestDescreption {  get; set; }
        private clsTestType(enTestType ID, string Title,string descreption, float fees)
        {
            TestID = ID;
            TestTypeTitle = Title;
            TestFees = fees;
            TestDescreption = descreption;
        }
        public clsTestType()
        {
            TestID = new enTestType();
            TestFees = 0;
            TestDescreption = string.Empty;
            TestTypeTitle=string.Empty;
        }

        public static clsTestType Find(enTestType ID)
        {
            string title = ""; float fees = 0;
            string descreption = "";
            if (clsTestTypesData.GetTestType((int)ID, ref title,ref descreption, ref fees))
            {
                return new clsTestType(ID, title,descreption, fees);
            }
            return null;
        }
        public static float GetTestTypeFees(int ID)
        {
            return clsTestTypesData.GetTestTypeFees(ID);
        }
        public static DataTable GetAllAppTypes()
        {
            return clsTestTypesData.GetAllTestTypes();

        }
        public bool UpdateInfoOfTypes()
        {
            return clsTestTypesData.UpdateTestType((int)TestID, TestTypeTitle, TestDescreption, TestFees);
        }
    }
}
