using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thiesen.Domain.Entities;

namespace Thiesen.Infra.Data.Mapping
{
    public class PessoaFisicaEnderecoMapping : IEntityTypeConfiguration<PessoaFisicaEndereco>
    {
        public void Configure(EntityTypeBuilder<PessoaFisicaEndereco> builder)
        {
            builder.HasKey(x => new { x.PessoaFisicaId, x.EnderecoId });

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(x => x.PessoaFisica)
                .WithMany(p => p.PessoaFisicaEnderecos)
                .HasForeignKey(x => x.PessoaFisicaId);

            builder.HasOne(x => x.Endereco)
                .WithMany(p => p.PessoaFisicaEnderecos)
                .HasForeignKey(x => x.EnderecoId);

            builder.ToTable(nameof(PessoaFisicaEndereco));
        }
    }
}
