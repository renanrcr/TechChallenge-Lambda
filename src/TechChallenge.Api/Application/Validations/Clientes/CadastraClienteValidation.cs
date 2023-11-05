using TechChallenge.Api.Application.Validations.Clientes.Base;
using TechChallenge.Api.Domain.Adapters;

namespace TechChallenge.Api.Application.Validations.Clientes
{
    public class CadastraClienteValidation : ClienteBaseValidation
    {
        public CadastraClienteValidation(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            ValidarDataCadastro();
            ValidarNome();
            ValidarEmail();
        }
    }
}