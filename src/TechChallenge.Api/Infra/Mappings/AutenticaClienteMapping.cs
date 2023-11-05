using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TechChallenge.Api.Domain.Entities;

namespace TechChallenge.Api.Infra.Mappings
{
    public class AutenticaClienteMapping : IEntityTypeConfiguration<AutenticaCliente>
    {
        public void Configure(EntityTypeBuilder<AutenticaCliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("AutenticaCliente");
        }
    }
}