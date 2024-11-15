using AutoMapper;
using DataService.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly ISender _sender;

        public BaseController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ISender sender
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sender = sender;
        }
    }
}
