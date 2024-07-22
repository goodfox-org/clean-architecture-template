using CleanArchitecture.Template.Application.User.CreateUser;
using FluentValidation;
using FluentValidation.Results;
using OneOf;

namespace CleanArchitecture.Template.Tests;

public class CreateUserHandlerTests {
    [Fact]
    public async Task Given_valid_data_returns_new_user() {
        var validator = new CreateUserCommandValidator();
        var handler = new CreateUserHandler(validator);
        var request = new CreateUserCommand("John", "Doe");

        var response = await handler.Handle(request, default);
        var newUser = response.AsT0;

        response.Should().BeOfType<OneOf<CreateUserResponse, ValidationResult>>();
        response.IsT0.Should().BeTrue();
        newUser.UserId.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Validator_is_called_when_the_handler_is_invoked() {
        var validatorMock = new Mock<IValidator<CreateUserCommand>>();
        var handler = new CreateUserHandler(validatorMock.Object);
        var request = new CreateUserCommand("John", "Doe");
        validatorMock.Setup(x => x.Validate(request)).Returns(new ValidationResult());

        _ = await handler.Handle(request, default);

        validatorMock.Verify(x => x.Validate(request), Times.Once);
    }

    [Theory]
    [InlineData("", "Doe")]
    [InlineData("John", "")]
    [InlineData("", "")]
    [InlineData(null, "Doe")]
    [InlineData("John", null)]
    [InlineData(null, null)]
    public async Task Given_invalid_input_returns_appropriate_errors(string? firstName, string? lastName) {
        var validator = new CreateUserCommandValidator();
        var handler = new CreateUserHandler(validator);
        var request = new CreateUserCommand(firstName, lastName);
        const string errorForFirstName = "'First Name' must not be empty.";
        const string errorForLastName = "'Last Name' must not be empty.";

        var response = await handler.Handle(request, default);
        var errorResult = response.AsT1;

        response.Should().BeOfType<OneOf<CreateUserResponse, ValidationResult>>();
        response.IsT1.Should().BeTrue();

        switch (firstName, lastName) {
            case var tuple
            when string.IsNullOrEmpty(tuple.firstName)
              && string.IsNullOrEmpty(tuple.lastName):
                errorResult.Errors.Should().HaveCount(2);
                errorResult.Errors[0].ErrorMessage.Should().BeEquivalentTo(errorForFirstName);
                errorResult.Errors[1].ErrorMessage.Should().BeEquivalentTo(errorForLastName);
                break;
            case var tuple when tuple.firstName?.Length > 0:
                errorResult.Errors.Should().HaveCount(1);
                errorResult.Errors[0].ErrorMessage.Should().BeEquivalentTo(errorForLastName);
                break;
            case var tuple when tuple.lastName?.Length > 0:
                errorResult.Errors.Should().HaveCount(1);
                errorResult.Errors[0].ErrorMessage.Should().BeEquivalentTo(errorForFirstName);
                break;
        };
    }
}