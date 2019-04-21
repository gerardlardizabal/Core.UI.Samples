using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Base.Core.App.Models.FormSamples.FormSampleModel;

namespace Base.Core.App.Controllers.FormSamples
{
    public class FormSamplesController : Controller
    {
        public IActionResult Index()
        {
            return View("FormSamples");
        }

        [HttpPost]
        public IActionResult SampleMethod1([FromForm] SampleModel1 sampleModel1)
        {
            return ViewComponent("ModalMessage", new ModalMessageModel { message = "Hi " + sampleModel1.FirstName, title = "Sample Form" });
        }
    }
}