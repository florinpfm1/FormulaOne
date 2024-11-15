using Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Commands
{
    public record UpdateDriverCommand(UpdateDriverRequest Driver) : IRequest<bool>;
   
}
