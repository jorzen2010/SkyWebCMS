using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SkyWebCMS.Models
{
    #region 添加模型
    public class UserAddViewModel
    {
        [Display(Name = "用户名")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "用户名必须大于{2} 位且要小于{1}位")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "用户名必须由字母或数字组成")]
        [Required(ErrorMessage = "请输入用户名")]
        [System.Web.Mvc.Remote("ValidateUserName", "AjaxValidation", ErrorMessage = "用户名已经被占用")]
        public string UserName { get; set; }

        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "请输入邮箱")]
        [RegularExpression("^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+.([a-zA-Z0-9_-])+", ErrorMessage = "邮箱格式不正确")]
        [System.Web.Mvc.Remote("ValidateUserEmail", "AjaxValidation", ErrorMessage = "邮箱已经被占用")]
        public string UserEmail { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "密码不是太短了就是太长了，你看着办吧")]
        public string UserPassword { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入确认密码")]
        [Compare("UserPassword", ErrorMessage = "密码不同")]
        public string UserConfirmPassword { get; set; }
    }
    #endregion

    #region 编辑模型
    public class EditUserRolesViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "角色权限")]
        public string UserRoles { get; set; }
    }
    #endregion
    #region 编辑模型
    public class EditPasswordViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "原密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "密码不是太短了就是太长了，你看着办吧")]
        public string OldPassword { get; set; }
        [Display(Name = "新密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "密码不是太短了就是太长了，你看着办吧")]
        public string UserPassword { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入确认密码")]
        [Compare("UserPassword", ErrorMessage = "密码不同")]
        public string UserConfirmPassword { get; set; }

    }
    #endregion

    #region 重置密码模型
    public class ResetPasswordViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "原密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入密码")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "密码不是太短了就是太长了，你看着办吧")]
        public string UserPassword { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入确认密码")]
        [Compare("UserPassword", ErrorMessage = "密码不同")]
        public string UserConfirmPassword { get; set; }

    }
    #endregion


}