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
    public class XueyaController : BaseController
    {
        //
        // GET: /Xueya/
        public ActionResult Index(int? p, int id)
        {
            Pager pager = new Pager();
            pager.table = "CMSXueya";
            pager.strwhere = "CustomerId=" + id;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "XueyaId";
            pager.FiledOrder = "XueyaId Desc";
            pager = CMSService.SelectAll("Xueya", pager);

            List<XueyaDto> list = new List<XueyaDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                XueyaDto dto = XueyaMapping.getDTO(dr);
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
        // GET: /Xueya/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Xueya/Create
        public ActionResult Create(int id)
        {
            XueyaAddViewModel model = new XueyaAddViewModel();
            model.CustomerId = id;
            ViewData["Weizhi"] = MyService.GetXueyaWeizhiSelectList();
            ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);
            return View(model);
        }

        //
        // POST: /Xueya/Create
        [HttpPost]
        public ActionResult Create(XueyaAddViewModel model)
        {
           
                XueyaDto dto = new XueyaDto();
                dto.XueyaDiya = model.XueyaDiya;
                dto.XueyaGaoya = model.XueyaGaoya;
                dto.XueyaMaibo = model.XueyaMaibo;
                dto.XueyaSId = "XUEYAJISHEBEIHAO";
                dto.XueyaUId = 1;
                dto.CustomerId = model.CustomerId;
                dto.XueyaSource = "医生手动测量";
                dto.XueyaTime = System.DateTime.Now;
                dto.XueyaWeizhi = model.XueyaWeizhi;
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Xueya", JsonString);
               // return RedirectTo("/Customer/Index", msg.MessageInfo);
                return RedirectTo("/Xueya/Index/" + dto.CustomerId, msg.MessageInfo); 

           
        }

        //
        // GET: /Xueya/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Xueya/Edit/5
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
        // GET: /Xueya/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Xueya/Delete/5
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
