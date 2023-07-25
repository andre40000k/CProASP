using Microsoft.AspNetCore.Mvc.Filters;

namespace CProASP.Filter
{
    public class LogFilterAttribute : Attribute, IActionFilter
    {
        public LogFilterAttribute() { }
        public LogFilterAttribute(ILogger<LogFilterAttribute> logger) 
        {
            Logger= logger;
        }

        public ILogger<LogFilterAttribute> Logger { get;}
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogTrace("Date of completion: {0}\n" +
                "Path: {1}\n" +
                "Method: {2}",
                DateTime.Now, context.HttpContext.Request.Path,
                context.HttpContext.Request.Method);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("Date start: {0}\n" +
                "Path: {1}\n" +
                "Method: {2}", 
                DateTime.Now, context.HttpContext.Request.Path,
                context.HttpContext.Request.Method);
        }
    }
}
