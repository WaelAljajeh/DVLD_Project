using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsUsers
    {
        enum enMode { Add = 0, Update = 1 }
        enMode _Mode;
        public int UserID { get; set; }

        public int PersonID {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUsers()
        {
            _Mode = enMode.Add;
            UserID = -1;
            Username = "";
            Password = "";
            IsActive = false;
            PersonID=-1;

        }
        private clsUsers(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
            _Mode = enMode.Update;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive= IsActive;
           
        }
        public static bool IsUserExistingByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistingByPersonID(PersonID);
        }
        bool AddNewUser()
        {
            UserID = clsUsersData.AddNewUser(PersonID, Username, Password
  ,IsActive);
            return UserID != -1;
        }
        bool UpdateUser()
        {
            return clsUsersData.UpdateUser(UserID,PersonID, Username, Password
  , IsActive);
        }
       public static clsUsers Find(int UserID)
        {
            string Username = "", Password = "" ;
            int PersonID = -1;
            bool IsActive = false;
            if (clsUsersData.GetUserInfoByID(UserID, ref PersonID, ref Username, ref Password
  , ref IsActive))
            {
                return new clsUsers(UserID,  PersonID, Username, Password
  , IsActive);
            }
            return null;
        }
       public static clsUsers Find(string Username,string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;
            if (clsUsersData.GetUserInfoByUsernameAndPassword(Username, Password,ref UserID, ref PersonID,
   ref IsActive))
            {
                return new clsUsers(UserID, PersonID, Username, Password
  , IsActive);
            }
            return null;
        }
       public static DataTable GetAllUsersTable()
        {
            return clsUsersData.GetAllUsers();
        }
        public static bool IsUserExisting(int UserID)
        {
            return clsUsersData.IsUserExistingByID(UserID);
        }
        public static bool IsUserExisting(string Username,string Password)
        {
          return clsUsersData.IsUserExistingByUsernameAndPassword(Username,Password);
        }
        public static bool Delete(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
        public static bool IsUserExisting(string Username)
        {
            return clsUsersData.IsUserExistingByUsername(Username);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return UpdateUser();
            }
            return false;
        }
    }
}
