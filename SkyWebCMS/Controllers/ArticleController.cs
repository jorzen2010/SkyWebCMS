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
    public class ArticleController : BaseController
    {
        //
        // GET: /Article/
        public ActionResult Index(int ? p)
        {
            Pager pager = new Pager();
            pager.table = "CMSArticle";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "ArticleId";
            pager.FiledOrder = "ArticleId Desc";
            pager = CMSService.SelectAll("Article", pager);

            List<ArticleDto> list = new List<ArticleDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                ArticleDto dto = ArticleMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;

            return View(pager.Entity);
        }

        //
        // GET: /Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Article/Create
        public ActionResult Create()
        {
            ViewData["Category"] = MyService.GetCategorySelectList("CategoryParentId=1");
            return View();
        }

        //
        // POST: /Article/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(ArticleModel model)
        {
            try{
           
                ArticleDto dto = new ArticleDto();

                dto.ArticleTitle = model.ArticleTitle;
                dto.ArticleContent = model.ArticleContent;
                dto.ArticleKeywords = model.ArticleKeywords;
                dto.ArticleDescription = model.ArticleDescription;
                dto.ArticleCategory = model.ArticleCategory;
                dto.ArticleAuthor = model.ArticleTitle;
                dto.ArticleEditor = "系统自动进入";
                if (String.IsNullOrEmpty(model.ArticleImg))
                {
                    model.ArticleImg = "";
                    dto.ArticleImg = model.ArticleImg;
                }
                dto.ArticleClassic = model.ArticleClassic;
                dto.ArticleTop = model.ArticleTop;
                dto.ArticleHot = model.ArticleHot;
                dto.ArticleTime = System.DateTime.Now;

                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Article", JsonString);
                return RedirectTo("/Article/Index", msg.MessageInfo);
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

        //
        // GET: /Article/Edit/5
        public ActionResult Edit(int id)
        {
            ArticleModel model = new ArticleModel();
            DataTable dt = CMSService.SelectOne("Article", "CMSArticle", "ArticleId=" + id);
            foreach (DataRow dr in dt.Rows)
            {
                ArticleDto dto = new ArticleDto();
                dto = ArticleMapping.getDTO(dr);
                model.ArticleId = dto.ArticleId;
                model.ArticleTitle = dto.ArticleTitle;
                model.ArticleContent = dto.ArticleContent;
                model.ArticleKeywords = dto.ArticleKeywords;
                model.ArticleDescription = dto.ArticleDescription;
                model.ArticleCategory = dto.ArticleCategory;
                model.ArticleAuthor = dto.ArticleTitle;
                model.ArticleEditor = dto.ArticleEditor;
                model.ArticleImg = dto.ArticleImg;
                model.ArticleClassic = dto.ArticleClassic;
                model.ArticleTop = dto.ArticleTop;
                model.ArticleHot = dto.ArticleHot;
                model.ArticleTime = dto.ArticleTime;
            }

            ViewData["Category"] = MyService.GetCategorySelectList("CategoryParentId=1");
            return View(model);
        }

        //
        // POST: /Article/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(ArticleModel model)
        {
            ArticleDto dto = new ArticleDto();
            DataTable dt = CMSService.SelectOne("Article", "CMSArticle", "ArticleId=" + model.ArticleId);
            foreach (DataRow dr in dt.Rows)
            {

                dto = ArticleMapping.getDTO(dr);
                dto.ArticleId = model.ArticleId;
                dto.ArticleTitle = model.ArticleTitle;
                dto.ArticleContent = model.ArticleContent;
                dto.ArticleKeywords = model.ArticleKeywords;
                dto.ArticleDescription = model.ArticleDescription;
                dto.ArticleCategory = model.ArticleCategory;
                dto.ArticleAuthor = model.ArticleTitle;
                dto.ArticleEditor = "系统自动进入";
                if (String.IsNullOrEmpty(model.ArticleImg))
                {
                    model.ArticleImg = "";
                    dto.ArticleImg = model.ArticleImg;
                }
                dto.ArticleClassic = model.ArticleClassic;
                dto.ArticleTop = model.ArticleTop;
                dto.ArticleHot = model.ArticleHot;
                dto.ArticleTime = System.DateTime.Now;
               
            }
            string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
            Message msg = CMSService.Update("Article", JsonString);
            // TODO: Add update logic here

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            try
            {
                Message msg = CMSService.Delete("Article", "CMSArticle", "ArticleId=" + id);
                msg.MessageInfo = "数据删除操作成功";
                return RedirectTo("/Article/Index", msg.MessageInfo);
           
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
