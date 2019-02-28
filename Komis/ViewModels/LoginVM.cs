using System.ComponentModel.DataAnnotations;

namespace Komis.ViewModels
{
	public class LoginVM
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string RoleName { get; set; }
	}
}
