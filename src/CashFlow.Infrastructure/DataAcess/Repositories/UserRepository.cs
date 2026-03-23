using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Despesas;

namespace CashFlow.Infrastrucutre.DataAcess.Repositories;

public class UserRepository :  IUserRepository
{
    private readonly CashFlowDbContext _dbContext;
    
    public UserRepository(CashFlowDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }


    public async Task Add(User user)
    {
       await _dbContext.AddAsync(user);
        
    }
}