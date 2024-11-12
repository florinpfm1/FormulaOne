using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Entities.Dtos.Requests;
using Entities.Dtos.Responses;
using FormulaOne.Commands;
using FormulaOne.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    public class DriversController : BaseController
    {
        

        public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
            
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            // Specifying the query that I have for this endpoint
            var query = new GetAllDriversQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddDriver(
            [FromBody] CreateDriverRequest driver
            )
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var command = new CreateDriverInfoRequest(driver);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriver), new {driverId = result.DriverId}, result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateDriver(
            [FromBody] UpdateDriverRequest driver
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new UpdateDriverInfoRequest(driver);

            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var command = new DeleteDriverInfoRequest(driverId);

            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();

        }

    }
}
