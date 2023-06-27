using Microsoft.AspNetCore.Mvc.Filters;

namespace CProASP.Filter
{
    public class LogFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Date of completion: {0}\n" +
                "Path: {1}\n" +
                "Method: {2}",
                DateTime.Now, context.HttpContext.Request.Path,
                context.HttpContext.Request.Method);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Date start: {0}\n" +
                "Path: {1}\n" +
                "Method: {2}", 
                DateTime.Now, context.HttpContext.Request.Path,
                context.HttpContext.Request.Method);
        }
    }
}
