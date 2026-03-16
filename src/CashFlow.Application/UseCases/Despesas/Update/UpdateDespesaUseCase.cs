using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Exeception;
using CashFlow.Exeception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Despesas.Update;

public class UpdateDespesaUseCase : IUpdateDespesaUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IDespesasRepository _repository;

    public UpdateDespesaUseCase(IUnidadeDeTrabalho unidadeDeTrabalho, IDespesasRepository repository, IMapper mapper)
    {
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repository = repository;
        _mapper = mapper;
    }

    
    public async Task Execute(long id, RequestDespesa request)
    {
        Validate(request);
        
         var despesa = await _repository.GetByIdUpdate(id);
         if (despesa is null)
         {
             throw new NotFoundException(ResourceErrorMessages.Despesa_NotFound);
         }
         
         _mapper.Map(request, despesa);
         
         _repository.Update(despesa);
        await _unidadeDeTrabalho.Commit();
    }

    private void Validate(RequestDespesa request)
    {
        var validator = new DespesaValidator();
        
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}