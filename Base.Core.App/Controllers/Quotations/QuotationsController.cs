using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Base.Core.App.Interface.Quotations;
using static Base.Core.App.Models.Quotations.QuotationsModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Base.Core.App.Controllers.Quotations
{
    [Route("/Quotation")]
    public class QuotationsController : Controller
    {
        //IQuotationService _quotationService;
        //public QuotationsController(IQuotationService quotationService)
        //{
        //    _quotationService = quotationService;
        //}

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("Display")]
        public IActionResult Display()
        {
            return View("Display");
        }

        [HttpGet]
        [Route("GetQuotationList")]
        public async Task<IActionResult> GetQuotationList()
        {
            List<QuotationDisplayTable> quotationDisplayTable = new List<QuotationDisplayTable>
            {
                new QuotationDisplayTable{
                    quoteId = "1",
                    customer = "gerard",
                    date = "04/12/2019",
                    channel = "All Channel",
                    branch = "pasig",
                    encoder = "siena",
                    status = "Pending",
                    subtotal = 120.00,
                    itemDisc = 0.00,
                    overallDisc = 0.00,
                    total = 120.00,
                    details=new List<QuotationDisplayTable.QuotationDisplayDetails>
                    {
                        new QuotationDisplayTable.QuotationDisplayDetails
                        {
                            quantity = 5,
                            unit = "pc",
                            itemCode = "7162",
                            description = "random",
                            itemPrice = 20,
                            subtotal = 30
                        },
                        new QuotationDisplayTable.QuotationDisplayDetails
                        {
                            quantity = 5,
                            unit = "pc",
                            itemCode = "7162",
                            description = "random",
                            itemPrice = 20,
                            subtotal = 30
                        },
                        new QuotationDisplayTable.QuotationDisplayDetails
                        {
                            quantity = 5,
                            unit = "pc",
                            itemCode = "7162",
                            description = "random",
                            itemPrice = 20,
                            subtotal = 30
                        }
                    }
                },
                new QuotationDisplayTable{
                    quoteId = "2",
                    customer = "danica",
                    date = "04/14/2019",
                    channel = "All Channel",
                    branch = "pasig",
                    encoder = "jangku",
                    status = "Pending",
                    subtotal = 120.00,
                    itemDisc = 0.00,
                    overallDisc = 0.00,
                    total = 120.00,
                    details=new List<QuotationDisplayTable.QuotationDisplayDetails>
                    {
                        new QuotationDisplayTable.QuotationDisplayDetails
                        {
                            quantity = 5,
                            unit = "pc",
                            itemCode = "7162",
                            description = "random",
                            itemPrice = 20,
                            subtotal = 30
                        },
                        new QuotationDisplayTable.QuotationDisplayDetails
                        {
                            quantity = 5,
                            unit = "pc",
                            itemCode = "7162",
                            description = "random",
                            itemPrice = 20,
                            subtotal = 30
                        }
                    }
                }
            };
            return ViewComponent("QuotationDisplay", quotationDisplayTable);
        }
    }
}
