namespace Combo.Middleware;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

[AttributeUsage(AttributeTargets.Method)]
public class NullIsBadRequestAttribute(string message) : ActionFilterAttribute
{
	public override void OnActionExecuted(ActionExecutedContext context)
	{
		if (context.Result is ObjectResult objectResult && objectResult.Value == null)
			context.Result = new BadRequestObjectResult(message);
	}
}
