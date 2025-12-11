using Library.ApplicationCore;
using Library.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

// Register JsonData as singleton
services.AddSingleton<JsonData>();

// Register repositories
services.AddSingleton<IPatronRepository, JsonPatronRepository>();
services.AddSingleton<ILoanRepository, JsonLoanRepository>();

// Register services
services.AddSingleton<ILoanService, LoanService>();
services.AddSingleton<IPatronService, PatronService>();

// Register configuration
services.AddSingleton<IConfiguration>(config);

// Register ConsoleApp
services.AddSingleton<ConsoleApp>();

// Build service provider
var serviceProvider = services.BuildServiceProvider();

// Get and run the ConsoleApp
var consoleApp = serviceProvider.GetRequiredService<ConsoleApp>();
await consoleApp.Run();
