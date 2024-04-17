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
					.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDb;Trusted_Connection=True;")
					.Options;
				using (var dbContext = new ZoneDbContext(options))
				{
					dbContext.Recipes.Add(new Recipe { Name = "Recipe 1" });
					dbContext.Recipes.Add(new Recipe { Name = "Recipe 2" });
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
					Assert.That(model.Count(), Is.EqualTo(2));
				}
			}

			// Add more test methods as needed
		}
}
