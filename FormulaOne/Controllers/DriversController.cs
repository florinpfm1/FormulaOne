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
        public DriversController(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ISender sender) : base(unitOfWork, mapper, sender)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            // Specifying the query that I have for this endpoint
            var query = new GetAllDriversQuery();

            var result = await _sender.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);

            var result = await _sender.Send(query);

            if (result == null)
                return NotFound();

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

            var command = new CreateDriverCommand(driver);

            var result = await _sender.Send(command);

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

            var command = new UpdateDriverCommand(driver);

            var result = await _sender.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var command = new DeleteDriverCommand(driverId);

            var result = await _sender.Send(command);

            return result ? NoContent() : BadRequest();

        }

    }
}
