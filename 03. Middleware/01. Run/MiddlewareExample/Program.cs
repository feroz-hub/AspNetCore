var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello");
});
/*The Extension method called "Run" is used to execute a terminating/short-circuiting middleware
that doesn't forward the request to the next middleware*/ 
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello again");
});

app.Run();
