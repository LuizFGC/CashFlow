using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Exeception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Despesas.Registrar;

public class RegistrarDespesaUseCase : IRegistrarDespesaUseCase
{
    private readonly IDespesasRepository _repository;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IMapper _mapper;
    public RegistrarDespesaUseCase(IDespesasRepository repository, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapper)
    {
        _repository = repository;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _mapper = mapper;
    }
    
    public async Task<ResponseRegistrarDespesa> Execute(RequestDespesa request)
    {
        Validate(request);

        var entidade = _mapper.Map<Despesa>(request);
        
       await _repository.Add(entidade);
        
        await _unidadeDeTrabalho.Commit();
        
        return _mapper.Map<ResponseRegistrarDespesa>(entidade);
    }

    private void Validate(RequestDespesa request)
    {
        var validator = new DespesaValidator();
        
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages =  result.Errors.Select(error => error.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
        
    
        
    }
}