using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Mapping;
using InterfaceMapping;

namespace Bll
{
    public  class CMSService
    {
        public static Message InsertDto(string DtoName,string JsonString)
        {
           
            Message msg = new Message();
            SqlParameter[] arParames = null;
            string StoredProcedure = "";
            IMapping Mapping = MappingFactory.CreatMapping(DtoName);
           
            
            arParames = Mapping.JsonStringToSqlParameter(JsonString);
            StoredProcedure=Mapping.GetStoredProcedure();
           




            msg.MessageInfo = CommonDal.Insert(arParames,StoredProcedure);
            
            return msg;

        }

    }
}
