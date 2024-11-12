using Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Queries
{
    public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
    {

    }
}
