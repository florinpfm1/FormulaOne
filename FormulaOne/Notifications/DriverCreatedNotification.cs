using Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Notifications
{
    public record DriverCreatedNotification(CreateDriverRequest Driver) : INotification;
   
}
