using CleanArchitecture.Template.Application.User.CreateUser;
using CleanArchitecture.Template.GrpcApi.Services;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

builder.Services.AddGrpc();
builder.Services.AddMediatR(typeof(CreateUserCommand));
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
