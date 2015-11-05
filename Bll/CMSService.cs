using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StoredProcedure=Mapping.GetStoredProcedure("Insert");
            msg.MessageInfo = CommonDal.Insert(arParames,StoredProcedure);
            
            return msg;

        }

        public static Message UpdateDto(string DtoName, string JsonString)
        {
            Message msg = new Message();
            SqlParameter[] arParames = null;
            string StoredProcedure = "";


            IMapping Mapping = MappingFactory.CreatMapping(DtoName);

            arParames = Mapping.JsonStringToSqlParameter(JsonString);
            StoredProcedure = Mapping.GetStoredProcedure("Update");
            msg.MessageInfo = CommonDal.Update(arParames, StoredProcedure);

            return msg;
        }
        public static Pager SelectAll(string DtoName, Pager pager)
        {
            
            IMapping Mapping = MappingFactory.CreatMapping(DtoName);

            pager=CommonDal.GetPager(pager);
            return pager; 
        }

        public static DataTable SelectOne(string DtoName,string table,string strWhere)
        {
            IMapping Mapping = MappingFactory.CreatMapping(DtoName);
            DataTable dt = CommonDal.GetOneByWhere(table, strWhere);

            return dt;
        }
        public static DataTable SelectSome(string DtoName, string table, string strWhere)
        {
            IMapping Mapping = MappingFactory.CreatMapping(DtoName);
            DataTable dt = CommonDal.GetSomeByWhere(table, strWhere);

            return dt;
        }

    }
}
