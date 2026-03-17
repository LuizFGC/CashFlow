using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Requests;

public class RequestDespesa
{
    public string Title { get; set; } = String.Empty;
    
    public string Description { get; set; } = String.Empty;
    
    public DateOnly Data { get; set; } 
    
    public decimal Valor { get; set; }
    
    public TipoPagamento TipoDePagamento { get; set; }
}