﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using InterfaceMapping;

namespace Mapping
{
    public class UserMapping:IMapping
    {
        public  string GetStoredProcedure()           
        {
            string StoredProcedure = "InsertUser";
            return StoredProcedure;
        }
            
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[1];
            return arParames;
        }
    }
}
