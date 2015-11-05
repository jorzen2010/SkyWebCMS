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
        public ActionResult UserList(int?p)
        {
            Pager pager = new Pager();
            pager.table = "CMSUser";
            pager.strwhere = "1=1";
            pager.PageSize = 3;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "UserId";
            pager.FiledOrder = "UserId Desc";
            pager = CMSService.SelectAll("User", pager);

            List<UserDto> Listusers = new List<UserDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                UserDto userDto = UserMapping.getDTO(dr);
                Listusers.Add(userDto);


            }
            pager.Entity = Listusers.AsQueryable();


            ViewBag.Message = pager.Amount;

            return View(pager.Entity);
        }
     
    }
}