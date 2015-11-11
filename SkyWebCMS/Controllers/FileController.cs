using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll;
using Newtonsoft.Json;

namespace SkyWebCMS.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/
        public ActionResult Upload(string folder)
        {
            if (Request.Files.Count > 0 && Request.Files[0] != null && !string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                try
                {
                    string fileName = CMSService.Uploadfiles(folder, Request.Files[0]);

                    var a = new { success = true, file = fileName, url = fileName };


                    return Content(JsonConvert.SerializeObject(a));
                }
                catch (Exception ex)
                {
                    var b = new { success = false, msg = ex.Message };
                    return Content(JsonConvert.SerializeObject(b));
                }
            }
            var c = new { success = false, msg = "未选择文件" };
            return Content(JsonConvert.SerializeObject(c));
        }
	}
}