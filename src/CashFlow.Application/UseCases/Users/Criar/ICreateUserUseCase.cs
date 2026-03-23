using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Users.Criar;

public interface ICreateUserUseCase
{
    Task<ResponseCreateUser> Execute(RequestCreateUser request);
}