using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Drawing;
using Bll;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using SkyWebCMS.Attributes;
using InterfaceMapping;
using Mapping;
using Dto;

namespace SkyWebCMS.Controllers
{
    [CMSAuth(Roles = "普通管理员")] 
    public class TizhiController : Controller
    {
        //
        // GET: /Liangbiao/
         [ValidateInput(false)]
        public ActionResult Index(string id,string cid)
        {
            
            string CustomerName = "";
            string CustomerSex = "";
            string CustomerBirthday = "";
            DataTable dt = CMSService.SelectOne("Customer", "CMSCustomer", "CustomerId=" + cid);
            foreach (DataRow dr in dt.Rows)
            {
                CustomerDto dto = new CustomerDto();
                dto = CustomerMapping.getDTO(dr);
                CustomerName = dto.CustomerName;
                CustomerSex = dto.CustomerSex;
                CustomerBirthday = dto.CustomerBirthday.ToShortDateString();


            }
            string result = id;
            string[] tizhi = result.Split(',');
             int i=0;
             int yangxuzhi = 0;
             for (i = 0; i < 7; i++)
             { 
                 yangxuzhi =yangxuzhi+ int.Parse(tizhi[i]);
             
             }
             int yangxuzhiresult = ((yangxuzhi-7)*100)/(7*4);
            
             int yinxuzhi = 0;
             for (i = 7; i < 15; i++)
             {
                 yinxuzhi = yinxuzhi + int.Parse(tizhi[i]);

             }
             int yinxuzhiresult = ((yinxuzhi - 8) * 100) / (8 * 4);
         
             int qixuzhi = 0;
             for (i = 15; i < 23; i++)
             {
                 qixuzhi = qixuzhi + int.Parse(tizhi[i]);

             }
             int qixuzhiresult = ((yinxuzhi - 8) * 100) / (8 * 4);
            
             int tanshizhi = 0;
             for (i = 23; i < 31; i++)
             {
                 tanshizhi = tanshizhi + int.Parse(tizhi[i]);

             }
             int tanshizhiresult = ((tanshizhi - 8) * 100) / (8 * 4);

             int shirezhi = 0;
             for (i = 31; i < 38; i++)
             {
                 shirezhi = shirezhi + int.Parse(tizhi[i]);
                 

             }
             if (CustomerSex == "男")
             { shirezhi = shirezhi - int.Parse(tizhi[36]); }
             if (CustomerSex == "女")
             { shirezhi = shirezhi - int.Parse(tizhi[37]); }

             //如果是男的减去36项，如果是女的减去37项
             
             int shirezhiresult = ((shirezhi - 6) * 100) / (6 * 4);

             int xueyuzhi = 0;
             for (i = 38; i < 45; i++)
             {
                 xueyuzhi = xueyuzhi + int.Parse(tizhi[i]);

             }
             int xueyuzhiresult = ((xueyuzhi - 7) * 100) / (7 * 4);

             int qiyuzhi = 0;
             for (i = 45; i < 52; i++)
             {
                 qiyuzhi = qiyuzhi + int.Parse(tizhi[i]);

             }
             int qiyuzhiresult = ((qiyuzhi - 7) * 100) / (7 * 4);


             int tebingzhi = 0;
             for (i = 52; i < 59; i++)
             {
                 tebingzhi = tebingzhi + int.Parse(tizhi[i]);

             }
             int tebingzhiresult = ((tebingzhi - 7) * 100) / (7 * 4);


             int pinghezhi = 0;
             for (i = 59; i < 67; i++)
             {
                 pinghezhi = pinghezhi + int.Parse(tizhi[i]);

             }
             int pinghezhiresult = ((pinghezhi - 7) * 100) / (7 * 4);

             string Customertizhi = "";
             if (yangxuzhiresult < 30 && yinxuzhiresult < 30 && qixuzhiresult < 30 && tanshizhiresult < 30 && shirezhiresult < 30 && xueyuzhiresult < 30 && qiyuzhiresult < 30 && tebingzhiresult < 30 && pinghezhiresult > 60)
             {
                 Customertizhi = "平和质";
             }
             else
             { 
             if (yangxuzhiresult >= 40)
             {  Customertizhi += "阳虚质,";}
             if (yinxuzhiresult >= 40)
             { Customertizhi += "阴虚质,"; }
             if (qixuzhiresult >= 40)
             { Customertizhi += "气虚质,"; }
             if (tanshizhiresult >= 40)
             { Customertizhi += "痰湿质,"; }
             if (shirezhiresult >= 40)
             { Customertizhi += "湿热质,"; }
             if (xueyuzhiresult >= 40)
             { Customertizhi += "血瘀质,"; }
             if (qiyuzhiresult >= 40)
             { Customertizhi += "气淤质,"; }
             if (tebingzhiresult >= 40)
             { Customertizhi += "特禀质,"; }
             }
             if (!String.IsNullOrEmpty(Customertizhi))
             { Customertizhi = Customertizhi.Substring(0, Customertizhi.Length - 1); }

             

             string Customerqinxiangtizhi = "";
             if (yangxuzhiresult > 30 && yangxuzhiresult<40)
             { Customerqinxiangtizhi += "阳虚质,"; }
             if (yinxuzhiresult > 30&&yinxuzhiresult<40)
             { Customerqinxiangtizhi += "阴虚质,"; }
             if (qixuzhiresult > 30 && qixuzhiresult < 40)
             { Customerqinxiangtizhi += "气虚质,"; }
             if (tanshizhiresult > 30 && tanshizhiresult < 40)
             { Customerqinxiangtizhi += "痰湿质,"; }
             if (shirezhiresult > 30 && shirezhiresult < 40)
             { Customerqinxiangtizhi += "湿热质,"; }
             if (xueyuzhiresult > 30 && xueyuzhiresult < 40)
             { Customerqinxiangtizhi += "血瘀质,"; }
             if (qiyuzhiresult > 30 && qiyuzhiresult < 40)
             { Customerqinxiangtizhi += "气淤质,"; }
             if (tebingzhiresult > 30 && tebingzhiresult < 40)
             { Customerqinxiangtizhi += "特禀质,"; }
             if (!String.IsNullOrEmpty(Customerqinxiangtizhi))
             { Customerqinxiangtizhi = Customerqinxiangtizhi.Substring(0, Customerqinxiangtizhi.Length - 1); }

             string Danganhao = System.DateTime.Now.ToString("yyyyMMddhhmmss");
             TizhiDto tizhiDto = new TizhiDto();
             tizhiDto.TizhiYangxu = yangxuzhiresult.ToString();
             tizhiDto.TizhiYinxu = yinxuzhiresult.ToString();
             tizhiDto.TizhiQixu = qixuzhiresult.ToString();
             tizhiDto.TizhiTanshi = tanshizhiresult.ToString();
             tizhiDto.TizhiShire = shirezhiresult.ToString();
             tizhiDto.TizhiQiyu = qiyuzhiresult.ToString();
             tizhiDto.TizhiXueyu = xueyuzhiresult.ToString();
             tizhiDto.TizhiTebing = tebingzhiresult.ToString();
             tizhiDto.TizhiPinghe = pinghezhiresult.ToString();
             tizhiDto.TizhiResult = Customertizhi;
             tizhiDto.TizhiCustomerId = int.Parse(cid);
             tizhiDto.TizhiTime = System.DateTime.Now;
             tizhiDto.TizhiNumber = Danganhao;
             tizhiDto.TizhiImg = "/tizhiresult/" + Danganhao + ".png";

             //ViewBag.yangxuzhiresult = yangxuzhiresult;
             //ViewBag.yinxuzhiresult = yinxuzhiresult;
             //ViewBag.qixuzhiresult = qixuzhiresult;
             //ViewBag.tanshizhiresult = tanshizhiresult;
             //ViewBag.shirezhiresult = shirezhiresult;
             //ViewBag.xueyuzhiresult = xueyuzhiresult;
             //ViewBag.qiyuzhiresult = qiyuzhiresult;
             //ViewBag.tebingzhiresult = tebingzhiresult;
             //ViewBag.pinghezhiresult = pinghezhiresult;
             string JsonString = JsonHelper.JsonSerializerBySingleData(tizhiDto);
             Message msg = CMSService.Insert("Tizhi", JsonString);
             msg=CMSService.UpdateFieldOneByOne("Customer", "CMSCustomer", "CustomerId=" + cid, "CustomerTizhi", Customertizhi);
             ViewBag.CustomerBirthday = CustomerBirthday;
             ViewBag.CustomerName=CustomerName;
             ViewBag.CustomerSex = CustomerSex;
             ViewBag.Customerqinxiangtizhi = Customerqinxiangtizhi;
             ViewBag.Customertizhi = Customertizhi;
             ViewBag.Danganhao = Danganhao;
             //ViewBag.userId = cid;
             return View(tizhiDto);
        }

        //
        // GET: /Liangbiao/Details/5
        public ActionResult List(int?p,int id)
        {
            Pager pager = new Pager();
            pager.table = "CMSTizhi";
            pager.strwhere = "TizhiCustomerId="+id;
            pager.PageSize = 10;
            pager.PageNo = p ?? 1;
            pager.FieldKey = "TizhiId";
            pager.FiledOrder = "TizhiId Desc";
            pager = CMSService.SelectAll("Tizhi", pager);

            List<TizhiDto> list = new List<TizhiDto>();
            foreach (DataRow dr in pager.EntityDataTable.Rows)
            {
                TizhiDto dto = TizhiMapping.getDTO(dr);
                list.Add(dto);


            }
            pager.Entity = list.AsQueryable();

            ViewBag.PageNo = p ?? 1;
            ViewBag.PageCount = pager.PageCount;
            ViewBag.RecordCount = pager.Amount;
            ViewBag.Message = pager.Amount;
            ViewBag.CustomerId = id;
            ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);

            return View(pager.Entity);
        }

        public ActionResult Details(int id)
        {
            TizhiDto dto = new TizhiDto();
            DataTable dt = CMSService.SelectOne("Tizhi", "CMSTizhi", "TizhiId=" + id);
            foreach (DataRow dr in dt.Rows)
            {               
                dto = TizhiMapping.getDTO(dr);

            }
             CustomerDto cDto = new CustomerDto();
            DataTable CustomerDt = CMSService.SelectOne("Customer", "CMSCustomer", "CustomerId=" + dto.TizhiCustomerId);
            foreach (DataRow cdr in CustomerDt.Rows)
            {
               
                cDto = CustomerMapping.getDTO(cdr);

            }
            ViewBag.CustomerName = cDto.CustomerName;
            ViewBag.CustomerSex = cDto.CustomerSex;
            ViewBag.CustomerBirthday = cDto.CustomerBirthday.ToShortDateString();
           
            
            return View(dto);
        
        }
        [HttpPost]
        public ActionResult CreateImg()
        {

          string base64ImgString = Request.Params["a"];
          string customerNumber = System.Web.HttpUtility.HtmlDecode(Request.Form["b"]); 
          string[] u = base64ImgString.Split(',');
          string imgstr = u[1];
          string filename = "/tizhiresult/" + customerNumber + ".png";
    
          // string filename = "/tizhiresult/" + CommonTools.ToUnixTime(System.DateTime.Now).ToString() + CommonTools.getRandomNumber() +".png";
           FileTools.Base64StringToImage(imgstr, filename);
        //   CMSService.UpdateFieldOneByOne("Tizhi", "CMSTizhi", "TizhiNumber='" + customerNumber + "'", "TizhiImg", filename);

           return Content("成功了");
        }

        //
        // GET: /Liangbiao/Create
        public ActionResult Create(string id)
        {
            ViewBag.cid = id;
            ViewData["TizhiQuestion"] = LiangbiaoService.GetTizhiQuestionList();
            ViewBag.CustomerName = MyService.CustomerIdToName("CustomerId=" + id);
            return View();
        }

        //
        // POST: /Liangbiao/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int i=1;
                string yangxuzhi = "";
                for (i = 1; i <= 7; i++)
                {
                    yangxuzhi =yangxuzhi+ collection[i.ToString()]+",";
                }
                string yinxuzhi = "";
                for (i = 8; i <= 15; i++)
                {
                    yinxuzhi = yinxuzhi + collection[i.ToString()] + ",";
                }
                string qixuzhi = "";
                for (i = 16; i <= 23; i++)
                {
                    qixuzhi = qixuzhi + collection[i.ToString()] + ",";
                }
                string tanshizhi = "";
                for (i = 24; i <= 31; i++)
                {
                    tanshizhi = tanshizhi + collection[i.ToString()] + ",";
                }
                string shirezhi = "";
                for (i = 32; i <= 38; i++)
                {
                    shirezhi = shirezhi + collection[i.ToString()] + ",";
                }
                string xueyuzhi = "";
                for (i = 39; i <= 45; i++)
                {
                    xueyuzhi = xueyuzhi + collection[i.ToString()] + ",";
                }
                string qiyuzhi = "";
                for (i = 46; i <= 52; i++)
                {
                    qiyuzhi = qiyuzhi + collection[i.ToString()] + ",";
                }
                string tebingzhi = "";
                for (i = 53; i <= 59; i++)
                {
                    tebingzhi = tebingzhi + collection[i.ToString()] + ",";
                }
                string pinghezhi = "";
                for (i = 60; i <= 67; i++)
                {
                    pinghezhi = pinghezhi + collection[i.ToString()] + ",";
                }

                string reslut = "";
                
                for (i = 1; i <= 67; i++)
                {
                    reslut = reslut + collection[i.ToString()] + ",";
                }

                string CustomerId = collection["CustomerId"];

                return RedirectToAction("Index", "Tizhi", new { id = reslut, cid = CustomerId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Liangbiao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Liangbiao/Edit/5
        [HttpPost]
        public ActionResult Edit()
        {
            if (Request.Files.Count > 0 && Request.Files[0] != null && !string.IsNullOrEmpty(Request.Files[0].FileName))
            {
                string fileName = CMSService.Uploadfiles("fsf", Request.Files[0]);
                return Content(fileName);
            }
            else
            {
                return Content("图片是空的");
            }
        }

        //
        // GET: /Liangbiao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Liangbiao/Delete/5
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
