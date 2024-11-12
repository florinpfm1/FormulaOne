using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using FormulaOne.Commands;
using MediatR;

namespace FormulaOne.Handlers
{
    public class DeleteDriverInfoHandler : IRequestHandler<DeleteDriverInfoRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDriverInfoHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDriverInfoRequest request, CancellationToken cancellationToken)
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
