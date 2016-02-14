using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMapping;
using Mapping;

namespace Bll
{
    public class MappingFactory
    {
        public static IMapping CreatMapping(string DtoName)
        {
            IMapping Mapping = null;
            if (DtoName == "User")
            {
                Mapping = new UserMapping();
            }
            if (DtoName == "Role")
            {
                Mapping = new RoleMapping();
            }
            if (DtoName == "Category")
            {
                Mapping = new CategoryMapping();
            }
            if (DtoName == "Article")
            {
                Mapping = new ArticleMapping();
            }
            if (DtoName == "Image")
            {
                Mapping = new ImageMapping();
            }
            if (DtoName == "Customer")
            {
                Mapping = new CustomerMapping();
            }
            if (DtoName == "Tizhi")
            {
                Mapping = new TizhiMapping();
            }
            if (DtoName == "Xueya")
            {
                Mapping = new XueyaMapping();
            }
            if (DtoName == "Jianyan")
            {
                Mapping = new JianyanMapping();
            }
            if (DtoName == "Chufang")
            {
                Mapping = new ChufangMapping();
            }
            if (DtoName == "Jixiao")
            {
                Mapping = new JixiaoMapping();
            }
            if (DtoName == "Fankui")
            {
                Mapping = new FankuiMapping();
            }
            if (DtoName == "Yuyue")
            {
                Mapping = new YuyueMapping();
            }
            return Mapping;



        }
    }
}
