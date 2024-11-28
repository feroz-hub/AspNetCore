namespace MiddlewareExample.CustomMiddleware;

public class HelloCustomMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
        {
            string fullname = httpContext.Request.Query["firstname"] + httpContext.Request.Query["lastname"];
            await httpContext.Response.WriteAsync(fullname);
        }

        await next(httpContext);
    }
}

public static class HelloCustomMiddlewareExtension
{
    public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<HelloCustomMiddleware>();
    }
}