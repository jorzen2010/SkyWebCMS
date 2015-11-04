using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dto;
using Common;
using Bll;

namespace SkyWebCMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserDto userDto = new UserDto();

            userDto.UserEmail = "jorzen2010@163.com";
            userDto.UserId = 1;
            userDto.UserName = "jorzen";
            userDto.UserPassword = "jorzen2008";
            userDto.UserTelephone = "16852569656";
            userDto.UserRegisterTime =System.DateTime.Now;
            userDto.UserRoles = "1,2";
            userDto.UserStatus = true;

           
            string userJsonString=JsonHepler.JsonSerializerBySingleData(userDto);
            Message msg=CMSService.InsertDto("User",userJsonString);
            
            ViewBag.msg = msg.MessageInfo;

            return View();
        }

        public ActionResult About()
        {
            Message msg = CMSService.InsertDto("Role", "userJsonString");

            ViewBag.msg = msg.MessageInfo;

            ViewBag.Message = msg.MessageInfo;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}