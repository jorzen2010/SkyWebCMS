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
    public class ImageController : BaseController
    {
        //
        // GET: /Image/
        public ActionResult Index(int ? p)
        {
            Pager pager = new Pager();
            pager.table = "CMSImage";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "ImageId";
            pager.FiledOrder = "ImageId Desc";
            pager = CMSService.SelectAll("Image", pager);

            List<ImageDto> list = new List<ImageDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                ImageDto dto = ImageMapping.getDTO(dr);
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
        // GET: /Image/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Image/Create
        public ActionResult Create()
        {

            ViewData["Category"] = MyService.GetCategorySelectList("CategoryParentId=6");

            return View();
        }

        //
        // POST: /Image/Create
        [HttpPost]
        public ActionResult Create(ImageModel model)
        {
           
                ImageDto dto = new ImageDto();

                dto.ImageTitle = model.ImageTitle;
                if (String.IsNullOrEmpty(model.ImageUrl))
                {
                    ViewBag.status = "Error";
                    ViewBag.msg = "图片不能为空";
                    DataTable dt = CMSService.SelectSome("Category", "CMSCategory", "CategoryParentId=6");
                    List<SelectListItem> items = new List<SelectListItem>();
                    //List<CategoryDto> list = new List<CategoryDto>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        CategoryDto categoryDto = CategoryMapping.getDTO(dr);
                        items.Add(new SelectListItem { Text = categoryDto.CategoryName, Value = categoryDto.CategoryId.ToString() });

                        // list.Add(dto);


                    }
                    ViewData["Category"] = items;
                    return View();
                }
                else
                {
                    dto.ImageUrl = model.ImageUrl;
                }
                dto.ImageHref = model.ImageHref;
                dto.ImageDescription = model.ImageDescription;
                dto.ImageCategory = model.ImageCategory;
                dto.ImageStatus = false;
               

                string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
                Message msg = CMSService.Insert("Image", JsonString);
                return RedirectTo("/Image/Index", msg.MessageInfo); 

          
        }

        //
        // GET: /Image/Edit/5
        public ActionResult Edit(int id)
        {
            ImageModel model = new ImageModel();
            DataTable dt = CMSService.SelectOne("Image", "CMSImage", "ImageId=" + id);
            foreach (DataRow dr in dt.Rows)
            {
                ImageDto dto = new ImageDto();
                dto = ImageMapping.getDTO(dr);
                model.ImageId = dto.ImageId;
                model.ImageUrl = dto.ImageUrl;
                model.ImageHref = dto.ImageHref;
                model.ImageTitle = dto.ImageTitle;
                model.ImageDescription = dto.ImageDescription;
                model.ImageCategory = dto.ImageCategory;
            }
            ViewData["Category"] = MyService.GetCategorySelectList("CategoryParentId=6");
            return View(model);
        }

        //
        // POST: /Image/Edit/5
        [HttpPost]
        public ActionResult Edit(ImageModel model)
        {
            ImageDto dto = new ImageDto();
            DataTable dt = CMSService.SelectOne("Image", "CMSImage", "ImageId=" + model.ImageId);
            foreach (DataRow dr in dt.Rows)
            {

                dto = ImageMapping.getDTO(dr);
                dto.ImageId = model.ImageId;
                dto.ImageTitle = model.ImageTitle;
                dto.ImageUrl = model.ImageUrl;
                dto.ImageHref = model.ImageHref;
                dto.ImageCategory = model.ImageCategory;
                dto.ImageDescription = model.ImageDescription;
                dto.ImageStatus = model.ImageStatus;


            }
            string JsonString = JsonHelper.JsonSerializerBySingleData(dto);
            Message msg = CMSService.Update("Image", JsonString);
            // TODO: Add update logic here

            return RedirectToAction("Index");
        }

        //
        // GET: /Image/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Message msg = CMSService.Delete("Image", "CMSImage", "ImageId=" + id);
                msg.MessageInfo = "数据删除操作成功";
                return RedirectTo("/Image/Index", msg.MessageInfo);
            }
            catch
            {
                return View();
            }
        }

       
    }
}
