using MediatR;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Domain.Commands.Clientes
{
    public class CadastraClienteCommand : IRequest<ClienteDTO>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}