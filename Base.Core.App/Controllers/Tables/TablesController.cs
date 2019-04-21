using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Core.App.Models.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Base.Core.App.Controllers.Tables
{
    public class TablesController : Controller
    {
        public IActionResult Index()
        {
            return View("Tables");
        }

        //This is a Get Function
        public IActionResult Tables()
        {
            List<TablesModel> tablesModel = new List<TablesModel>();
            tablesModel.Add(new TablesModel
            {
                location = "Location 1",
                name = "Gerard",
                position = "Staff",
                status = "Active"
            });

            tablesModel.Add(new TablesModel
            {
                location = "Location 2",
                name = "Vincent",
                position = "Staff",
                status = "Active"
            });

            tablesModel.Add(new TablesModel
            {
                location = "Location 1",
                name = "John",
                position = "Administrator",
                status = "Active"
            });

            tablesModel.Add(new TablesModel
            {
                location = "Location 1",
                name = "Luis",
                position = "Staff",
                status = "Active"
            });

            return View(tablesModel);
        }
    }
}