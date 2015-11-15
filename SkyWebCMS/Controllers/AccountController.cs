using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SkyWebCMS.Models;

namespace SkyWebCMS.Controllers
{
    
    public class AccountController : Controller
    {
       
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return RedirectToAction("Login", "User", new { ac = "RoleError" });
        }

       
    }
}