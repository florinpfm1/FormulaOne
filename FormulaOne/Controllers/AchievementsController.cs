using AutoMapper;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Entities.Dtos.Requests;
using Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(
            IUnitOfWork unitOfWork, 
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

            if(driverAchievements == null)
                return NotFound("Achievemnets not found");

            var result = _mapper.Map<DriverAchievementResponse>(driverAchievements); 

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAchievement (
            [FromBody] CreateDriverAchievementRequest achievement
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateAchievements(
            [FromBody] UpdateDriverAchievementRequest achievement
            )
        {
            if(!ModelState.IsValid) 
                return BadRequest();

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }


    }
}