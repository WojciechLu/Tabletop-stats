using MediatR;
using Microsoft.AspNetCore.Mvc;
using TabletopStats.Application.UseCases.Commons.Bases;
using TabletopStats.Application.UseCases.SessionLog.Commands.CreateAdventure;
using TabletopStats.Application.UseCases.SessionLog.Commands.CreateCampaign;
using TabletopStats.Application.UseCases.SessionLog.Commands.CreateSessionLog;
using TabletopStats.Application.UseCases.SessionLog.Commands.GetPlayerLogs;

namespace TabletopStats.UI.Net.Controllers;

[Route("api/sessionLog")]
[ApiController]
public class SessionLogController : ControllerBase
{
    private readonly IMediator _mediator;

    public SessionLogController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    private async Task<IActionResult> HandleRequest<TResponse>(IRequest<BaseResponse<TResponse>> command)
    {
        if (command == null) 
            return BadRequest("Request body cannot be null.");

        var response = await _mediator.Send(command);
        
        return response.succcess ? Ok(response) : BadRequest(response);
    }
    
    [HttpPost("GetPlayerLogs")]
    public Task<IActionResult> GetPlayerLogs([FromBody] GetPlayerLogsQuery command)
        => HandleRequest(command);

    [HttpPost("CreateSessionLog")]
    public Task<IActionResult> CreateSessionLog([FromBody] CreateSessionLogCommand command)
        => HandleRequest(command);

    [HttpPost("CreateCampaign")]
    public Task<IActionResult> CreateCampaign([FromBody] CreateCampaignCommand command)
        => HandleRequest(command);

    [HttpPost("CreateAdventure")]
    public Task<IActionResult> CreateAdventure([FromBody] CreateAdventureCommand command)
        => HandleRequest(command);
}