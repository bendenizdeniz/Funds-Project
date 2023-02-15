using Funds.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funds.Application
{
    public class FundsService : IFundsService
    {
        public IFundsRepository fundsRepository { get; }

        public FundsService(IFundsRepository _fundsRepository)
        {
            fundsRepository = _fundsRepository;
        }


        public List<FundsEntity> GetAllFundsUC()
        {
            return fundsRepository.GetAllFunds();
        }

        public FundsEntity GetFundByIdUC(string id)
        {
            return fundsRepository.GetFundById(id);
        }

        public FundsEntity GetFundByCodeUC(string code)
        {
            return fundsRepository.GetFundByCode(code);
        }

        public List<FundsPrices> GetFundsPricesUC()
        {
            return fundsRepository.GetFundsPrices();
        }

        public double GetFundsPricesByCodeUC(string code)
        {
            FundsEntity fund = GetFundByCodeUC(code);
            List<FundsPrices> AllFundsPrices = GetFundsPricesUC();
            List<FundsPrices> prices = AllFundsPrices.Where(x => x.FundId == fund.Id).ToList();

            return prices.Sum(p => float.Parse(p.Close, CultureInfo.InvariantCulture.NumberFormat));
        }

        public float GetPrice(string price)
        {
            return float.Parse(price, CultureInfo.InvariantCulture.NumberFormat);
        }

        public double GetRateOfReturn(DateTime startDate, DateTime endDate, List<FundsPrices> fundsPrices)
        {
            List<FundsPrices> currentFundPrices = fundsPrices.Where(p => p.Date > startDate || p.Date < endDate).ToList();
            currentFundPrices.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            FundsPrices firstEl = currentFundPrices[0];
            FundsPrices lastEl = currentFundPrices[currentFundPrices.Count - 1];

            var firstPrice = GetPrice(firstEl.Close);
            var lastPrice = GetPrice(lastEl.Close);

            var priceDiff = lastPrice - firstPrice;

            var res = priceDiff / firstPrice * 100;

            double result = Math.Round(res, 2);

            return result < 0 ? -result : result;
        }

        public double GetLastThreeMonthsFundsPricesUC(string code)
        {
            FundsEntity fund = fundsRepository.GetFundByCode(code);
            List<FundsPrices> fundsPrices = fundsRepository.GetFundsPricesById(fund.Id);
            DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);

            return GetRateOfReturn(DateTime.Now, threeMonthsAgo, fundsPrices);

            //List<FundsPrices> fundsPrices = fundsRepository.GetFundsPrices();
            //fundsPrices = fundsPrices.Where(x => x.Date < threeMonthsAgo).ToList();
            //double total = fundsPrices.Sum(item => float.Parse(item.Close, CultureInfo.InvariantCulture.NumberFormat));
            //return total;
        }

        public double GetLastMonthsFundsPricesUC(string code)
        {
            FundsEntity fund = fundsRepository.GetFundByCode(code);
            List<FundsPrices> fundsPrices = fundsRepository.GetFundsPricesById(fund.Id);
            DateTime aMonthAgo = DateTime.Now.AddMonths(-1);

            return GetRateOfReturn(aMonthAgo, DateTime.Now, fundsPrices);
        }

        public double GetLastWeeksFundsPricesUC(string code)
        {
            FundsEntity fund = fundsRepository.GetFundByCode(code);
            List<FundsPrices> fundsPrices = fundsRepository.GetFundsPricesById(fund.Id);
            DateTime aWeekAgo = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 6);

            return GetRateOfReturn(aWeekAgo, DateTime.Now, fundsPrices);
        }

        public double GetYesterdayFundsPricesUC(string code)
        {
            FundsEntity fund = fundsRepository.GetFundByCode(code);
            List<FundsPrices> fundsPrices = fundsRepository.GetFundsPricesById(fund.Id);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            return GetRateOfReturn(yesterday, DateTime.Now, fundsPrices);
        }

    }
}
