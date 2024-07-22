using CleanArchitecture.Template.Application.User.CreateUser;
using FluentValidation;

namespace CleanArchitecture.Template.RestApi.Setup;

public static class DependencyInjectionSetup {
    public static void AddDependencyInjection(this IServiceCollection services) {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserCommand>());
        services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
    }
}
