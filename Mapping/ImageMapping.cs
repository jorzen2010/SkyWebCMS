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
    public class ImageMapping : IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateImage";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateImage";
            }

            return StoredProcedure;
        }
        public SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {

            SqlParameter[] arParames = new SqlParameter[7];
            ImageDto ImageDto = JsonHelper.JsonDeserializeBySingleData<ImageDto>(jsonString);

            arParames[0] = new SqlParameter("@ImageId", SqlDbType.Int);
            arParames[0].Value = ImageDto.ImageId;

            arParames[1] = new SqlParameter("@ImageTitle ", SqlDbType.VarChar, 50);
            arParames[1].Value = ImageDto.ImageTitle;

            arParames[2] = new SqlParameter("@ImageUrl ", SqlDbType.VarChar, 500);
            arParames[2].Value = ImageDto.ImageUrl;

            arParames[3] = new SqlParameter("@ImageHref ", SqlDbType.VarChar, 500);
            arParames[3].Value = ImageDto.ImageHref;

            arParames[4] = new SqlParameter("@ImageDescription ", SqlDbType.VarChar, 5000);
            arParames[4].Value = ImageDto.ImageDescription;

            arParames[5] = new SqlParameter("@ImageCategory ", SqlDbType.Int);
            arParames[5].Value = ImageDto.ImageCategory;

            arParames[6] = new SqlParameter("@ImageStatus ", SqlDbType.Bit);
            arParames[6].Value = ImageDto.ImageStatus;
;


            return arParames;
        }
        public static ImageDto getDTO(DataRow dr)
        {

            ImageDto ImageDto = new ImageDto();

            ImageDto.ImageId = int.Parse(dr["ImageId"].ToString());
            ImageDto.ImageTitle = dr["ImageTitle"].ToString();
            ImageDto.ImageUrl = dr["ImageUrl"].ToString();
            ImageDto.ImageHref = dr["ImageHref"].ToString();
            ImageDto.ImageDescription = dr["ImageDescription"].ToString();
            ImageDto.ImageCategory = int.Parse(dr["ImageCategory"].ToString());
            ImageDto.ImageStatus = bool.Parse(dr["ImageStatus"].ToString());


            return ImageDto;
        }
    }
}
