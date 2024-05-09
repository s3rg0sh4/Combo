namespace Combo.Middleware;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Method)]
public class NullIsNotFoundAttribute(string message) : ActionFilterAttribute
{
	public override void OnActionExecuted(ActionExecutedContext context)
	{
		if (context.Result is ObjectResult objectResult && objectResult.Value == null)
			context.Result = new NotFoundObjectResult(message);
	}
}
