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
    public class FankuiMapping : IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateFankui";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateFankui";
            }

            return StoredProcedure;
        }
        public SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[9];
            FankuiDto dto = JsonHelper.JsonDeserializeBySingleData<FankuiDto>(jsonString);

            arParames[0] = new SqlParameter("@FankuiId", SqlDbType.Int);
            arParames[0].Value = dto.FankuiId;

            arParames[1] = new SqlParameter("@FankuiCustomerId", SqlDbType.Int);
            arParames[1].Value = dto.FankuiCustomerId;

            arParames[2] = new SqlParameter("@FankuiResult", SqlDbType.Int);
            arParames[2].Value = dto.FankuiResult;

            arParames[3] = new SqlParameter("@FankuiDescription", SqlDbType.Text);
            arParames[3].Value = dto.FankuiDescription;

            arParames[4] = new SqlParameter("@FankuiTime", SqlDbType.DateTime);
            arParames[4].Value = dto.FankuiTime;

            arParames[5] = new SqlParameter("@FankuiSendTime", SqlDbType.DateTime);
            arParames[5].Value = dto.FankuiSendTime;

            arParames[6] = new SqlParameter("@FankuiStatus", SqlDbType.VarChar, 50);
            arParames[6].Value = dto.FankuiStatus;

            arParames[7] = new SqlParameter("@FankuiSource", SqlDbType.Int);
            arParames[7].Value = dto.FankuiSource;

            arParames[8] = new SqlParameter("@FankuiDoctor", SqlDbType.Int);
            arParames[8].Value = dto.FankuiDoctor;

            return arParames;
        }
        public static FankuiDto getDTO(DataRow dr)
        {

            FankuiDto dto = new FankuiDto();

            dto.FankuiId = int.Parse(dr["FankuiId"].ToString());

            dto.FankuiCustomerId = int.Parse(dr["FankuiCustomerId"].ToString());
            dto.FankuiResult = int.Parse(dr["FankuiResult"].ToString());
            dto.FankuiDescription = dr["FankuiDescription"].ToString();
            dto.FankuiTime =  DateTime.Parse(dr["FankuiTime"].ToString());
            dto.FankuiSendTime = DateTime.Parse( dr["FankuiSendTime"].ToString());
            dto.FankuiSource = int.Parse(dr["FankuiSource"].ToString());
            dto.FankuiStatus = dr["FankuiSource"].ToString();
            dto.FankuiDoctor = int.Parse(dr["FankuiDoctor"].ToString());




            return dto;
        }



    }
}
