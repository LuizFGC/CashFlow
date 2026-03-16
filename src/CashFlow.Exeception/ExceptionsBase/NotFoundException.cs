using System.Net;

namespace CashFlow.Exeception.ExceptionsBase;

public class NotFoundException : CashFlowException
{
    
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    
    public override List<string> GetErrors()
    {
        return [Message];
    }
    
    public NotFoundException(string message) : base(message)
    {
        
    }
}