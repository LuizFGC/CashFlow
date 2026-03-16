using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Despesas.GetById;

public interface IGetDespesasByIdUseCase
{
    Task<ResponseDespesaById> Execute(long id);
}