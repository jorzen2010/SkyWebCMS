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
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Controllers
{
     [CMSAuth(Roles = "普通管理员")] 
    public class CategoryController : BaseController
    {
        
        // Category列表
        public ActionResult Index(int? p, int id, string CategoryParentName)
        {
            Pager pager = new Pager();
            pager.table = "CMSCategory";
            pager.strwhere = "CategoryParentId="+id;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "CategoryId";
            pager.FiledOrder = "CategoryId Desc";
            pager = CMSService.SelectAll("Category", pager);

            List<CategoryDto> list = new List<CategoryDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                CategoryDto dto = CategoryMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewBag.CategoryParentName = CategoryParentName;
            return View(pager.Entity);

        }


        // Category详情页
        public ActionResult Details(int id)
        {
            return View();
        }

        
        // 新增Category视图
        public ActionResult Create(int  CategoryParentId,string CategoryParentName)
        {
            CategoryModel model = new CategoryModel();
            model.CategoryParentId = CategoryParentId;
            model.CategoryParentName = CategoryParentName;
            return View();
        }

        // 新增Category操作
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            try
            {
                CategoryDto dto = new CategoryDto();

                dto.CategoryName = model.CategoryName;
                dto.CategoryDescription = model.CategoryDescription;
                dto.CategoryParentId = model.CategoryParentId;



                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Category", JsonString);
                return RedirectTo("/Category/Index/" + model.CategoryParentId + "?CategoryParentName=" + model.CategoryParentName, msg.MessageInfo);
            }
            catch
            {
                Message msg = new Message();
                msg.MessageInfo = "插入操作出错了";
                ViewBag.Status = "Error";
                ViewBag.msg = msg.MessageInfo;
                return View();
            }
        }

        
        // 编辑Category视图
        public ActionResult Edit(int id,string CategoryParentName)
        {
            CategoryModel model = new CategoryModel();
            DataTable dt = CMSService.SelectOne("Category", "CMSCategory", "CategoryId=" + id);
            foreach (DataRow dr in dt.Rows)
            {
                CategoryDto dto = new CategoryDto();
                dto = CategoryMapping.getDTO(dr);
                model.CategoryId = dto.CategoryId;
                model.CategoryName = dto.CategoryName;
                model.CategoryDescription = dto.CategoryDescription;
                model.CategoryParentId = dto.CategoryParentId;
                model.CategoryParentName = CategoryParentName;

            }

            return View(model);
        }

        
        // 编辑Category操作
        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
           
                CategoryDto dto = new CategoryDto();
                DataTable dt = CMSService.SelectOne("Category", "CMSCategory", "CategoryId=" + model.CategoryId);
                foreach (DataRow dr in dt.Rows)
                {

                    dto = CategoryMapping.getDTO(dr);
                    dto.CategoryId = model.CategoryId;
                    dto.CategoryName = model.CategoryName;
                    dto.CategoryDescription = model.CategoryDescription;
                    dto.CategoryParentId = model.CategoryParentId;
                }
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Update("Category", JsonString);
                // TODO: Add update logic here

                return RedirectTo("/Category/Index/" + model.CategoryParentId + "?CategoryParentName=" + model.CategoryParentName, msg.MessageInfo);

                
           
        }

       
        // 删除Category
     
        public ActionResult Delete(int id,string CategoryName)
        {
            try
            {
                CategoryDto dto = new CategoryDto();
                DataTable dt = CMSService.SelectOne("Category", "CMSCategory", "CategoryId=" + id);
                foreach (DataRow dr in dt.Rows)
                {
                    dto = CategoryMapping.getDTO(dr);
                }
                string strwhere = "CategoryParentId="+id;
                DataTable categorydt = CMSService.SelectSome("Category", "CMSCategory", strwhere);

                Message msg = new Message();
                if (categorydt.Rows.Count > 0)
                {
                    msg.MessageInfo = "此角色还有" + categorydt.Rows.Count + "条相关数据，不允许删除";
                    return RedirectTo("/Category/Index/" + dto.CategoryParentId + "?CategoryName=" + CategoryName, msg.MessageInfo);
                }
                else
                {
                    msg = CMSService.Delete("Category", "CMSCategory", "CategoryId=" + id);
                    msg.MessageInfo = "数据删除操作成功";
                    return RedirectTo("/Category/Index/" + dto.CategoryParentId + "?CategoryName=" + CategoryName, msg.MessageInfo);
                }

               
            }
            catch
            {
                return View();
            }
        }
    }
}
