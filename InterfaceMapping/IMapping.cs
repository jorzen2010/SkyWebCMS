using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace InterfaceMapping
{
    public interface IMapping
    {
        SqlParameter[] JsonStringToSqlParameter(string jsonString);
        string GetStoredProcedure(string actionName);


      

    }
}
