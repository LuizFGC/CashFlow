using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Users.Login;

public interface IDoLoginUseCase
{
    Task<ResponseLogin> Execute(RequestLogin request);
}