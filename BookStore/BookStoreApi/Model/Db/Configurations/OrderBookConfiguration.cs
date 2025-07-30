using BookStoreApi.Modules.OrderBooks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Model.Db.Configurations;

public class OrderBookConfiguration : IEntityTypeConfiguration<OrderBook>
{
    public void Configure(EntityTypeBuilder<OrderBook> builder)
    {
        _ = builder
            .ToTable("order_book");

        _ = builder
            .HasKey(e => new { e.BookId, e.OrderId });

        _ = builder
            .Property(e => e.Price)
            .IsRequired()
            .HasColumnName("price");

        _ = builder
            .Property(e => e.Quantity)
            .IsRequired()
            .HasColumnName("quantity");

        _ = builder
            .Property(e => e.BookId)
            .HasColumnName("book_id")
            .IsRequired();

        _ = builder
            .Property(e => e.OrderId)
            .HasColumnName("order_id")
            .IsRequired();

        _ = builder
            .HasOne(e => e.Book)
            .WithMany(e => e.OrderBooks)
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder
            .HasOne(e => e.Order)
            .WithMany(e => e.OrderBooks)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
