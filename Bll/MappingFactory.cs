﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMapping;
using Mapping;

namespace Bll
{
    public class MappingFactory
    {
        public static IMapping CreatMapping(string DtoName)
        {
            IMapping Mapping = null;
            if (DtoName == "User")
            {
                Mapping = new UserMapping();
            }
            if (DtoName == "Role")
            {
                Mapping = new RoleMapping();
            }

            return Mapping;

 
        
        }
    }
}