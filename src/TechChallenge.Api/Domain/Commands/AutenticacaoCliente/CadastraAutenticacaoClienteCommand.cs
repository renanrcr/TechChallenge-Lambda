using MediatR;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Domain.Commands.AutenticacaoCliente
{
    public class CadastraAutenticacaoClienteCommand : IRequest<AutenticacaoClienteDTO>
    {
        public string? CPF { get; set; }
    }
}