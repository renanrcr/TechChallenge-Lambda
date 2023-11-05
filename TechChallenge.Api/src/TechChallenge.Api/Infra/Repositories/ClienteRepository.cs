using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.Infra.Context;

namespace TechChallenge.Api.Infra.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}