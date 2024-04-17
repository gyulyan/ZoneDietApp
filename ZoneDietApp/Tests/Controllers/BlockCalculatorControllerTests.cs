using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ZoneDietApp.Controllers;
using ZoneDietApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ZoneDietApp.Tests.Controllers
{
	[TestFixture]
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
