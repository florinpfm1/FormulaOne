using Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Queries
{
    public record GetDriverQuery(Guid DriverId) : IRequest<GetDriverResponse>;
}
