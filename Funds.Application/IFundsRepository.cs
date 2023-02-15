using Funds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funds.Application
{
    public interface IFundsRepository
    {
        List<FundsEntity> GetAllFunds();

        FundsEntity GetFundById(string id);

        FundsEntity GetFundByCode(string code);
        List<FundsPrices> GetFundsPricesById(string id);

        List<FundsPrices> GetFundsPrices();
    }
}
