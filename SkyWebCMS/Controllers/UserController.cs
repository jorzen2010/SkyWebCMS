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
                dto.UserRoles = "0";
                dto.UserStatus = true;


                string userJsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("User", userJsonString);
                return RedirectTo("/User/Index", msg.MessageInfo); 
            }
            catch
            {
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

        //
        // POST: /User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
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
