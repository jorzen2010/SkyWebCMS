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
        public ActionResult Index(int? p, string  category,string guidang)
        {
            string Category = category ?? "全部";
            string Guidang = guidang ?? "0";
            Pager pager = new Pager();
            pager.table = "CMSCustomer";
            pager.strwhere = "1=1";
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "CustomerId";
            pager.FiledOrder = "CustomerId Desc";

            if (Category !="全部")
            {

                pager.strwhere = pager.strwhere + " and charindex('" + Category + "',CustomerTizhi)>0";

            }
            if (Guidang != "0")
            {

                pager.strwhere = pager.strwhere + " and charindex('" + Guidang + "',CustomerGuidang)>0";

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
            ViewData["Guidang"] = MyService.GetCategoryList("CategoryParentId=30");

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
      
        public ActionResult Guidang(int id)
        {
            CustomerGuidangViewModel model = new CustomerGuidangViewModel();
            DataTable dt = CMSService.SelectOne("Customer", "CMSCustomer", "CustomerId=" + id);
            foreach (DataRow dr in dt.Rows)
            {
                CustomerDto dto = new CustomerDto();
                dto = CustomerMapping.getDTO(dr);
                model.CustomerId = dto.CustomerId;
                model.CustomerName = dto.CustomerName;
                model.CustomerGuidang = dto.CustomerGuidang;

            }
            ViewData["ListGuidang"] = MyService.GetCategoryList("CategoryParentId=30");
            return View(model);
        }
        [HttpPost]
        public ActionResult Guidang(CustomerGuidangViewModel model)
        {
            Message msg = new Message();
            string CustomerGuidang = Request.Form["CustomerGuidang"];
            try
            {
                msg = CMSService.UpdateFieldOneByOne("Customer", "CMSCustomer", "CustomerId=" + model.CustomerId, "CustomerGuidang", CustomerGuidang);
                return RedirectToAction("Index", new { category="全部",guidang="0"});
               // return RedirectTo("/Customer/Index?category=全部&guidang=0", msg.MessageInfo);
            }

            catch
            {

                msg.MessageStatus = "Error";
                msg.MessageInfo = "操作出错了";
                ViewBag.Status = msg.MessageStatus;
                ViewBag.msg = msg.MessageInfo;
                return View();
            }
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
        public ActionResult Create()
        {

            return View();
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
                return RedirectTo("/Customer/Index?category=全部&guidang=0", msg.MessageInfo);
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

        public ActionResult Edit(int id)
        {
            CustomerEditViewModel model = new CustomerEditViewModel();
            DataTable dt = CMSService.SelectSome("Customer", "CMSCustomer", "CustomerId=" + id);
            
            foreach (DataRow dr in dt.Rows)
            {
                CustomerDto dto = CustomerMapping.getDTO(dr);
                model.CustomerName = dto.CustomerName;
                model.CustomerNumber = dto.CustomerNumber;
                model.CustomerBirthday = dto.CustomerBirthday.ToShortDateString();
                model.CustomerSex = dto.CustomerSex;
                model.CustomerId = dto.CustomerId;
                model.CustomerTelephone = dto.CustomerTelephone;
                model.CustomerEmail = dto.CustomerEmail;
                model.CustomerMinzu = dto.CustomerMinzu;
                model.CustomerChangzhu = dto.CustomerChangzhu;
                model.CustomerWenhua = dto.CustomerWenhua;
                model.CustomerHunyin = dto.CustomerHunyin;
                model.CustomerZhiye = dto.CustomerZhiye;
                model.CustomerAddress = dto.CustomerAddress;
                model.CustomerHujiAddress = dto.CustomerHujiAddress;
                model.CustomerXiangzhen = dto.CustomerXiangzhen;
                model.CustomerJuweihui = dto.CustomerJuweihui;
                model.CustomerLianxiren = dto.CustomerLianxiren;
                model.CustomerLianxirenTel = dto.CustomerLianxirenTel;
                model.CustomerBeizhu = dto.CustomerBeizhu;
                model.CustomerYongyao = dto.CustomerYongyao;
                model.CustomerShequ = dto.CustomerShequ;
                model.CustomerDoctor = dto.CustomerDoctor;
                
                
                
            }
            ViewData["CChangzhu"] = CustomerService.GetChangzhuSelectList();
            ViewData["CHunyin"] = CustomerService.GetHunyinSelectList();
            ViewData["CMinzu"] = CustomerService.GetMinzuSelectList();
            ViewData["CZhiye"] = CustomerService.GetZhiyeSelectList();
            ViewData["CWenhua"] = CustomerService.GetWenhuaSelectList();
            ViewData["Category"] = MyService.GetCategorySelectList("CategoryParentId=36");
            ViewData["Doctor"] = MyService.GetUserSelectList("charindex('47',UserRoles)>0");
            return View(model);
        }
	}
}