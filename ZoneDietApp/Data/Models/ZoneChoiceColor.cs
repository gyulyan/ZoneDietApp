using System.ComponentModel.DataAnnotations;

namespace ZoneDietApp.Data.Models
{
	public class ZoneChoiceColor
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;
	}
}
