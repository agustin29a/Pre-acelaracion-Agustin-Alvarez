using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.ViewModels.Auth.Register
{
    public class RegisterRequestModel
	{
		[Required]
		[MinLength(6)]
		public string Username { set; get; }

		[Required]
		[EmailAddress]
		public string Email { set; get; }

		[Required]
		[MinLength(6)]
		public string Password { set; get; }
	}
}
