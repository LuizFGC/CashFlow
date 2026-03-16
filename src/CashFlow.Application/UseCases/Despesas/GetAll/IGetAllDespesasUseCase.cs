using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Despesas.GetAll;

public interface IGetAllDespesasUseCase
{
    Task<ResponseDespesas> Execute();
}