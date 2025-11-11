using MediatR;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.Customers.Commands.CreatePlayer;

public class CreatePlayerCommand: IRequest<BaseResponse<bool>>
{
    public string PlayerName { get; set; }
}