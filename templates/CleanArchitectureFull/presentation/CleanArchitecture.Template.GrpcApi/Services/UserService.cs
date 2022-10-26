using CleanArchitecture.Template.Application.User.CreateUser;
using CleanArchitecture.Template.GrpcApi;
using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.GrpcApi.Services {
    public class UserService : User.UserBase {
        private readonly IMediator _mediator;

        public UserService(IMediator mediator) {
            _mediator = mediator;
        }

        public override async Task<NewUser> CreateUser(CreateUserRequest request, ServerCallContext context) {
            var result = await _mediator.Send(new CreateUserCommand(request.FirstName, request.LastName));

            return result.Match(
                user => new NewUser() { UserId = user.UserId.ToString() },
                error => throw new RpcException(new Status(StatusCode.InvalidArgument, error.ToString()))
            );
        }
    }
}