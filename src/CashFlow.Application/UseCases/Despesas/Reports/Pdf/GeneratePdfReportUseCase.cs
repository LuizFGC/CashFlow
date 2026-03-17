using CashFlow.Application.UseCases.Despesas.Reports.Pdf.Fonts;
using CashFlow.Domain.Repositories.Despesas;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Despesas.Reports.Pdf;

public class GeneratePdfReportUseCase: IGeneratePdfReportUseCase
{
    private readonly IDespesasRepository _repository;

    public GeneratePdfReportUseCase(IDespesasRepository repository)
    {
        _repository = repository;
        GlobalFontSettings.FontResolver = new DespesasResportFontResolver();
    }
    public async Task<byte[]> Execute(DateOnly month)
    {
        var despesas = await _repository.FiltrarMes(month);

        if (despesas.Count == 0)
        {
            return [];
        }
        return [];
    }
}