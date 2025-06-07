using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsCountries
    {
        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
        public static string GetCountryName(int CountryID)
        {
            return clsCountryData.GetCountryName(CountryID);
        }
    }
}
