using AutoMapper;
using ChatApp.DAL.Context;

namespace ChatApp.BLL.Services.Abstract
{
    public abstract class BaseService
    {
        protected readonly ChatAppContext _context;
        protected readonly IMapper _mapper;

        protected BaseService(ChatAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
