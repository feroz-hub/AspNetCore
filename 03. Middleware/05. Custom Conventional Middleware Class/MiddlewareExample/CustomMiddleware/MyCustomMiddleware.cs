namespace MiddlewareExample.CustomMiddleware;


public class MyCustomMiddleware:IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("My Custom Middleware -Start \n");
        await next(context);
        await context.Response.WriteAsync("My CustomMiddleware -Ends \n");
    }
}

public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<MyCustomMiddleware>();
        return app;
    }
}