using ChatApp.DAL.Entities;

namespace ChatApp.DAL.Repositories.Abstract
{
    public interface IImageRepository
    {
        Task<Image?> GetAsync(string? id);

        Task<Image> AddAsync(string imagePath);

        Task<Image> DeleteAsync(string id);
    }
}
