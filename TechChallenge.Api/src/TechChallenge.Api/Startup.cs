using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Api.Infra.Context;
using TechChallenge.Api.Application;
using Microsoft.OpenApi.Models;
using TechChallenge.Api.Infra;
using Microsoft.Extensions.Hosting;

namespace TechChallenge.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        var connectionString = Configuration.GetSection("DatabaseSettings:ConnectionString").Value;
        services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(AppDomain)));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddInfraModule();
        services.AddApplicationModule();

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechChallenge - Fase 02", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechChallenge v1"));
        }

        DatabaseManagementService.MigrationInitialisation(app);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", context => {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
        });
    }
}