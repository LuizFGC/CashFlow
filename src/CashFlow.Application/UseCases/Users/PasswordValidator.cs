using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace CashFlow.Application.UseCases.Users;

public class PasswordValidator<T> : PropertyValidator<T, string>
{
    
    public override string Name =>  "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "{ErrorMessage}";
    }
    
    
    
    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha Obrigatoria");
            return false;
        }
        if (password.Length < 8)
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha deve conter no minimo 8 caracteres");
            return false;
        }

        if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$"))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", "Senha deve conter 1 letra Maiuscula,1 letra minuscula, 1 caracter especial, e um Numero");
            return false;
        }
        
        return true;
    }

    
}