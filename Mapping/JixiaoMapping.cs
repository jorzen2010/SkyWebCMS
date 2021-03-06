﻿using System;
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
    public class JixiaoMapping : IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateJixiao";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateJixiao";
            }

            return StoredProcedure;
        }
        public SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[9];
            JixiaoDto jixiaoDto = JsonHelper.JsonDeserializeBySingleData<JixiaoDto>(jsonString);

            arParames[0] = new SqlParameter("@JixiaoUser", SqlDbType.VarChar, 50);
            arParames[0].Value = jixiaoDto.JixiaoUser;

            arParames[1] = new SqlParameter("@JixiaoForUser", SqlDbType.VarChar, 50);
            arParames[1].Value = jixiaoDto.JixiaoForUser;

            arParames[2] = new SqlParameter("@JixiaoParentCategory", SqlDbType.VarChar, 500);
            arParames[2].Value = jixiaoDto.JixiaoParentCategory;

            arParames[3] = new SqlParameter("@JixiaoCategory", SqlDbType.VarChar, 500);
            arParames[3].Value = jixiaoDto.JixiaoCategory;

            arParames[4] = new SqlParameter("@JixiaoRenwu", SqlDbType.VarChar, 5000);
            arParames[4].Value = jixiaoDto.JixiaoRenwu;

            arParames[5] = new SqlParameter("@JixiaoStatus", SqlDbType.VarChar, 50);
            arParames[5].Value = jixiaoDto.JixiaoStatus;

            arParames[6] = new SqlParameter("@JixiaoFenshu", SqlDbType.Real);
            arParames[6].Value = jixiaoDto.JixiaoFenshu;

            arParames[7] = new SqlParameter("@JixiaoTime", SqlDbType.DateTime);
            arParames[7].Value = jixiaoDto.JixiaoTime;

            arParames[8] = new SqlParameter("@JixiaoShenheTime", SqlDbType.DateTime);
            arParames[8].Value = jixiaoDto.JixiaoShenheTime;









            return arParames;
        }
        public static JixiaoDto getDTO(DataRow dr)
        {

            JixiaoDto jixiaoDto = new JixiaoDto();

            jixiaoDto.JixiaoId = int.Parse(dr["JixiaoId"].ToString());
            jixiaoDto.JixiaoUser = dr["JixiaoUser"].ToString();
            jixiaoDto.JixiaoForUser = dr["JixiaoForUser"].ToString();
            jixiaoDto.JixiaoCategory = int.Parse(dr["JixiaoCategory"].ToString());
            jixiaoDto.JixiaoParentCategory = int.Parse(dr["JixiaoParentCategory"].ToString());
            jixiaoDto.JixiaoTime = DateTime.Parse(dr["JixiaoTime"].ToString());
            jixiaoDto.JixiaoShenheTime = DateTime.Parse(dr["JixiaoShenheTime"].ToString());
            jixiaoDto.JixiaoFenshu = double.Parse(dr["JixiaoFenshu"].ToString());
            jixiaoDto.JixiaoRenwu = dr["JixiaoRenwu"].ToString();
            jixiaoDto.JixiaoStatus = dr["JixiaoStatus"].ToString();

            return jixiaoDto;
        }



    }
}
