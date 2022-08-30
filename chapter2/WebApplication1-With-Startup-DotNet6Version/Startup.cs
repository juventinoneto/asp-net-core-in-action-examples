namespace WebApplication1_With_Startup_DotNet6Version;

public interface IStartup
{
    void ConfigureServices(IServiceCollection services);

    void Configure(WebApplication app, IWebHostEnvironment env);

}

public class Startup : IStartup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
    }
}

public static class StartupExtensions
{ 
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder) where TStartup : IStartup 
    {
        var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration) as IStartup;
        if (startup == null) throw new ArgumentException("Classe não encontrada");

        startup.ConfigureServices(builder.Services);
        var app = builder.Build();
        startup.Configure(app, app.Environment);
        app.Run();

        return builder;
    }
}
