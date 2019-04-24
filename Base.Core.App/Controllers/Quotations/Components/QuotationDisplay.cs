using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Base.Core.App.Models.Quotations.QuotationsModel;

namespace Base.Core.App.Controllers.Quotations.Components
{
    [ViewComponent(Name = "QuotationDisplay")]
    public class QuotationDisplay : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<QuotationDisplayTable> quotationDisplayTable)
        {
            return View("~/Views/Quotations/Components/DisplayTable.cshtml", quotationDisplayTable);
        }
    }
}
