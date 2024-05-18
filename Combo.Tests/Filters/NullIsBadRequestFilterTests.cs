namespace Combo.Tests.Filters;
using Combo.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class NullIsBadRequestFilterTests
{
	[Fact]
	public void NullIsBadRequestFilter_NullResult()
	{
		// Arrange
		var actionContext = new ActionExecutedContext(new(new DefaultHttpContext(), new(), new()), [], null)
		{
			Result = new OkObjectResult(null)
		};

		var filter = new NullIsBadRequestAttribute("Test");

		// Act
		filter.OnActionExecuted(actionContext);

		// Assert
		Assert.IsType<BadRequestObjectResult>(actionContext.Result);
	}

	[Fact]
	public void NullIsBadRequestFilter_HasResult()
	{
		// Arrange
		var actionContext = new ActionExecutedContext(new(new DefaultHttpContext(), new(), new()), [], null)
		{
			Result = new OkObjectResult(new())
		};

		var filter = new NullIsBadRequestAttribute("Test");

		// Act
		filter.OnActionExecuted(actionContext);

		// Assert
		Assert.IsType<OkObjectResult>(actionContext.Result);
	}

}
