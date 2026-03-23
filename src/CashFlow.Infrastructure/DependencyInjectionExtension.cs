using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Despesas;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Infrastrucutre.DataAcess;
using CashFlow.Infrastrucutre.DataAcess.Repositories;
using CashFlow.Infrastrucutre.Security.Cryptography;
using CashFlow.Infrastrucutre.Security.Tokens;
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
        AddToken(services, configuration);
        services.AddScoped<IPasswordEncripter, Bcrypt>();

    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IDespesasRepository, DespesasRepository>();
        services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTime = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");
        
        services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(expirationTime, signingKey!));
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<CashFlowDbContext>(config =>
            config.UseSqlServer(connectionString));
    }
}