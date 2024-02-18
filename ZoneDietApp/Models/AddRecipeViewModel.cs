using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoneDietApp.Data.Models;
using static ZoneDietApp.Data.DataConstants;

namespace ZoneDietApp.Models
{
    public class AddRecipeViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(RecipeNameMaxLenght, MinimumLength = RecipeNameMinLenght, ErrorMessage = ShtringLenghtErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(RecipeDescriptionMaxLenght, MinimumLength = RecipeDescriptionMinLenght, ErrorMessage = ShtringLenghtErrorMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        public IEnumerable<RecipeTypeViewModel> RecipeType { get; set; } = new List<RecipeTypeViewModel>();


        [Required(ErrorMessage = RequireErrorMessage)]
        public int TotalCarbohydrat { get; set; }

       
        [Required(ErrorMessage = RequireErrorMessage)]
        public int TotalFat { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int TotalProtein { get; set; }

        public IFormFile Pfp { get; set; } = null!;

        [Range(0, 240)]
        public int PrepTime { get; set; }

        [Range(0, 240)]
        public int CookTime { get; set; }

        [Range(0, 240)]
        public int TotalTime { get; set; }

        [Required]
        public List<RecipeProduct> Ingredients { get; set; } = new List<RecipeProduct>();

        [Required]
        public int TypeId { get; set; }
    }
}
