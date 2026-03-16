using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Exeception;
using CashFlow.Exeception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Despesas.GetById;

public class GetDespesasByIdUseCase : IGetDespesasByIdUseCase
{
    private readonly IDespesasRepository _repository;
    private readonly IMapper _mapper;

    public GetDespesasByIdUseCase(IDespesasRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseDespesaById> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.Despesa_NotFound);
        }
        
        return _mapper.Map<ResponseDespesaById>(result);
    }
}