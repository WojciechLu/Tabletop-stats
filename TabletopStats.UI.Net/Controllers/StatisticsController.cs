using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TabletopStats.UI.Net.Controllers;

[Route("api/statistics")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatisticsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpGet("GetPlayerStatistics")]
    public async Task<IActionResult> GetPlayerStatistics()
    {
        // var response = await _mediator.Send(new GetPlayerStatistics() { Page = ..., PerPage = ...});
        // if (response.succcess)
        // {
        //     return Ok(response);
        // }
        //
        // return BadRequest(response);
        return Ok();
    }
}