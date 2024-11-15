using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using FormulaOne.Commands;
using MediatR;

namespace FormulaOne.Handlers
{
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Driver>(request.Driver);

            await _unitOfWork.Drivers.Update(result);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
