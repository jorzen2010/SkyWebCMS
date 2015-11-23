using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Models
{
    

    public class CustomerAddViewModel
    {
        public int CustomerId { get; set; }
        [Display(Name = "姓名")]
        [RegularExpression("^[\u4E00-\u9FA5]{2,4}$", ErrorMessage = "姓名必须是2-4个汉字")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "姓名必须是2-4个汉字")]
        [Required(ErrorMessage = "姓名不能为空")]
        public string CustomerName { get; set; }

        [Display(Name = "身份证")]
        [Required(ErrorMessage = "身份证不能为空")]
        [System.Web.Mvc.Remote("ValidateIDCardNo", "AjaxValidation", ErrorMessage = "身份证号未经过校验")]
        [RegularExpression("[0-9z]{15,18}", ErrorMessage = "身份证号格式错误应该为15或18位")]
        public string CustomerNumber { get; set; }
       

    }
    public class CustomerEditViewModel
    {
        public int CustomerId { get; set; }
        [Display(Name = "姓名")]
        [RegularExpression("^[\u4E00-\u9FA5]{2,4}$", ErrorMessage = "姓名必须是2-4个汉字")]
        [StringLength(4, MinimumLength = 2, ErrorMessage = "姓名必须是2-4个汉字")]
        [Required(ErrorMessage = "姓名不能为空")]
        public string CustomerName { get; set; }

        [Display(Name = "身份证")]
        [Required(ErrorMessage = "身份证不能为空")]
        [System.Web.Mvc.Remote("ValidateIDCardNo", "AjaxValidation", ErrorMessage = "身份证号未经过校验")]
        [RegularExpression("[0-9z]{15,18}", ErrorMessage = "身份证号格式错误应该为15或18位")]
        public string CustomerNumber { get; set; }
        [Display(Name = "生日")]
        public string CustomerBirthday { get; set; }
        [Display(Name = "性别")]
        public string CustomerSex { get; set; }
        [Display(Name = "邮箱")]
        public string CustomerEmail { get; set; }
        [Display(Name = "手机")]
        public string CustomerTelephone { get; set; }
        [Display(Name = "常住类型")]
        public string CustomerChangzhu { get; set; }
        [Display(Name = "民族")]
        public string CustomerMinzu { get; set; }
        [Display(Name = "婚姻状况")]
        public string CustomerHunyin { get; set; }


    }

  
}