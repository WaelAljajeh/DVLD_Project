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
    }
}
