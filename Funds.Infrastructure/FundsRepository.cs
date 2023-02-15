using Funds.Application;
using Funds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funds.Infrastructure
{
    public class FundsRepository : IFundsRepository
    {
        //public static List<FundsEntity> fundsList = new List<FundsEntity>() {
        //    new FundsEntity { Id = "1", Name = "First Fund", Code = "AMK1"},
        //    new FundsEntity { Id = "2", Name = "Second Fund", Code = "AMK2"},
        //    new FundsEntity { Id = "3", Name = "Third Fund", Code = "AMK3"},
        //};

        public FundsDbContext dbContext { get; }

        public FundsRepository(FundsDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<FundsEntity> GetAllFunds()
        {
            return dbContext.Funds.ToList();
            //return fundsList;
        }

        public FundsEntity GetFundById(string id)
        {
            return dbContext.Funds.FirstOrDefault(f => f.Id == id);
        }

        public FundsEntity GetFundByCode(string code)
        {
            return dbContext.Funds.FirstOrDefault(f => f.Code == code);
        }

        public List<FundsPrices> GetFundsPrices()
        {
            return dbContext.FundsPrices.ToList();
        }

        public List<FundsEntity> GetFundsPricesById(string id)
        {
            return dbContext.Funds.Where(f => f.Id == id).ToList();
        }

        List<FundsPrices> IFundsRepository.GetFundsPricesById(string id)
        {
            return dbContext.FundsPrices.Where(f => f.FundId == id).ToList();
        }
    }
}
