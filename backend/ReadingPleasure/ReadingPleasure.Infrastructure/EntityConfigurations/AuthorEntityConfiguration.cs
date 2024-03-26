using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.EntityConfigurations
{
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("first_name");

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("last_name");

            builder
                .Property(x => x.Biography)
                .IsRequired()
                .HasColumnName("biography");

            builder
                .Property(x => x.Image)
                .IsRequired()
                .HasColumnName("image");

            builder
                .Property(s => s.Sex)
                .HasColumnName("sex")
                .HasMaxLength(1)
                .HasColumnType("varchar(1)")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
