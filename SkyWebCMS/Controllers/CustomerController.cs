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
    [CMSAuth(Roles = "普通管理员")]
    public class CustomerController : BaseController
    {
        //
        // GET: /Customer/
        public ActionResult Index(int? p, int? categoryId)
        {
            int CategoryId = categoryId ?? 0;
            Pager pager = new Pager();
            pager.table = "CMSCustomer";
            pager.strwhere = "1=1";
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "CustomerId";
            pager.FiledOrder = "CustomerId Desc";
            
            if (CategoryId > 0)
            {

                pager.strwhere = pager.strwhere + " and charindex('" + CategoryId + "',CustomerTizhi)>0";

            }
            pager = CMSService.SelectAll("Customer", pager);
            List<CustomerDto> list = new List<CustomerDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                CustomerDto dto = CustomerMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewData["Category"] = MyService.GetCategoryList("CategoryParentId=20");

            return View(pager.Entity);

        }

        public ActionResult Daizhen(int? p)
        {
           
            Pager pager = new Pager();
            pager.table = "CMSCustomer";
            pager.strwhere = "1=1";
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "CustomerId";
            pager.FiledOrder = "CustomerId Desc";
            pager.strwhere = pager.strwhere + " and CustomerTizhi='0'";

    
            pager = CMSService.SelectAll("Customer", pager);
            List<CustomerDto> list = new List<CustomerDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                CustomerDto dto = CustomerMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
           

            return View(pager.Entity);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search()
        {
            string CustomerName = Request.Form["CustomerName"].ToString();
            DataTable dt = CMSService.SelectSome("Customer", "CMSCustomer", "CustomerName='" + CustomerName + "'");
            List<CustomerDto> list = new List<CustomerDto>();
            foreach (DataRow dr in dt.Rows)
            {
                CustomerDto dto = CustomerMapping.getDTO(dr);
                list.Add(dto);
            }
            ViewData["Category"] = MyService.GetCategoryList("CategoryParentId=20");
            return View(list);
        }
        [HttpPost]
        public ActionResult Create(CustomerAddViewModel model)
        {
            try
            {
                CustomerDto dto = new CustomerDto();

                dto.CustomerName = model.CustomerName;
                dto.CustomerNumber = model.CustomerNumber;
                dto.CustomerSex = CommonTools.GetSexByVerify(model.CustomerNumber);
                dto.CustomerBirthday = DateTime.Parse(CommonTools.GetBirthdyByVerify(model.CustomerNumber));



                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Customer", JsonString);
                return RedirectTo("/Customer/Index", msg.MessageInfo);
            }
            catch
            {
                Message msg = new Message();
                msg.MessageStatus = "Error";
                msg.MessageInfo = "操作出错了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View();
            }

        }
	}
}