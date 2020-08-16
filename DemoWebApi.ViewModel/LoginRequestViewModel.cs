using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWebApi.ViewModel
{
    public class LoginRequestViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
