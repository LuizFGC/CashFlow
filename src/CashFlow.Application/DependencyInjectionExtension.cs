using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Despesas.Deletar;
using CashFlow.Application.UseCases.Despesas.GetAll;
using CashFlow.Application.UseCases.Despesas.GetById;
using CashFlow.Application.UseCases.Despesas.Registrar;
using CashFlow.Application.UseCases.Despesas.Reports.Excel;
using CashFlow.Application.UseCases.Despesas.Reports.Pdf;
using CashFlow.Application.UseCases.Despesas.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegistrarDespesaUseCase, RegistrarDespesaUseCase>();
        AddUseCases(services);
        AddAutoMapper(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, typeof(AutoMapping));
    }
    
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegistrarDespesaUseCase, RegistrarDespesaUseCase>();
        services.AddScoped<IGetAllDespesasUseCase, GetAllDespesasUseCase>();
        services.AddScoped<IGetDespesasByIdUseCase, GetDespesasByIdUseCase>();
        services.AddScoped<IDeleteDespesaUseCase, DeleteDespesaUseCase>();
        services.AddScoped<IUpdateDespesaUseCase, UpdateDespesaUseCase>();
        services.AddScoped<IGenerateExcelReportUseCase, GenerateExcelReportUseCase>();
        services.AddScoped<IGeneratePdfReportUseCase, GeneratePdfReportUseCase>();
    }
    
}