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
    public class RoleMapping : IMapping
  {
        public  string GetStoredProcedure(string actionName)           
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            { 
                 StoredProcedure = "CreateRole";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateRole";
            }
            
            return StoredProcedure;
        }
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
           
            SqlParameter[] arParames = new SqlParameter[3];
            RoleDto roleDto = JsonHelper.JsonDeserializeBySingleData<RoleDto>(jsonString);

            arParames[0] = new SqlParameter("@RoleId", SqlDbType.Int);
            arParames[0].Value = roleDto.RoleId;

            arParames[1] = new SqlParameter("@RoleName ", SqlDbType.VarChar, 50);
            arParames[1].Value = roleDto.RoleName;

            arParames[2] = new SqlParameter("@RoleDescription ", SqlDbType.VarChar, 50);
            arParames[2].Value = roleDto.RoleDescription;

          
            return arParames;
        }
        public static RoleDto getDTO(DataRow dr)
        {

            RoleDto roleDto = new RoleDto();

            roleDto.RoleId = int.Parse(dr["RoleId"].ToString());
            roleDto.RoleName = dr["RoleName"].ToString();
            roleDto.RoleDescription = dr["RoleDescription"].ToString();
           

            return roleDto;
        }
       
      
    }
}
