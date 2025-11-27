using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.Dictionary.Queries;

public class GetRpgSystemsQuery: IRequest<BaseResponse<IEnumerable<RpgSystemDto>>>
{
    public string? Name { get; set; }
}