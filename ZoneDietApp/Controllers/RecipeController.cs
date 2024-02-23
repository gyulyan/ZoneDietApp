using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IActionResult> Index(int? select1, string search)
        {
            var recipesQuery = dbContext.Recipes
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
                });

            if (select1.HasValue)
            {
                recipesQuery = recipesQuery.Where(r => r.RecipeType.Id == select1.Value);
            }

            if (!string.IsNullOrEmpty(search))
            {
                recipesQuery = recipesQuery.Where(r => r.Name.Contains(search));
            }

            var model = await recipesQuery.ToListAsync();

            // Запазваме опциите в ViewBag, за да можем да ги използваме в Index.cshtml
            ViewBag.RecipeTypeOptions = await dbContext.RecipeTypes
                .AsNoTracking()
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
            var recipe = await dbContext.Recipes
                   .Include(r => r.Ingredients)
                   .ThenInclude(i => i.Type)
                      .Include(r => r.RecipeType)
                         .Include(r => r.Creator)
                     .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            var model = new DetailsRecipeViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                PrepTime = recipe.PrepTime,
                CookTime = recipe.CookTime,
                TotalTime = recipe.TotalTime,
                RecipeType = recipe.RecipeType.Name,
                Creator = recipe.Creator.UserName,
                TotalCarbohydrat = recipe.TotalCarbohydrat,
                TotalFat = recipe.TotalFat,
                TotalProtein = recipe.TotalProtein,
                Ingredients = recipe.Ingredients
            };

            return View(model);
        }

       
    }
}

