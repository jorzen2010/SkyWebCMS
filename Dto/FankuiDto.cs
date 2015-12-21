using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class FankuiDto
    {
        public int FankuiId { get; set; }
        public int FankuiCustomerId { get; set; }
        public int FankuiResult { get; set; }
        public string FankuiDescription { get; set; }
        public int FankuiSource { get; set; }
        public DateTime FankuiTime { get; set; }
        public int FankuiDoctor { get; set; }
        public string FankuiStatus { get; set; }
        public DateTime FankuiSendTime { get; set; }
        

    }
}
