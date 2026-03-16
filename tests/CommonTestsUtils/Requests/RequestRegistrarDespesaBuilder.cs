using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestsUtils.Requests;

public class RequestRegistrarDespesaBuilder
{
    public static RequestDespesa Build()
    {

      return  new Faker<RequestDespesa>()
            .RuleFor(r => r.Title, f => f.Commerce.ProductName())
            .RuleFor(r => r.Descricao, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.Data, f => f.Date.FutureDateOnly())
            .RuleFor(r => r.Valor, f => f.Finance.Amount())
            .RuleFor(r => r.TipoDePagamento, f => f.PickRandom<TipoPagamento>());


    }
}