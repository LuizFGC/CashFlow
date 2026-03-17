
using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Despesas;

public interface IDespesasRepository
{
    Task Add(Despesa despesa);
    Task<List<Despesa>> GetAll();
    
    Task<Despesa?> GetById(long id);
    
    Task<bool> Delete(long id);
    
    Task<Despesa?> GetByIdUpdate(long id);
    void Update( Despesa despesa);

    Task<List<Despesa>> FiltrarMes(DateOnly month);
} 