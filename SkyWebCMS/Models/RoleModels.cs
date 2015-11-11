using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SkyWebCMS.Models
{


    public class RoleModel
    {
        public int RoleId { get; set; }
        [Display(Name = "角色名称")]
        [Required(ErrorMessage="请输入角色名称")]
        public string RoleName { get; set; }
        [Display(Name = "角色介绍")]
        [Required(ErrorMessage="请输入角色介绍")]
        public string RoleDescription { get; set; }
    }
}