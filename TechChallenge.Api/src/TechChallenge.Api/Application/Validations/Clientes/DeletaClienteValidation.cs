using TechChallenge.Api.Application.Validations.Clientes.Base;
using TechChallenge.Api.Domain.Adapters;

namespace TechChallenge.Api.Application.Validations.Clientes
{
    public class DeletaClienteValidation : ClienteBaseValidation
    {
        public DeletaClienteValidation(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            ValidarExisteClienteCadastrado();
            ValidarDataExclusao();
        }
    }
}