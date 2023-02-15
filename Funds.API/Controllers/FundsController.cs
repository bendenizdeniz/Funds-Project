using Funds.Application;
using Funds.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Funds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : Controller
    {
        public IFundsService fundsService { get; }

        public FundsController(IFundsService _fundsService)
        {
            fundsService = _fundsService;
        }


        [HttpGet]
        [Route("fundsList")]
        public List<FundsEntity> GetFunds()
        {
            return fundsService.GetAllFundsUC();
        }

        [HttpGet]
        [Route("getFundById")]
        public FundsEntity GetFundById(string id)
        {
            return fundsService.GetFundByIdUC(id);
        }

        [HttpGet]
        [Route("getFundByCode")]
        public FundsEntity GetFundByCode(string code)
        {
            return fundsService.GetFundByCodeUC(code);
        }

        [HttpGet]
        [Route("getFundsPrices")]
        public List<FundsPrices> GetFundsPrices()
        {
            return fundsService.GetFundsPricesUC();
        }

        [HttpGet]
        [Route("GetLastThreeMonthsFundsPrices")]
        public double GetLastThreeMonthsFundsPrices(string code)
        {
            return fundsService.GetLastThreeMonthsFundsPricesUC(code);
        }

        [HttpGet]
        [Route("GetLastMonthsFundsPrices")]
        public double GetLastMonthsFundsPrices(string code)
        {
            return fundsService.GetLastMonthsFundsPricesUC(code);
        }

        [HttpGet]
        [Route("GetLastWeeksFundsPrices")]
        public double GetLastWeeksFundsPricesUC(string code)
        {
            return fundsService.GetLastWeeksFundsPricesUC(code);
        }

        [HttpGet]
        [Route("GetYesterdayFundsPrices")]
        public double GetYesterdayFundsPricesUC(string code)
        {
            return fundsService.GetYesterdayFundsPricesUC(code);
        }

        [HttpGet]
        [Route("GetFundsPricesByCode")]
        public double GetFundsPricesByCodeUC(string code)
        {
            return fundsService.GetFundsPricesByCodeUC(code);
        }
    }
}
