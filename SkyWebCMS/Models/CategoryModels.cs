using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SkyWebCMS.Models
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "分类名称")]
        [Required(ErrorMessage = "请输入分类名称")]
        public string CategoryName { get; set; }
        [Display(Name = "分类描述")]
        [Required(ErrorMessage = "请输入分类描述")]
        public string CategoryDescription { get; set; }
        [Display(Name = "上一级分类名称")]
        public string CategoryParentName { get; set; }

        public int CategoryParentId { get; set; }
    }

    public class EditCategoryViewModel
    {
        [Display(Name = "分类名称")]
        [Required(ErrorMessage = "请输入分类名称")]
        public string CategoryName { get; set; }
        [Display(Name = "分类描述")]
        [Required(ErrorMessage = "请输入分类描述")]
        public string CategoryDescription { get; set; }
        [Display(Name = "上一级分类名称")]
        public string CategoryParentName { get; set; }

        public int CategoryParentId { get; set; }
        public int CategoryId { get; set; }
    }
}