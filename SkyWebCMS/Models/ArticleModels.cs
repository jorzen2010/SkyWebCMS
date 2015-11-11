using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Models
{
    

    public class ArticleModel
    {
        public int ArticleId { get; set; }
        [Display(Name = "标题")]
        [Required(ErrorMessage = "标题不能为空")]
        public string ArticleTitle { get; set; }
        [Display(Name = "文章分类")]
        [Required(ErrorMessage = "文章分类不能为空")]
        public int ArticleCategory { get; set; }
        [Display(Name = "标题缩略图")]
        [ImageUpload("Article")]
        public string ArticleImg { get; set; }
        [Display(Name = "作者")]
        [Required(ErrorMessage = "作者不能为空")]
        public string ArticleAuthor { get; set; }
        [Display(Name = "简介")]
        [Required(ErrorMessage = "简介不能为空")]
        public string ArticleDescription { get; set; }
        [Display(Name = "关键词")]
        [Required(ErrorMessage = "关键词不能为空")]
        public string ArticleKeywords { get; set; }
        [Display(Name = "内容")]
        [Required(ErrorMessage = "内容不能为空")]
        public string ArticleContent { get; set; }
        [Display(Name = "编辑")]
        [Required(ErrorMessage = "编辑不能为空")]
        public string ArticleEditor { get; set; }
        [Display(Name = "时间")]
        [Required(ErrorMessage = "时间不能为空")]
        public DateTime ArticleTime { get; set; }
        [Display(Name = "置顶")]
        public bool ArticleTop { get; set; }
        [Display(Name = "推荐")]
        public bool ArticleHot { get; set; }
        [Display(Name = "精华")]
        public bool ArticleClassic { get; set; }

    }

  
}