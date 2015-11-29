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
    public class JianyanController : BaseController
    {
        //
        // GET: /Jianyan/
        public ActionResult Index(int? p, int id)
        {
            Pager pager = new Pager();
            pager.table = "CMSJianyan";
            pager.strwhere = "JianyanCustomerId=" + id;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "JianyanId";
            pager.FiledOrder = "JianyanId Desc";
            pager = CMSService.SelectAll("Jianyan", pager);

            List<JianyanDto> list = new List<JianyanDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                JianyanDto dto = JianyanMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewBag.CustomerId = id;

            return View(pager.Entity);
        }

        //
        // GET: /Jianyan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Jianyan/Create
        public ActionResult Create(int id)
        {
            ViewData["Category"] = MyService.GetCategorySelectList("CategoryParentId=40");
            JianyanAddViewModel model = new JianyanAddViewModel();
            model.JianyanCustomerId = id;
            return View(model);
        }

        //
        // POST: /Jianyan/Create
        [HttpPost]
        public ActionResult Create(JianyanAddViewModel model)
        {
            try
            {
                JianyanDto dto = new JianyanDto();
                dto.JianyanCategory = model.JianyanCategory;
                dto.JianyanImg = model.JianyanImg;
                dto.JianyanDescription = model.JianyanDescription;
                dto.JianyanCustomerId = model.JianyanCustomerId;
                dto.JianyanTime = System.DateTime.Now;

                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Jianyan", JsonString);
                return RedirectTo("/Jianyan/Index/" + dto.JianyanCustomerId, msg.MessageInfo); 
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Jianyan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Jianyan/Edit/5
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
        // GET: /Jianyan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Jianyan/Delete/5
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
