namespace WebApplication1_With_Startup;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    }

    public void Configure(IApplicationBuilder builder, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            builder.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            builder.UseHsts();
        }

        builder.UseHttpsRedirection();
        builder.UseStaticFiles();

        builder.UseRouting();

        builder.UseAuthorization();
        
        builder.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
    }
}
