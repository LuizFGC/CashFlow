using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Despesas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastrucutre.DataAcess.Repositories;

internal class DespesasRepository : IDespesasRepository
{
    private readonly CashFlowDbContext _dbContext;
    
    public DespesasRepository(CashFlowDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }
    public async Task Add(Despesa despesa)
    {
        await _dbContext.Despesas.AddAsync(despesa);
    }

    public async Task<List<Despesa>> GetAll()
    {
        return await _dbContext.Despesas.AsNoTracking().ToListAsync();
    }
    
    public async Task<Despesa?> GetById(long id)
    {
        return await _dbContext.Despesas.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Despesas.FirstOrDefaultAsync(d => d.Id == id);

        if (result is null)
        {
            return false;
        }
        
        _dbContext.Despesas.Remove(result);
        return true;
    }

    public async Task<Despesa?> GetByIdUpdate(long id)
    {
        return await _dbContext.Despesas.FirstOrDefaultAsync(d => d.Id == id);
    }

    public void Update( Despesa despesa)
    {
        _dbContext.Despesas.Update(despesa);
    }
}