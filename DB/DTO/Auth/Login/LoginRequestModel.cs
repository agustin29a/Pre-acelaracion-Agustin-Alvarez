using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.ViewModels.Auth.Login
{
    public class LoginRequestModel
    {
		[Required]
		[MinLength(6)]
		public string Username { set; get; }

		[Required]
		[MinLength(6)]
		public string Password { set; get; }

	}
}
