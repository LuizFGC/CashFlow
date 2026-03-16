using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Responses;

public class ResponseDespesaById
{
    public long Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string? Description { get; set; } 
    
    public DateOnly Date { get; set; }
    
    public decimal Valor { get; set; }
    
    public TipoPagamento TipoPagamento { get; set; }
}