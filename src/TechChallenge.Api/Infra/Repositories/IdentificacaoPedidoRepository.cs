using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.Infra.Context;

namespace TechChallenge.Api.Infra.Repositories
{
    public class IdentificacaoPedidoRepository : Repository<IdentificacaoPedido>, IIdentificacaoPedidoRepository
    {
        public IdentificacaoPedidoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}