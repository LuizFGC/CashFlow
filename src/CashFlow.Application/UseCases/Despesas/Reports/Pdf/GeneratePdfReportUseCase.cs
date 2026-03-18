using CashFlow.Application.UseCases.Despesas.Reports.Pdf.Fonts;
using CashFlow.Domain.Repositories.Despesas;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
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

        var document = CreateDocument(month);
        var page = CreatePage(document);

        var paragraph = page.AddParagraph();
        
       var title = string.Format( $"Total Gasto em {month.ToString("Y")}");
       
       paragraph.AddFormattedText(title, new Font{Name = FontHelper.RALEWAY_REGULAR, Size = 15});
       
       paragraph.AddLineBreak();

       var totalDespesas = despesas.Sum(despesa => despesa.Valor);
       
       paragraph.AddFormattedText($"R$ {totalDespesas}", new Font{Name = FontHelper.WORKSANS_BLACK, Size = 50});
        
        return RenderDocument(document);
    }

    private Document CreateDocument(DateOnly month)
    {
        var document = new Document();
        
        document.Info.Title = $"Despesas {month.ToString("MMMM")}";
        document.Info.Author = "Luiz Filipe";
        
        var style = document.Styles["Normal"];
        style!.Font.Name = FontHelper.RALEWAY_REGULAR;
        
        
        
        return document;
    }

    private Section CreatePage(Document document)
    {
        var page = document.AddSection();
        page.PageSetup = document.DefaultPageSetup.Clone();
        page.PageSetup.PageFormat = PageFormat.A4;
        page.PageSetup.LeftMargin = 40;
        page.PageSetup.RightMargin = 40;
        page.PageSetup.TopMargin = 80;
        page.PageSetup.BottomMargin = 80;
        
        return page;
    }

    private byte[] RenderDocument(Document document)
    {
        var renderer = new PdfDocumentRenderer()
        {
            Document = document,
        };
            
            renderer.RenderDocument();

            using var file = new MemoryStream();
            renderer.PdfDocument.Save(file);
            
            return file.ToArray();
    }
}