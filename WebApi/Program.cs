namespace TychoWebsite;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplication.CreateBuilder(args)
                      .ConfigureServices()
                      .SetupMiddleware()
                      .Run();
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