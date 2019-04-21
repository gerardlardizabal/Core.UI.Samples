using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Base.Core.App.Models.FormSamples.FormSampleModel;

namespace Base.Core.App.Models.ViewComponents
{
    public class ModalMessage : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string message,string title)
        {
            ModalMessageModel modalMessageModel = new ModalMessageModel {
                message = message,
                title = title
            };
            return View("ModalMessage",modalMessageModel);
        }
    }
}
