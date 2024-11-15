using Entities.Dtos.Requests;
using Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Commands
{
    public record CreateDriverCommand(CreateDriverRequest DriverRequest) : IRequest<GetDriverResponse>;
}
