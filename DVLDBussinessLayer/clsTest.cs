using DataAccessLayer;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBussinessLayer
{
    public class clsTest
    {
        public int TestID {  get; set; }
        public int TestAppointmentID {  get; set; }
        public bool TestResult {  get; set; }
        public string Notes {  get; set; }
        public int CreatedByUserID { get; set; }
        public bool AddNewTest()
        {
            TestID = clsTestData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return TestID!=-1;
        }
        public static bool IsTestPassed(int LocalDrivingLicenseID,int TestTypeID)
        {
            return clsTestData.IsTestPassed(LocalDrivingLicenseID, TestTypeID);
        }
        public static bool IsTestPassed(int TestAppointmentID)
        {
            return clsTestData.IsTestPassed(TestAppointmentID);
        }
    
    }
}
