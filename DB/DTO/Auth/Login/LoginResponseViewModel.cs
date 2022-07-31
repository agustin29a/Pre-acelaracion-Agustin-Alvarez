using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.ViewModels.Auth.Login
{
    public class LoginResponseViewModel
    {
        public string Token { set; get; }
        public DateTime ValidTo { set; get; }

    }
}
