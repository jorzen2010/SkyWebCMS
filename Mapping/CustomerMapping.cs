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
           

            return CustomerDto;
        }
       
      
    }
}
