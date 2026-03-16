namespace CashFlow.Application.UseCases.Despesas.Deletar;

public interface IDeleteDespesaUseCase
{
    Task Execute(long id);
}