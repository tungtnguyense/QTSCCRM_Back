using APIProject.Data.Infrastructure;
using APIProject.Data.Repositories;
using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service
{
    public class MarketingStageService : IMarketingStageService
    {
        private readonly IMarketingStageRepository marketingStageRepository;
        private readonly IUnitOfWork unitOfWork;

        public MarketingStageService(IMarketingStageRepository marketingStageRepository,
            IUnitOfWork unitOfWork)
        {
            this.marketingStageRepository = marketingStageRepository;
            this.unitOfWork = unitOfWork;
        }

        //just for initial mock data
        public void CreateMarketingStages()
        {
            marketingStageRepository.Add(new MarketingStage() { Name = "test" });
            unitOfWork.Commit();
        }

       
    }
    public interface IMarketingStageService
    {
        void CreateMarketingStages( );
        
    }
}
