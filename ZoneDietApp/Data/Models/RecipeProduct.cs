using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ZoneDietApp.Data.DataConstants;

namespace ZoneDietApp.Data.Models
{
    public class RecipeProduct
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLenght, MinimumLength = ProductNameMinLenght)]
        public string Name { get; set; } = null!;

		[Required]
		[Comment("Weight of the product")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Weight { get; set; } 

    }
}
