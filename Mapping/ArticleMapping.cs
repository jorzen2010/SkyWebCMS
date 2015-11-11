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
    public class ArticleMapping:IMapping
    {
        public string GetStoredProcedure(string actionName)
        {
            string StoredProcedure = "";
            if (actionName == "Insert")
            {
                StoredProcedure = "CreateArticle";
            }
            if (actionName == "Update")
            {
                StoredProcedure = "UpdateArticle";
            }

            return StoredProcedure;
        }
        public SqlParameter[] JsonStringToSqlParameter(string jsonString)
        {

            SqlParameter[] arParames = new SqlParameter[13];
            ArticleDto articleDto = JsonHelper.JsonDeserializeBySingleData<ArticleDto>(jsonString);

            arParames[0] = new SqlParameter("@ArticleId", SqlDbType.Int);
            arParames[0].Value = articleDto.ArticleId;

            arParames[1] = new SqlParameter("@ArticleTitle ", SqlDbType.VarChar, 500);
            arParames[1].Value = articleDto.ArticleTitle;

            arParames[2] = new SqlParameter("@ArticleDescription ", SqlDbType.VarChar, 5000);
            arParames[2].Value = articleDto.ArticleDescription;

            arParames[3] = new SqlParameter("@ArticleKeywords ", SqlDbType.VarChar, 500);
            arParames[3].Value = articleDto.ArticleKeywords;

            arParames[4] = new SqlParameter("@ArticleContent ", SqlDbType.Text);
            arParames[4].Value = articleDto.ArticleContent;

            arParames[5] = new SqlParameter("@ArticleAuthor ", SqlDbType.VarChar, 50);
            arParames[5].Value = articleDto.ArticleAuthor;

            arParames[6] = new SqlParameter("@ArticleEditor ", SqlDbType.VarChar, 50);
            arParames[6].Value = articleDto.ArticleEditor;

            arParames[7] = new SqlParameter("@ArticleTime ", SqlDbType.DateTime);
            arParames[7].Value = articleDto.ArticleTime;

            arParames[8] = new SqlParameter("@ArticleTop ", SqlDbType.Bit);
            arParames[8].Value = articleDto.ArticleTop;

            arParames[9] = new SqlParameter("@ArticleHot ", SqlDbType.Bit);
            arParames[9].Value = articleDto.ArticleHot;

            arParames[10] = new SqlParameter("@ArticleClassic ", SqlDbType.Bit);
            arParames[10].Value = articleDto.ArticleClassic;

            arParames[11] = new SqlParameter("@ArticleCategory ", SqlDbType.Int);
            arParames[11].Value = articleDto.ArticleCategory;

            arParames[12] = new SqlParameter("@ArticleImg ", SqlDbType.VarChar, 500);
            arParames[12].Value = articleDto.ArticleImg;


            return arParames;
        }
        public static ArticleDto getDTO(DataRow dr)
        {

            ArticleDto articleDto = new ArticleDto();

            articleDto.ArticleId = int.Parse(dr["ArticleId"].ToString());
            articleDto.ArticleTitle = dr["ArticleTitle"].ToString();
            articleDto.ArticleCategory = int.Parse(dr["ArticleCategory"].ToString());
            articleDto.ArticleImg = dr["ArticleImg"].ToString();
            articleDto.ArticleDescription = dr["ArticleDescription"].ToString();
            articleDto.ArticleKeywords = dr["ArticleKeywords"].ToString();
            articleDto.ArticleEditor = dr["ArticleEditor"].ToString();
            articleDto.ArticleAuthor = dr["ArticleAuthor"].ToString();
            articleDto.ArticleContent = dr["ArticleContent"].ToString();
            articleDto.ArticleTop = bool.Parse(dr["ArticleTop"].ToString());
            articleDto.ArticleHot = bool.Parse(dr["ArticleHot"].ToString());
            articleDto.ArticleClassic = bool.Parse(dr["ArticleClassic"].ToString());
            articleDto.ArticleTime = DateTime.Parse(dr["ArticleTime"].ToString());




            return articleDto;
        }
    }
}
