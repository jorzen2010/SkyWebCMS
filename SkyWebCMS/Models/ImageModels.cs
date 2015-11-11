using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        [Display(Name = "图片标题")]
        [Required(ErrorMessage = "请输入图片标题")]
        public string ImageTitle { set; get; }
        [Display(Name = "图片地址")]
        [Required(ErrorMessage = "请输入图片地址")]
        [ImageUpload("Image")]
        public string ImageUrl { set; get; }
        [Display(Name = "图片分类")]
        [Required(ErrorMessage = "请输入图片分类")]
        public int ImageCategory { set; get; }
        [Display(Name = "图片链接")]
        [Required(ErrorMessage = "请输入图片链接")]
        public string ImageHref { set; get; }
        [Display(Name = "图片描述")]
        [Required(ErrorMessage = "请输入图片描述")]
        public string ImageDescription { set; get; }
        [Display(Name = "图片禁用")]
        public bool ImageStatus { set; get; }

    }
}