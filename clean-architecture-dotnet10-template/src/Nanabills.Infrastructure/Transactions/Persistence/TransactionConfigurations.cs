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

        builder.HasIndex(g => g.UserId);

        builder.HasIndex(g => g.CreateAt);

        builder.Property(g => g.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(g => g.UserId)
            .IsRequired();

        builder.Property(s => s.Type)
            .IsRequired()
            .HasConversion(
                type => type.Name,
                name => TransactionType.FromName(name));

        builder.Property(g => g.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(g => g.Description)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(s => s.Status)
            .IsRequired()
            .HasConversion(
                status => status.Name,
                name => TransactionStatusType.FromName(name));

        builder.Property(g => g.CreateAt)
            .IsRequired();
    }
}
