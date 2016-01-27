using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SkyWebCMS.Models
{
    public class YuyueAddViewModel
    {
        public int YuyueId { get; set; }
        [Display(Name = "医生")]
        [Required(ErrorMessage = "请选择医生")]
        public int YuyueDoctorId { get; set; }
        [Display(Name = "患者姓名")]
        [Required(ErrorMessage = "请输入患者姓名")]
        public int YuyueCustomerId { get; set; }
        [Display(Name = "预约时间")]
        [Required(ErrorMessage = "请输入时间")]
        public DateTime YuyueTime { get; set; }
    }
   
}