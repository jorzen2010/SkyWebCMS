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
    public class UserMapping: IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateUser";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateUser";
            }

            return StoredProcedure;
        }           
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[5];
            UserDto userDto = JsonHelper.JsonDeserializeBySingleData<UserDto>(jsonString);

            arParames[0] = new SqlParameter("@UserId", SqlDbType.Int);
            arParames[0].Value = userDto.UserId;

            arParames[1] = new SqlParameter("@UserPassword ", SqlDbType.VarChar, 50);
            arParames[1].Value = userDto.UserPassword;

            arParames[2] = new SqlParameter("@UserName ", SqlDbType.VarChar, 50);
            arParames[2].Value = userDto.UserName;


            arParames[3] = new SqlParameter("@UserRoles ", SqlDbType.VarChar, 50);
            arParames[3].Value = userDto.UserRoles;

            arParames[4] = new SqlParameter("@UserStatus ", SqlDbType.Bit);
            arParames[4].Value = userDto.UserStatus;



            return arParames;
        }
        public static UserDto getDTO(DataRow dr) 
        {
           
                UserDto userDto = new UserDto();

                userDto.UserId = int.Parse(dr["UserId"].ToString());
                userDto.UserPassword = dr["UserPassword"].ToString();
                userDto.UserName = dr["UserName"].ToString();
                userDto.UserRoles = dr["UserRoles"].ToString();
                userDto.UserEmail = dr["UserEmail"].ToString();
                userDto.UserTelephone = dr["UserTelephone"].ToString();
                userDto.UserStatus = bool.Parse(dr["UserStatus"].ToString());
                userDto.UserRegisterTime = DateTime.Parse(dr["UserRegisterTime"].ToString());
                userDto.UserSex = dr["UserSex"].ToString();
                userDto.UserRealName = dr["UserRealName"].ToString();
                userDto.UserImg = dr["UserImg"].ToString();
                userDto.UserBirthday = DateTime.Parse(dr["UserBirthday"].ToString());


                return userDto;
        }

        public SqlParameter[] JsonStringToSqlParameterForUpdateUser(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[12];
            UserDto userDto = JsonHelper.JsonDeserializeBySingleData<UserDto>(jsonString);

            arParames[0] = new SqlParameter("@UserId", SqlDbType.Int);
            arParames[0].Value = userDto.UserId;

            arParames[1] = new SqlParameter("@UserPassword ", SqlDbType.VarChar, 50);
            arParames[1].Value = userDto.UserPassword;

            arParames[2] = new SqlParameter("@UserName ", SqlDbType.VarChar, 50);
            arParames[2].Value = userDto.UserName;

            arParames[3] = new SqlParameter("@UserEmail ", SqlDbType.VarChar, 50);
            arParames[3].Value = userDto.UserEmail;

            arParames[4] = new SqlParameter("@UserRegisterTime ", SqlDbType.DateTime);
            arParames[4].Value = userDto.UserRegisterTime;

            arParames[5] = new SqlParameter("@UserTelephone ", SqlDbType.VarChar, 50);
            arParames[5].Value = userDto.UserTelephone;

            arParames[6] = new SqlParameter("@UserRoles ", SqlDbType.VarChar, 50);
            arParames[6].Value = userDto.UserRoles;

            arParames[7] = new SqlParameter("@UserStatus ", SqlDbType.Bit);
            arParames[7].Value = userDto.UserStatus;

            arParames[8] = new SqlParameter("@UserRealName ", SqlDbType.VarChar, 50);
            arParames[8].Value = userDto.UserRealName;

            arParames[9] = new SqlParameter("@UserSex ", SqlDbType.VarChar, 50);
            arParames[9].Value = userDto.UserSex;

            arParames[10] = new SqlParameter("@UserImg ", SqlDbType.VarChar, 500);
            arParames[10].Value = userDto.UserImg;

            arParames[11] = new SqlParameter("@UserBirthday ", SqlDbType.DateTime);
            arParames[11].Value = userDto.UserBirthday;

            return arParames;
        }

        
    }
}
