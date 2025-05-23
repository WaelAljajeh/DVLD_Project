using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBussinessLayer
{
    public class clsUtil
    {
       public enum enApplicationType { New_License = 1, Renew = 2, Replace_Lost_License = 3, Replace_Damaged_License = 4, Realease_Detain_License = 5, International_Licenese = 6, Retake_Test = 7 };
        public static enApplicationType ApplicationType;
    }
}
