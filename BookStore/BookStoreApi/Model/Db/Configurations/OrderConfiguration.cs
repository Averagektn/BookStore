using BookStoreApi.Modules.Orders;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Model.Db.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        _ = builder
            .ToTable("order");

        _ = builder
            .HasKey(e => e.Id);

        _ = builder
            .Property(e => e.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        _ = builder
            .Property(e => e.TotalPrice)
            .IsRequired()
            .HasColumnName("total_price");

        _ = builder
            .HasMany(e => e.OrderBooks)
            .WithOne(e => e.Order)
            .HasForeignKey(e => e.OrderId);
    }
}
