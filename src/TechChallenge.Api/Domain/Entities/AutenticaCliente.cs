using TechChallenge.Api.Application.Validations.AutenticacaoCliente;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.AutenticacaoCliente;

namespace TechChallenge.Api.Domain.Entities
{
    public class AutenticaCliente : EntidadeBase<Guid>
    {
        public string? CPF { get; private set; }

        public async Task<AutenticaCliente> Cadastrar(IAutenticaClienteRepository autenticaClienteRepository, CadastraAutenticacaoClienteCommand command)
        {
            Id = Guid.NewGuid();
            CPF = command.CPF;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraAutenticacaoClienteValidation(autenticaClienteRepository));

            return this;
        }
    }
}