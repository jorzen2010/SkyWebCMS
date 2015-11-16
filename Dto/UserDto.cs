using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserTelephone { get; set; }
        public string UserRoles { get; set; }
        public DateTime UserRegisterTime { get; set; }
        public bool UserStatus { get; set; }
        public string UserRealName { get; set; }
        public string UserSex { get; set; }
        public string UserImg { get; set; }
        public DateTime UserBirthday { get; set; }
        
        
    }
}
