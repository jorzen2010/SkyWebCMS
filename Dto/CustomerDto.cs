using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public  class CustomerDto
    {
        public int CustomerId{get;set;}
        public string CustomerName{get;set;}
        public string CustomerNumber{get;set;}
        public string CustomerSex { get; set; }
        public DateTime CustomerBirthday{get;set;}
        public string CustomerTelephone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMinzu { get; set; }
        public string CustomerChangzhu { get; set; }
        public string CustomerHunyin { get; set; }
        public string CustomerWenhua { get; set; }
        public string CustomerZhiye { get; set; }

        public string CustomerLianxiren { get; set; }

        public string CustomerLianxirenTel { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerHujiAddress { get; set; }

        public string CustomerXiangzhen { get; set; }

        public string CustomerJuweihui { get; set; }
        public string CustomerYongyao { get; set; }
        public string CustomerBeizhu { get; set; }
        public string CustomerDanwei { get; set; }
        public string CustomerGuidang { get; set; }
        public string CustomerDoctor { get; set; }
        public string CustomerShequ { get; set; }
    }
}
