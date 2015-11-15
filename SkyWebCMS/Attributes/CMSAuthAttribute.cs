using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Collections;
using Bll;
using Dto;
using Mapping;

namespace SkyWebCMS.Attributes
{
    public class CMSAuthAttribute : AuthorizeAttribute
    {
        // 只需重载此方法，模拟自定义的角色授权机制  
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string currentRole = GetRole(httpContext.User.Identity.Name);
            if (currentRole.Contains(Roles))
                return true;
            return base.AuthorizeCore(httpContext);
        }

        // 返回用户对应的角色， 在实际中， 可以从SQL数据库中读取用户的角色信息  
        private string GetRole(string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
            {
               
                return "游客";
            }
            else
            {
            UserDto dto = new UserDto();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserName='" + UserName+"'");
            foreach (DataRow dataRow in dt.Rows)
            {
                
                dto = UserMapping.getDTO(dataRow);
            
            }
            

            string userRoles = "";
            string roleName = "";
            string s = dto.UserRoles;
            string[] sArray = s.Split(',');
            foreach (string i in sArray)
            {
                DataTable dataTable = CMSService.SelectOne("Role", "CMSRole", "RoleId=" + int.Parse(i));
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    RoleDto roleDto = new RoleDto();
                    roleDto = RoleMapping.getDTO(dataRow);
                    roleName = roleDto.RoleName;
                }
                userRoles = userRoles + roleName + ",";
                userRoles = userRoles.Substring(0, userRoles.Length - 1);

            }
            return userRoles;
            }
        }
    }  
}