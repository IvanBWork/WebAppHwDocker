using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppHwDocker.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRoleDto Role { get; set; }
    }
}
