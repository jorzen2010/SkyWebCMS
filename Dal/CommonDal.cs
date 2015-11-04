using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace Dal
{
    public class CommonDal
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionStrings"];

        #region 删除一个对象
        public static void DeleteObject(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "deleteModelByWhere", arParames);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }

        }
        #endregion

        #region 更新一个对象的一个字段
        public static void SetModelBitByAjax(string table, string strwhere, string columnname, string columnvalue)
        {



            SqlParameter[] arParames = new SqlParameter[4];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;

            arParames[2] = new SqlParameter("@columnname ", SqlDbType.VarChar, 200);
            arParames[2].Value = columnname;

            arParames[3] = new SqlParameter("@columnvalue ", SqlDbType.VarChar, 200);
            arParames[3].Value = columnvalue;
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(myconn, CommandType.StoredProcedure, "setModelBitByAjax", arParames);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }

        }
        #endregion setBitFiledByAjax

        #region 删除一个Editor对象DTO
        public static void DeleteOneDto(string table, string strwhere)
        {


            SqlParameter[] arParames = new SqlParameter[2];
            arParames[0] = new SqlParameter("@table ", SqlDbType.VarChar, 200);
            arParames[0].Value = table;

            arParames[1] = new SqlParameter("@Where ", SqlDbType.VarChar, 8000);
            arParames[1].Value = strwhere;
            SqlConnection myconn = new SqlConnection(CommonDal.ConnectionString);
            try
            {
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure, "deleteModelByWhere", arParames);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }

        }
        #endregion

        public static string Insert(SqlParameter[] arParames, string StoredProcedure)
        {


            string msg = "插入操作成功";
            SqlConnection myconn = null;

            
            try
            {    myconn = new SqlConnection(CommonDal.ConnectionString);
                SqlHelper.ExecuteNonQuery(myconn, CommandType.StoredProcedure,StoredProcedure, arParames);
            }
            catch (SqlException ex)
            {
                msg = "数据库错误:"+ex.Message;
                throw ex;
                
            }
            finally
            {

                myconn.Close();
                myconn.Dispose();
            }

            return msg;

        }
    }
}
