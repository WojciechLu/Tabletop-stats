using MediatR;
using Microsoft.AspNetCore.Mvc;
using TabletopStats.Application.UseCases.Dictionary.Queries;
using TabletopStats.Application.UseCases.Persons.Commands.CreatePlayer;
using TabletopStats.Application.UseCases.SessionLog.Queries.GetGameMasterLogs;

namespace TabletopStats.UI.Net.Controllers;

[Route("api/dictionary")]
[ApiController]
public class DictionaryController: ControllerBase
{
    private readonly IMediator _mediator;

    public DictionaryController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpGet("GetRpgSystems")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetRpgSystems([FromQuery]GetRpgSystemsQuery query)
    {
        var response = await _mediator.Send(query);
        
        if (response.succcess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}