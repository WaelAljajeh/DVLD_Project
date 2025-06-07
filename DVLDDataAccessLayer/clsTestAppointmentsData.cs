using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class clsTestAppointmentsData
    {
        public static int AddNewTestAppointment(int TestTypeID,int LocalDrivingLicenseApplicationID,DateTime AppointmentDate,float PaidFees, int CreatedByUserID,bool IsLocked,int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"INSERT INTO TestAppointments
           (TestTypeID
           ,LocalDrivingLicenseApplicationID
           ,AppointmentDate
           ,PaidFees
           ,CreatedByUserID
           ,IsLocked
           ,RetakeTestApplicationID)
     VALUES
           (@TestTypeID
           ,@LocalDrivingLicenseApplicationID
           ,@AppointmentDate
           ,@PaidFees
           ,@CreatedByUserID
           ,@IsLocked
           ,@RetakeTestApplicationID)
            select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("PaidFees", PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("IsLocked", IsLocked);
            if(RetakeTestApplicationID!=-1)
            command.Parameters.AddWithValue("RetakeTestApplicationID", RetakeTestApplicationID);
            else
                command.Parameters.AddWithValue("RetakeTestApplicationID", DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    TestAppointmentID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return TestAppointmentID;
            
        }
        public static DataTable GetAllTestAppointments(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {

            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select TestAppointmentID,AppointmentDate,PaidFees,IsLocked from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
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
        public static bool IsThereAnActiveAppointment(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select IsLocked from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID  and IsLocked=0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    IsFound = true;
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
        public static bool IsThereAnActiveAppointment(int TestAppointmentID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select IsLocked from TestAppointments where TestAppointmentID=@TestAppointmentID and IsLocked=0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    IsFound = true;
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
        public static bool GetTestAppointmentInfo(int TestAppointmentID,ref int TestTypeID,ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,ref float PaidFees,ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select * from TestAppointments where TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if(RetakeTestApplicationID!=null)
                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    else
                        RetakeTestApplicationID = -1;



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

        public static bool UpdateTestAppointmentInfo(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int result = 0;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Update TestAppointments
           Set TestTypeID=@TestTypeID
           , LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
           , AppointmentDate=@AppointmentDate
           , PaidFees=@PaidFees
           , CreatedByUserID=@CreatedByUserID
           , IsLocked=@IsLocked
           , RetakeTestApplicationID=@RetakeTestApplicationID
           where TestAppointmentID=@TestAppointmentID";
    ;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("PaidFees", PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("IsLocked", IsLocked);
            if (RetakeTestApplicationID != -1)
                command.Parameters.AddWithValue("RetakeTestApplicationID", RetakeTestApplicationID);
            else
                command.Parameters.AddWithValue("RetakeTestApplicationID", DBNull.Value);

            try
            {
                connection.Open();
                 result = command.ExecuteNonQuery();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return result>0;
        }
        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID,int TestTypeID, ref int TestAppointmentID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"select top 1 * from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID order by TestAppointmentID desc";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if (RetakeTestApplicationID != null)
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    else
                        RetakeTestApplicationID = -1;



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

    }
    
}
