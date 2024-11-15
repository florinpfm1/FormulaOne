using DataService.Data;
using DataService.Repositories.Interfaces;
using Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Driver>> All()
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
                _logger.LogError(e, "{Repo} All function error", typeof(DriverRepository));
                throw;
            }
        }

        

        public override async Task<bool> Update(Driver driver)
        {
            try
            {
                //get my entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.DriverNumber = driver.DriverNumber;
                result.FirstName = driver.FirstName;
                result.LastName = driver.LastName;
                result.DateOfBirth = driver.DateOfBirth;

                return true;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Update function error", typeof(DriverRepository));

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
                _logger.LogError(e, "{Repo} Delete function error", typeof(DriverRepository));
                throw;
            }
        }

    }
}
