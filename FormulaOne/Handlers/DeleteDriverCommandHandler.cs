using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using FormulaOne.Commands;
using MediatR;

namespace FormulaOne.Handlers
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDriverCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

            if (driver == null)
                return false;

            await _unitOfWork.Drivers.Delete(request.DriverId);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
