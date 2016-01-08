using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Mapping;
using InterfaceMapping;
using System.Web;
using System.Web.Hosting;

namespace Bll
{
    public  class CMSService
    {
        
        public static Message Insert(string DtoName,string JsonString)
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
        public static Message Delete(string DtoName, string table, string strWhere)
        {
            Message msg = new Message();
            IMapping Mapping = MappingFactory.CreatMapping(DtoName);
            msg.MessageInfo = CommonDal.Delete(table, strWhere);
            return msg;
        
        }

        public static Message Update(string DtoName, string JsonString)
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

        public static int GetSomeValue(string DtoName, string table, string strWhere,string thevalue)
        {
            int count = 0;
            count = CommonDal.GetSomeValueByWhere(table, strWhere,thevalue);
            return count;

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

        public static Message UpdateFieldOneByOne(string DtoName, string table, string strWhere, string columnname, string columnvalue)
        {
            Message msg = new Message();
            IMapping Mapping = MappingFactory.CreatMapping(DtoName);
            msg.MessageInfo = CommonDal.SetFiledOneByOne(table, strWhere,columnname,columnvalue);
            return msg;
        
        }

        public static string Uploadfiles(string folder, HttpPostedFileBase file)
        {
            string UploadPath = "Upload";

            //提供平台特定的替换字符，该替换字符用于在反映分层文件系统组织的路径字符串中分隔目录级别
            var sep = Path.AltDirectorySeparatorChar.ToString();
            //指定为根目录
            var root = "~" + sep + UploadPath + sep;
            //拼接成路径
            var path = root + folder + sep;
            //找到这个路径
            var phicyPath = HostingEnvironment.MapPath(path);
            //判断是否存在，不存在创建一个
            if (!Directory.Exists(phicyPath))
            {
                Directory.CreateDirectory(phicyPath);
            }

            string extension = file.FileName.Substring(file.FileName.LastIndexOf('.'));

            string filename = CommonTools.ToUnixTime(System.DateTime.Now).ToString() + CommonTools.getRandomNumber() +
                              extension;


            file.SaveAs(phicyPath + filename);

            string fileuploadpath = "/" + UploadPath + "/" + folder + "/" + filename;

            return fileuploadpath;

        }

    }
}
