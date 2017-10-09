using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIProject.Model.Models;
using APIProject.Data.Infrastructure;
using APIProject.Data.Repositories;

namespace APIProject.Service
{
    public class MarketingResultService : IMarketingResultService
    {
        private readonly IMarketingResultRepository _marketingResultRepository;
        private readonly IContactRepository _contactService;
        private readonly IUnitOfWork _unitOfWork;

        public MarketingResultService(IMarketingResultRepository _marketingResultRepository, IUnitOfWork _unitOfWork,
            IContactService _contactService)
        {
            this._marketingResultRepository = _marketingResultRepository;
            this._contactService = _contactService;
            this._unitOfWork = _unitOfWork;
        }
        public void CreateMarketingResults(List<MarketingResult> requestList)
        {
            foreach(MarketingResult item in requestList)
            {
                _marketingResultRepository.Add(item);
                if(item.ContactId != null)
                {
                    _contactService.
                }
            }
        }
    }

    public interface IMarketingResultService
    {
        void CreateMarketingResults(List<MarketingResult> requestList);
    }
}
