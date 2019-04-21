using Base.Core.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Base.Core.App.Models.UserAccounts.UserAccountsModel;

namespace Base.Core.App.Interface.UserAccounts
{
    public interface IUserService
    {
        Task<LoginResponse> Authenticate(LoginRequest loginRequest);
    }
}
