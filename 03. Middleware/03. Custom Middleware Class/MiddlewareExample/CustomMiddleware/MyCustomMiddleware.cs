namespace MiddlewareExample.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project

    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - Starts");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - Ends");
        }
    }


}
