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
    }
}
