using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class JixiaoDto
    {
        public int JixiaoId { get; set; }
        public string JixiaoUser { get; set; }

        public string JixiaoForUser { get; set; }
        public int JixiaoParentCategory { get; set; }
        public int JixiaoCategory { get; set; }
        public string JixiaoRenwu { get; set; }
        public double JixiaoFenshu { get; set; }
        public string JixiaoStatus { get; set; }
        public DateTime JixiaoTime { get; set; }
        public DateTime JixiaoShenheTime { get; set; }

        
        
    }
}
