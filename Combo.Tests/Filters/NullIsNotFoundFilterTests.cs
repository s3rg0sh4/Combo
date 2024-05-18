namespace Combo.Tests.Filters;
using Combo.Filters;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class NullIsNotFoundFilterTests
{
	[Fact]
	public void NullIsNotFoundFilter_NullResult()
	{
		// Arrange
		var actionContext = new ActionExecutedContext(new(new DefaultHttpContext(), new(), new()), [], null)
		{
			Result = new OkObjectResult(null)
		};

		var filter = new NullIsNotFoundAttribute("Test");

		// Act
		filter.OnActionExecuted(actionContext);

		// Assert
		Assert.IsType<NotFoundObjectResult>(actionContext.Result);
	}

	[Fact]
	public void NullIsNotFoundFilter_HasResult()
	{
		// Arrange
		var actionContext = new ActionExecutedContext(new(new DefaultHttpContext(), new(), new()), [], null)
		{
			Result = new OkObjectResult(new())
		};

		var filter = new NullIsNotFoundAttribute("Test");

		// Act
		filter.OnActionExecuted(actionContext);

		// Assert
		Assert.IsType<OkObjectResult>(actionContext.Result);
	}
}
