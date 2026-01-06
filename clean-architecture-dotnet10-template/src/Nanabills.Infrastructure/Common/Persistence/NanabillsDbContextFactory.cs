using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nanabills.Infrastructure.Common.Persistence;

public class NanabillsDbContextFactory : IDesignTimeDbContextFactory<NanabillsDbContext>
{
    public NanabillsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NanabillsDbContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=NanabillsDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new NanabillsDbContext(optionsBuilder.Options);
    }
}
