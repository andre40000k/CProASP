using Microsoft.AspNetCore.Mvc.Filters;

namespace CProASP.Filter
{
    public class ResourceFilterAttribute : Attribute, IResourceFilter
    {
        public ResourceFilterAttribute() { }
        public ResourceFilterAttribute(ILogger<ResourceFilterAttribute> logger) 
        {
            Logger = logger;        
        }

        public ILogger Logger { get;}
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string userCookies = context.HttpContext.Request.Cookies.ToString();
            Logger.LogInformation("user Cookies: {0}", userCookies);
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string userCookies =  context.HttpContext.Request.Cookies.Count.ToString();
            Logger.LogTrace("user Cookies: {0}", userCookies);
        }
    }
}
