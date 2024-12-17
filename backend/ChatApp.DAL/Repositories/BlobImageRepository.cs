using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;

namespace ChatApp.DAL.Repositories;

public class BlobImageRepository : GenericRepository<BlobImage>, IBlobImageRepository
{
    public BlobImageRepository(ChatAppContext context) : base(context)
    {
    }
}