using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thiesen.Domain.Entities;

namespace Thiesen.Infra.Data.Mapping
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.TipoContato)
                   .IsRequired();

            builder.ToTable(nameof(Contato));
        }
    }
}
