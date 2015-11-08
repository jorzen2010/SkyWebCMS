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
    public class RoleController : BaseController
    {
        //
        // GET: /Role/
        public ActionResult Index(int? p)
        {
            Pager pager = new Pager();
            pager.table = "CMSRole";
            pager.strwhere = "1=1";
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "RoleId";
            pager.FiledOrder = "RoleId Desc";
            pager = CMSService.SelectAll("Role", pager);

            List<RoleDto> list = new List<RoleDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                RoleDto dto = RoleMapping.getDTO(dr);
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
        // GET: /Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Role/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Role/Create
        [HttpPost]
        public ActionResult Create(CreateRoleViewModel model)
        {
            try
            {
                RoleDto dto = new RoleDto();

                dto.RoleName = model.RoleName;
                dto.RoleDescription = model.RoleDescription;



                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Role", JsonString);
                return RedirectTo("/Role/Index", msg.MessageInfo); 
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Role/Edit/5
        public ActionResult Edit(int id)
        {
            EditRoleViewModel model = new EditRoleViewModel();
            DataTable dt = CMSService.SelectOne("Role", "CMSRole", "RoleId=" + id);
            foreach (DataRow dr in dt.Rows)
            {
                RoleDto dto = new RoleDto();
                dto = RoleMapping.getDTO(dr);
                model.RoleName = dto.RoleName;
                model.RoleDescription = dto.RoleDescription;
                model.RoleId = dto.RoleId;
                
            }

            return View(model);
        }

        //
        // POST: /Role/Edit/5
        [HttpPost]
        public ActionResult Edit(EditRoleViewModel model)
        {
            
                RoleDto dto = new RoleDto();
                DataTable dt = CMSService.SelectOne("Role", "CMSRole", "RoleId=" + model.RoleId);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    dto = RoleMapping.getDTO(dr);
                    dto.RoleName = model.RoleName;
                    dto.RoleDescription = model.RoleDescription;
                }
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Update("Role", JsonString);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            
        }

        //
        // GET: /Role/Delete/5
        public ActionResult Delete(int id)
        {
            RoleDto dto = new RoleDto();
            DataTable dt = CMSService.SelectOne("Role", "CMSRole", "RoleId=" + id);
            foreach(DataRow dr in dt.Rows)
            {
                dto = RoleMapping.getDTO(dr);
            }
            string strwhere = "CHARINDEX('"+dto.RoleName+"', UserRoles)>0";
            DataTable userdt = CMSService.SelectSome("User", "CMSUser", strwhere);

            Message msg = new Message();
            if (userdt.Rows.Count > 0)
            {
                msg.MessageInfo = "此角色还有"+userdt.Rows.Count+"条相关数据，不允许删除";
                return RedirectTo("/Role/Index", msg.MessageInfo);
            }
            else
            { 
            msg=CMSService.Delete("Role", "CMSRole", "RoleId=" + id);
            msg.MessageInfo = "数据删除操作成功" ;
            return RedirectTo("/Role/Index", msg.MessageInfo);
            }
            
        }

       
       
    }
}
