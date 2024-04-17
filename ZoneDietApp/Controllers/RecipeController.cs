using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<RecipeTypeViewModel>> GetRecipeTypes()
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

        public async Task<IEnumerable<ProductTypeViewModel>> GetProductTypes()
        {
            return await dbContext.ProductTypeOptions
                .AsNoTracking()
                .Select(t => new ProductTypeViewModel
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
            var model = new AddRecipeViewModel()
            {
                RecipeType = await GetRecipeTypes(),
                ProductTypeOptions = await GetProductTypes()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.RecipeType = await GetRecipeTypes();
                model.ProductTypeOptions = await GetProductTypes();
                return View(model);
            }

            // Валидацията е успешна, продължете с обработката на данните
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
     .Include(r => r.Comments)
       .Include(r => r.Ingredients)
                      //   .ThenInclude(i => i.RecipeProductType)
                      .Include(r => r.RecipeType)
                         .Include(r => r.Creator)
                     .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return BadRequest();
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
                Ingredients = recipe.Ingredients,
                Comments = recipe.Comments.Select(c => new CommentViewModel
                {
                    Name = c.Name,
                    Subject = c.Subject,
                    Message = c.Message,
                    DateTime = c.DateTime
                }).ToList()
            };

            return View(model);
        }

        [Authorize]

        [HttpPost]
        public async Task<IActionResult> PostComment(int recipeId, string name, string subject, string message)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                // If any of the required fields are empty, handle the error appropriately
                // You may want to display an error message to the user or handle it in another way
                // For simplicity, we'll just return to the details view with no changes
                return RedirectToAction("Details", new { id = recipeId });
            }

            // Find the recipe in the database
            var recipe = await dbContext.Recipes.FindAsync(recipeId);

            if (recipe == null)
            {
                // Handle the case where the recipe with the specified ID doesn't exist
                return NotFound();
            }

            // Create a new Comment object with the data from the form
            var comment = new Comment
            {
                Name = name,
                Subject = subject,
                Message = message,
                RecipeId = recipeId, // Associate the comment with the specific recipe
                DateTime = DateTime.Now.ToString() // Assuming you want to store the current date and time of the comment
            };

            // Add the comment to the recipe's collection of comments
            recipe.Comments.Add(comment);

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Redirect the user back to the details page of the recipe where the comment was posted
            return RedirectToAction("Details", new { id = recipeId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await dbContext.Recipes
                .Include(r => r.Ingredients)
                //.ThenInclude(i => i.RecipeProductType)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return BadRequest();
            }

            if (recipe.CreatorId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new AddRecipeViewModel()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                TypeId = recipe.RecipeTypeId,
                TotalCarbohydrat = recipe.TotalCarbohydrat,
                TotalFat = recipe.TotalFat,
                TotalProtein = recipe.TotalProtein,
                PrepTime = recipe.PrepTime,
                CookTime = recipe.CookTime,
                Ingredients = recipe.Ingredients,
            };

            model.RecipeType = await GetRecipeTypes();
            model.ProductTypeOptions = await GetProductTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddRecipeViewModel model, int id)
        {
            var recipe = await dbContext.Recipes
               .Include(r => r.Ingredients)
                     .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return BadRequest();
            }

            if (recipe.CreatorId != GetUserId())
            {
                return Unauthorized();
            }

            recipe.Description = model.Description;
            recipe.Name = model.Name;
            recipe.RecipeTypeId = model.TypeId;
            recipe.TotalCarbohydrat = model.TotalCarbohydrat;
            recipe.TotalFat = model.TotalFat;
            recipe.TotalProtein = model.TotalProtein;
            recipe.PrepTime = model.PrepTime;
            recipe.CookTime = model.CookTime;
            recipe.Ingredients = model.Ingredients;

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

