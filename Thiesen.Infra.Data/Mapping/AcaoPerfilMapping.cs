using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thiesen.Domain.Entities;

namespace Thiesen.Infra.Data.Mapping
{
    public class AcaoPerfilMapping : IEntityTypeConfiguration<AcaoPerfil>
    {
        public void Configure(EntityTypeBuilder<AcaoPerfil> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.ToTable(nameof(AcaoPerfil));
        }
    }
}