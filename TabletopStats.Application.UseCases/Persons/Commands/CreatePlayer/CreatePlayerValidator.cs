using FluentValidation;

namespace TabletopStats.Application.UseCases.Persons.Commands.CreatePlayer;

public class CreatePlayerValidator: AbstractValidator<CreatePlayerCommand>
{
    public CreatePlayerValidator()
    {
        RuleFor(x => x.PlayerName).NotEmpty().NotNull();
    }
}