using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories.Despesas;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Despesas.Reports.Excel;

public class GenerateExcelReportUseCase : IGenerateExcelReportUseCase
{
    
    private readonly IDespesasRepository _repository;

    public GenerateExcelReportUseCase(IDespesasRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<byte[]> Execute(DateOnly month)
    {
        var despesas = await _repository.FiltrarMes(month);

        if (despesas.Count == 0)
        {
            return [];
        }
        
      using var workbook = new XLWorkbook(); //Arquivo Excel em Branco
        
       //Configurando Arquivo
       workbook.Author = "Luiz Filipe";
       workbook.Style.Font.FontSize = 12;
       workbook.Style.Font.FontName = "Times New Roman";
       
       //Criando Planilha e definindo nome
       var worksheet = workbook.Worksheets.Add("Despesas - " + month.ToString("Y"));
        
       //Criando header da planilha 
       WorkSheetHeader(worksheet);

       var linha = 2;
       foreach (var despesa in despesas)
       {
           worksheet.Cell($"A{linha}").Value = despesa.Title;
           
           
           var valor = worksheet.Cell($"B{linha}");
            valor.Value = despesa.Valor;
            valor.Style.NumberFormat.Format = "R$ #,##0.00";
            
           worksheet.Cell($"C{linha}").Value = despesa.TipoPagamento.ToString();
           worksheet.Cell($"D{linha}").Value = despesa.Description;


           var data = worksheet.Cell($"E{linha}");
           data.Value = ConvertData(despesa.Data);
           data.Style.DateFormat.Format = "MM/yyyy";
           linha++;
           
       }
       
       worksheet.Columns().AdjustToContents();
       
       var file = new MemoryStream();
       
       workbook.SaveAs(file); 
       
       return file.ToArray();
    }

    private DateTime ConvertData(DateOnly data)
    {
      return  data.ToDateTime(TimeOnly.MinValue);
    }
    
    private void WorkSheetHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = "Despesa";
        worksheet.Cell("B1").Value = "Valor";
        worksheet.Cell("C1").Value = "Tipo de Pagamento";
        worksheet.Cell("D1").Value = "Descricao";
        worksheet.Cell("E1").Value = "Data";
        
        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.Green;
    }
}