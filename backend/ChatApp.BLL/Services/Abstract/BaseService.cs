using AutoMapper;
using ChatApp.Common.Logic.Abstract;

namespace ChatApp.BLL.Services.Abstract
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IUserIdGetter _userIdGetter;

        protected BaseService(IMapper mapper, IUserIdGetter userIdGetter)
        {
            _mapper = mapper;
            _userIdGetter = userIdGetter;
        }
    }
}
