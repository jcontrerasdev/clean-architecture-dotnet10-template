using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nanabills.Domain.Transactions;

namespace Nanabills.Infrastructure.Transactions.Persistence;

public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(g => g.UserId)
            .IsRequired();

        builder.Property(g => g.Type)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(g => g.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(g => g.Description)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(g => g.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(g => g.CreateAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
