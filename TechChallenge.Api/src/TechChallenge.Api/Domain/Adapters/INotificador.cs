using TechChallenge.Api.Application.Notificacoes;

namespace TechChallenge.Api.Domain.Adapters
{
    public interface INotificador
    {
        bool TemNotificacao();

        object ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}