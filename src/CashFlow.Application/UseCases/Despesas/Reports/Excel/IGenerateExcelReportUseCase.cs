namespace CashFlow.Application.UseCases.Despesas.Reports.Excel;

public interface IGenerateExcelReportUseCase
{
    Task<byte[]> Execute(DateOnly month);
}