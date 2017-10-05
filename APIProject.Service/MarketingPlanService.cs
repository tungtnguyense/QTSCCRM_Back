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
        private readonly IUnitOfWork unitOfWork;
        
    }
    public interface IMarketingPlanService
    {
        

    }
}
