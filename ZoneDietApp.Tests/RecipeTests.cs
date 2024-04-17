using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Tests
{
	[TestFixture]
	public class RecipeTests
	{
		[Test]
		public void Recipe_SetAndGetProperties()
		{
			// Arrange
			var recipe = new Recipe();

			// Act
			recipe.Name = "Test Recipe";
			recipe.Description = "Test Description";
			recipe.CreatorId = "1";

			// Assert
			Assert.AreEqual("Test Recipe", recipe.Name);
			Assert.AreEqual("Test Description", recipe.Description);
			Assert.AreEqual("1", recipe.CreatorId);
		}
	}
}