using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ZoneDietApp.Controllers;
using ZoneDietApp.Models;
using ZoneDietApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Tests.Controllers
{
	[TestFixture]
	public class RecipeControllerTests
	{
		[Test]
		public async Task Index_ReturnsViewResult_WithListOfRecipes()
		{
			// Arrange
			var options = new DbContextOptionsBuilder<ZoneDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDb")
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
				Assert.IsNotNull(viewResult);
				var model = viewResult.Model as IEnumerable<AllRecipesViewModel>;
				Assert.IsNotNull(model);
				Assert.AreEqual(2, model.Count());
			}
		}

		// Add more test methods as needed
	}
}
