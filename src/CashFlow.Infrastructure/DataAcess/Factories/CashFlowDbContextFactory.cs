using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CashFlow.Infrastrucutre.DataAcess.Factories;

public class CashFlowDbContextFactory : IDesignTimeDbContextFactory<CashFlowDbContext>
{
    public CashFlowDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CashFlowDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=CashFlowDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new CashFlowDbContext(optionsBuilder.Options);
    }
}