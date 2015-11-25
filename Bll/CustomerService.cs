using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using Dto;
using Mapping;
using System.Web;
using System.Web.Mvc;


namespace Bll
{
    public class CustomerService
    {

        public static List<SelectListItem> GetChangzhuSelectList()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "未知", Value = "未知" });
            items.Add(new SelectListItem { Text = "户籍", Value = "户籍" });
            items.Add(new SelectListItem { Text = "非户籍", Value = "非户籍" });
            

            return items;

        }
        public static List<SelectListItem> GetMinzuSelectList()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "未知", Value = "未知" });
            items.Add(new SelectListItem { Text = "汉族", Value = "汉族" });
            items.Add(new SelectListItem { Text = "非汉族", Value = "非汉族" });


            return items;

        }
        public static List<SelectListItem> GetHunyinSelectList()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "未知", Value = "未知" });
            items.Add(new SelectListItem { Text = "未婚", Value = "未婚" });
            items.Add(new SelectListItem { Text = "已婚", Value = "已婚" });
            items.Add(new SelectListItem { Text = "丧偶", Value = "丧偶" });
            items.Add(new SelectListItem { Text = "离婚", Value = "离婚" });


            return items;

        }

        public static List<SelectListItem> GetZhiyeSelectList()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "不便分类的其他从业人员", Value = "不便分类的其他从业人员" });
            items.Add(new SelectListItem { Text = "国家机关、党群组织、企业、事业单位负责人", Value = "国家机关、党群组织、企业、事业单位负责人" });
            items.Add(new SelectListItem { Text = "专业技术人员", Value = "专业技术人员" });
            items.Add(new SelectListItem { Text = "办事人员和有关人员", Value = "办事人员和有关人员" });
            items.Add(new SelectListItem { Text = "商业、服务业人员", Value = "商业、服务业人员" });
            items.Add(new SelectListItem { Text = "农、林、牧、渔、水利业生产人员", Value = "农、林、牧、渔、水利业生产人员" });
            items.Add(new SelectListItem { Text = "生产、运输设备操作人员及有关人员", Value = "生产、运输设备操作人员及有关人员" });
            items.Add(new SelectListItem { Text = "军人", Value = "军人" });
            return items;

        }

        public static List<SelectListItem> GetWenhuaSelectList()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "未知", Value = "未知" });
            items.Add(new SelectListItem { Text = "文盲及半文盲", Value = "文盲及半文盲" });
            items.Add(new SelectListItem { Text = "小学", Value = "小学" });
            items.Add(new SelectListItem { Text = "初中", Value = "初中" });
            items.Add(new SelectListItem { Text = "高中/技校/中专", Value = "中/技校/中专" });
            items.Add(new SelectListItem { Text = "大专及以上", Value = "大专及以上" });
            return items;

        }
    }
}
