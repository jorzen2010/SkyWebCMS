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
    public class XueyaMapping: IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateXueya";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateXueya";
            }

            return StoredProcedure;
        }           
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[10];
            XueyaDto xueyaDto = JsonHelper.JsonDeserializeBySingleData<XueyaDto>(jsonString);

            arParames[0] = new SqlParameter("@XueyaId", SqlDbType.Int);
            arParames[0].Value = xueyaDto.XueyaId;

            arParames[1] = new SqlParameter("@XueyaGaoya", SqlDbType.Int);
            arParames[1].Value = xueyaDto.XueyaGaoya;

            arParames[2] = new SqlParameter("@XueyaDiya", SqlDbType.Int);
            arParames[2].Value = xueyaDto.XueyaDiya;

            arParames[3] = new SqlParameter("@XueyaMaibo", SqlDbType.Int);
            arParames[3].Value = xueyaDto.XueyaMaibo;

            arParames[4] = new SqlParameter("@XueyaTime", SqlDbType.DateTime);
            arParames[4].Value = xueyaDto.XueyaTime;

            arParames[5] = new SqlParameter("@XueyaSId", SqlDbType.VarChar, 50);
            arParames[5].Value = xueyaDto.XueyaSId;

            arParames[6] = new SqlParameter("@XueyaUId", SqlDbType.Int);
            arParames[6].Value = xueyaDto.XueyaUId;

            arParames[7] = new SqlParameter("@CustomerId", SqlDbType.Int);
            arParames[7].Value = xueyaDto.CustomerId;

            arParames[8] = new SqlParameter("@XueyaSource", SqlDbType.VarChar, 50);
            arParames[8].Value = xueyaDto.XueyaSource;

            arParames[9] = new SqlParameter("@XueyaWeizhi ", SqlDbType.VarChar, 50);
            arParames[9].Value = xueyaDto.XueyaWeizhi;



 



            return arParames;
        }
        public static XueyaDto getDTO(DataRow dr) 
        {

                XueyaDto xueyaDto = new XueyaDto();

                xueyaDto.XueyaId = int.Parse(dr["XueyaId"].ToString());

                xueyaDto.CustomerId = int.Parse(dr["CustomerId"].ToString());
                xueyaDto.XueyaGaoya = int.Parse(dr["XueyaGaoya"].ToString());
                xueyaDto.XueyaDiya = int.Parse(dr["XueyaDiya"].ToString());
                xueyaDto.XueyaMaibo = int.Parse(dr["XueyaMaibo"].ToString());
                xueyaDto.XueyaTime = DateTime.Parse(dr["XueyaTime"].ToString());
                xueyaDto.XueyaSId = dr["XueyaSId"].ToString();
                xueyaDto.XueyaUId = int.Parse(dr["XueyaUId"].ToString());
                xueyaDto.CustomerId = int.Parse(dr["CustomerId"].ToString());
                xueyaDto.XueyaSource = dr["XueyaSource"].ToString();
                xueyaDto.XueyaWeizhi = dr["XueyaWeizhi"].ToString();

                return xueyaDto;
        }

      
        
    }
}
