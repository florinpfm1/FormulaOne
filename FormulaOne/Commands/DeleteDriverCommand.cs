using MediatR;

namespace FormulaOne.Commands
{
    public record DeleteDriverCommand(Guid DriverId) : IRequest<bool>;
}
