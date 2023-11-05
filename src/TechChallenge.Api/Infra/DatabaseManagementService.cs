using Microsoft.AspNetCore.Builder;
using TechChallenge.Api.Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace TechChallenge.Api.Infra
{
    public class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<DataBaseContext>();
                dbContext.Database.EnsureCreated();
            }
        }
    }
}