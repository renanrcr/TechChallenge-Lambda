using AutoMapper;
using MediatR;
using TechChallenge.Api.Application.Services;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.Clientes;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Application.Services.Handlers
{
    public class ClienteHandler : BaseService,
        IRequestHandler<CadastraClienteCommand, ClienteDTO>,
        IRequestHandler<AtualizaClienteCommand, ClienteDTO>,
        IRequestHandler<DeletaClienteCommand, ClienteDTO>
    {
        private IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteHandler(INotificador notificador,
            IClienteRepository clienteRepository,
            IMapper mapper)
            : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente entidade = await new Cliente().Cadastrar(_clienteRepository, request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _clienteRepository.Adicionar(entidade);

            return _mapper.Map<ClienteDTO>(entidade);
        }

        public async Task<ClienteDTO> Handle(AtualizaClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente entidade = await new Cliente().Atualizar(_clienteRepository, request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _clienteRepository.Atualizar(entidade);

            return _mapper.Map<ClienteDTO>(entidade);
        }

        public async Task<ClienteDTO> Handle(DeletaClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente entidade = await new Cliente().Deletar(_clienteRepository, request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _clienteRepository.Remover(entidade);

            return _mapper.Map<ClienteDTO>(entidade);
        }
    }
}