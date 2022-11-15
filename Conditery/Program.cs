using Conditery;
using Conditery.Context;
using Conditery.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;

var app = BuildConfig();
app.Start();

static AppStart BuildConfig()
{
    var services = new ServiceCollection()
    .AddDbContextFactory<ApplicationContext>(options =>
    {
        options.UseSqlServer(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["connectionString"].Value);
        options.EnableSensitiveDataLogging();
    },
    lifetime: ServiceLifetime.Singleton);

    services.AddTransient<IUserRepository, UserRepository>();
    services.AddTransient<IOrderRepository, OrderRepository>();

    services.AddTransient<AppStart>();

    var serviceProvider = services.BuildServiceProvider();

    var userRepo = serviceProvider.GetService<IUserRepository>();

    userRepo.ABOBA();

    //logger.LogInformation("Closing Application");
    AppStart app = serviceProvider.GetService<AppStart>();
    return app;
}