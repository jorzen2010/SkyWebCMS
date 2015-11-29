using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Models
{
    public class JianyanAddViewModel
    {
        public int JianyanId { get; set; }
        [Display(Name = "检验分类")]
        [Required(ErrorMessage = "请输入检验分类")]
        public string JianyanCategory { get; set; }
        [Display(Name = "检验描述")]
        [Required(ErrorMessage = "请输入检验描述")]
        public string JianyanDescription { get; set; }
        [Display(Name = "化验单上传")]
        [Required(ErrorMessage = "请输入")]
        [ImageUpload("Jianyan")]
        public string JianyanImg { get; set; }
        public int JianyanCustomerId { get; set; }
        public DateTime JianyanTime { get; set; }
    }
}