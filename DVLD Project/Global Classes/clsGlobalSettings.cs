using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDBussinessLayer;
using System.IO;

namespace DVLD_Project
{
    public class clsGlobalSettings
    {
       public static clsUsers CuurentUser = clsUsers.Find(-1);
        public static bool GetStoredCredinality(ref string Username, ref string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string UserNameValue = "Username";
            string PasswordValue = "Password";
            try
            {
                Username = Registry.GetValue(KeyPath, UserNameValue, null) as string;
                Password = Registry.GetValue(KeyPath, PasswordValue, null) as string;
                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                    return false;

            }
            catch(Exception e)
            {
                return false;
            }
            return true;
            //string FilePath=Directory.GetCurrentDirectory()+ "/UserInfoForLogin.txt";
            //if (File.Exists(FilePath))
            //{
            //    string strFileInfo = File.ReadAllText(FilePath);
            //    string[] UserInformation = strFileInfo.Split('#');
            //    if (UserInformation.Length > 0)
            //    {
            //        Username = UserInformation[0];
            //        Password = UserInformation[1];

            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //return false;
        }
        public static bool RememberUsernameandPassword(string Username,string Password)
        {
            string KeyPath= @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string UserNameValue = "Username";
            string PasswordValue = "Password";
            try
            {
                Registry.SetValue(KeyPath, UserNameValue, Username);
                Registry.SetValue(KeyPath, PasswordValue, Password);

            }
            catch(Exception e) 
            {
                Console.WriteLine("An Error occured " + e.ToString());
                return false;
            }
            //string FilePath = Directory.GetCurrentDirectory() + "/UserInfoForLogin.txt";
            //if (String.IsNullOrEmpty(Username) && String.IsNullOrEmpty(Password))
            //    return false;
            //File.WriteAllText(FilePath, Username + "#" + Password);
            return true;
        }
    }
  
}
