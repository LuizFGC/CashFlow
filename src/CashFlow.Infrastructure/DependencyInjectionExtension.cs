using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Infrastrucutre.DataAcess;
using CashFlow.Infrastrucutre.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastrucutre;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IDespesasRepository, DespesasRepository>();
        services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<CashFlowDbContext>(config =>
            config.UseSqlServer(connectionString));
    }
}