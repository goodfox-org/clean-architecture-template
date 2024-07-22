using FluentValidation.Results;
using MediatR;
using OneOf;

namespace CleanArchitecture.Template.Application.User.CreateUser;

public record CreateUserCommand(string? FirstName, string? LastName) : IRequest<OneOf<CreateUserResponse, ValidationResult>>;