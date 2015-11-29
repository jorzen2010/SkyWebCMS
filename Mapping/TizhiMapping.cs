using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using InterfaceMapping;
using Common;
using Dto;

namespace Mapping
{
    public class TizhiMapping: IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateTizhi";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateTizhi";
            }

            return StoredProcedure;
        }           
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[15];
            TizhiDto tizhiDto = JsonHelper.JsonDeserializeBySingleData<TizhiDto>(jsonString);

            arParames[0] = new SqlParameter("@TizhiId", SqlDbType.Int);
            arParames[0].Value = tizhiDto.TizhiId;

            arParames[1] = new SqlParameter("@TizhiYangxu", SqlDbType.VarChar, 50);
            arParames[1].Value = tizhiDto.TizhiYangxu;

            arParames[2] = new SqlParameter("@TizhiYinxu", SqlDbType.VarChar, 50);
            arParames[2].Value = tizhiDto.TizhiYinxu;

            arParames[3] = new SqlParameter("@TizhiQixu", SqlDbType.VarChar, 50);
            arParames[3].Value = tizhiDto.TizhiQixu;

            arParames[4] = new SqlParameter("@TizhiTanshi", SqlDbType.VarChar, 50);
            arParames[4].Value = tizhiDto.TizhiTanshi;

            arParames[5] = new SqlParameter("@TizhiShire", SqlDbType.VarChar, 50);
            arParames[5].Value = tizhiDto.TizhiShire;

            arParames[6] = new SqlParameter("@TizhiXueyu", SqlDbType.VarChar, 50);
            arParames[6].Value = tizhiDto.TizhiXueyu;

            arParames[7] = new SqlParameter("@TizhiQiyu", SqlDbType.VarChar, 50);
            arParames[7].Value = tizhiDto.TizhiQiyu;

            arParames[8] = new SqlParameter("@TizhiTebing", SqlDbType.VarChar, 50);
            arParames[8].Value = tizhiDto.TizhiTebing;

            arParames[9] = new SqlParameter("@TizhiPinghe ", SqlDbType.VarChar, 50);
            arParames[9].Value = tizhiDto.TizhiPinghe;

            arParames[10] = new SqlParameter("@TizhiResult ", SqlDbType.VarChar, 500);
            arParames[10].Value = tizhiDto.TizhiResult;

            arParames[11] = new SqlParameter("@TizhiTime ", SqlDbType.DateTime);
            arParames[11].Value = tizhiDto.TizhiTime;

            arParames[12] = new SqlParameter("@TizhiCustomerId ", SqlDbType.Int);
            arParames[12].Value = tizhiDto.TizhiCustomerId;

            arParames[13] = new SqlParameter("@TizhiNumber ", SqlDbType.VarChar, 500);
            arParames[13].Value = tizhiDto.TizhiNumber;

            arParames[14] = new SqlParameter("@TizhiImg ", SqlDbType.VarChar, 500);
            arParames[14].Value = tizhiDto.TizhiImg;

 



            return arParames;
        }
        public static TizhiDto getDTO(DataRow dr) 
        {

                TizhiDto tizhiDto = new TizhiDto();

                tizhiDto.TizhiId = int.Parse(dr["TizhiId"].ToString());
                tizhiDto.TizhiYangxu = dr["TizhiYangxu"].ToString();
                tizhiDto.TizhiYinxu = dr["TizhiYinxu"].ToString();
                tizhiDto.TizhiQixu = dr["TizhiQixu"].ToString();
                tizhiDto.TizhiTanshi = dr["TizhiTanshi"].ToString();
                tizhiDto.TizhiShire = dr["TizhiShire"].ToString();
                tizhiDto.TizhiQiyu = dr["TizhiQiyu"].ToString();
                tizhiDto.TizhiXueyu = dr["TizhiXueyu"].ToString();
                tizhiDto.TizhiTebing = dr["TizhiTebing"].ToString();
                tizhiDto.TizhiPinghe = dr["TizhiPinghe"].ToString();
                tizhiDto.TizhiResult = dr["TizhiResult"].ToString();
                tizhiDto.TizhiTime = DateTime.Parse(dr["TizhiTime"].ToString());
                tizhiDto.TizhiCustomerId = int.Parse(dr["TizhiCustomerId"].ToString());
                tizhiDto.TizhiNumber = dr["TizhiNumber"].ToString();
                tizhiDto.TizhiImg = dr["TizhiImg"].ToString();
                return tizhiDto;
        }

      
        
    }
}
