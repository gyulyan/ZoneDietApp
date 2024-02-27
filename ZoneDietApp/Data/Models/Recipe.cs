using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ZoneDietApp.Data.DataConstants;

namespace ZoneDietApp.Data.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(RecipeNameMaxLenght, MinimumLength = RecipeNameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(RecipeDescriptionMaxLenght, MinimumLength = RecipeDescriptionMinLenght)]
        public string Description { get; set; } = null!;

        [Required]
        public string CreatorId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;


        [Range(0,240)]
        public int PrepTime { get; set; }

        [Range(0, 240)]
        public int CookTime { get; set; }

        [Range(0, 240)]
        public int TotalTime { get; set; }

        [Required]
        public List<RecipeProduct> Ingredients { get; set; } = new List<RecipeProduct>();

        [Required]
        public int RecipeTypeId { get; set; }

        [Required]
        [ForeignKey(nameof(RecipeTypeId))]
        public RecipeType RecipeType { get; set; } = null!;

        [Required]
        [Range(0, 50)]
        public int TotalCarbohydrat {  get; set; }

        [Required]
        [Range(0, 50)]
        public int TotalFat {  get; set; }

        [Required]
        [Range(0, 50)]
        public int TotalProtein { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

		public List<Comment>? Comments { get; set; } = new List<Comment>();
		
	}
}
