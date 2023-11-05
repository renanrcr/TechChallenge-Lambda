using AutoMapper;
using MediatR;
using TechChallenge.Api.Application.Services.Auth;
using TechChallenge.Api.Domain.Commands.AutenticacaoCliente;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Application.Services.Handlers
{
    public class AutenticaClienteHandler : IRequestHandler<CadastraAutenticacaoClienteCommand, AutenticacaoClienteDTO>
    {
        private readonly IAutenticaClienteService _autenticaClienteService;
        private readonly IMapper _mapper;

        public AutenticaClienteHandler(IAutenticaClienteService autenticaClienteService,
            IMapper mapper)
        {
            _autenticaClienteService = autenticaClienteService;
            _mapper = mapper;
        }

        public async Task<AutenticacaoClienteDTO> Handle(CadastraAutenticacaoClienteCommand request, CancellationToken cancellationToken)
        {
            AutenticaCliente? autenticaCliente = await _autenticaClienteService.AutenticarClientePorCPF(request);
                        
            return _mapper.Map<AutenticacaoClienteDTO>(autenticaCliente);
        }
    }
}