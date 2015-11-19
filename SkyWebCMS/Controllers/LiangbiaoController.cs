using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Drawing;
using Bll;
using System.IO;

namespace SkyWebCMS.Controllers
{
    public class LiangbiaoController : Controller
    {
        //
        // GET: /Liangbiao/
         [ValidateInput(false)]
        public ActionResult Index(string id)
        {
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


             ViewBag.yangxuzhiresult = yangxuzhiresult;
             ViewBag.yinxuzhiresult = yinxuzhiresult;
             ViewBag.qixuzhiresult = qixuzhiresult;
             ViewBag.tanshizhiresult = tanshizhiresult;
             ViewBag.shirezhiresult = shirezhiresult;
             ViewBag.xueyuzhiresult = xueyuzhiresult;
             ViewBag.qiyuzhiresult = qiyuzhiresult;
             ViewBag.tebingzhiresult = tebingzhiresult;
             ViewBag.pinghezhiresult = pinghezhiresult;
            return View();
        }

        //
        // GET: /Liangbiao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Test()
        {
           string base64ImgString = Request["a"]; ;
           string[] u = base64ImgString.Split(',');
           string imgstr = u[1];

           string filename = "/tizhiresult/" + CommonTools.ToUnixTime(System.DateTime.Now).ToString() + CommonTools.getRandomNumber() +".png";
           FileTools.Base64StringToImage(imgstr, filename);

           return Content("成功了");
        }

        //
        // GET: /Liangbiao/Create
        public ActionResult Create()
        {
            ViewData["TizhiQuestion"] = LiangbiaoService.GetTizhiQuestionList();
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

                return RedirectToAction("Index", "Liangbiao", new { id = reslut });
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
