using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ZoneDietApp.Data.DataConstants;

namespace ZoneDietApp.Data.Models
{
	public class Comment
	{
		[Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }

		[Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(UserNameMaxLenght)]
        [Comment("User's name")]
        public string Name { get; set; } = null!;

		[Required(ErrorMessage = "Please Enter Subject")]
        [MaxLength(SubjectMaxLenght)]
        [Comment("Subject of the comment")]
        public string Subject { get; set; } = null!;

		[Required(ErrorMessage = "Please Enter Message")]
        [MaxLength(MessageMaxLenght)]
        [Comment("Message of the comment")]
        public string Message { get; set; } = null!;

		[Required]
        [Comment("Date of publishing")]
        public string DateTime { get; set; } = System.DateTime.Now.ToString();

		[Required]
        [Comment("Recipe identifier")]
        public int RecipeId { get; set; }

		[Required]
		[ForeignKey(nameof(RecipeId))]
		public Recipe Recipe { get; set; } = null!;
	}
}
