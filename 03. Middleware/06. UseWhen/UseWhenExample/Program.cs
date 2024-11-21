var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(context =>context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello form Middleware Branch");
            await next();
        });
    });

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from middleware at main chain");
});
app.Run();