using APIProject.Data.Infrastructure;
using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Data.Repositories
{
    public class MarketingPlanRepository: RepositoryBase<MarketingPlan>, IMarketingPlanRepository
    {
        public MarketingPlanRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public IEnumerable<MarketingPlan> GetMarketingPlanList()
        {
            return DbContext.MarketingPlans
                .Include("MarketingStage").ToList();
        }
    }
    public interface IMarketingPlanRepository : IRepository<MarketingPlan>
    {
        IEnumerable<MarketingPlan> GetMarketingPlanList();
    }
}
