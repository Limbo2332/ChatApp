using AutoMapper;
using ChatApp.BLL.Hubs;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using Microsoft.AspNetCore.SignalR;

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
