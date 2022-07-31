using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    public class UserLogin : IdentityUser 
    {
        public bool isActive { set; get; }
    }
}
