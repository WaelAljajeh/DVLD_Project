﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessSettings
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString;
    }
}
