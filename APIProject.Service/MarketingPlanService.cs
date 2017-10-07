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
        private readonly IMarketingPlanRepository _marketingPlanRepository;
        private readonly IMarketingPlanDateRepository _marketingPlanDateRepository;
        private readonly IMarketingStageRepository _marketingStageRepository;
        private readonly IUnitOfWork unitOfWork;

        public MarketingPlanService(IMarketingPlanRepository _marketingPlanRepository, IMarketingPlanDateRepository _marketingPlanDateRepository,
            IMarketingStageRepository _marketingStageRepository, IUnitOfWork unitOfWork)
        {
            this._marketingPlanDateRepository = _marketingPlanDateRepository;
            this._marketingPlanRepository = _marketingPlanRepository;
            this._marketingStageRepository = _marketingStageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateMarketingPlan(MarketingPlan plan, List<MarketingPlanDate> planDates)
        {
            int insertMarketingPlanID = InsertMarketingPlan(plan);
            if(planDates != null)
            {
                AddMarketingPlanDates(insertMarketingPlanID, planDates);
            }
        }

        public void ValidatePlan(MarketingPlan plan)
        {
            MarketingPlan _plan = _marketingPlanRepository.GetById(plan.Id);

            //Not found
            if(_plan == null)
            {
                //deal with bad request display code
            }

            //Found
            _plan.IsValidated = plan.IsValidated;
            _plan.ValidatedById = plan.ValidatedById;
            _plan.ValidateNotes = plan.ValidateNotes;

            //move stage
            if (_plan.IsValidated)
            {

            }

            _plan.UpdatedById = plan.ValidatedById;
        }

        private int InsertMarketingPlan(MarketingPlan plan)
        {
            _marketingPlanRepository.Add(plan);
            plan.StageId = _marketingStageRepository.GetInitialStageID();
            unitOfWork.Commit();
            return plan.Id;
        }

        private void AddMarketingPlanDates(int planID, List<MarketingPlanDate> planDates)
        {
            foreach (MarketingPlanDate item in planDates)
            {
                item.MarketingPlanId = planID;
                _marketingPlanDateRepository.Add(item);
            }
            unitOfWork.Commit();
        }

    }
    public interface IMarketingPlanService
    {
        void CreateMarketingPlan(MarketingPlan plan, List<MarketingPlanDate> planDates);
        void ValidatePlan(MarketingPlan plan);

    }
}
