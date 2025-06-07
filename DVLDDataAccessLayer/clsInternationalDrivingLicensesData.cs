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
    public class clsInternationalDrivingLicensesData
    {
      public static int AddNewInternationalLicense(int ApplicationID,int DriverID,int IssuedUsingLocalLicenseID,DateTime IssueDate,DateTime ExpirationDate,bool IsActive,int CreatedByUserID)
      {
            int InternationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query =


                @"Update InternationalLicenses
                Set IsActive=0
                where DriverID=@DriverID;
            
             INSERT INTO InternationalLicenses
           (ApplicationID
           ,DriverID
           ,IssuedUsingLocalLicenseID
           ,IssueDate
           ,ExpirationDate
           ,IsActive
           ,CreatedByUserID)
     VALUES
           (@ApplicationID
           ,@DriverID
           ,@IssuedUsingLocalLicenseID
           ,@IssueDate
           ,@ExpirationDate
           ,@IsActive
           ,@CreatedByUserID)
          select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("DriverID", DriverID);
            command.Parameters.AddWithValue("IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("IssueDate", IssueDate);
            command.Parameters.AddWithValue("ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("IsActive", IsActive);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    InternationID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return InternationID;

        }
        public static DataTable GetInternationalList()
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select InternationalLicenseID,ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive 
             from InternationalLicenses";
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
        public static DataTable GetInternationalListPerPerson(int ApplicantPersonID)
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select I.InternationalLicenseID,I.ApplicationID,I.DriverID,I.IssuedUsingLocalLicenseID,I.IssueDate,I.ExpirationDate,I.IsActive 
             from InternationalLicenses I inner join Applications A on A.ApplicationID=I.ApplicationID where A.ApplicantPersonID=@ApplicantPersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicantPersonID", ApplicantPersonID);

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
        public static bool GetInternationalLicesneInfoByID(int InternationalLicenseID,ref int ApplicationID,ref int DriverID,ref int IssuedUsingLocalLicenseID,ref DateTime IssueDate,ref DateTime ExpirationDate,ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];

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
        public static bool GetInternationalLicesneInfoByDriverID(int DriverID,ref int InternationalLicenseID, ref int ApplicationID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from InternationalLicenses where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];

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
        public static bool GetActiveInternationalLicesneInfoByDriverID(int DriverID, ref int InternationalLicenseID, ref int ApplicationID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate,  bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from InternationalLicenses where DriverID=@DriverID and IsActive=@IsActive";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("DriverID", DriverID);
            command.Parameters.AddWithValue("IsActive", IsActive);
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                   

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
        public static bool IsInternationalLicenseExisting(int InternationalLicenseID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("InternationalLicenseID", InternationalLicenseID);

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
        public static bool IsInternationalLicenseExistingByAppID(int ApplicationID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from InternationalLicenses where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
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
        public static bool IsInternationalLicenseExistingByPerosnID(int ApplicationPersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from InternationalLicenses IL inner join Applications A on IL.ApplicationID=A.ApplicationID where A.ApplicantPersonID=@ApplicationPersonID and IL.IsActive=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ApplicationPersonID", ApplicationPersonID);
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
        public static bool IsInternationalLicenseExistingByLocalLicenseID(int IssuedUsingLocalLicenseID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from InternationalLicenses where IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
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
        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
        
                int result = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
                string query = @"UPDATE InternationalLicenses
   SET ApplicationID = @ApplicationID
      ,DriverID = @DriverID
      ,IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
      ,IssueDate = @IssueDate
      ,ExpirationDate= @ExpirationDate
      ,IsActive = @IsActive
      ,CreatedByUserID = @CreatedByUserID
 WHERE InternationalLicenseID=@InternationalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("DriverID", DriverID);
            command.Parameters.AddWithValue("IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("IssueDate", IssueDate);
            command.Parameters.AddWithValue("ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("IsActive", IsActive);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
            try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine("Error " + ex.ToString()); }
                finally { connection.Close(); }
                return result > 0;
            }
        
    }
}
