using TechChallenge.Api.Application.Validations.Clientes.Base;
using TechChallenge.Api.Domain.Adapters;

namespace TechChallenge.Api.Application.Validations.Clientes
{
    public class AtualizaClienteValidation : ClienteBaseValidation
    {
        public AtualizaClienteValidation(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            ValidarExisteClienteCadastrado();
            ValidarNome();
            ValidarEmail();
            ValidarDataAtualizacao();
        }
    }
}