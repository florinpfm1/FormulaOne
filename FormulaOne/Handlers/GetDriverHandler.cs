using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Entities.Dtos.Responses;
using FormulaOne.Queries;
using MediatR;

namespace FormulaOne.Handlers
{
    public class GetDriverHandler : IRequestHandler<GetDriverQuery, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetDriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

            if (driver == null)
                return null;

            var result = _mapper.Map<GetDriverResponse>(driver);

            return result;
        }
    }
}
