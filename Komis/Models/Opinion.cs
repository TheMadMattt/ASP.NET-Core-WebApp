using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Komis.Models
{
	public class Opinion
	{
		[BindNever]
		public int Id { get; set; }

		[Required(ErrorMessage = "Nazwa użytkownika jest wymagana!")]
		[StringLength(100, ErrorMessage = "Nazwa użtywkonika jest za długa!")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Adres e-mail jest wymagany!")]
		[StringLength(100,ErrorMessage = "E-mail jest za długi!")]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
			ErrorMessage = "To nie jest poprawny adres email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Wiadomość jest wymagana")]
		[StringLength(5000, ErrorMessage = "Wiadomość jest za długa")]
		public string Message { get; set; }

		public bool WaitingForRespond { get; set; }
	}
}
