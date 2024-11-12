using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Entities.Dtos.Responses;
using FormulaOne.Commands;
using MediatR;

namespace FormulaOne.Handlers
{
    public class GetDriverInfoHandler : IRequestHandler<CreateDriverInfoRequest, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverInfoHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetDriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request.DriverRequest);

            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<GetDriverResponse>(driver);

            return result;
        }






    }
}
