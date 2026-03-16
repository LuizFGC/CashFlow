namespace CashFlow.Communication.Responses;

public class ResponseShortDespesa
{
    public long Id { get; set; }
    
    public string Title  { get; set; } = String.Empty;
    
    public decimal Valor { get; set; }
}