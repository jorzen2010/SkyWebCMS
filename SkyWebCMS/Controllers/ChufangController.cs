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
    public class ChufangController : BaseController
    {
        //
        // GET: /Chufang/
        public ActionResult Index(int? p, int id)
        {
            Pager pager = new Pager();
            pager.table = "CMSChufang";
            pager.strwhere = "ChufangCustomerId=" + id;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "ChufangId";
            pager.FiledOrder = "ChufangId Desc";
            pager = CMSService.SelectAll("Chufang", pager);

            List<ChufangDto> list = new List<ChufangDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                ChufangDto dto = ChufangMapping.getDTO(dr);
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
        // GET: /Chufang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Chufang/Create
        public ActionResult Create(int id)
        {
            ChufangAddViewModel model = new ChufangAddViewModel();
            model.ChufangCustomerId = id;
            ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);
            return View(model);
        }

        //
        // POST: /Chufang/Create
        [HttpPost]
        public ActionResult Create(ChufangAddViewModel model)
        {
            try
            {
                ChufangDto dto = new ChufangDto();
                dto.ChufangChuzhi = model.ChufangChuzhi;
                dto.ChufangZhenduan = model.ChufangZhenduan;
                dto.ChufangYongyao=model.ChufangYongyao;
                dto.ChufangCustomerId = model.ChufangCustomerId;
                dto.ChufangTime = System.DateTime.Now;
                if (string.IsNullOrEmpty(model.ChufangImg))
                {
                    dto.ChufangImg = "";
                }
                else
                { 
                dto.ChufangImg = model.ChufangImg;
                }

                dto.ChufangDoctor = int.Parse(System.Web.HttpContext.Current.Request.Cookies["UserId"].Value);
                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Chufang", JsonString);
                return RedirectTo("/Chufang/Index/" + dto.ChufangCustomerId, msg.MessageInfo); 

            }
            catch
            {
                Message msg = new Message();
                msg.MessageInfo = "上传图片好像出错了";

                return RedirectTo("/Chufang/Create/" + model.ChufangCustomerId, msg.MessageInfo); 
            }
        }

        //
        // GET: /Chufang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Chufang/Edit/5
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
        // GET: /Chufang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Chufang/Delete/5
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
