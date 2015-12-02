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
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Controllers
{
    [CMSAuth(Roles = "普通会员")] 
    public class HomeController : BaseController
    {
       
        public ActionResult Index()
        {


            return RedirectToAction("Index","Customer", new { category = "全部", guidang = "0" });
        }
        
    }
}