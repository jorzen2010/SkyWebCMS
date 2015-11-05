using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Collections;
using System.Reflection; 
using Dto;
using Common;
using Bll;
using Mapping;
using InterfaceMapping;

namespace SkyWebCMS.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Index()
        {
            UserDto userDto = new UserDto();

            userDto.UserEmail = "jorzen2010@163.com";
            userDto.UserId = 2;
            userDto.UserName = "jorzen11";
            userDto.UserPassword = "jorzen2008";
            userDto.UserTelephone = "16852569656";
            userDto.UserRegisterTime =System.DateTime.Now;
            userDto.UserRoles = "1,2";
            userDto.UserStatus = false;

           
            string userJsonString=JsonHelper.JsonSerializerBySingleData(userDto);
            Message msg=CMSService.Update("User",userJsonString);
            
            ViewBag.msg = msg.MessageInfo;

            return View();
        }

        public ActionResult About()
        {
            RoleDto roleDto = new RoleDto();
            roleDto.RoleId = 1;
            roleDto.RoleName = "超级管理员";
            roleDto.RoleDescription = "这是本系统的最高权限";
            string roleJsonString = JsonHelper.JsonSerializerBySingleData(roleDto);
            Message msg = CMSService.Insert("Role", roleJsonString);

            ViewBag.msg = msg.MessageInfo;

            ViewBag.Message = msg.MessageInfo;

            return View();
        }

        public ActionResult Contact(int?p)
        {

            Pager pager = new Pager();
            pager.table = "CMSUser";
            pager.strwhere = "1=1";
            pager.PageSize = 3;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "UserId";
            pager.FiledOrder = "UserId Desc";
            pager = CMSService.SelectAll("User",pager);

            List<UserDto> Listusers = new List<UserDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
               UserDto userDto= UserMapping.getDTO(dr);
               Listusers.Add(userDto);

            
            }
            pager.Entity = Listusers.AsQueryable();


            ViewBag.Message = pager.Amount;

            return View(pager.Entity);
        }

        public ActionResult SelectOne()
        {
            UserDto userDto = new UserDto();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", "1=1");
            foreach (DataRow dr in dt.Rows)
            {
                userDto = UserMapping.getDTO(dr);
            }


            return View(userDto);
        }

        public ActionResult SelectSome()
        {
            
            DataTable dt = CMSService.SelectSome("User", "CMSUser", "UserId>15");
          
            List<UserDto> Listusers = new List<UserDto>();
            foreach (DataRow dr in dt.Rows)
            {
                UserDto userDto = UserMapping.getDTO(dr);
                Listusers.Add(userDto);


            }
            return View(Listusers);
        }
    }
}