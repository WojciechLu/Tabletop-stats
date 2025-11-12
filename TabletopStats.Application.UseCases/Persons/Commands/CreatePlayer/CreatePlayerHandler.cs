using MediatR;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.UseCases.Persons.Commands.CreatePlayer;

public class CreatePlayerHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreatePlayerCommand, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            await unitOfWork.Persons.InsertAsync(new Person
            {
                Name = request.PlayerName
            });
        }
        catch (Exception ex)
        {
            response.Message  = ex.Message;
        }
        response.Data = true;
        response.succcess = true;
        response.Message  = "Create succeed!";
        return response;
    }
}