using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ZoneDietApp.Data;
using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Models
{
    public class AllRecipesViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int TotalCarbohydrat { get; set; }

        public int TotalTime { get; set; }

        public RecipeType RecipeType { get; set; } = null!;

        public string Creator { get; set; } = null!;

        public int TotalFat { get; set; }

        public int TotalProtein { get; set; }

        public IFormFile Pfp { get; set; } = null!;
    }
}
