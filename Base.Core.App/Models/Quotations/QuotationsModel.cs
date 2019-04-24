using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Core.App.Models.Quotations
{
    public class QuotationsModel
    {
        public class QuotationDisplayTable
        {
            public string quoteId { get; set; }
            public string customer { get; set; }
            public string date { get; set; }
            public string channel { get; set; }
            public string branch { get; set; }
            public string encoder { get; set; }
            public string status { get; set; }
            public Double subtotal { get; set; }
            public Double itemDisc { get; set; }
            public Double overallDisc { get; set; }
            public Double total { get; set; }
            public List<QuotationDisplayDetails> details { get; set; }

            public class QuotationDisplayDetails
            {
                public int quantity { get; set; }
                public string unit { get; set; }
                public string itemCode { get; set; }
                public string description { get; set; }
                public Double itemPrice { get; set; }
                public Double subtotal { get; set; }

            }
        }
    }
}
