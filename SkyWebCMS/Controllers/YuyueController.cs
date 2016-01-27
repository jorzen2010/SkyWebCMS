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
    public class YuyueController : Controller
    {
        //
        // GET: /Yuyue/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Yuyue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Yuyue/Create
        public ActionResult Create()
        {
            ViewData["Doctor"] = MyService.GetUserSelectList("charindex('47',UserRoles)>0");
            return View();
        }

        //
        // POST: /Yuyue/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
