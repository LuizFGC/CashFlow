using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;
namespace CashFlow.Infrastrucutre.Security.Cryptography;

internal class Bcrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);
        
       
        return passwordHash;
    }

    public bool Verify(string password, string hash)
    {
      return BC.Verify(password, hash );
    }
}