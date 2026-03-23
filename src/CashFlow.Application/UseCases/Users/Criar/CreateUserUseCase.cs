using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Exeception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Criar;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IUserRepository _repository;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IMapper _mapper;

    public CreateUserUseCase(IUserRepository repository, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapper)
    {
        _repository = repository;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _mapper = mapper;
    }
    
    public async Task<ResponseCreateUser> Execute(RequestCreateUser request)
    {
        Validate(request);
        
       var entidade = _mapper.Map<User>(request);
       
       await _repository.Add(entidade);
       
       await _unidadeDeTrabalho.Commit();
       
       return  _mapper.Map<ResponseCreateUser>(entidade);
        
    }

    private void Validate(RequestCreateUser request)
    {
        var validator = new UserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages =  result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}