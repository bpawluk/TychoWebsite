using Tycho;
using TychoWebsite.App;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
await builder.AddTycho<AcademyApp>();

var app = builder.Build();
app.MapOpenApi("/openapi");
app.UseSwaggerUI(options => 
{
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint("/openapi", "Tycho Website");
});
app.MapControllers();
app.Run();