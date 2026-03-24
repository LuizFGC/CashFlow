using  CashFlow.Application.UseCases.Users.Criar;
using CommonTestsUtils.Requests;

namespace UseCases.Tests.Users.Create;

public class CreateUserUseCaseTest
{
    [Fact]
    public async Task Sucess()
    {
        //Arrange
        var request = RequestCreateUserBuilder.Build();
        
    }
}