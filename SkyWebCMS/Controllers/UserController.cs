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

namespace SkyWebCMS.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
     
    }
}