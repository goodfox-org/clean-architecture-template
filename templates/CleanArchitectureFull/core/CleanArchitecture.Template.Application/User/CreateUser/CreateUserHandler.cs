using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OneOf;

namespace CleanArchitecture.Template.Application.User.CreateUser;
public class CreateUserHandler : IRequestHandler<CreateUserCommand, OneOf<CreateUserResponse, ValidationResult>> {
    private readonly IValidator<CreateUserCommand> _validator;

    public CreateUserHandler(IValidator<CreateUserCommand> validator) {
        _validator = validator;
    }

    public async Task<OneOf<CreateUserResponse, ValidationResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
            return validationResult;

        //simulate work
        await Task.Delay(100, cancellationToken);

        return new CreateUserResponse(Guid.NewGuid());
    }
}