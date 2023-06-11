using Hocomm.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Hocomm.WebApi.Filters;

public class HttpResponseHeadersFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 11;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        context.HttpContext.Response.Headers.Add("X-Powered-By", "LIFO_C");
    }
}