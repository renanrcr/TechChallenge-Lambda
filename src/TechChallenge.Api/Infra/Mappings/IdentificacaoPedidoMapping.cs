using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechChallenge.Api.Domain.Entities;

namespace TechChallenge.Api.Infra.Mappings
{
    public class IdentificacaoPedidoMapping : IEntityTypeConfiguration<IdentificacaoPedido>
    {
        public void Configure(EntityTypeBuilder<IdentificacaoPedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("IdentificacaoPedido");
        }
    }
}