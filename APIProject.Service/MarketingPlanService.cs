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
    public class MarketingPlanService: IMarketingPlanService
    {

        private readonly IMarketingPlanRepository marketingPlanRepository;
        private readonly IMarketingPlanDateRepository marketingPlanDateRepository;
        private readonly IUnitOfWork unitOfWork;
        public MarketingPlanService(IMarketingPlanDateRepository marketingPlanDateRepository , IMarketingPlanRepository marketingPlanRepository, IUnitOfWork unitOfWork)
        {
            this.marketingPlanRepository = marketingPlanRepository;
            this.marketingPlanDateRepository = marketingPlanDateRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePlan(MarketingPlan plan)
        {
            marketingPlanRepository.Add(plan);
            unitOfWork.Commit();
        }
        public void CreatePlanV2(MarketingPlan plan, ICollection<MarketingPlanDate> dates)
        {
            marketingPlanRepository.Add(plan);
            //marketingPlanDateRepository.Add(new MarketingPlanDate() { PlanDate= DateTime.Now});

            //save changes error->foreign keys
            unitOfWork.Commit();
            int planID = plan.Id;
            foreach (MarketingPlanDate dateItem in dates)
            {
                dateItem.PlanId = planID;
                marketingPlanDateRepository.Add(dateItem);
            }

            unitOfWork.Commit();
        }

        public IEnumerable<MarketingPlan> GetMarketingPlanList()
        {
            return marketingPlanRepository.GetMarketingPlanList();

        }
    }
    public interface IMarketingPlanService
    {
        void CreatePlan(MarketingPlan plan);
        void CreatePlanV2(MarketingPlan plan, ICollection<MarketingPlanDate> dates);

        IEnumerable<MarketingPlan> GetMarketingPlanList();

    }
}
