using Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Commands
{
    public class UpdateDriverInfoRequest : IRequest<bool>
    {
        public UpdateDriverRequest Driver { get; }

        public UpdateDriverInfoRequest(UpdateDriverRequest driver)
        {
            Driver = driver;
        }


    }
}
