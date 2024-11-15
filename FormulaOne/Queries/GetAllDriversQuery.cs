using Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Queries
{
    public record GetAllDriversQuery() : IRequest<IEnumerable<GetDriverResponse>>
    {

    }
}
