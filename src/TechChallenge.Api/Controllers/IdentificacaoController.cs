using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.IdentificacoesPedido;
using TechChallenge.Api.DTOs;

namespace TechChallenge.Api.Controllers
{
    public class IdentificacaoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IIdentificacaoPedidoRepository _identificacaoPedidoRepository;

        public IdentificacaoController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            IIdentificacaoPedidoRepository identificacaoPedidoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _identificacaoPedidoRepository = identificacaoPedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<IdentificacaoDTO>>(await _identificacaoPedidoRepository.ObterTodos()));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraIdentificacaoPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}