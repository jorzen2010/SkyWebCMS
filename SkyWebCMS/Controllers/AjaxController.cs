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
           if (columnname != "CustomerTelephone" && columnname != "CustomerEmail" && columnname != "CustomerLianxirenTel")
           {
               msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
               msg.MessageStatus = "true";

           }
          

           else 
           {
               if (columnname == "CustomerTelephone" || columnname == "CustomerLianxirenTel")
               { 
               if (CommonValidate.IsTelephone(columnvalue))
               {
                   msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
                   msg.MessageStatus = "true";
               }
               else
               {
                   msg.MessageStatus = "false";
                   msg.MessageInfo = "手机格式不正确";
               }
               }
               if (columnname == "CustomerEmail")
               {
                   if (CommonValidate.IsEmail(columnvalue))
                   {
                       msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
                       msg.MessageStatus = "true";
                      
                   }
                   else
                   {
                       msg.MessageStatus = "false";
                       msg.MessageInfo = "邮箱格式不正确";
                   }
               }
               
           
           }
           
           var result = msg;
           
           return Json(result, JsonRequestBehavior.AllowGet);
        }


       [HttpPost]
       public JsonResult updateUserField()
       {

           Message msg = new Message();
           string DtoName = Request.Params["DtoName"];
           string table = Request.Params["table"];
           string strWhere = Request.Params["strWhere"];
           string columnname = Request.Params["columnname"];
           string columnvalue = Request.Params["columnvalue"];
           if (columnname != "UserTelephone" && columnname != "UserEmail")
           {
               msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
               msg.MessageStatus = "true";

           }


           else
           {
               if (columnname == "UserTelephone")
               {
                   if (CommonValidate.IsTelephone(columnvalue))
                   {
                       DataTable dt = CMSService.SelectOne("User", "CMSUser", strWhere + " and UserTelephone='"+columnvalue+"'");
                       if (dt.Rows.Count > 0)
                       {
                           msg.MessageStatus = "false";
                           msg.MessageInfo = "此手机号已经被其他用户占用";
                       }
                       else
                       {
                           msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
                           msg.MessageStatus = "true";
                       }
               
                       
                   }
                   else
                   {
                       msg.MessageStatus = "false";
                       msg.MessageInfo = "手机格式不正确";
                   }
               }
               if (columnname == "UserEmail")
               {
                   if (CommonValidate.IsEmail(columnvalue))
                   {

                       DataTable dt = CMSService.SelectOne("User", "CMSUser", strWhere + " and UserEmail='" + columnvalue + "'");
                       if (dt.Rows.Count > 0)
                       {
                           msg.MessageStatus = "false";
                           msg.MessageInfo = "此邮箱已经被其他用户占用";
                       }
                       else
                       {
                           msg = CMSService.UpdateFieldOneByOne(DtoName, table, strWhere, columnname, columnvalue);
                           msg.MessageStatus = "true";
                       }
                     

                   }
                   else
                   {
                       msg.MessageStatus = "false";
                       msg.MessageInfo = "邮箱格式不正确";
                   }
               }


           }

           var result = msg;

           return Json(result, JsonRequestBehavior.AllowGet);
       }
	}
}