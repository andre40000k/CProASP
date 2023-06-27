using Microsoft.AspNetCore.Mvc.Filters;

namespace CProASP.Filter
{
    public class ResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string userCookies = context.HttpContext.Request.Cookies.ToString();
            Console.WriteLine("user Cookies: {0}", userCookies);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string userCookies =  context.HttpContext.Request.Cookies.Count.ToString();
            Console.WriteLine("user Cookies: {0}", userCookies);
        }
    }
}
