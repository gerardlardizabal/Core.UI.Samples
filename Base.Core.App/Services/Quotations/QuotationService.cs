using Base.Core.App.Interface.Quotations;
using Base.Core.App.Models.Generics;
using Base.Core.App.Services.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Core.App.Services.Quotations
{
    public class QuotationService : IQuotationService
    {
        private readonly ApplicationSetttings _applicationSettings;
        private ApiClient apiClient;

        public QuotationService(IOptions<ApplicationSetttings> applicationSetttings)
        {
            _applicationSettings = applicationSetttings.Value;
            apiClient = new ApiClient(_applicationSettings.APIUri, "");

        }
    }
}
