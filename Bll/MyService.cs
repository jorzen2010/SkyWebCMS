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
    }
}
