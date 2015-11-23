using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Dto;
using Bll;
using Mapping;
using Common;

namespace SkyWebCMS.Controllers
{
    public class AjaxController : Controller
    {
        //
       [HttpPost]
        public JsonResult updateCusField()
        {

            Message msg = new Message();
           string DtoName = Request.Params["DtoName"];
           string table = Request.Params["table"];
           string strWhere = Request.Params["strWhere"];
           string columnname = Request.Params["columnname"];
           string columnvalue = Request.Params["columnvalue"];
           if (columnname == "CustomerTelephone")
           {
               if (CommonValidate.IsTelephone(columnvalue))
               {
                   msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
                   msg.MessageStatus = "true";
               }
               else
               {
                   msg.MessageStatus = "false";
               }

           }
           else 
           {
               msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
               msg.MessageStatus = "true";
           
           }
           
           var result = msg.MessageStatus;
           
           return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}