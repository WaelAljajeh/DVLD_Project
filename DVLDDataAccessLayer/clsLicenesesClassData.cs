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
   public class clsLicenesesClassData
    {
        public static DataTable GetAllLicensesClassesName()
        {
			DataTable result = new DataTable();
			SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
			string query = @"Select ClassName from LicenseClasses";
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
        public static string GetClassNameByID(int ID)
        {
            string result = "";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select ClassName from LicenseClasses where LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LicenseClassID",ID);

            try
            {
                connection.Open();
                result = command.ExecuteScalar().ToString();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return result;
        }
        public static int GetMinimumAgeByID(int ID)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select MinimumAllowedAge from LicenseClasses where LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LicenseClassID", ID);

            try
            {
                connection.Open();
                result = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return result;
        }
        public static float GetPaidFeesForClassByID(int ID)
        {
            float result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select ClassFees from LicenseClasses where LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LicenseClassID", ID);

            try
            {
                connection.Open();
                result = Convert.ToSingle(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return result;
        }
        public static int GetValidityLength(int ID)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
            string query = @"Select DefaultValidityLength from LicenseClasses where LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LicenseClassID", ID);

            try
            {
                connection.Open();
                result = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString());
            }
            finally { connection.Close(); }
            return result;
        }
        public static bool GetLicenseClassInfoByID(int LicenseClassID,
           ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge,
           ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID,
            ref string ClassDescription, ref byte MinimumAllowedAge,
           ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);

            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
