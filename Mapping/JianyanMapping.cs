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
    public class JianyanMapping: IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateJianyan";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateJianyan";
            }

            return StoredProcedure;
        }           
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[7];
            JianyanDto jianyanDto = JsonHelper.JsonDeserializeBySingleData<JianyanDto>(jsonString);

            arParames[0] = new SqlParameter("@JianyanId", SqlDbType.Int);
            arParames[0].Value = jianyanDto.JianyanId;

            arParames[1] = new SqlParameter("@JianyanCustomerId", SqlDbType.Int);
            arParames[1].Value = jianyanDto.JianyanCustomerId;

            arParames[2] = new SqlParameter("@JianyanCategory", SqlDbType.VarChar,50);
            arParames[2].Value = jianyanDto.JianyanCategory;

            arParames[3] = new SqlParameter("@JianyanDescription", SqlDbType.VarChar,5000);
            arParames[3].Value = jianyanDto.JianyanDescription;

            arParames[4] = new SqlParameter("@JianyanImg", SqlDbType.VarChar,500);
            arParames[4].Value = jianyanDto.JianyanImg;

            arParames[5] = new SqlParameter("@JianyanTime", SqlDbType.DateTime);
            arParames[5].Value = jianyanDto.JianyanTime;

            arParames[6] = new SqlParameter("@JianyanDoctor", SqlDbType.Int);
            arParames[6].Value = jianyanDto.JianyanDoctor;





 



            return arParames;
        }
        public static JianyanDto getDTO(DataRow dr) 
        {

                JianyanDto dto = new JianyanDto();

                dto.JianyanId = int.Parse(dr["JianyanId"].ToString());

                dto.JianyanCustomerId = int.Parse(dr["JianyanCustomerId"].ToString());
                dto.JianyanImg = dr["JianyanImg"].ToString();
                dto.JianyanCategory = dr["JianyanCategory"].ToString();
                dto.JianyanDescription = dr["JianyanDescription"].ToString();
                dto.JianyanTime = DateTime.Parse(dr["JianyanTime"].ToString());
                dto.JianyanDoctor = int.Parse(dr["JianyanDoctor"].ToString());



                return dto;
        }

      
        
    }
}
