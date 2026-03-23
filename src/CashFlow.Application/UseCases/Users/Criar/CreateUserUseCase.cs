using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exeception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Criar;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IUserRepository _repository;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAcessTokenGenerator _tokenGenerator;

    public CreateUserUseCase(IUserRepository repository, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapper,IPasswordEncripter passwordEncripter, IAcessTokenGenerator tokenGenerator)
    {
        _repository = repository;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }
    
    public async Task<ResponseCreateUser> Execute(RequestCreateUser request)
    {
       await Validate(request);
        
       var entidade = _mapper.Map<User>(request);
       entidade.UserId = Guid.NewGuid();
       entidade.Password = _passwordEncripter.Encrypt(request.Password);
       
       await _repository.Add(entidade);
       
       await _unidadeDeTrabalho.Commit();
       
       return  _mapper.Map<ResponseCreateUser>(entidade);
        
    }

    private async Task Validate(RequestCreateUser request)
    {
        var validator = new UserValidator();
        
        var result = validator.Validate(request);
        var emailExists = await _repository.EmailExists(request.Email);
      
       
        if (emailExists)
        {
          result.Errors.Add(new FluentValidation.Results.ValidationFailure("Email", "Email ja Cadastrado"));
        }


        if (!result.IsValid)
        {
            var errorMessages =  result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}