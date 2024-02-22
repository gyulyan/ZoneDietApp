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
            var productTypeOptions = await dbContext.ProductTypeOptions.ToListAsync();
            model.ProductTypeOptions = await dbContext.ProductTypeOptions.ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeViewModel model)
        {

            //if (!ModelState.IsValid)
            //{
            //    model.RecipeType = await GetTypes();
            //    model.ProductTypeOptions = await dbContext.ProductTypeOptions.ToListAsync();
            //    return View(model);
            //}

            var recipe = new Recipe()
            {
                Name = model.Name,
                Description = model.Description,
                CreatorId = GetUserId(),
                PrepTime = model.PrepTime,
                CookTime = model.CookTime,
                TotalTime = model.PrepTime + model.CookTime,
                Ingredients = model.Ingredients,
                RecipeTypeId = model.TypeId,
                TotalCarbohydrat = model.TotalCarbohydrat,
                TotalFat = model.TotalFat,
                TotalProtein = model.TotalProtein,
                CreatedOn = DateTime.Now
            };

            await dbContext.Recipes.AddAsync(recipe);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var model = await dbContext.Recipes
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new DetailsRecipeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    PrepTime = x.PrepTime,
                    CookTime = x.CookTime,
                    TotalTime = x.TotalTime,
                    RecipeType = x.RecipeType.Name,
                    Creator = x.Creator.UserName,
                    TotalCarbohydrat = x.TotalCarbohydrat,
                    TotalFat = x.TotalFat,
                    TotalProtein = x.TotalProtein
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}

