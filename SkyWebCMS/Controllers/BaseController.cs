using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Bll;

namespace SkyWebCMS.Controllers
{
    public class BaseController : Controller
    {
        
        public ActionResult RedirectTo(string action = "Index", string controller = "Home", string message = "")
        {
            ViewBag.Message = message;
            ViewBag.Url = Url.Action(action, controller);
            return View("Redirect");
        }

        public ActionResult RedirectTo(string url, string message = "")
        {
            if (string.IsNullOrEmpty(url))
            {
                url = Url.Action("Index", "Home");
            }
            ViewBag.Message = message;
            ViewBag.Url = url;
            return View("Redirect");
        }
        public JsonResult SetFieldOneByOne(string DtoName, string table, string strwhere, string columnname, string columnvalue)
        {
           
            Message message = new Message();
            message = CMSService.UpdateFieldOneByOne(DtoName,table,strwhere,columnname,columnvalue);
            var json = new
            {
                message.MessageInfo,
                message.MessageStatus,
                message.MessageUrl
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
	}
}