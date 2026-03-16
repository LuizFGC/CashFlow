using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastrucutre.DataAcess;

public class CashFlowDbContext : DbContext
{

    public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options) : base(options) {}
    
    public DbSet<Despesa>Despesas { get; set; }


}