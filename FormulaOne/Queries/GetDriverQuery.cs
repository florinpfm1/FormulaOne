using Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Queries
{
    public class GetDriverQuery : IRequest<GetDriverResponse>
    {
        public Guid DriverId { get; }

        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}
