using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Criar;

public class UserValidator : AbstractValidator<RequestCreateUser>
{
    public UserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Nome e Obrigatorio");
        RuleFor(U => U.Email).NotEmpty().WithMessage("E-mail e Obrigatorio");
    }
}