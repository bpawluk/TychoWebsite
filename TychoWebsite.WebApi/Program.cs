using TychoWebsite.App;

namespace TychoWebsite.WebApi;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var app = await WebApplication.CreateBuilder(args).AddTychoApp();
        app.ConfigureServices()
           .SetupMiddleware()
           .Run();
    }

    private static async Task<WebApplicationBuilder> AddTychoApp(this WebApplicationBuilder builder)
    {
        var tychoApp = await new AppModule()
            .Configure(configuarionBuilder =>
            {
                configuarionBuilder.AddConfiguration(builder.Configuration);
            }).Build();
        builder.Services.AddSingleton(tychoApp);
        return builder;
    }

    private static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
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
