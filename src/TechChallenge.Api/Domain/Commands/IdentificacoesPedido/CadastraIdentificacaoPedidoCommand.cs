using MediatR;
using TechChallenge.Api.Domain.Enums;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Domain.Commands.IdentificacoesPedido
{
    public class CadastraIdentificacaoPedidoCommand : IRequest<IdentificacaoDTO>
    {
        public string? Valor { get; set; }
        public int TipodIdentificacaoPedido { get; set; } = (int)ETipoIdentificacaoPedido.NAO_IDENTIFICADO;
    }
}