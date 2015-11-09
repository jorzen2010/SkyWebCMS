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
    public class CategoryMapping:IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateCategory";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateCategory";
            }

            return StoredProcedure;
        }
        public SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {
            SqlParameter[] arParames = new SqlParameter[4];
            CategoryDto categoryDto = JsonHelper.JsonDeserializeBySingleData<CategoryDto>(jsonString);

            arParames[0] = new SqlParameter("@CategoryId", SqlDbType.Int);
            arParames[0].Value = categoryDto.CategoryId;

            arParames[1] = new SqlParameter("@CategoryName ", SqlDbType.VarChar, 50);
            arParames[1].Value = categoryDto.CategoryName;

            arParames[2] = new SqlParameter("@CategoryDescription ", SqlDbType.VarChar, 5000);
            arParames[2].Value = categoryDto.CategoryDescription;

            arParames[3] = new SqlParameter("@CategoryParentId ", SqlDbType.Int);
            arParames[3].Value = categoryDto.CategoryParentId;

           

            return arParames;
        }
        public static CategoryDto getDTO(DataRow dr)
        {

            CategoryDto categoryDto = new CategoryDto();
            categoryDto.CategoryId = int.Parse(dr["CategoryId"].ToString());


            categoryDto.CategoryName = dr["CategoryName"].ToString();
            categoryDto.CategoryDescription = dr["CategoryDescription"].ToString();

            categoryDto.CategoryParentId = int.Parse(dr["CategoryParentId"].ToString());


            return categoryDto;
        }
    }
}
