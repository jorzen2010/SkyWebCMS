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
    public class CategoryController : BaseController
    {
        //
        // GET: /Category/
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

        //
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create
        public ActionResult Create(int  CategoryParentId,string CategoryParentName)
        {
            CreateCategoryViewModel model = new CreateCategoryViewModel();
            model.CategoryParentId = CategoryParentId;
            model.CategoryParentName = CategoryParentName;
            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel model)
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

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(int id,string CategoryParentName)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            DataTable dt = CMSService.SelectOne("Category", "CMSCategory", "CategoryId=" + id);
            foreach (DataRow dr in dt.Rows)
            {
                CategoryDto dto = new CategoryDto();
                dto = CategoryMapping.getDTO(dr);
                model.CategoryName = dto.CategoryName;
                model.CategoryDescription = dto.CategoryDescription;
                model.CategoryParentId = dto.CategoryParentId;
                model.CategoryParentName = CategoryParentName;

            }

            return View(model);
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            try
            {
                CategoryDto dto = new CategoryDto();
                DataTable dt = CMSService.SelectOne("Category", "CMSCategory", "CategoryId=" + model.CategoryId);
                foreach (DataRow dr in dt.Rows)
                {

                    dto = CategoryMapping.getDTO(dr);
                    dto.CategoryName = model.CategoryName;
                    dto.CategoryDescription = model.CategoryDescription;
                    dto.CategoryParentId = model.CategoryParentId;
                }
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Update("Category", JsonString);
                // TODO: Add update logic here

                return RedirectToAction("Index");

                
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5
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
    }
}
