using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.EntityConfigurations
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genres");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name");

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description");
        }
    }
}
