using CashFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CashFlow.Infrastrucutre.DataAcess;

internal class UnidadeDeTrabalho : IUnidadeDeTrabalho
{
    private readonly CashFlowDbContext _dbcontext;

    public UnidadeDeTrabalho(CashFlowDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task Commit()
    {
       await _dbcontext.SaveChangesAsync();
    }
    
}