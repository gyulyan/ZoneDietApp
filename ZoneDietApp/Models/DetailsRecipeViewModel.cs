using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZoneDietApp.Data.Models;
using static ZoneDietApp.Data.DataConstants;
using System.Collections.Generic;

namespace ZoneDietApp.Models
{
    public class DetailsRecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string RecipeType = null!;

        public string Creator = null!;
        public int TotalCarbohydrat { get; set; }
        public int TotalFat { get; set; }
        public int TotalProtein { get; set; }

        //public IFormFile? Photo { get; set; } = null!;

        public int PrepTime { get; set; }

        public int CookTime { get; set; }

        public int TotalTime { get; set; }

        public List<RecipeProduct> Ingredients { get; set; } = new List<RecipeProduct>();

    }
}
