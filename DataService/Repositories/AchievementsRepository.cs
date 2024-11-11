using DataService.Data;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
    public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
    {
        public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<IEnumerable<Achievement>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                //get my entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Achievement achievement)
        {
            try
            {
                //get my entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.DriverId == achievement.DriverId);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.FastestLap = achievement.FastestLap;
                result.PolePosition = achievement.PolePosition;
                result.RaceWins = achievement.RaceWins;
                result.WorldChampionship = achievement.WorldChampionship;

                return true;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Update function error", typeof(AchievementsRepository));

                throw;
            }
        }
    }
}
