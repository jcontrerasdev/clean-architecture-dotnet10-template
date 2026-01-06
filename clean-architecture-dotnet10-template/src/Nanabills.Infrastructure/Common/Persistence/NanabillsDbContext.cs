using Microsoft.EntityFrameworkCore;
using Nanabills.Application.Common.Interfaces;
using System.Reflection;
using Nanabills.Domain.Transactions;

namespace Nanabills.Infrastructure.Common.Persistence;

public class NanabillsDbContext : DbContext, IUnitOfWork
{
    public NanabillsDbContext(DbContextOptions<NanabillsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; } = null!;

    public async Task<int> CommitChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}