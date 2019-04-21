using Base.Core.App.Interface.UserAccounts;
using Base.Core.App.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using static Base.Core.App.Models.UserAccounts.UserAccountsModel;
using Base.Core.App.Models.Generics;
using Microsoft.Extensions.Options;
using Base.Core.App.Services.Helpers;

namespace Base.Core.App.Services.UserAccounts
{
    public class UserService : IUserService
    {
        private readonly ApplicationSetttings _applicationSettings;
        private ApiClient apiClient;

        public UserService(IOptions<ApplicationSetttings> applicationSetttings)
        {
            _applicationSettings = applicationSetttings.Value;
            apiClient = new ApiClient(_applicationSettings.APIUri, "");
    
        }

        public async Task<LoginResponse> Authenticate(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = await apiClient.PostAsync<LoginResponse,LoginRequest>("api/users/authenticateUser",loginRequest);
            return loginResponse;
        }
    }
}
