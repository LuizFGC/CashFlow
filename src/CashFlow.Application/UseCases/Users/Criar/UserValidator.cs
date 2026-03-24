using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Criar;

public class UserValidator : AbstractValidator<RequestCreateUser>
{
    public UserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Nome e Obrigatorio");
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("E-mail e Obrigatorio")
            .EmailAddress()
            .When(u => string.IsNullOrWhiteSpace(u.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage("E-mail e Invalido");
        
        RuleFor(u => u.Password).SetValidator(new PasswordValidator<RequestCreateUser>());
    }
}