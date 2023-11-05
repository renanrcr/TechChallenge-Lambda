using TechChallenge.Api.Application.Validations.Clientes;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.Clientes;

namespace TechChallenge.Api.Domain.Entities
{
    public class Cliente : EntidadeBase<Guid>
    {
        public string? Nome { get; private set; }
        public string? Email { get; private set; }

        public async Task<Cliente> Cadastrar(IClienteRepository clienteRepository, CadastraClienteCommand command)
        {
            Id = Guid.NewGuid();
            Nome = command.Nome;
            Email = command.Email;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraClienteValidation(clienteRepository));

            return this;
        }

        public async Task<Cliente> Atualizar(IClienteRepository clienteRepository, AtualizaClienteCommand command)
        {
            Id = command.Id;
            Nome = command.Nome;
            Email = command.Email;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaClienteValidation(clienteRepository));

            return this;
        }

        public async Task<Cliente> Deletar(IClienteRepository clienteRepository, DeletaClienteCommand command)
        {
            Id = command.Id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaClienteValidation(clienteRepository));

            return this;
        }
    }
}