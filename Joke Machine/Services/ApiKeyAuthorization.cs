using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Joke_Machine.Services
{
    public class ApiKeyAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            var expectedApiKey = "oGHzIB1jGKv36rT1x3hmAETPgoZSw+xXXj0MhjqNgfip1naKV2M18MtkAz3P+nI6WB5SSFkf5zdh19LG1u7qeXZZkG/97mR1gURVvcn0OtIUfzQSfvzm26lp6nV438jasIqwwp5KtODfmJPYhSa7/EHQ/W+sPJaMTh2kxLNljUZrsQHmV5I3qWxA3SWnfjdavkPZV19c8W/9U6sLnrrnM0X37ZmhEe5OJgTCjExGFbw3cGaH9wRFFMmYqoqJHrGG97bVqvhetnNW7ZUQaYuWYhidt2SgJWcZfQUoR1pQYlVabliMAuDFWGBmgh7LXSxuId2V6GCw6OGUs/sw4byCQg=="; 

            if (!context.HttpContext.Request.Headers.TryGetValue("x-api-key", out var apiKey) || apiKey != expectedApiKey)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
