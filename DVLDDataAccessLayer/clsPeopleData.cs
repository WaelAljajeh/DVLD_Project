using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsPeopleData
    {
        public static bool GetPersonInfoByID(int PersonID,ref string NationalNo,ref string FirstName,ref string SecondName
  ,ref string ThirdName,ref string LastName,ref DateTime DateOfBirth,ref byte Gendor,ref string Address
            ,ref string Email,ref string PhoneNumber,ref int NationalityCountryID,ref string ImagePath)
        {
            bool IsFound=false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from People where PersonID=@PersonID";
            SqlCommand command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PersonID",PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = reader["Address"].ToString();
                    Email = reader["Email"].ToString();
                    PhoneNumber = reader["Phone"].ToString();
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"].ToString();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error "+ex.ToString());
            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static bool GetPersonInfoByNationalNo(string NationalNo,ref int PersonID, ref string FirstName, ref string SecondName
, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address
       , ref string Email, ref string PhoneNumber, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from People where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = reader["Address"].ToString();
                    Email = reader["Email"].ToString();
                    PhoneNumber = reader["Phone"].ToString();
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"].ToString();
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
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName
  , string ThirdName,  string LastName, DateTime DateOfBirth,  byte Gendor, string Address
            , string Email, string PhoneNumber, int NationalityCountryID,  string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"INSERT INTO People
           (NationalNo
           ,FirstName
           ,SecondName
           ,ThirdName
           ,LastName
           ,DateOfBirth
           ,Gendor
           ,Address
           ,Phone
           ,Email
           ,NationalityCountryID
           ,ImagePath)
     VALUES
           (@NationalNo
           ,@FirstName
           ,@SecondName
           ,@ThirdName
           ,@LastName
           ,@DateOfBirth
           ,@Gendor
           ,@Address
           ,@Phone
           ,@Email
           ,@NationalityCountryID
           ,@ImagePath)
            select SCOPE_IDENTITY();";
           SqlCommand command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("NationalNo", NationalNo);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("SecondName", SecondName);
            if(ThirdName!="")
            command.Parameters.AddWithValue("ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("ThirdName", DBNull.Value);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("Gendor", Gendor);
            command.Parameters.AddWithValue("Address", Address);
            command.Parameters.AddWithValue("Phone", PhoneNumber);
            if(Email!="")
            command.Parameters.AddWithValue("Email", Email);
            else
                command.Parameters.AddWithValue("Email", DBNull.Value);
            command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);
            if(ImagePath!="")
            command.Parameters.AddWithValue("ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("ImagePath", DBNull.Value);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error " + ex.ToString()); 
            }
            finally { connection.Close(); }
            return PersonID;

        }
        public static bool UpdatePerson(int PersonID,string NationalNo, string FirstName, string SecondName
  , string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address
            , string Email, string PhoneNumber, int NationalityCountryID, string ImagePath)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Update People
            Set NationalNo=@NationalNo
           ,FirstName=@FirstName
           ,SecondName=@SecondName
           ,ThirdName=@ThirdName
           ,LastName=@LastName
           ,DateOfBirth=@DateOfBirth
           ,Gendor=@Gendor
           ,Address=@Address
           ,Phone=@Phone
           ,Email=@Email
           ,NationalityCountryID=@NationalityCountryID
           ,ImagePath=@ImagePath               
            Where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("NationalNo", NationalNo);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("SecondName", SecondName);
            if(ThirdName!="")
            command.Parameters.AddWithValue("ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("ThirdName", DBNull.Value);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("Gendor", Gendor);
            command.Parameters.AddWithValue("Address", Address);
            command.Parameters.AddWithValue("Phone", PhoneNumber);
            if(Email!="")
            command.Parameters.AddWithValue("Email", Email);
            else
                command.Parameters.AddWithValue("Email", DBNull.Value);
            command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);
            if(ImagePath!="")
            command.Parameters.AddWithValue("ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("ImagePath", DBNull.Value);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine("Error " + ex.ToString()); }
            finally {  connection.Close(); }
            return result > 0;

        }
        public static bool DeletePerson(int PersonID)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = "Delete from People where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PersonID", PersonID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine("Error " + ex.ToString()); }
            finally { connection.Close(); }
            return result > 0;

        }
        public static bool IsPersonExistingByID(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from People Where PersonID=@PersonID";
            SqlCommand command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PersonID", PersonID);
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    IsFound = true;
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return IsFound;

        }
        public static bool IsPersonExistingByNationalNo(string NationalNo)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select * from People Where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("NationalNo", NationalNo);
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
        public static DataTable GetAllPeople()
        {
            DataTable result = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"SELECT [PersonID]
             ,[NationalNo]
             ,[FirstName]
             ,[SecondName]
             ,[ThirdName]
             ,[LastName]
             ,[DateOfBirth]
             ,Gendor=case Gendor
              when 0 then 'Male'
             when 1 then 'Female'
              end
             ,Countries.CountryName
            ,[Address]
            ,[Phone]
            ,[Email]

           FROM [dbo].[People] inner join Countries on Countries.CountryID=People.NationalityCountryID
 ";
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
    }
}
