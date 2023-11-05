using TechChallenge.Api.Application.Validations.IdentificacoesPedido;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.IdentificacoesPedido;
using TechChallenge.Api.Domain.Enums;

namespace TechChallenge.Api.Domain.Entities
{
    public class IdentificacaoPedido : EntidadeBase<Guid>
    {
        public string? Valor { get; private set; }
        public ETipoIdentificacaoPedido TipoIdentificacaoPedido { get; private set; }

        public async Task<IdentificacaoPedido> Cadastrar(IIdentificacaoPedidoRepository identificacaoPedidoRepository, CadastraIdentificacaoPedidoCommand command)
        {
            Id = Guid.NewGuid();
            Valor = command.Valor;
            TipoIdentificacaoPedido = (ETipoIdentificacaoPedido)command.TipodIdentificacaoPedido;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraIdentificacaoPedidoValidation(identificacaoPedidoRepository));

            return this;
        }
    }
}