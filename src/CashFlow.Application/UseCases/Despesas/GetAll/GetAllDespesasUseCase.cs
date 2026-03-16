using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Despesas;

namespace CashFlow.Application.UseCases.Despesas.GetAll;

public class GetAllDespesasUseCase : IGetAllDespesasUseCase
{
    private readonly IDespesasRepository _repository;
    private readonly IMapper _mapper;
    
    public GetAllDespesasUseCase(IDespesasRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ResponseDespesas> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseDespesas()
        {
            Despesas = _mapper.Map<List<ResponseShortDespesa>>(result)
        };
    }
}