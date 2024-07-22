using CleanArchitecture.Template.Application.User.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> CreateUser([FromBody] CreateUserCommand request) {
        var result = await _mediator.Send(request);

        return result.Match<ActionResult>(
            user => Ok(user),
            error => BadRequest(error.ToDictionary())
        );
    }
}
