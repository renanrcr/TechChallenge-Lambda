using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Api.Application.Notificacoes;
using TechChallenge.Api.Application.Services.Auth;
using TechChallenge.Api.Domain.Adapters;

namespace TechChallenge.Api.Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAutenticaClienteService, AutenticaClienteService>();
        }
    }
}