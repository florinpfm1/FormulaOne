using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Entities.Dtos.Responses;
using FormulaOne.Commands;
using FormulaOne.Notifications;
using MediatR;

namespace FormulaOne.Handlers
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPublisher _publisher;

        public CreateDriverCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPublisher publisher
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publisher = publisher;
        }

        public async Task<GetDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request.DriverRequest);

            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<GetDriverResponse>(driver);

            //we publish the notification for Driver Created to trigger all handlers for this notification
            await _publisher.Publish(new DriverCreatedNotification(request.DriverRequest));

            return result;
        }






    }
}
