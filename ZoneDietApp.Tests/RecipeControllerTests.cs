using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZoneDietApp.Controllers;
using ZoneDietApp.Data;
using ZoneDietApp.Data.Models;
using ZoneDietApp.Models;

namespace ZoneDietApp.Tests
{
	[TestFixture]
	public class RecipeControllerTests
	{
		[Test]
		public async Task Index_ReturnsViewResult_WithListOfRecipes()
		{
			// Arrange
			var options = new DbContextOptionsBuilder<ZoneDbContext>()
				.UseSqlServer("Server=C-6LZCHR2\\SQLEXPRESS;Database=ZoneDietApp;Trusted_Connection=True;MultipleActiveResultSets=true")
				.Options;

			var recipesCount = 0;

			using (var dbContext = new ZoneDbContext(options))
			{
				recipesCount = dbContext.Recipes.Count();

				var ingredient1 = new RecipeProduct
				{				
					Name = "сирене",
					Weight = 20
				};
				var ingredient2 = new RecipeProduct
				{
					Name = "кашкавал",
					Weight = 20
				};

				var ingredients = new List<RecipeProduct>();
				ingredients.Add(ingredient1);
				ingredients.Add(ingredient2);

				

				dbContext.Recipes.Add(new Recipe
				{
					Name = "Рецепта 1",
					Description = "Начин на приготвяне на Рецепта 1",
					CreatorId = "5ef9cf9f-7320-4342-80e8-cfffa708eaed",
					PrepTime = 10,
					CookTime = 20,
					TotalTime = 30,
					Ingredients = ingredients,
					RecipeTypeId = 1,
					TotalCarbohydrat = 3,
					TotalFat = 2,
					TotalProtein = 1,
					CreatedOn = DateTime.Now
				});
				dbContext.SaveChanges();
			}

			using (var dbContext = new ZoneDbContext(options))
			{
				var controller = new RecipeController(dbContext);

				// Act
				var result = await controller.Index(null, null);
				
				// Assert
				Assert.That(result, Is.InstanceOf<ViewResult>());
				var viewResult = result as ViewResult;
				Assert.That(viewResult, Is.Not.Null);
				var model = viewResult.Model as IEnumerable<AllRecipesViewModel>;
				Assert.That(model, Is.Not.Null);
				Assert.That(model.Count(), Is.EqualTo(recipesCount+1));
			}
		}

		// Add more test methods as needed
	}
}
