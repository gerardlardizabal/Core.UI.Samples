using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Base.Core.App.Controllers.Examples
{
    [Route("creatingPages")]
    public class CreatingPagesController : Controller
    {
        // This method renders the main page by default
        // You may add your own methods and render specific View
        public IActionResult Index()
        {
            return View("CreatingPages");
        }

        //Here is an example of a personalized method
        //Notice that we named this SampleMethod and we return a View()
        //by just returning View(), the controller would by default look for a View named SampleMethod
        //on either the Views/CreatingPages Folder, or the View/Shared Folder
        [Route("SampleMethod")]
        public IActionResult SampleMethod()
        {
            return View();
        }

        //Here is an example of a personalized method but returns a custom View 
        //the controller would by default look for a View named SampleCustomView
        //on either the Views/CreatingPages Folder, or the View/Shared Folder
        [Route("sampleRoute")]
        public IActionResult SampleMethod2()
        {
            return View("SampleView");
        }
    }
}