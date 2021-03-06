﻿using System.Collections.Generic;
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
    public class JixiaoController : BaseController
    {
        //
        // GET: /Jixiao/
        public ActionResult Baobiao()
        {
            int NowYear = int.Parse(System.DateTime.Now.Year.ToString());
            ViewBag.year = NowYear;
            ViewBag.month = int.Parse(System.DateTime.Now.Month.ToString());
            ViewData["Users"] = MyService.GetUserList("1=1");
            
            return View();
        
        }
        public ActionResult Index(int? p)
        {
            Pager pager = new Pager();
            pager.table = "CMSJixiao";
            pager.strwhere = "1=1";
            pager.PageSize = 20;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "JixiaoId";
            pager.FiledOrder = "JixiaoId Desc";
            pager = CMSService.SelectAll("Jixiao", pager);

            List<JixiaoDto> list = new List<JixiaoDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                JixiaoDto dto = JixiaoMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewBag.ZongCount = CMSService.GetSomeValue("Jixiao", "CMSJixiao", "1=1", "Count(JixiaoId)");
            ViewBag.ShenheCount = CMSService.GetSomeValue("Jixiao", "CMSJixiao", "JixiaoStatus='已审核'", "Count(JixiaoId)");
            ViewBag.WeishenheCount = CMSService.GetSomeValue("Jixiao", "CMSJixiao", "JixiaoStatus='未通过'", "Count(JixiaoId)");
            ViewBag.ZongFenshu = CMSService.GetSomeValue("Jixiao", "CMSJixiao", "1=1", "SUM(JixiaoFenshu)");
            ViewBag.ShenheFenshu = CMSService.GetSomeValue("Jixiao", "CMSJixiao", "JixiaoStatus='已审核'", "SUM(JixiaoFenshu)");
            ViewBag.WeishenheFenshu = CMSService.GetSomeValue("Jixiao", "CMSJixiao", "JixiaoStatus='未通过'", "SUM(JixiaoFenshu)"); 
            ViewData["Month"] =CommonTools.GetMontList();

            return View(pager.Entity);
        }

        //
        // GET: /Jixiao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Jixiao/Create
        public ActionResult Create()
        {
            JixiaoModel model = new JixiaoModel();
            model.JixiaoUser = System.Web.HttpContext.Current.Request.Cookies["UserId"].Value;
            ViewData["ParentCategory"] = MyService.GetCategorySelectBlankList("CategoryParentId=11");
            ViewData["Category"] = MyService.GetCategorySelectBlankList("CategoryParentId=12");
            return View(model);
        }

        //
        // POST: /Jixiao/Create
        [HttpPost]
        public ActionResult Create(JixiaoModel model)
        {
            JixiaoDto dto = new JixiaoDto();
           
           
            dto.JixiaoUser = model.JixiaoUser;
            dto.JixiaoForUser = model.JixiaoForUser;
            dto.JixiaoCategory = model.JixiaoCategory;
            dto.JixiaoParentCategory = model.JixiaoParentCategory;
            dto.JixiaoRenwu = model.JixiaoRenwu;
            dto.JixiaoStatus = "已审核";
            dto.JixiaoTime = System.DateTime.Now;
            dto.JixiaoFenshu = MyService.GetFenshuByCategory(model.JixiaoCategory);
            dto.JixiaoShenheTime = System.DateTime.Now;


            string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
            Message msg = CMSService.Insert("Jixiao", JsonString);
            return RedirectTo("/Jixiao/Index", msg.MessageInfo); 
        }

        //
        // GET: /Jixiao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Jixiao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Jixiao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Jixiao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
