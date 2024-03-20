using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ZoneDietApp.Data.DataConstants;

namespace ZoneDietApp.Data.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(ProductNameMaxLenght, MinimumLength = ProductNameMinLenght)]
		public string Name { get; set; } = null!;

		[Required]
		public int TypeId { get; set; }

		[Required]
		[ForeignKey(nameof(TypeId))]
		public ProductTypeOption Type { get; set; } = null!;

		[Required]
		public int ZoneChoiceColorId { get; set; }

		[Required]
		[ForeignKey(nameof(ZoneChoiceColorId))]
		public ZoneChoiceColor ZoneChoiceColor { get; set; } = null!;

		[Required]
		[Comment("Weight of the product")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Weight { get; set; } 
    }
}
