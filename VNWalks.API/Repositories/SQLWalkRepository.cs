using Microsoft.EntityFrameworkCore;
using VNWalks.API.Data;
using VNWalks.API.Models.Domain;

namespace VNWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly AppDbContext _dbContext;

        public SQLWalkRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }
        private IQueryable<Walk> ApplyFiltering(IQueryable<Walk> walks, string? filterOn, string? filterQuery)
        {
            // check xem nó tìm theo Name hay Description hay LengthInKm
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
            else if (filterOn.Equals("Description", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Description.Contains(filterQuery));
            }
            else if (filterOn.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
            {
                if (double.TryParse(filterQuery, out double lengthInKm))
                {
                    walks = walks.Where(x => x.LengthInKm == lengthInKm);
                }
                else
                {
                    throw new ArgumentException("filterQuery for LengthInKm must be a valid number.");
                }
            }
            return walks;
        }

        private IQueryable<Walk> ApplySorting(IQueryable<Walk> walks, string? sortBy, bool isAscending)
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
            else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
            }
            return walks;
        }


        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 5)
        {
            // sử dụng AsQueryable()
            var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            // Nếu không null, có tham số để filter
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                walks = ApplyFiltering(walks, filterOn, filterQuery);
            }
            // Nếu không null, có tham số để sort
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                walks = ApplySorting(walks, sortBy, isAscending);
            }
            // Phân trang
            var skipResults = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
        }
        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
