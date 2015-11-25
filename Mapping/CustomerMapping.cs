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
    public class CustomerMapping : IMapping
  {
        public  string GetStoredProcedure(string actionName)           
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            { 
                 StoredProcedure = "CreateCustomer";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateCustomer";
            }
            
            return StoredProcedure;
        }
        public  SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
           
            SqlParameter[] arParames = new SqlParameter[5];
            CustomerDto CustomerDto = JsonHelper.JsonDeserializeBySingleData<CustomerDto>(jsonString);

            arParames[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
            arParames[0].Value = CustomerDto.CustomerId;

            arParames[1] = new SqlParameter("@CustomerName ", SqlDbType.VarChar, 50);
            arParames[1].Value = CustomerDto.CustomerName;

            arParames[2] = new SqlParameter("@CustomerNumber ", SqlDbType.VarChar, 50);
            arParames[2].Value = CustomerDto.CustomerNumber;

            arParames[3] = new SqlParameter("@CustomerSex ", SqlDbType.VarChar, 50);
            arParames[3].Value = CustomerDto.CustomerSex;

            arParames[4] = new SqlParameter("@CustomerBirthday ", SqlDbType.DateTime);
            arParames[4].Value = CustomerDto.CustomerBirthday;

          
            return arParames;
        }
        public static CustomerDto getDTO(DataRow dr)
        {

            CustomerDto CustomerDto = new CustomerDto();

            CustomerDto.CustomerId = int.Parse(dr["CustomerId"].ToString());
            CustomerDto.CustomerName = dr["CustomerName"].ToString();
            CustomerDto.CustomerNumber = dr["CustomerNumber"].ToString();
            CustomerDto.CustomerSex = dr["CustomerSex"].ToString();
            CustomerDto.CustomerBirthday = DateTime.Parse(dr["CustomerBirthday"].ToString());
            CustomerDto.CustomerTelephone = dr["CustomerTelephone"].ToString();
            CustomerDto.CustomerEmail = dr["CustomerEmail"].ToString();
            CustomerDto.CustomerMinzu = dr["CustomerMinzu"].ToString();
            CustomerDto.CustomerHunyin = dr["CustomerHunyin"].ToString();
            CustomerDto.CustomerChangzhu = dr["CustomerChangzhu"].ToString();
            CustomerDto.CustomerWenhua = dr["CustomerWenhua"].ToString();
            CustomerDto.CustomerZhiye = dr["CustomerZhiye"].ToString();
            CustomerDto.CustomerAddress = dr["CustomerAddress"].ToString();
            CustomerDto.CustomerHujiAddress = dr["CustomerHujiAddress"].ToString();
            CustomerDto.CustomerLianxiren = dr["CustomerLianxiren"].ToString();
            CustomerDto.CustomerLianxirenTel = dr["CustomerLianxirenTel"].ToString();
            CustomerDto.CustomerJuweihui = dr["CustomerJuweihui"].ToString();
            CustomerDto.CustomerXiangzhen = dr["CustomerXiangzhen"].ToString();
            CustomerDto.CustomerDanwei = dr["CustomerDanwei"].ToString();
            CustomerDto.CustomerYongyao = dr["CustomerYongyao"].ToString();
            CustomerDto.CustomerBeizhu = dr["CustomerBeizhu"].ToString();
            CustomerDto.CustomerGuidang = dr["CustomerGuidang"].ToString();
            CustomerDto.CustomerDoctor = dr["CustomerDoctor"].ToString();
            CustomerDto.CustomerShequ = dr["CustomerShequ"].ToString();
            

           

            return CustomerDto;
        }
       
      
    }
}
