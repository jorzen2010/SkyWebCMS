using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SkyWebCMS.Models
{
    public class XueyaAddViewModel
    {
        public int XueyaId { get; set; }
        [Display(Name = "高压")]
        [Required(ErrorMessage = "请输入高压")]
        public int XueyaGaoya { get; set; }
        [Display(Name = "低压")]
        [Required(ErrorMessage = "请输入低压")]
        public int XueyaDiya { get; set; }
        [Display(Name = "脉搏")]
        public int XueyaMaibo { get; set; }
        [Display(Name = "测量时间")]
        public DateTime XueyaTime { get; set; }
        [Display(Name = "测量设备SID")]
        public string XueyaSId { get; set; }
        [Display(Name = "测量设备UID")]
        public int XueyaUId { get; set; }
        [Display(Name = "患者ID")]
        public int CustomerId { get; set; }
        [Display(Name = "数据来源")]
        public string XueyaSource { get; set; }
        [Display(Name = "测量位置")]
        public string XueyaWeizhi { get; set; }
    }
}