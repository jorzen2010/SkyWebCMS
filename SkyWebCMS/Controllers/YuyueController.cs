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
    public class YuyueController : BaseController
    {
        //
        // GET: /Yuyue/
        public ActionResult Index(int? p, int? id)
        {
            Pager pager = new Pager();
            pager.table = "CMSYuyue";
            pager.strwhere = "1=1";
            if (id != 0)
            {
                pager.strwhere = pager.strwhere + "YuyueDoctorId=" + id;
            }
           // pager.strwhere = "YuyueCustomerId=" + id;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "YuyueId";
            pager.FiledOrder = "YuyueDateTime Desc";
            pager = CMSService.SelectAll("Yuyue", pager);

            List<YuyueDto> list = new List<YuyueDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                YuyueDto dto = YuyueMapping.getDTO(dr);
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

        public ActionResult List(int? p)
        {
            int DoctorId = int.Parse(System.Web.HttpContext.Current.Request.Cookies["UserId"].Value);
            Pager pager = new Pager();
            pager.table = "CMSYuyue";
           
            pager.strwhere = " YuyueDoctorId=" + DoctorId;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "YuyueId";
            pager.FiledOrder = "YuyueDateTime Desc";
            pager = CMSService.SelectAll("Yuyue", pager);

            List<YuyueDto> list = new List<YuyueDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                YuyueDto dto = YuyueMapping.getDTO(dr);
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
        // GET: /Yuyue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Yuyue/Create
        public ActionResult Create(int id)
        {

            YuyueAddViewModel model = new YuyueAddViewModel();
            model.YuyueCustomerId = id;
            model.YuyueCustomerName = MyService.CustomerIdToName("CustomerId=" + id);
            ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);
            ViewData["Doctor"] = MyService.GetUserSelectList("charindex('47',UserRoles)>0");
            return View(model);
        }

        //
        // POST: /Yuyue/Create
        [HttpPost]
        public ActionResult Create(YuyueAddViewModel model)
        {
            try
            {
                YuyueDto dto = new YuyueDto();
                dto.YuyueCustomerId = model.YuyueCustomerId;
                dto.YuyueDoctorId = model.YuyueDoctorId;
                dto.YuyueDateTime = model.YuyueTime;
                dto.YuyueDescription = model.YuyueDescription;
                dto.YuyueStatus = "待诊";

                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Yuyue", JsonString);

                return RedirectTo("/Yuyue/Index/0", msg.MessageInfo); 

            }
            catch
            {
                Message msg = new Message();
                msg.MessageInfo="预约出问题了";
                return RedirectTo("/Yuyue/Create/"+model.YuyueCustomerId, msg.MessageInfo); 
            }
        }

        //
        // GET: /Yuyue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Yuyue/Edit/5
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
        // GET: /Yuyue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Yuyue/Delete/5
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
