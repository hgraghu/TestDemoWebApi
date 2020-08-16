using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebApi.Interface
{
    public interface IUser
    {
        bool AuthenticateUsers(string username, string password);
    }
}
