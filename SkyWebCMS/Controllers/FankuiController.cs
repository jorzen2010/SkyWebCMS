using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyWebCMS.Controllers
{
    public class FankuiController : Controller
    {
        //
        // GET: /Fankui/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Fankui/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Fankui/Create
         [AllowAnonymous]
        public ActionResult Create(int id)
        {

            return View();
        }

        //
        // POST: /Fankui/Create
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
