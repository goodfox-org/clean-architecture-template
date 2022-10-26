using CleanArchitecture.Template.Application.User.CreateUser;
using FluentAssertions;
using FluentValidation.Results;
using OneOf;

namespace CleanArchitecture.Template.Tests;

public class CreateUserHandlerTests {
    [Fact]
    public async Task Given_valid_data_returns_new_user() {
        var validator = new CreateUserCommandValidator();
        var handler = new CreateUserHandler(validator);
        var request = new CreateUserCommand("John", "Doe");

        var newUser = await handler.Handle(request, default);

        newUser.Should().NotBeNull();
        newUser.Should().BeOfType<OneOf<CreateUserResponse, ValidationResult>>();
        newUser.IsT0.Should().BeTrue();
        newUser.AsT0.UserId.Should().NotBeEmpty();
    }
}