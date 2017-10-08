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
    public class MarketingPlanService : IMarketingPlanService
    {
        private readonly IMarketingPlanRepository _marketingPlanRepository;
        private readonly IMarketingPlanDateRepository _marketingPlanDateRepository;
        private readonly IMarketingStageRepository _marketingStageRepository;
        private readonly IUnitOfWork unitOfWork;

        private readonly string DraftingStageName = "Drafting";
        private readonly string ValidatingStageName = "Validating";
        private readonly string ApprovingStageName = "Approving";

        public MarketingPlanService(IMarketingPlanRepository _marketingPlanRepository, IMarketingPlanDateRepository _marketingPlanDateRepository,
            IMarketingStageRepository _marketingStageRepository, IUnitOfWork unitOfWork)
        {
            this._marketingPlanDateRepository = _marketingPlanDateRepository;
            this._marketingPlanRepository = _marketingPlanRepository;
            this._marketingStageRepository = _marketingStageRepository;
            this.unitOfWork = unitOfWork;
        }

        public int CreateMarketingPlan(MarketingPlan plan, List<MarketingPlanDate> planDates, bool isFinished)
        {
            int insertMarketingPlanID = InsertMarketingPlan(plan);
            if (planDates != null)
            {
                AddMarketingPlanDates(insertMarketingPlanID, planDates);
            }
            if (isFinished)
            {
                plan.StageId = _marketingStageRepository.GetStageByName(ValidatingStageName);
            }

            unitOfWork.Commit();

            return insertMarketingPlanID;
        }

        public void ValidatePlan(MarketingPlan plan)
        {
            MarketingPlan _plan = _marketingPlanRepository.GetById(plan.Id);



            //Found
            _plan.IsValidated = plan.IsValidated;
            _plan.ValidatedById = plan.ValidatedById;
            _plan.ValidateNotes = plan.ValidateNotes;

            //move stage
            if (_plan.IsValidated)
            {
                if (_plan.MarketingStage.NextStageId != null)
                {
                    _plan.StageId = _plan.MarketingStage.NextStageId;
                }
            }
            else
            {
                _plan.StageId = _marketingStageRepository.GetStageByName(DraftingStageName);
            }

            _plan.UpdatedById = plan.ValidatedById;

            unitOfWork.Commit();
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

        public bool CheckPlanStageIsValidating(int planId)
        {
            MarketingPlan plan = _marketingPlanRepository.GetById(planId);

            return plan.MarketingStage.Name.Equals(ValidatingStageName);

        }

        public bool CheckPlanExist(int planId)
        {
            return _marketingPlanRepository.GetById(planId) != null;
        }

        public bool CheckPlanStageIsApproving(int planId)
        {
            MarketingPlan plan = _marketingPlanRepository.GetById(planId);

            return plan.MarketingStage.Name.Equals(ApprovingStageName);
        }

        public void ApprovePlan(MarketingPlan updatedPlan)
        {
            MarketingPlan _plan = _marketingPlanRepository.GetById(updatedPlan.Id);



            //Found
            _plan.IsApproved = updatedPlan.IsApproved;
            _plan.ApprovedById = updatedPlan.ApprovedById;
            _plan.ApproveNotes = updatedPlan.ApproveNotes;

            //move stage
            if (_plan.IsApproved)
            {
                if (_plan.MarketingStage.NextStageId != null)
                {
                    _plan.StageId = _plan.MarketingStage.NextStageId;
                }
            }
            else
            {
                _plan.StageId = _marketingStageRepository.GetStageByName(DraftingStageName);
            }

            _plan.UpdatedById = updatedPlan.ApprovedById;

            unitOfWork.Commit();
        }

        public bool CheckPlanStageIsDrafting(int planID)
        {
            MarketingPlan plan = _marketingPlanRepository.GetById(planID);

            return plan.MarketingStage.Name.Equals(DraftingStageName);
        }

        public int EditMarketingPlan(MarketingPlan editingPlan, List<MarketingPlanDate> planDates, bool isFinished)
        {
            MarketingPlan _plan = _marketingPlanRepository.GetById(editingPlan.Id);
            _plan.UpdatedById = editingPlan.UpdatedById;
            _plan.Title = editingPlan.Title;
            _plan.Budget = editingPlan.Budget;
            _plan.Description = editingPlan.Description;
            
            // Code here for replacing database dates with inputted dates


            if (isFinished)
            {
                _plan.StageId = _marketingStageRepository.GetStageByName(ValidatingStageName);
            }

            unitOfWork.Commit();

            return editingPlan.Id;
        }
    }
    public interface IMarketingPlanService
    {
        int CreateMarketingPlan(MarketingPlan plan, List<MarketingPlanDate> planDates, bool isFinished);
        void ValidatePlan(MarketingPlan plan);
        bool CheckPlanStageIsValidating(int planId);
        bool CheckPlanExist(int planId);
        bool CheckPlanStageIsApproving(int planId);
        void ApprovePlan(MarketingPlan updatedPlan);
        bool CheckPlanStageIsDrafting(int planID);
        int EditMarketingPlan(MarketingPlan editingPlan, List<MarketingPlanDate> planDates, bool isFinished);
    }
}
