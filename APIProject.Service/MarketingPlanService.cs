﻿using APIProject.Data.Infrastructure;
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
        private readonly IUnitOfWork unitOfWork;

        public MarketingPlanService(IMarketingPlanRepository _marketingPlanRepository, IMarketingPlanDateRepository _marketingPlanDateRepository,
            IUnitOfWork unitOfWork)
        {
            this._marketingPlanDateRepository = _marketingPlanDateRepository;
            this._marketingPlanRepository = _marketingPlanRepository;
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

        private int InsertMarketingPlan(MarketingPlan plan)
        {
            _marketingPlanRepository.Add(plan);
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

    }
}
