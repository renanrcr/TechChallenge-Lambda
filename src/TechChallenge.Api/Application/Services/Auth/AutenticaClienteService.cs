using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.AutenticacaoCliente;
using TechChallenge.Api.Domain.Entities;

namespace TechChallenge.Api.Application.Services.Auth
{
    public class AutenticaClienteService : BaseService, IAutenticaClienteService
    {
        private readonly IAutenticaClienteRepository _autenticaClienteRepository;
        private readonly ILoginClienteRepository _loginClienteRepository;

        public AutenticaClienteService(INotificador notificador,
            IAutenticaClienteRepository autenticaClienteRepository,
            ILoginClienteRepository loginClienteRepository)
            : base(notificador)
        {
            _autenticaClienteRepository = autenticaClienteRepository;
            _loginClienteRepository = loginClienteRepository;
        }

        public async Task<AutenticaCliente?> AutenticarClientePorCPF(CadastraAutenticacaoClienteCommand request)
        {
            var entidade = await new AutenticaCliente().Cadastrar(_autenticaClienteRepository, request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _autenticaClienteRepository.Adicionar(entidade);

            await _loginClienteRepository.Adicionar(entidade.CPF);

            bool usuarioExiste = await _loginClienteRepository.UsuarioExiste(entidade.CPF);

            if (!usuarioExiste)
                await _loginClienteRepository.Adicionar(entidade.CPF);

            return entidade;
        }
    }
}
