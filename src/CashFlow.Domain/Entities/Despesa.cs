using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;

public class Despesa
{
    public long Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; } = string.Empty;
    
    public DateOnly Data { get; set; }
    
    public decimal Valor { get; set; }
    
    public  TipoPagamento TipoPagamento { get; set; }
}