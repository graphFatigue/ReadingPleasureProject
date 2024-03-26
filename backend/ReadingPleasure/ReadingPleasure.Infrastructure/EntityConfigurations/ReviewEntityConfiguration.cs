using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.EntityConfigurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(x => x.Content)
                .IsRequired()
                .HasColumnName("content");

            builder
                .Property(s => s.ReaderId)
                .HasColumnName("user_id");

            builder
                .HasOne(c => c.Reader)
                .WithMany(x => x.Reviews)
                .HasForeignKey(c => c.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(s => s.BookId)
                .HasColumnName("book_id");

            builder
                .HasOne(c => c.Book)
                .WithMany(x => x.Reviews)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
