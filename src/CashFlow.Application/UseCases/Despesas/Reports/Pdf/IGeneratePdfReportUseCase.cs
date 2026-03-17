namespace CashFlow.Application.UseCases.Despesas.Reports.Pdf;

public interface IGeneratePdfReportUseCase
{
    Task<byte[]> Execute(DateOnly month);
}