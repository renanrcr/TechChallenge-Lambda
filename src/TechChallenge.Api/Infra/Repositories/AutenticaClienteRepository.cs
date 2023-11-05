using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Entities;
using TechChallenge.Api.Infra.Context;

namespace TechChallenge.Api.Infra.Repositories
{
    public class AutenticaClienteRepository : Repository<AutenticaCliente>, IAutenticaClienteRepository
    {
        public AutenticaClienteRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}