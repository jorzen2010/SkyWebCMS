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
using SkyWebCMS.Models;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Controllers
{
    public class XueyaJianceController : BaseController
    {
        //
        // GET: /Xueya/
        public ActionResult Index(int? p)
        {
            Pager pager = new Pager();
            pager.table = "CMSXueya";
            pager.strwhere = "1=1";
            pager.PageSize = 30;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "XueyaId";
            pager.FiledOrder = "XueyaId Desc";
            pager = CMSService.SelectAll("Xueya", pager);

            List<XueyaDto> list = new List<XueyaDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                XueyaDto dto = XueyaMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
          //  ViewBag.CustomerId = id;
            //ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);

            return View(pager.Entity);
        }

   
    }
}
