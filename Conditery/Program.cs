using Conditery;
using Conditery.Context;
using Conditery.Repository;
using Conditery.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Configuration;

var app = BuildConfig();
app.Start();

static AppStart BuildConfig()
{

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/ConditeryLog-.txt"), rollingInterval: RollingInterval.Day)
        .CreateLogger();

    var services = new ServiceCollection()
    .AddDbContextFactory<ApplicationContext>(options =>
    {
        options.UseSqlServer(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["connectionString"].Value);
        options.EnableSensitiveDataLogging();
    },
    lifetime: ServiceLifetime.Singleton);

    services.AddSingleton<IUserRepository, UserRepository>();
    services.AddSingleton<IOrderRepository, OrderRepository>();

    services.AddTransient<IOrderService, OrderService>();
    services.AddTransient<IUserService, UserService>();

    services.AddTransient<AppStart>();

    var serviceProvider = services.BuildServiceProvider();

    var userRepo = serviceProvider.GetService<IUserRepository>();

    userRepo.ABOBA();

    //logger.LogInformation("Closing Application");
    AppStart app = serviceProvider.GetService<AppStart>();
    return app;
}
