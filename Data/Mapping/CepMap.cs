using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Cep);

            builder.HasOne(x => x.Municipio)
                   .WithMany(y => y.Ceps);
        }
    }
}
