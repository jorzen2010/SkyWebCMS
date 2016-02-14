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
    public class YuyueMapping: IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateYuyue";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateYuyue";
            }

            return StoredProcedure;
        }           
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[6];
            YuyueDto yuyueDto = JsonHelper.JsonDeserializeBySingleData<YuyueDto>(jsonString);

            arParames[0] = new SqlParameter("@YuyueId", SqlDbType.Int);
            arParames[0].Value = yuyueDto.YuyueId;

            arParames[1] = new SqlParameter("@YuyueDoctorId", SqlDbType.Int);
            arParames[1].Value = yuyueDto.YuyueDoctorId;

            arParames[2] = new SqlParameter("@YuyueCustomerId", SqlDbType.Int);
            arParames[2].Value = yuyueDto.YuyueCustomerId;

            arParames[3] = new SqlParameter("@YuyueDescription", SqlDbType.Text);
            arParames[3].Value = yuyueDto.YuyueDescription;

            arParames[4] = new SqlParameter("@YuyueDateTime", SqlDbType.DateTime);
            arParames[4].Value = yuyueDto.YuyueDateTime;

            arParames[5] = new SqlParameter("@YuyueStatus", SqlDbType.VarChar,50);
            arParames[5].Value = yuyueDto.YuyueStatus;



            return arParames;
        }
        public static YuyueDto getDTO(DataRow dr) 
        {

                YuyueDto yuyueDto = new YuyueDto();

                yuyueDto.YuyueId = int.Parse(dr["YuyueId"].ToString());
                yuyueDto.YuyueCustomerId = int.Parse(dr["YuyueCustomerId"].ToString());
                yuyueDto.YuyueDoctorId = int.Parse(dr["YuyueDoctorId"].ToString());
                yuyueDto.YuyueDateTime = DateTime.Parse(dr["YuyueDateTime"].ToString());
                yuyueDto.YuyueStatus = dr["YuyueStatus"].ToString();
                yuyueDto.YuyueDescription = dr["YuyueDescription"].ToString();

                return yuyueDto;
        }

      
        
    }
}
