﻿using ChatApp.DAL.Context;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChatApp.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ChatAppContext context) : base(context)
        {
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
