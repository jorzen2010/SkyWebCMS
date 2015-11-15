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
    [CMSAuth(Roles = "普通管理员")] 
    public class UserController : BaseController
    {
        
        // 显示用户列表页
        
        public ActionResult Index(int?p,int?roleId)
        {
            int RoleId = roleId ?? 0;
            Pager pager = new Pager();
            pager.table = "CMSUser";
            pager.strwhere = "1=1";
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "UserId";
            pager.FiledOrder = "UserId Desc";
            if (RoleId > 0)
            {

                pager.strwhere = pager.strwhere + " and charindex('" + RoleId + "',UserRoles)>0";

            }

            pager = CMSService.SelectAll("User", pager);
           

            List<UserDto> list = new List<UserDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                UserDto dto = UserMapping.getDTO(dr);
                dto.UserRoles = MyService.RolesIdToRolesName(dto.UserRoles);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewData["Roles"] = MyService.GetRolesList("1=1");

            return View(pager.Entity);
            
        }



        // 发送密码操作
        [HttpPost]
        public ActionResult SendPassword(UserForgotViewModel model)
        {
            string strwhere = "UserName='" + model.UserName + "' and UserEmail='" + model.UserEmail + "'";
            DataTable dt = CMSService.SelectOne("User", "CMSUser", strwhere);
            if (dt.Rows.Count > 0)
            {
                string newpassword = CommonTools.GenerateRandomNumber(8);

                CMSService.UpdateFieldOneByOne("User", "CMSUser", "UserName='" + model.UserName + "'", "UserPassword", CommonTools.ToMd5(newpassword));
                //TO DO Sendemail
                string toMail = model.UserEmail; 
                string fromMail="277602146@qq.com";
                string displayName = model.UserName;
                string mailTitle="重置密码";
                string username = model.UserName;
                string content = "密码重置为:" + newpassword + "。请尽快登录修改密码！";
                //string myname = "曲线社区卫生服务中心";
                //string mailcontent = CommonTools.ReplaceText(username, content, myname);

                CommonServices.SendEmail(toMail, fromMail, displayName, mailTitle, content);
                return RedirectToAction("Login", "Login", new { ac = "SendSuccess" });
            }
            else
            {
                return RedirectToAction("Login", "Login", new { ac = "SendError" });
            }

        }

        // 修改密码
        [ChildActionOnly]
        public ActionResult PartialPassword(string id)
        {
            EditPasswordViewModel model = new EditPasswordViewModel();
            model.UserId = int.Parse(id);
            model.UserName = System.Web.HttpContext.Current.Request.Cookies["User"].Value;


            return View(model);
        
        }
        // 修改密码操作
        [HttpPost]
        public ActionResult EditPassword(EditPasswordViewModel model)
        {
            try
            {
                UserDto dto = new UserDto();
                Message msg = new Message();
                DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserPassword='" + CommonTools.ToMd5(model.OldPassword) + "' and UserId=" + model.UserId);
                if (dt.Rows.Count == 0)
                {

                    msg.MessageStatus = "Error";
                    msg.MessageInfo = "原密码错误";
                    ViewBag.Status = msg.MessageStatus;
                    ViewBag.msg = msg.MessageInfo;
                    return View("UserInfo");
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

                    return RedirectTo("/Login/Login", msg.MessageInfo);
                }

            }
            catch
            {
                Message msg = new Message();
                msg.MessageStatus = "Error";
                msg.MessageInfo = "操作出错了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View("UserInfo");
            }
        }
       
        // 修改邮件
        [ChildActionOnly]
        public ActionResult PartialEmail(string id)
        {
            UserEmailViewModel model = new UserEmailViewModel();
            model.UserId = int.Parse(id);
            model.UserName = System.Web.HttpContext.Current.Request.Cookies["User"].Value;
            return View(model);

        }
        // 修改邮件动作
        [HttpPost]
        public ActionResult EditEmail(UserEmailViewModel model)
        {
            try
            {
                UserDto dto = new UserDto();
                Message msg = new Message();
                DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserName!='" + model.UserName + "' and UserEmail='" + model.UserEmail+"'");
                if (dt.Rows.Count > 0)
                {

                    msg.MessageStatus = "Error";
                    msg.MessageInfo = "此邮箱已经被其他用户占用。";
                    ViewBag.Status = msg.MessageStatus;
                    ViewBag.msg = msg.MessageInfo;
                    return View("UserInfo");
                }
                else
                {

                    msg = CMSService.UpdateFieldOneByOne("User", "CMSUser", "UserName='" + model.UserName + "'", "UserEmail",model.UserEmail);
                    msg.MessageStatus = "Success";
                    msg.MessageInfo = "邮箱更改成功";
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
                return View("UserInfo");
            }
        }
        // 修改手机
        [ChildActionOnly]
        public ActionResult PartialTelephone(string id)
        {
            UserTelephoneViewModel model = new UserTelephoneViewModel();
            model.UserId = int.Parse(id);
            model.UserName = System.Web.HttpContext.Current.Request.Cookies["User"].Value;
            return View(model);

        }
        // 修改手机动作
        [HttpPost]
        public ActionResult EditTelephone(UserTelephoneViewModel model)
        {
            try
            {
                UserDto dto = new UserDto();
                Message msg = new Message();
                DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserName!='" + model.UserName + "' and UserTelephone='" + model.UserTelephone + "'");
                if (dt.Rows.Count > 0)
                {

                    msg.MessageStatus = "Error";
                    msg.MessageInfo = "此手机已经被其他用户占用。";
                    ViewBag.Status = msg.MessageStatus;
                    ViewBag.msg = msg.MessageInfo;
                    return View("UserInfo");
                }
                else
                {

                    msg = CMSService.UpdateFieldOneByOne("User", "CMSUser", "UserName='" + model.UserName + "'", "UserTelephone", model.UserTelephone);
                    msg.MessageStatus = "Success";
                    msg.MessageInfo = "手机更改成功";
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
                return View("UserInfo");
            }
        }
        // 用户个人信息
        [ChildActionOnly]
        public ActionResult PartialInfo(string username)
        {
            UserViewModel model = new UserViewModel();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserName='" + username + "'");
            foreach (DataRow dr in dt.Rows)
            {
                UserDto dto = new UserDto();
                dto = UserMapping.getDTO(dr);
                model.UserId = dto.UserId;
                model.UserName = dto.UserName;
                model.UserRoles = MyService.RolesIdToRolesName(dto.UserRoles);
                model.UserEmail = dto.UserEmail;
                model.UserTelephone = dto.UserTelephone;
                model.UserStatus = dto.UserStatus;
                model.UserRegisterTime = dto.UserRegisterTime;


            }
            return View(model);

        }
        // 用户信息
        public ActionResult UserInfo()
        {
            return View();
        }
        // 编辑权限
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
        // 编辑权限动作
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
        // 新增用户
        public ActionResult Create()
        {
            return View();
        }

        // 新增用户动作
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
                dto.UserRoles = "45";
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
        // 删除用户
        public ActionResult Delete(int id)
        {
            Message msg = CMSService.Delete("User", "CMSUser", "UserId=" + id);
            msg.MessageInfo = "数据删除操作成功";
            return RedirectTo("/User/Index", msg.MessageInfo);
        }
        // 重置密码
        public ActionResult ResetPassword(int id)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            model.UserId = id;
            return View(model);
        }
        // 重置密码动作
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
        
       
    }
}
