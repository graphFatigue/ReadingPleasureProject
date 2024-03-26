using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingPleasure.Domain.Entities;

namespace ReadingPleasure.Infrastructure.EntityConfigurations
{
    public class EditionEntityConfiguration : IEntityTypeConfiguration<Edition>
    {
        public void Configure(EntityTypeBuilder<Edition> builder)
        {
            builder.ToTable("editions");

            builder
                .Property(c => c.Id)
                .HasColumnName("id");

            builder.HasKey(b => b.Id);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description");

            builder
                .Property(s => s.BookId)
                .HasColumnName("book_id");

            builder
                .HasOne(c => c.Book)
                .WithMany(x => x.Editions)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(s => s.PublishingHouseId)
                .HasColumnName("publishing_house_id");

            builder
                .HasOne(c => c.PublishingHouse)
                .WithMany(x => x.Editions)
                .HasForeignKey(c => c.PublishingHouseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
