using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exeception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Login;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAcessTokenGenerator _acessTokenGenerator;

    public DoLoginUseCase(IUserRepository repository,  IPasswordEncripter passwordEncripter,  IAcessTokenGenerator acessTokenGenerator)
    {
        _repository = repository;
        _passwordEncripter = passwordEncripter;
        _acessTokenGenerator = acessTokenGenerator;
    }
    
    
    public async Task<ResponseLogin> Execute(RequestLogin request)
    {
        var encriptedPassword = _passwordEncripter.Encrypt(request.Password);
        
       var user = await _repository.GetUserByEmail(request.Email);

       if (user is null)
       {
           throw new InvalidLoginException();
       }
       
     var passwordMatch =  _passwordEncripter.Verify(request.Password, user.Password);

     if (!passwordMatch)
     {
         throw new InvalidLoginException();
     }

     return new ResponseLogin()
     {
         Name = user.Name,
         Token = _acessTokenGenerator.Generate(user)
     };
    }
}