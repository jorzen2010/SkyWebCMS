using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SkyWebCMS.Models
{
    public class JixiaoModel
    {
        public int JixiaoId { get; set; }
        [Display(Name = "员工姓名")]
        [Required(ErrorMessage = "请输入员工姓名")]
        public string JixiaoUser { get; set; }
        [Display(Name = "任务对象")]
        [Required(ErrorMessage = "请输入任务对象")]
        public string JixiaoForUser { get; set; }
        [Display(Name = "任务分类")]
        [Required(ErrorMessage = "请输入任务分类")]
        public string JixiaoParentCategory { get; set; }
        [Display(Name = "任务具体分类")]
        [Required(ErrorMessage = "请输入任务具体分类")]
        public string JixiaoCategory { get; set; }
        [Display(Name = "任务名称")]
        [Required(ErrorMessage = "请输入任务名称")]
        public string JixiaoRenwu { get; set; }
        [Display(Name = "任务状态")]
        [Required(ErrorMessage = "请输入任务状态")]
        public string JixiaoStatus { get; set; }
        public DateTime JixiaoTime { get; set; }
        public DateTime JixiaoShenheTime { get; set; }
    }
}