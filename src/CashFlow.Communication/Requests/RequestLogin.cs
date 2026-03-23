namespace CashFlow.Communication.Requests;

public class RequestLogin
{
    public string Email { get; set; } = String.Empty;
    
    public string Password { get; set; } = String.Empty;
}