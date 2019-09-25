using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaApp
{
    public static class GlobalInfo
    {
        static Boolean dbType = false; //false = Oracle -- true = SQL Server

        public static void ChangeType()
        {
            dbType = !dbType;
        }

        public static Boolean GetDBType()
        {
            return dbType;
        }
   
    }
}