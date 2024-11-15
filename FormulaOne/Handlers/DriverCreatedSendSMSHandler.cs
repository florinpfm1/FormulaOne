using AutoMapper;
using Azure.Core;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Entities.Dtos.Responses;
using FormulaOne.Notifications;
using MediatR;

namespace FormulaOne.Handlers
{
    public class DriverCreatedSendSMSHandler : INotificationHandler<DriverCreatedNotification>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DriverCreatedSendSMSHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<DriverCreatedSendEmailHandler> logger
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DriverCreatedNotification notification, CancellationToken cancellationToken)
        {
            //Log that SMS was sent start
            _logger.LogInformation($"Confirmation SMS start sent for driver {notification.Driver.FirstName} {notification.Driver.LastName}");

            await Task.Delay(3000);
            //Send a confirmation SMS
            // .....................

            //Log that SMS was sent end
            _logger.LogInformation($"Confirmation SMS end sent for driver {notification.Driver.FirstName} {notification.Driver.LastName}");

            await Task.CompletedTask;

        }
    }
}
