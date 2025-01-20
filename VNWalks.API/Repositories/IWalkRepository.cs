using VNWalks.API.Models.Domain;

namespace VNWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync();
        Task<Walk> CreateAsync(Walk walk);
    }
}
