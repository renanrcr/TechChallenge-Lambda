using MediatR;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Domain.Commands.Clientes
{
    public class DeletaClienteCommand : IRequest<ClienteDTO>
    {
        public Guid Id { get; set; }
    }
}