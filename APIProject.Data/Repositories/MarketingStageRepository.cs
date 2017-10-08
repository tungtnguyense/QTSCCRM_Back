using APIProject.Data.Infrastructure;
using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Data.Repositories
{
    public class MarketingStageRepository : RepositoryBase<MarketingStage>, IMarketingStageRepository
    {
        public MarketingStageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public int GetInitialStageID()
        {
            return DbContext.MarketingStages.Where(x => x.IsInitial == true).FirstOrDefault().Id;
        }

        public int GetStageByName(string stageName)
        {
            return DbContext.MarketingStages.Where(x => x.Name.Equals(stageName)).FirstOrDefault().Id;
        }
    }

    public interface IMarketingStageRepository : IRepository<MarketingStage>
    {
        int GetInitialStageID();
        int GetStageByName(string stageName);
    }
}
