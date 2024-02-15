using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZoneDietApp.Data;
using ZoneDietApp.Models;

namespace ZoneDietApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ZoneDbContext dbContext;

        public RecipeController(ZoneDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {

            var model = await dbContext.Recipes
                    .AsNoTracking()
                    .Select(x => new AllRecipesViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        TotalCarbohydrat = x.TotalCarbohydrat,
                        TotalFat = x.TotalFat,
                        TotalProtein = x.TotalProtein                  
                    })
                    .ToListAsync();

            return View(model);
        }
    }
}

