using Entities.Dtos.Requests;
using Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Commands
{
    public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
    {
        public CreateDriverRequest DriverRequest { get; }

        public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }




    }
}
