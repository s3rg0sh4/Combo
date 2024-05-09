namespace Combo.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Method)]
public class NullIsNotFoundAttribute(string message) : ActionFilterAttribute
{
	public override void OnActionExecuted(ActionExecutedContext context)
	{
		if (context.Result is ObjectResult objectResult && objectResult.Value == null)
		{
			var id = context.HttpContext.Request.RouteValues["Id"];
			context.Result = new NotFoundObjectResult(new { message, id });
		}
	}
}
