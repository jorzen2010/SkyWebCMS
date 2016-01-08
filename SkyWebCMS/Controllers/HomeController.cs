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
            int CustomerCount = CMSService.GetSomeValue("CustomerDto", "CMSCustomer", "1=1", "Count(CustomerId)");
            int JianyanCount = CMSService.GetSomeValue("JianyanDto", "CMSJianyan", "1=1", "Count(JianyanId)");
            int ChufangCount = CMSService.GetSomeValue("ChufangDto", "CMSChufang", "1=1", "Count(ChufangId)");
            int TizhiCount = CMSService.GetSomeValue("TizhiDto", "CMSTizhi", "1=1", "Count(TizhiId)");
            int XueyaCount = CMSService.GetSomeValue("XueyaDto", "CMSXueya", "1=1", "Count(XueyaId)");
            float JixiaoCount = CMSService.GetSomeValue("JixiaoDto", "CMSJixiao", "1=1", "Count(JixiaoId)");
            float JixiaoPassCount = CMSService.GetSomeValue("JixiaoDto", "CMSJixiao", "JixiaoStatus='已审核'", "Count(JixiaoId)");
            float JixiaoPersent =(JixiaoPassCount / JixiaoCount) * 100;
            



            ViewBag.CustomerCount = CustomerCount;
            ViewBag.JianyanCount = JianyanCount;
            ViewBag.ChufangCount = ChufangCount;
            ViewBag.TizhiCount = TizhiCount;
            ViewBag.XueyaCount = XueyaCount;
            ViewBag.JixiaoCount = JixiaoCount;
            ViewBag.JixiaoPassCount = JixiaoPassCount;
            ViewBag.JixiaoPersent = JixiaoPersent.ToString() + "%";
            return View();
            //return RedirectToAction("Index","Customer", new { category = "全部", guidang = "0" });
        }
        
    }
}