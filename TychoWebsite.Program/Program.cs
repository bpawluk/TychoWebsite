using Tycho;
using TychoWebsite.App;

var builder = WebApplication.CreateBuilder(args);

await builder.AddTycho<AcademyApp>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();