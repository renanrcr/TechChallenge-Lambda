using AutoMapper;
using MediatR;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.IdentificacoesPedido;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Application.Services.Handlers
{
    public class IdentificacaoPedidoHandler : BaseService,
        IRequestHandler<CadastraIdentificacaoPedidoCommand, IdentificacaoDTO>
    {
        private readonly IIdentificacaoPedidoRepository _identificacaoPedidoRepository;
        private readonly IMapper _mapper;

        public IdentificacaoPedidoHandler(INotificador notificador,
            IIdentificacaoPedidoRepository identificacaoPedidoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _identificacaoPedidoRepository = identificacaoPedidoRepository;
            _mapper = mapper;
        }

        public async Task<IdentificacaoDTO> Handle(CadastraIdentificacaoPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new IdentificacaoPedido().Cadastrar(_identificacaoPedidoRepository, request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _identificacaoPedidoRepository.Adicionar(entidade);

            return _mapper.Map<IdentificacaoDTO>(entidade);
        }
    }
}