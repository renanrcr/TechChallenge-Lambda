using Amazon.DynamoDBv2.DataModel;
using TechChallenge.Api.Domain.Adapters;
using TechChallenge.Api.Domain.Entities;

namespace TechChallenge.Api.Infra.Repositories
{
    public class LoginClienteRepository : ILoginClienteRepository
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public LoginClienteRepository(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public async Task<bool> Adicionar(string? cpf)
        {
            try
            {
                var loginUsuario = new LoginCliente();
                loginUsuario.Cadastrar(cpf);

                await _dynamoDBContext.SaveAsync(loginUsuario);

                return true;
            }
            catch { return false; }
        }

        public async Task<bool> UsuarioExiste(string? cpf)
        {
            try
            {
                var entidade = await _dynamoDBContext.LoadAsync<LoginCliente>(cpf);

                return entidade != null && !string.IsNullOrWhiteSpace(entidade.CPF);
            }
            catch { return false; }
        }
    }
}
