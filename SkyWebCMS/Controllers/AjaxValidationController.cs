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
    public class AjaxValidationController : Controller
    {
        //
        // GET: /AjaxValidation/
        public JsonResult ValidateUserName(string UserName)
        {
            var result = false;
            UserDto userDto = new UserDto();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserName='"+UserName+"'");
            foreach (DataRow dr in dt.Rows)
            {
                userDto = UserMapping.getDTO(dr);
            }
            
            result = !(userDto.UserId > 0);

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult ValidateUserEmail(string UserEmail)
        {
            var result = false;
            UserDto userDto = new UserDto();
            DataTable dt = CMSService.SelectOne("User", "CMSUser", "UserEmail='" + UserEmail + "'");
            foreach (DataRow dr in dt.Rows)
            {
                userDto = UserMapping.getDTO(dr);
            }

            result = !(userDto.UserId > 0);

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ValidateIDCardNo(string CustomerNumber)
        {
            return Json(CommonTools.Verify(CustomerNumber), JsonRequestBehavior.AllowGet);
        }

       

       
	}
}