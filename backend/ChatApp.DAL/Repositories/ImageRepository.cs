using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace ChatApp.DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly MongoDbService _mongoDatabase;

        public ImageRepository(MongoDbService mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<Image> AddAsync(string imagePath)
        {
            var image = new Image
            {
                ImagePath = imagePath
            };

            await _mongoDatabase.Images.InsertOneAsync(image);

            return image;
        }

        public async Task<Image> DeleteAsync(string id)
        {
            var image = await _mongoDatabase.Images.FindOneAndDeleteAsync(x => x.Id == id);

            return image;
        }

        public async Task<Image?> GetAsync(string? id)
        {
            if (id.IsNullOrEmpty())
            {
                return null;
            }

            var image = await _mongoDatabase.Images.FindAsync(x => x.Id == id);

            return await image.FirstOrDefaultAsync();
        }
    }
}
