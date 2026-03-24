using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestsUtils.Requests;

public class RequestCreateUserBuilder
{
    public static RequestCreateUser Build()
    {
        return new Faker<RequestCreateUser>()
            .RuleFor(user => user.Name, faker => faker.Person.FirstName)
            .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
            .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa1"));
    }
}