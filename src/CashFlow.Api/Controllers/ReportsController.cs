using System.Net.Mime;
using CashFlow.Application.UseCases.Despesas.Reports.Excel;
using CashFlow.Application.UseCases.Despesas.Reports.Pdf;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateExcelReportUseCase useCase,
        [FromHeader] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);

        if (file.Length > 0)
        {
            var fileName = $"Despesas_{month:MM-yyyy}.xlsx";

            return File(
                file,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }

        return NoContent();
    }
    [HttpGet("pdf")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPdf(
        [FromServices] IGeneratePdfReportUseCase useCase,
        [FromHeader] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);

        if (file.Length > 0)
        {
            var fileName = $"Despesas_{month:MM-yyyy}.pdf";
            return File(file, MediaTypeNames.Application.Pdf, fileName);
        } 

        return NoContent();
    }
}