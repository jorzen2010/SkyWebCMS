using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using System.Collections;
using System.Reflection;
using Dto;
using Common;
using Bll;
using Mapping;
using InterfaceMapping;
using SkyWebCMS.Models;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Controllers
{
    public class LoginController : Controller
    {
        [ChildActionOnly]
        public ActionResult PartialForgot()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult PartialSignup()
        {
            UserSignupViewModel model = new UserSignupViewModel();
            model.UserRoles = "45";
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult PartialLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(UserLoginViewModel model)
        {
            string strwhere = "UserName='" + model.UserName + "' and UserPassword='" + CommonTools.ToMd5(model.UserPassword) + "'";
            DataTable dt = CMSService.SelectOne("User", "CMSUser", strwhere);
            if (dt.Rows.Count > 0)
            {
                UserDto dto = new UserDto();
                foreach (DataRow dr in dt.Rows)
                {

                    dto = UserMapping.getDTO(dr);

                }
                if (!dto.UserStatus)
                {
                    return RedirectToAction("Login", "Login", new { ac = "StatusError" });
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("User");
                    cookie.Value = dto.UserName;
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                    HttpCookie cookieid = new HttpCookie("UserId");
                    cookieid.Value = dto.UserId.ToString();
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookieid);

                    System.Web.HttpContext.Current.Session["UserId"] = dto.UserId;
                    FormsAuthentication.SetAuthCookie(dto.UserName, false);

                    return Redirect("/Home/Index");
                }
            }
            else
            {
                return RedirectToAction("Login", "Login", new { ac = "LoginError" });
            }

        }
        [AllowAnonymous]
        public ActionResult Login(string ac)
        {
            string action = ac ?? "NoAction";
            if (action == "NoAction")
            {
                ViewBag.msg = "曲线社区欢迎您";
            }
            if (action == "SignupSuccess")
            {
                ViewBag.msg = "注册成功了";
            }
            if (action == "LoginError")
            {
                ViewBag.msg = "用户名或密码错误，登录失败";
            }
            if (action == "StatusError")
            {
                ViewBag.msg = "用户已经被禁用，不允许登录";
            }
            if (action == "SendSuccess")
            {
                ViewBag.msg = "密码发送成功，请用新密码登录";
            }
            if (action == "SendError")
            {
                ViewBag.msg = "用户名与邮箱不匹配";
            }
            if (action == "RoleError")
            {
                ViewBag.msg = "权限不足，不允许访问";
            }


            return View();
        }
        [HttpPost]
        public ActionResult UserSignup(UserSignupViewModel model)
        {
            try
            {

                UserDto dto = new UserDto();

                dto.UserEmail = "";
                dto.UserTelephone = "";
                dto.UserName = model.UserName;
                dto.UserPassword = CommonTools.ToMd5(model.UserPassword);
                dto.UserRegisterTime = System.DateTime.Now;
                dto.UserRoles = model.UserRoles;
                dto.UserStatus = true;


                string userJsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("User", userJsonString);

                // return RedirectTo("/Login/Login", msg.MessageInfo);
                return RedirectToAction("Login", "Login", new { ac = "SignupSuccess" });
            }

            catch
            {
                Message msg = new Message();
                msg.MessageStatus = "Error";
                msg.MessageInfo = "注册失败了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View("Login");
            }

        }
	}
}