namespace MovieTrackerProject.Application.Interfaces
{
    public interface IRateRepository<Rate>
    {
        Task<List<Rate>> GetAllAsync();
        Task<Rate> GetByIdAsync(int id);

        Task CreateAsync(Rate entity);
        Task UpdateAsync(Rate entity);
        Task DeleteAsync(Rate entity);


    }
}
