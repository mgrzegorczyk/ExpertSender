using ExpertSender.Infrastructure.Data;
using ExpertSender.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExpertSender.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        
        serviceCollection.AddScoped<IPersonRepository, PersonRepository>();
        serviceCollection.AddScoped<IEmailRepository, EmailRepository>();
        serviceCollection.AddScoped<DataSeeder>();

        return serviceCollection;
    }

    public static void InitializeDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var seeder = services.GetRequiredService<DataSeeder>();
                seeder.Seed();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<DataSeeder>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }
    }
}