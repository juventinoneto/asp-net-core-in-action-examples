using Microsoft.AspNetCore;
using WebApplication1_With_Startup;

var builder = WebHost.CreateDefaultBuilder(args);

builder.UseStartup<Startup>()
    .Build()
    .Run();
