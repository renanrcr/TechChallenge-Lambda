using AutoMapper;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.AutenticacaoCliente;
using TechChallenge.Api.Domain.Entities;

namespace TechChallenge.Api.Application.Services.Auth
{
    public class AutenticaClienteService : BaseService, IAutenticaClienteService
    {
        private readonly IAutenticaClienteRepository _autenticaClienteRepository;
        private readonly IMapper _mapper;

        public AutenticaClienteService(INotificador notificador,
            IAutenticaClienteRepository autenticaClienteRepository,
            IMapper mapper)
            : base(notificador)
        {
            _autenticaClienteRepository = autenticaClienteRepository;
            _mapper = mapper;
        }

        public async Task<AutenticaCliente?> AutenticarClientePorCPF(CadastraAutenticacaoClienteCommand request)
        {
            var entidade = await new AutenticaCliente().Cadastrar(_autenticaClienteRepository, request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _autenticaClienteRepository.Adicionar(entidade);

            return entidade;
        }
    }
}
