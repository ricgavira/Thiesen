using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thiesen.Domain.Entities;

namespace Thiesen.Infra.Data.Mapping
{
    public class AcaoMapping : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.ToTable(nameof(Acao));
        }
    }
}
