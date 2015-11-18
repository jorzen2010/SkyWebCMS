using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Drawing;
using Bll;
using System.IO;

namespace SkyWebCMS.Controllers
{
    public class LiangbiaoController : Controller
    {
        //
        // GET: /Liangbiao/
         [ValidateInput(false)]
        public ActionResult Index(string id)
        {
            ViewBag.id = id;
            return View();
        }

        //
        // GET: /Liangbiao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Test()
        {
           string base64ImgString = Request["a"]; ;
           string[] u = base64ImgString.Split(',');
           string imgstr = u[1];

           string filename = "/tizhiresult/" + CommonTools.ToUnixTime(System.DateTime.Now).ToString() + CommonTools.getRandomNumber() +".png";
           FileTools.Base64StringToImage(imgstr, filename);

           return Content("成功了");
        }

        //
        // GET: /Liangbiao/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Liangbiao/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string tizhi = collection["1"] + "," +
                    collection["2"] + "," +
                    collection["3"] + "," + 
                    collection["4"] + "," + 
                    collection["5"] + "," + 
                    collection["6"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Liangbiao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Liangbiao/Edit/5
        [HttpPost]
        public ActionResult Edit()
        {
            if (Request.Files.Count > 0 && Request.Files[0] != null && !string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                string fileName = CMSService.Uploadfiles("fsf", Request.Files[0]);
                return Content(fileName);
            }
            else
            {
                return Content("图片是空的");
            }
        }

        //
        // GET: /Liangbiao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Liangbiao/Delete/5
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
