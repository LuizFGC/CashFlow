using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;

public class User
{
    public long Id {get; set;}
    
    public string Name {get; set;} = String.Empty;
    
    public string Email {get; set;} = String.Empty;
    
    public string Password {get; set;} = String.Empty;
    
    public Guid UserId {get; set;}

    public string Role { get; set; } = Roles.TEAM_MEMBER;
}





