using CleanArchitecture.Template.Application.User.CreateUser;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Template.RestApi.Setup {
    public static class DependencyInjectionSetup {
        public static void AddDependencyInjection(this IServiceCollection services) {
            services.AddMediatR(typeof(CreateUserCommand));
            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
        }
    }
}
