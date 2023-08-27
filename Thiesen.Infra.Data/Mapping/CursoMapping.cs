using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thiesen.Domain.Entities;

namespace Thiesen.Infra.Data.Mapping
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.ToTable(nameof(Curso));
        }
    }
}
