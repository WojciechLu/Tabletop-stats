using MediatR;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.Persons.Commands.CreatePlayer;

public class CreatePlayerCommand: IRequest<BaseResponse<bool>>
{
    public string PlayerName { get; set; }
}