using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SkyWebCMS.Attributes;

namespace SkyWebCMS.Models
{
    public class FankuiAddViewModel
    {
        [Display(Name = "患者姓名")]
        [Required(ErrorMessage = "患者姓名")]
        public int FankuiCustomerId { get; set; }
        [Display(Name = "患者状况")]
        [Required(ErrorMessage = "患者状况")]
        public int FankuiResult { get; set; }
        [Display(Name = "患者情况描述")]
        [Required(ErrorMessage = "患者情况描述")]
        public string FankuiDescription { get; set; }
        [Display(Name = "反馈来源")]
        [Required(ErrorMessage = "反馈来源")]
        public int FankuiSource { get; set; }
        [Display(Name = "反馈时间")]
        [Required(ErrorMessage = "反馈时间")]
        public DateTime FankuiTime { get; set; }
        [Display(Name = "反馈状态")]
        [Required(ErrorMessage = "反馈状态")]
        public string FankuiStatus { get; set; }
        [Display(Name = "反馈发送时间")]
        [Required(ErrorMessage = "反馈发送时间")]
        public DateTime FankuiSendTime { get; set; }
        [Display(Name = "记录医生")]
        [Required(ErrorMessage = "记录医生")]
        public int FankuiDoctor { get; set; }
    }
}