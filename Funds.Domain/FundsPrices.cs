using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funds.Domain
{
    public class FundsPrices
    {
        public string Id { get; set; }

        public string FundId { get; set; }

        public DateTime Date { get; set; }

        public string Close { get; set; }

    }
}
