using Tycho;
using TychoWebsite.App;

namespace TychoWebsite.WebApi;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var tychoApp = await new AppModule().Build();
        WebApplication.CreateBuilder(args)
                      .ConfigureServices(tychoApp)
                      .SetupMiddleware()
                      .Run();
    }

    private static WebApplication ConfigureServices(this WebApplicationBuilder builder, IModule tychoApp)
    {
        builder.Services.AddSingleton(tychoApp);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder.Build();
    }

    private static WebApplication SetupMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}
