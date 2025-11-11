using MediatR;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.UseCases.Customers.Commands.CreatePlayer;

public class CreatePlayerHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreatePlayerCommand, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            response.Data = await unitOfWork.Persons.InsertAsync(new Person
            {
                Name = request.PlayerName
            });
            if (response.Data) 
            {
                response.succcess = true;
                response.Message  = "Create succeed!";
            }
        }
        catch (Exception ex)
        {
            response.Message  = ex.Message;
        }
        return response;
    }
}