using System.Net;

namespace CashFlow.Exeception.ExceptionsBase;

public class InvalidLoginException : CashFlowException
{
    public InvalidLoginException() : base("Email ou Senha incorretos")
    {
        
    }
    
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}