using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Despesas;

public interface IUserRepository
{
    Task Add(User user);
    
    Task<bool>EmailExists(string email);
    
    Task<Entities.User?> GetUserByEmail(string email);
}