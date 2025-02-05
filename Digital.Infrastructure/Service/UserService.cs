﻿using AutoMapper;
using Digital.Data.Data;
using Digital.Data.Entities;
using Digital.Infrastructure.Interface;
using Digital.Infrastructure.Model.Requests;

namespace Digital.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public UserService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<User> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUser(Guid id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public User CreateUser(UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            user.Id = Guid.NewGuid();
            user.DateCreated = DateTime.Now;
            user.DateUpdated = DateTime.Now;

            _context.Users.Add(user);

            _context.SaveChanges();

            return user;
        }

        public User UpdateUser(Guid id, UserRequest userRequest)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                user = _mapper.Map(userRequest, user);
                user.DateUpdated = DateTime.Now;

                _context.Users.Update(user);

                _context.SaveChanges();
            }

            return user;
        }

        public User DeletedUser(Guid id, bool isDeleted)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                user.DateUpdated = DateTime.Now;
                user.IsDeleted = isDeleted;

                _context.Users.Update(user);

                _context.SaveChanges();
            }

            return user;
        }
    }
}
