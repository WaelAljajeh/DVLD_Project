using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace DVLDDataAccessLayer
{
    public class clsLocalDrivingLiceneseData
    {
        public static DataTable GetAllLocalDrivingLicenseTable()
        {
            
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select * from LocalDrivingLicenseApplications_View";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    result.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return result;
        }
        public static int AddNewLocalDrivingLicense(int ApplicationID,int LicenseClassID)
        {
            int LDL = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"INSERT INTO LocalDrivingLicenseApplications
           (
           ApplicationID
           ,LicenseClassID
          )
     VALUES
           (
           @ApplicationID
           ,@LicenseClassID
            )
            select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    LDL = InsertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return LDL;
        }
        public static bool UpdateLocalDrivingLicence(int LocalID,int LicenseClassID)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"UPDATE LocalDrivingLicenseApplications
   SET LicenseClassID = @LicenseClassID
 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine("Error " + ex.ToString()); }
            finally { connection.Close(); }
            return result > 0;
        }
        public static bool GetLocalDrivingInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationsID, ref int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from LocalDrivingLicenseApplications where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    LocalDrivingLicenseApplicationsID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static bool GetLocalDrivingInfoByID(int LocalDrivingLicenseApplicationsID,ref int ApplicationID,ref int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationsID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static bool GetLocalDrivingLicenseViewInfo(int LocalDrivingLicenseApplicationID,ref string ClassName, ref string FullName,ref int PassedTestCount)
        {
            bool IsFound=false ;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select * from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    ClassName = reader["ClassName"].ToString();
                    FullName = reader["FullName"].ToString();
                    PassedTestCount = (int)reader["PassedTestCount"];

                }
             }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static int GetActivateApplicationWithSameClass(int ApplicationPersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from Applications A inner join LocalDrivingLicenseApplications L on L.ApplicationID=A.ApplicationID 
      where A.ApplicantPersonID=@ApplicationPersonID and ApplicationTypeID=@ApplicationTypeID and (ApplicationStatus=1 or ApplicationStatus=3)  and LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationsID);
            command.Parameters.AddWithValue("ApplicationPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            //command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ApplicationID = (int)reader["ApplicationID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return ApplicationID;
        }
        public static bool DeleteLocalDrivingLicense(int LocalID)
        {
           
            
                int result = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
                string query = "Delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalID);
                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine("Error " + ex.ToString()); }
                finally { connection.Close(); }
                return result > 0;

            
        }
        public static int GetAllTrialsAppointment(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {

            int result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select Count(*) from LocalDrivingLicenseApplications L inner join TestAppointments T on L.LocalDrivingLicenseApplicationID=T.LocalDrivingLicenseApplicationID  inner join Tests Te on T.TestAppointmentID=Te.TestAppointmentID
           where L.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and T.TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                result = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return result;
        }
        public static bool IsPersonHaveApplicationWithSameClass(int ApplicationPersonID,int ApplicationTypeID,int LicenseClassID)
        {
            return GetActivateApplicationWithSameClass( ApplicationPersonID,  ApplicationTypeID, LicenseClassID) != -1;
        }
    }
}
