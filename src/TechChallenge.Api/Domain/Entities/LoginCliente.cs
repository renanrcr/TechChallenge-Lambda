using Amazon.DynamoDBv2.DataModel;

namespace TechChallenge.Api.Domain.Entities
{
    [DynamoDBTable("customers_cache")]
    public class LoginCliente
    {

        [DynamoDBHashKey("userId")]
        public Guid UsuarioId { get; set; }

        [DynamoDBProperty("cpf")]
        public string? CPF { get; set; }

        [DynamoDBProperty("ttl")]
        public long Ttl { get; set; }

        public LoginCliente Cadastrar(string? cpf)
        {
            var entidade = new LoginCliente
            {
                UsuarioId = Guid.NewGuid(),
                CPF = cpf,
                Ttl = DateTimeOffset.Now.AddDays(1).ToUnixTimeSeconds(),
            };

            return entidade;
        }
    }
}
