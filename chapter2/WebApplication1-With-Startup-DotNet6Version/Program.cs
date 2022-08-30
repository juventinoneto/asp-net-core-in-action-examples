using WebApplication1_With_Startup_DotNet6Version;

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();
