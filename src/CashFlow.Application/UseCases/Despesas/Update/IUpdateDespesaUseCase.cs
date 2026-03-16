using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Despesas.Update;

public interface IUpdateDespesaUseCase
{
    Task Execute(long id, RequestDespesa request);
}