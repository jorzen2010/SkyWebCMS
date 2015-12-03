using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Models
{
    public class ChufangAddViewModel
    {
        public int ChufangId { get; set; }
        [Display(Name = "处方报告")]
        [Required(ErrorMessage = "处方报告")]
        [ImageUpload("Chufang")]
        public string ChufangImg { get; set; }
        [Display(Name = "诊断")]
        [Required(ErrorMessage = "请输入诊断")]
        public string ChufangZhenduan { get; set; }
        [Display(Name = "处置")]
        [Required(ErrorMessage = "请输入处置")]
        public string ChufangChuzhi { get; set; }
        [Display(Name = "用药")]
        [Required(ErrorMessage = "请输入用药")]
        public string ChufangYongyao { get; set; }
        public DateTime ChufangTime { get; set; }
        public int ChufangCustomerId { get; set; }
    }
}