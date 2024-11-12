using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.Dtos.Responses;
using FormulaOne.Queries;
using MediatR;

namespace FormulaOne.Handlers
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriversHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.All();

            var driversResult = _mapper.Map<IEnumerable<GetDriverResponse>>(driver);

            return driversResult;
        }
    }
}
