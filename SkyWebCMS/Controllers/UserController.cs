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
using SkyWebCMS.Models;

namespace SkyWebCMS.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/
        public ActionResult Index(int?p)
        {
            Pager pager = new Pager();
            pager.table = "CMSUser";
            pager.strwhere = "1=1";
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "UserId";
            pager.FiledOrder = "UserId Desc";
            pager = CMSService.SelectAll("User", pager);

            List<UserDto> list = new List<UserDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                UserDto dto = UserMapping.getDTO(dr);
                string userRoles = "";
                string roleName = "";
                string s = dto.UserRoles;
                string[] sArray = s.Split(',');
                foreach (string i in sArray)
                {
                    DataTable dt=CMSService.SelectOne("Role", "CMSRole", "RoleId=" + int.Parse(i));
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        RoleDto roleDto = new RoleDto();
                        roleDto = RoleMapping.getDTO(dataRow);
                        roleName = roleDto.RoleName;
                    }
                    userRoles = userRoles+roleName+",";
                
                }
                dto.UserRoles = userRoles;
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;

            return View(pager.Entity);
            
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
         [ChildActionOnly]
        public ActionResult PartialLogin()
        {
            return View();
        }
        [HttpPost]
         public ActionResult UserLogin(UserLoginViewModel model)
         {
            string strwhere="UserName='"+model.UserName+"' and UserPassword='"+CommonTools.ToMd5(model.UserPassword)+"'";
            DataTable dt = CMSService.SelectOne("User", "CMSUser", strwhere);
            if (dt.Rows.Count > 0)
            {
                 UserDto dto = new UserDto();
                foreach (DataRow dr in dt.Rows)
                {
                   
                    dto = UserMapping.getDTO(dr);

                }
                HttpCookie cookie = new HttpCookie("User");
                cookie.Value = dto.UserName ;
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                System.Web.HttpContext.Current.Session["UserId"] = dto.UserId;

                return Redirect("/Home/Index");
            }
            else
            {
                return RedirectToAction("Login", "User", new { ac = "LoginError" });
            }
             
         }
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
             if (action == "SendSuccess")
             {
                 ViewBag.msg = "密码发送成功，请用新密码登录";
             }
             if (action == "SendError")
             {
                 ViewBag.msg = "用户名与邮箱不匹配";
             }
             
             
             return View();
         }
        [HttpPost]
         public ActionResult UserSignup(UserSignupViewModel model)
         {
            try{
             
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
                 
                // return RedirectTo("/User/Login", msg.MessageInfo);
                 return RedirectToAction("Login", "User", new { ac = "SignupSuccess" });
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
        [HttpPost]
        public ActionResult SendPassword(UserForgotViewModel model)
        {
            string strwhere = "UserName='" + model.UserName + "' and UserEmail='" + model.UserEmail + "'";
            DataTable dt = CMSService.SelectOne("User", "CMSUser", strwhere);
            if (dt.Rows.Count > 0)
            {
                //TO DO Sendemail
                string toMail="277602146@qq.com"; 
                string fromMail="277602146@qq.com";
                string displayName="显示姓名";
                string mailTitle="重置密码";
                string mailContent = "密码设置为123456";
                CommonServices.SendEmail( toMail,  fromMail,  displayName,  mailTitle, mailContent);
                return RedirectToAction("Login", "User", new { ac = "SendSuccess" });
            }
            else
            {
                return RedirectToAction("Login", "User", new { ac = "SendError" });
            }

        }
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
        public ActionResult UserInfo()
        {
            return View();
        }

        public ActionResult EditRoles(int id)
        {
            EditUserRolesViewModel model = new EditUserRolesViewModel();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserId=" + id);
            foreach (DataRow dr in dt.Rows)
            {
                UserDto dto = new UserDto();
                dto = UserMapping.getDTO(dr);
                model.UserId = dto.UserId;
                model.UserName = dto.UserName;
                model.UserRoles = dto.UserRoles;
                
            }
            DataTable RoleDt = CMSService.SelectSome("Role", "CMSRole", "1=1");
            List<RoleDto> ListRoles= new List<RoleDto>();
            foreach (DataRow dr in RoleDt.Rows)
            {
                RoleDto roleDto = RoleMapping.getDTO(dr);
                ListRoles.Add(roleDto);


            }
            ViewData["ListRoles"] = ListRoles;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditRoles(EditUserRolesViewModel model)
        {
            try
            {
                UserDto dto = new UserDto();
                DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserId=" + model.UserId);
                foreach (DataRow dr in dt.Rows)
                {

                    dto = UserMapping.getDTO(dr);
                    dto.UserRoles = Request.Form["UserRoles"];
                }
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Update("User", JsonString);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
           
            catch
            {
                Message msg = new Message();
                msg.MessageStatus = "Error";
                msg.MessageInfo = "操作出错了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View();
            }
           
        
        }
        //
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(UserAddViewModel model)
        {
            try
            {
                UserDto dto = new UserDto();

                dto.UserEmail = model.UserEmail;
                dto.UserTelephone = "";
                dto.UserName = model.UserName;
                dto.UserPassword = CommonTools.ToMd5(model.UserPassword);
                dto.UserRegisterTime = System.DateTime.Now;
                dto.UserRoles = "普通用户";
                dto.UserStatus = true;


                string userJsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("User", userJsonString);
                return RedirectTo("/User/Index", msg.MessageInfo); 
            }
            
            catch
            {
                Message msg = new Message();
                msg.MessageStatus = "Error";
                msg.MessageInfo = "操作出错了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View();
            }
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            Message msg = CMSService.Delete("User", "CMSUser", "UserId=" + id);
            msg.MessageInfo = "数据删除操作成功";
            return RedirectTo("/User/Index", msg.MessageInfo);
        }

       

      
        public ActionResult ResetPassword(int id)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            model.UserId = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                UserDto dto = new UserDto();
                Message msg = new Message();
                DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserId=" + model.UserId);
               
                    foreach (DataRow dr in dt.Rows)
                    {
                        dto = UserMapping.getDTO(dr);
                        dto.UserPassword = CommonTools.ToMd5(model.UserPassword);
                    }
                    string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                    msg = CMSService.Update("User", JsonString);
                    msg.MessageStatus = "Success";
                    msg.MessageInfo = "密码修改成功了";
                    ViewBag.Status = msg.MessageStatus;
                    // TODO: Add delete logic here

                    return RedirectTo("/User/Index", msg.MessageInfo);
                


            }
             
            catch
            {
                Message msg = new Message();
                msg.MessageStatus = "Error";
                msg.MessageInfo = "操作出错了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View();
            }
        }
        public ActionResult EditPassword(int id)
        {

            EditPasswordViewModel model = new EditPasswordViewModel();
            model.UserId = id;


            return View(model);
        }
        [HttpPost]
        public ActionResult EditPassword(EditPasswordViewModel model)
        {
            try
            {
                UserDto dto = new UserDto();
                Message msg = new Message();
                DataTable dt=CMSService.SelectOne("User", "CMSUser", "UserPassword='"+CommonTools.ToMd5(model.OldPassword)+"' and UserId=" + model.UserId);
                if (dt.Rows.Count==0)
                {
                    
                    msg.MessageStatus = "Error";
                    msg.MessageInfo = "原密码错误";
                    ViewBag.Status = msg.MessageStatus;
                    ViewBag.msg = msg.MessageInfo;
                    return View();
                }
                else
                { 
                foreach (DataRow dr in dt.Rows)
            {
                dto = UserMapping.getDTO(dr);
                dto.UserPassword = CommonTools.ToMd5(model.UserPassword);
            }
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                msg = CMSService.Update("User", JsonString);
                msg.MessageStatus = "Success";
                msg.MessageInfo = "密码修改成功了";
                ViewBag.Status = msg.MessageStatus;
                // TODO: Add delete logic here
               
                return RedirectTo("/User/Index", msg.MessageInfo); 
                }
               
            }
            catch
            {
                Message msg = new Message();
                msg.MessageStatus = "Error";
                msg.MessageInfo = "操作出错了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View();
            }
        }
    }
}
