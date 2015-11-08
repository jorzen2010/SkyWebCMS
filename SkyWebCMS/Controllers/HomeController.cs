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
    public class HomeController : BaseController
    {
        
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About()
        {
            


            return View();
        }

        public ActionResult Contact(int?p)
        {

            Pager pager = new Pager();
            pager.table = "CMSUser";
            pager.strwhere = "1=1";
            pager.PageSize = 3;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "UserId";
            pager.FiledOrder = "UserId Desc";
            pager = CMSService.SelectAll("User",pager);

            List<UserDto> Listusers = new List<UserDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
               UserDto userDto= UserMapping.getDTO(dr);
               Listusers.Add(userDto);

            
            }
            pager.Entity = Listusers.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewBag.Message = pager.Amount;

            return View(pager.Entity);
        }

        public ActionResult SelectOne()
        {
            UserDto userDto = new UserDto();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", "1=1");
            foreach (DataRow dr in dt.Rows)
            {
                userDto = UserMapping.getDTO(dr);
            }


            return View(userDto);
        }

        public ActionResult SelectSome()
        {
            
            DataTable dt = CMSService.SelectSome("User", "CMSUser", "UserId>15");
          
            List<UserDto> Listusers = new List<UserDto>();
            foreach (DataRow dr in dt.Rows)
            {
                UserDto userDto = UserMapping.getDTO(dr);
                Listusers.Add(userDto);


            }
            return View(Listusers);
        }
    }
}