using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.EntityConfigurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasColumnName("title");

            builder
                .Property(x => x.PagesCount)
                .IsRequired()
                .HasColumnName("pages_count");

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description");

            builder
                .Property(x => x.OriginalLanguage)
                .IsRequired()
                .HasColumnName("original_language");

            builder
                .Property(x => x.YearOfPublication)
                .IsRequired()
                .HasColumnName("year_of_publication");

            builder
                .Property(x => x.BookFile)
                .IsRequired()
                .HasColumnName("book_file");

            builder
                .Property(x => x.Language)
                .IsRequired()
                .HasColumnName("language");
        }
    }
}
