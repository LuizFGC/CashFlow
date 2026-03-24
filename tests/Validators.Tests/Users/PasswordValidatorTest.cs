using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests;
using CommonTestsUtils.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validator.Tests.Users;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("")]
    [InlineData("             ")]
    [InlineData(null)]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aaa")]
    [InlineData("aaaa")]
    [InlineData("aasaa")]
    [InlineData("aasaas")]
    [InlineData("aassaas")]
    [InlineData("aasfsaas")]
    [InlineData("ASDWERQWS")]
    [InlineData("ASDWERQWds")]
    [InlineData("ASDWERQWds2")]
    public void ErrorPasswordInvalid(string password)
    {
        //Arrange
        var validator = new PasswordValidator<RequestCreateUser>();
        //Act
        var result = validator.IsValid(new ValidationContext<RequestCreateUser>(new RequestCreateUser()), password);
        
        //Assert
        result.Should().BeFalse();
    }
}