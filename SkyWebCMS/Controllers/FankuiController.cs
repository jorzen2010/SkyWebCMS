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
    public class FankuiController : BaseController
    {
        //
        // GET: /Fankui/
        public ActionResult Index(int? p, int id)
        {
            Pager pager = new Pager();
            pager.table = "CMSFankui";
            pager.strwhere = "FankuiCustomerId=" + id;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "FankuiId";
            pager.FiledOrder = "FankuiId Desc";
            pager = CMSService.SelectAll("Fankui", pager);

            List<FankuiDto> list = new List<FankuiDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                FankuiDto dto = FankuiMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewBag.CustomerId = id;
            ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);
            return View(pager.Entity);
        }

        //
        // GET: /Fankui/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Fankui/Create
           
         public ActionResult Create(int id)
         {
             FankuiAddViewModel model = new FankuiAddViewModel();
             ViewData["FankuiCategory"] = MyService.GetCategorySelectList("CategoryParentId=44");
             ViewData["Source"] = MyService.GetCategorySelectList("CategoryParentId=50");
             model.FankuiCustomerId = id;
             ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);
             return View(model);
         }
        //
        // POST: /Fankui/Create
        [HttpPost]
         public ActionResult Create(FankuiAddViewModel model)
        {
            try
            {
                FankuiDto dto = new FankuiDto();
                dto.FankuiResult = model.FankuiResult;
                dto.FankuiSource = model.FankuiSource;
                dto.FankuiDescription = model.FankuiDescription;
                dto.FankuiSendTime = System.DateTime.Now;
                dto.FankuiTime = System.DateTime.Now;
                dto.FankuiStatus = "已查看";
                dto.FankuiCustomerId = model.FankuiCustomerId;
                dto.FankuiDoctor = int.Parse(System.Web.HttpContext.Current.Request.Cookies["UserId"].Value);
                // TODO: Add insert logic here
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Fankui", JsonString);
                return RedirectTo("/Fankui/Index/" + model.FankuiCustomerId, msg.MessageInfo); 
               // return RedirectToAction("Index");
            }
            catch
            {
                Message msg = new Message();
                msg.MessageInfo = "插入操作失败了，请检查是否输入错误";

                return RedirectTo("/Fankui/Create/" + model.FankuiCustomerId, msg.MessageInfo); 
            }
        }

        //
        // GET: /Fankui/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Fankui/Edit/5
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
        // GET: /Fankui/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Fankui/Delete/5
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
