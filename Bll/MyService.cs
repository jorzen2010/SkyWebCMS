using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using Dto;
using Mapping;
using System.Web;
using System.Web.Mvc;


namespace Bll
{
    public class MyService
    {
        //多个用户角色，从ID转化成名字
        public static string RolesIdToRolesName(string RoesId)
        {
            string userRoles = "";
            string roleName = "";
            string s = RoesId;
            string[] sArray = s.Split(',');
            foreach (string i in sArray)
            {
                DataTable dt = CMSService.SelectOne("Role", "CMSRole", "RoleId=" + int.Parse(i));
                foreach (DataRow dataRow in dt.Rows)
                {
                    RoleDto roleDto = new RoleDto();
                    roleDto = RoleMapping.getDTO(dataRow);
                    roleName = roleDto.RoleName;
                }
                userRoles = userRoles + roleName + ",";

            }
            userRoles = userRoles.Substring(0, userRoles.Length - 1);
            return userRoles;
        }
        //分类的下拉列表显示
        public static List<SelectListItem> GetCategorySelectList(string strwhere)
        {
            DataTable dt = CMSService.SelectSome("Category", "CMSCategory", strwhere);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (DataRow dr in dt.Rows)
            {
                CategoryDto dto = CategoryMapping.getDTO(dr);
                items.Add(new SelectListItem { Text = dto.CategoryName, Value = dto.CategoryId.ToString() });
            }
            return items;
        
        }

        //分类的下拉列表显示
        public static List<SelectListItem> GetCategorySelectBlankList(string strwhere)
        {
            DataTable dt = CMSService.SelectSome("Category", "CMSCategory", strwhere);
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "请输入分类", Value = "" });
            foreach (DataRow dr in dt.Rows)
            {
                CategoryDto dto = CategoryMapping.getDTO(dr);
                items.Add(new SelectListItem { Text = dto.CategoryName, Value = dto.CategoryId.ToString() });
            }
            return items;

        }
        //性别下拉列表
        public static List<SelectListItem> GetSexSelectList()
        {
           
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "未知", Value = "未知" });
            items.Add(new SelectListItem { Text = "男", Value = "男" });
            items.Add(new SelectListItem { Text = "女", Value = "女" });


            return items;

        }
        //血压位置下拉列表
        public static List<SelectListItem> GetXueyaWeizhiSelectList()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "未知", Value = "未知" });
            items.Add(new SelectListItem { Text = "右上肢", Value = "右上肢" });
            items.Add(new SelectListItem { Text = "左上肢", Value = "左上肢" });


            return items;

        }
        //用户角色列表
        public static List<RoleDto> GetRolesList(string strwhere)
        {
            List<RoleDto> RolesList = new List<RoleDto>();
            DataTable dt = CMSService.SelectSome("Role", "CMSRole", strwhere);
            foreach (DataRow dr in dt.Rows)
            {
                RoleDto dto = RoleMapping.getDTO(dr);
                RolesList.Add(dto);
            }

            return RolesList;
        }
        //分类列表
        public static List<CategoryDto> GetCategoryList(string strwhere)
        {
            List<CategoryDto> CategoryList = new List<CategoryDto>();
            DataTable dt = CMSService.SelectSome("Category", "CMSCategory", strwhere);
            foreach (DataRow dr in dt.Rows)
            {
                CategoryDto dto = CategoryMapping.getDTO(dr);
                CategoryList.Add(dto);
            }

            return CategoryList;
        }

        public static List<UserDto> GetUserList(string strwhere)
        {
            List<UserDto> UserList = new List<UserDto>();
            DataTable dt = CMSService.SelectSome("User", "CMSUser", strwhere);
            foreach (DataRow dr in dt.Rows)
            {
                UserDto dto = UserMapping.getDTO(dr);
                UserList.Add(dto);
            }
            return UserList;
        
        }
        public static string CustomerIdToName(string strWhere)
        {
             CustomerDto dto =new CustomerDto();
            DataTable dt=CMSService.SelectOne("Customer","CMSCustomer",strWhere);
            foreach (DataRow dr in dt.Rows)
            {
                dto = CustomerMapping.getDTO(dr);
            
            }
            return dto.CustomerName;
        
        }
        public static string UserIdToName(string strWhere)
        {
            UserDto dto = new UserDto();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", strWhere);
            foreach (DataRow dr in dt.Rows)
            {
                dto = UserMapping.getDTO(dr);

            }
            return dto.UserName;

        
        }
        public static string CategoryIdToName(string strWhere)
        {
            CategoryDto dto = new CategoryDto();
            DataTable dt = CMSService.SelectOne("Category", "CMSCategory", strWhere);
            foreach (DataRow dr in dt.Rows)
            {
                dto = CategoryMapping.getDTO(dr);

            }
            return dto.CategoryName;
        
        }
        public static double GetFenshuByCategory(int categoryId)
        {
            double fenshu = 0;
            CategoryDto dto = new CategoryDto();
            DataTable dt = CMSService.SelectOne("Category", "CMSCategory", "CategoryId="+categoryId);
            foreach (DataRow dr in dt.Rows)
            {
                dto = CategoryMapping.getDTO(dr);

            }
            try
            {
                fenshu = double.Parse(dto.CategoryDescription);
            }
            catch 
            {
                fenshu = 0;
            }
            return fenshu;

        }
        //用户列表
        public static List<SelectListItem> GetUserSelectList(string strwhere)
        {
            DataTable dt = CMSService.SelectSome("User", "CMSUser", strwhere);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (DataRow dr in dt.Rows)
            {
                UserDto dto = UserMapping.getDTO(dr);
                string username = "";
                if (String.IsNullOrEmpty(dto.UserRealName))
                {
                    username = dto.UserName;
                }
                else
                {
                    username = dto.UserRealName;
                }
                items.Add(new SelectListItem { Text = username, Value = dto.UserId.ToString() });
            }
            return items;

        }
    }
}
