using FluentValidation;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.Domain.ValueObjects;

namespace TechChallenge.Api.Application.Validations.AutenticacaoCliente
{
    public class CadastraAutenticacaoClienteValidation : ValidationBase<AutenticaCliente>
    {
        private IAutenticaClienteRepository _identificacaoPedidoRepository;

        public CadastraAutenticacaoClienteValidation(IAutenticaClienteRepository identificacaoPedidoRepository)
        {
            _identificacaoPedidoRepository = identificacaoPedidoRepository;

            ValidarId();
            ValidarValorCliente();
            ValidarValorCPF();
            ValidarExisteIdentificacaoCadastrada();
            ValidarDataCadastro();
        }

        public void ValidarValorCliente()
        {
            RuleFor(x => x.CPF).Must((x, CPF) =>
            {
                return !string.IsNullOrEmpty(x.CPF);
            }).WithMessage("Informe um valor válido.");
        }

        public void ValidarValorCPF()
        {
            RuleFor(x => x.CPF).Must((x, CPF) =>
            {
                return ValidarCPF(x.CPF);
            }).WithMessage("Informe um CPF válido.");
        }

        private bool ValidarCPF(string? valor) => new CPF(valor).IsValidado;

        private void ValidarExisteIdentificacaoCadastrada()
        {
            RuleFor(s => s.CPF)
                .MustAsync(ExisteIdentificacaoAsync).WithMessage("Identificação já cadastrada em nossa base de dados.");
        }

        private async Task<bool> ExisteIdentificacaoAsync(string? valor, CancellationToken token)
        {
            return !await _identificacaoPedidoRepository.Existe(x => !string.IsNullOrEmpty(valor) && x.CPF == valor);
        }
    }
}