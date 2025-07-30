using BookStoreApi.Modules.Books;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Model.Db.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        _ = builder
            .ToTable("book");

        _ = builder
            .HasKey(e => e.Id);

        _ = builder
            .Property(e => e.Id)
            .UseMySqlIdentityColumn()
            .HasColumnName("id");

        _ = builder
            .Property(e => e.Author)
            .HasMaxLength(256)
            .IsRequired()
            .HasColumnName("author");

        _ = builder
            .Property(e => e.Description)
            .HasMaxLength(1024)
            .HasColumnName("decription");

        _ = builder
            .Property(e => e.Price)
            .IsRequired()
            .HasColumnName("price");

        _ = builder
            .Property(e => e.PublishDate)
            .IsRequired()
            .HasColumnName("publish_date");

        _ = builder
            .Property(e => e.StockQuantity)
            .IsRequired()
            .HasColumnName("slock_quantity");

        _ = builder
            .Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnName("title");

        _ = builder
            .HasMany(e => e.OrderBooks)
            .WithOne(e => e.Book);

        _ = builder
            .HasIndex(e => new { e.Author, e.Title })
            .IsUnique();
    }
}
