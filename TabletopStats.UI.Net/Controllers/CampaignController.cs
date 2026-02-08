using MediatR;
using Microsoft.AspNetCore.Mvc;
using TabletopStats.Application.UseCases.Campaigns.Queries.GetAdventuresQuery;
using TabletopStats.Application.UseCases.Campaigns.Queries.GetCampaigns;
using TabletopStats.Application.UseCases.Dictionary.Queries;

namespace TabletopStats.UI.Net.Controllers;

[Route("api/campaign")]
[ApiController]
public class CampaignController: ControllerBase
{
    private readonly IMediator _mediator;

    public CampaignController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    [HttpGet("GetCampaigns")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCampaigns()
    {
        var response = await _mediator.Send(new GetCampaignsQuery());
        
        if (response.succcess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
    
    
    [HttpGet("GetAdventures")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAdventures([FromQuery]GetAdventuresQuery query)
    {
        var response = await _mediator.Send(query);
        
        if (response.succcess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}