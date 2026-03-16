using CashFlow.Communication.Requests;
using CashFlow.Exeception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Despesas;

public class DespesaValidator : AbstractValidator<RequestDespesa>
{
    public DespesaValidator()
    {
        RuleFor(despesa => despesa.Title).NotEmpty().WithMessage(ResourceErrorMessages.Titulo_Obrigatorio);
        
        RuleFor(despesa => despesa.Valor).GreaterThan(0).WithMessage(ResourceErrorMessages.Valor_Maior_0);
        
        RuleFor(despesa => despesa.Data).NotEmpty().WithMessage(ResourceErrorMessages.Data_Obrigatoria);

        RuleFor(despesa => despesa.TipoDePagamento).IsInEnum().WithMessage(ResourceErrorMessages.Tipo_Pagamento_Invalido);
    }
}