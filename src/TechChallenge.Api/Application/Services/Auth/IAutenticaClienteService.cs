using TechChallenge.Api.Domain.Commands.AutenticacaoCliente;
using TechChallenge.Api.Domain.Entities;

namespace TechChallenge.Api.Application.Services.Auth
{
    public interface IAutenticaClienteService
    {
        Task<AutenticaCliente?> AutenticarClientePorCPF(CadastraAutenticacaoClienteCommand request);
    }
}
