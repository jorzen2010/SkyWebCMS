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
    public class JixiaoController : BaseController
    {
        //
        // GET: /Jixiao/
        public ActionResult Index()
        {
            return View();
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
            model.JixiaoUser = "zheshi";
            ViewData["ParentCategory"] = MyService.GetCategorySelectList("CategoryParentId=11");
            ViewData["Category"] = MyService.GetCategorySelectList("CategoryParentId=12");
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
            dto.JixiaoStatus = "待审核";
            dto.JixiaoTime = System.DateTime.Now;
          //  dto.JixiaoFenshu = 5.65;
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
