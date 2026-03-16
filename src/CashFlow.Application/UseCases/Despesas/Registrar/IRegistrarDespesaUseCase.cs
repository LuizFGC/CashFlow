using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Despesas.Registrar;

public interface IRegistrarDespesaUseCase
{
   Task<ResponseRegistrarDespesa> Execute(RequestDespesa request);
}