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
    public class ChufangMapping : IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateChufang";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateChufang";
            }

            return StoredProcedure;
        }
        public SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[7];
            ChufangDto dto = JsonHelper.JsonDeserializeBySingleData<ChufangDto>(jsonString);

            arParames[0] = new SqlParameter("@ChufangId", SqlDbType.Int);
            arParames[0].Value = dto.ChufangId;

            arParames[1] = new SqlParameter("@ChufangCustomerId", SqlDbType.Int);
            arParames[1].Value = dto.ChufangCustomerId;

            arParames[2] = new SqlParameter("@ChufangZhenduan", SqlDbType.Text);
            arParames[2].Value = dto.ChufangZhenduan;

            arParames[3] = new SqlParameter("@ChufangChuzhi", SqlDbType.Text);
            arParames[3].Value = dto.ChufangChuzhi;

            arParames[4] = new SqlParameter("@ChufangYongyao", SqlDbType.Text);
            arParames[4].Value = dto.ChufangYongyao;

            arParames[5] = new SqlParameter("@ChufangTime", SqlDbType.DateTime);
            arParames[5].Value = dto.ChufangTime;

            arParames[6] = new SqlParameter("@ChufangImg", SqlDbType.VarChar,500);
            arParames[6].Value = dto.ChufangImg;

            return arParames;
        }
        public static ChufangDto getDTO(DataRow dr)
        {

            ChufangDto dto = new ChufangDto();

            dto.ChufangId = int.Parse(dr["ChufangId"].ToString());

            dto.ChufangCustomerId = int.Parse(dr["ChufangCustomerId"].ToString());
            dto.ChufangImg = dr["ChufangImg"].ToString();
            dto.ChufangZhenduan = dr["ChufangZhenduan"].ToString();
            dto.ChufangChuzhi = dr["ChufangChuzhi"].ToString();
            dto.ChufangYongyao = dr["ChufangYongyao"].ToString();
            dto.ChufangTime = DateTime.Parse(dr["ChufangTime"].ToString());



            return dto;
        }



    }
}
