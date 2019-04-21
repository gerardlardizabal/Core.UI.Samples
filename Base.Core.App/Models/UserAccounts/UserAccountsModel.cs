using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Core.App.Models.UserAccounts
{
    public class UserAccountsModel
    {
        public class LoginResponse
        {
            public string message { get; set; }
            public string token { get; set; }
            public bool allowedLogin { get; set; }
            public LoginResponseUserInformation user { get; set; }

            public class LoginResponseUserInformation
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
            }
        };

        public class LoginRequest
        {
            public string username { get; set; }
            public string password { get; set; }
        };
        
        public class AuthenticationResponse
        {
            public string message { get; set; }
        }
    }
}
