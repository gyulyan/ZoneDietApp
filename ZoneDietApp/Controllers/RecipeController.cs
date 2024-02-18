using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using ZoneDietApp.Data;
using ZoneDietApp.Data.Models;
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
                        TotalTime = x.TotalTime,
                        RecipeType = x.RecipeType,
                        Creator = x.Creator.UserName,
                        TotalCarbohydrat = x.TotalCarbohydrat,
                        TotalFat = x.TotalFat,
                        TotalProtein = x.TotalProtein                  
                    })
                    .ToListAsync();

            return View(model);
        }
        public async Task<IEnumerable<RecipeTypeViewModel>> GetTypes()
        {
            return await dbContext.RecipeTypes
                .AsNoTracking()
                .Select(t => new RecipeTypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
            .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        [HttpGet]

        public async Task<IActionResult> Add()
        {
            var model = new AddRecipeViewModel();

            model.RecipeType = await GetTypes();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeViewModel model)
        {
          
            if (!ModelState.IsValid)
            {
                model.RecipeType = await GetTypes();
                return View(model);
            }

            var entity = new Recipe()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                CreatorId = GetUserId(),

                RecipeTypeId = model.TypeId
            };

            await dbContext.Recipes.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}

