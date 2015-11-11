using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ArticleDto
    {
        public int ArticleId{get;set;}
        public string ArticleTitle{get;set;}
        public string ArticleImg { get; set; }
        public int ArticleCategory { get; set; }
        public string ArticleAuthor{get;set;}
        public string  ArticleDescription{get;set;}
        public string ArticleKeywords{get;set;}
        public string ArticleContent{get;set;}
        public string ArticleEditor{get;set;}
        public DateTime ArticleTime{get;set;}
        public bool ArticleTop{get;set;}
        public bool ArticleHot{get;set;}
        public bool ArticleClassic { get; set; }
                    
    }
}
