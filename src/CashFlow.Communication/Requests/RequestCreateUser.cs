namespace CashFlow.Communication.Requests;

public class RequestCreateUser
{
    public string Name {get; set;} = String.Empty;
    
    public string Email {get; set;} = String.Empty;
    
    public string Password {get; set;} = String.Empty;
}