using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Commands.AutenticacaoCliente;

namespace TechChallenge.Api.Controllers
{
    internal class AuthClienteController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthClienteController(INotificador notificador,
            IMediator mediator)
            : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraAutenticacaoClienteCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}