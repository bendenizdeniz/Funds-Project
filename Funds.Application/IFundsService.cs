using Funds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funds.Application
{
    public interface IFundsService
    {
        List<FundsEntity> GetAllFundsUC();

        FundsEntity GetFundByIdUC(string id);

        FundsEntity GetFundByCodeUC(string code);

        List<FundsPrices> GetFundsPricesUC();

        double GetFundsPricesByCodeUC(string code);

        double GetLastMonthsFundsPricesUC(string code);
        double GetLastThreeMonthsFundsPricesUC(string code);

        double GetLastWeeksFundsPricesUC(string code);

        double GetYesterdayFundsPricesUC(string code);

        double GetRateOfReturn(DateTime startDate, DateTime endDate, List<FundsPrices> fundsPrices);
    }
}
