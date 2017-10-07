using APIProject.Data.Infrastructure;
using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Data.Repositories
{
    public class MarketingPlanDateRepository : RepositoryBase<MarketingPlanDate>, IMarketingPlanDateRepository
    {
        public MarketingPlanDateRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IMarketingPlanDateRepository : IRepository<MarketingPlanDate>
    {

    }
}
