using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace ZoneDietApp.Data.Models
{
	public class Comment
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please Enter Name")]
		public string Name { get; set; }

		[Required]
		[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$", ErrorMessage = "Please provide Valid email")]
		public string Email { get; set; }

		[Required]
		public string Message { get; set; }

		public string dateTime { get; set; } = DateTime.Now.ToString();

		public int PostId { get; set; }
		public Recipe Recipe { get; set; }
	}
}
