using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TabletopStats.Application.UseCases.Commons.Bases;
using TabletopStats.Application.UseCases.Customers.Commands.CreatePlayer;

namespace TabletopStats.UI.Net.Controllers;

[Route("api/admin")]
[ApiController]
public class AdminController: ControllerBase
{
    
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpPost("AddPlayer")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddPlayer([FromBody]CreatePlayerCommand command)
    {
        if (command is null) return BadRequest();
        
        var response = await _mediator.Send(command);
        
        if (response.succcess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}