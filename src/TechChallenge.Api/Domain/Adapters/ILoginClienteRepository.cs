namespace TechChallenge.Api.Domain.Adapters
{
    public interface ILoginClienteRepository
    {
        Task<bool> Adicionar(string? cpf);

        Task<bool> UsuarioExiste(string? cpf);
    }
}
