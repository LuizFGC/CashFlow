using CashFlow.Application.UseCases.Despesas;
using CashFlow.Exeception;
using CommonTestsUtils.Requests;
using FluentAssertions;

namespace Validator.Tests.Despesas.Registrar;

public class DespesaValidatorTests
{
    [Fact]
    public void Sucess()
    {
        //Arrange
        var validator = new DespesaValidator();
        var request = RequestRegistrarDespesaBuilder.Build();
        
        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeTrue();
    }
    
    
    [Fact]
    public void Error_Titulo_Vazio()
    {
        //Arrange
        var validator = new DespesaValidator();
        var request = RequestRegistrarDespesaBuilder.Build();
        request.Title = String.Empty;
        //Act 
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.Titulo_Obrigatorio));
    }
    
}