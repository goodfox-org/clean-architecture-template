using FluentValidation;

namespace CleanArchitecture.Template.Application.User.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> {
    public CreateUserCommandValidator() {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}
