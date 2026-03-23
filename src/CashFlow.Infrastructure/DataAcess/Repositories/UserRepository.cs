using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Despesas;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> EmailExists(string email)
    {
      return await _dbContext.Users.AnyAsync(u => u.Email.Equals(email));

   
    }

    public async Task<User?> GetUserByEmail(string email)
    {
       return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email.Equals(email));
    }
}