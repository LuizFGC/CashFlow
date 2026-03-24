using CashFlow.Application.UseCases.Users.Criar;
using CommonTestsUtils.Requests;
using FluentAssertions;

namespace Validator.Tests.Users.Create;

public class CreateUserValidatorTest
{
    [Fact]
    public void Sucess()
    {
        
        //Arrange
        var validator = new UserValidator();
        var request = RequestCreateUserBuilder.Build();
        
        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("             ")]
    [InlineData(null)]
    public void ErrorNameInvalid(string name)
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestCreateUserBuilder.Build();
        request.Name = name;
        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle();
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("             ")]
    [InlineData(null)]
    public void ErrorEmailEmpty(string email)
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestCreateUserBuilder.Build();
        request.Email = email;
        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle();
    }
    
    [Fact]
    public void ErrorEmailInvalid()
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestCreateUserBuilder.Build();
        request.Email = "luiz.com";
        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle();
    }
    
    [Fact]
    public void ErrorPasswordEmpty()
    {
        //Arrange
        var validator = new UserValidator();
        var request = RequestCreateUserBuilder.Build();
        request.Password = String.Empty;
        //Act
        var result = validator.Validate(request);
        
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle();
    }
}