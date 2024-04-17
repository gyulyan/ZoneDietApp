using Microsoft.AspNetCore.Mvc;
using ZoneDietApp.Controllers;

namespace ZoneDietApp.Tests
{

	public class BlockCalculatorControllerTests
	{

		[Test]
		public void Index_ReturnsViewResult()
		{
			// Arrange
			var controller = new BlockCalculatorController();

			// Act
			var result = controller.Index();

			// Assert
			Assert.That(result, Is.InstanceOf<ViewResult>());
		}

		// Add more test methods as needed
	}
}