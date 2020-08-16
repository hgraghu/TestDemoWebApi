using DemoWebApi.Repository;
using DemoWebApi.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DemoWebApi.Repository
{
    public class UserRepository: IUser
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool AuthenticateUsers(string username, string password)
        {
            var result = (from user in _context.User
                          where user.UserName == username && user.Password == password
                          select user).Count();
            return result > 0 ? true : false;
        }
    }
}
