using FluentValidation;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.CreateSessionLog;

public class CreateSessionLogValidator: AbstractValidator<CreateSessionLogCommand>
{
    public CreateSessionLogValidator()
    {
        RuleFor(x => x.SessionName).NotEmpty().NotNull().MinimumLength(5).MaximumLength(200);
        RuleFor(x => x.StartTime).NotNull().NotEmpty();
        RuleFor(x => x.EndTime).NotNull().NotEmpty();
        RuleFor(x => x.EndTime).GreaterThanOrEqualTo(x => x.StartTime);
        RuleFor(x => x.RpgSystemCode).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(x => x.Players).NotNull().NotEmpty();
    }
}