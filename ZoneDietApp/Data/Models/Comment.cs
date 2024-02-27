using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoneDietApp.Data.Models
{
	public class Comment
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Please Enter Name")]
		public string Name { get; set; } = null!;

		[Required(ErrorMessage = "Please Enter Subject")]
		public string Subject { get; set; } = null!;

		[Required]
		public string Message { get; set; } = null!;

		[Required]
		public string dateTime { get; set; } = DateTime.Now.ToString();

		[Required]
		public int RecipeId { get; set; }

		[Required]
		[ForeignKey(nameof(RecipeId))]
		public Recipe Recipe { get; set; } = null!;
	}
}
