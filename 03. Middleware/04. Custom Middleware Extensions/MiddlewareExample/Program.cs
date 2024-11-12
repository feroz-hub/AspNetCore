using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// Middleware 1
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("From Middleware 1\n");
    await next(context);
});
// Middleware 2
app.UseMyCustomMiddleware();

// Middleware 3
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("From Middleware 3\n");
    await next(context);
});



app.Run();
