using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Exeception;
using CashFlow.Exeception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Despesas.Deletar;

public class DeleteDespesaUseCase : IDeleteDespesaUseCase
{
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IDespesasRepository _repository;

    public DeleteDespesaUseCase(IUnidadeDeTrabalho unidadeDeTrabalho, IDespesasRepository repository)
    {
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _repository = repository;
    }
    
    
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.Despesa_NotFound);
        }

        await _unidadeDeTrabalho.Commit();
    }
}