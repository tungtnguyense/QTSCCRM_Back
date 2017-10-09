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
        private readonly IContactRepository _contactRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MarketingResultService(IMarketingResultRepository _marketingResultRepository, IUnitOfWork _unitOfWork,
            IContactRepository _contactRepository, ICustomerRepository _customerRepository)
        {
            this._marketingResultRepository = _marketingResultRepository;
            this._contactRepository = _contactRepository;
            this._customerRepository = _customerRepository;
            this._unitOfWork = _unitOfWork;
        }
        public void CreateMarketingResults(List<MarketingResult> requestList)
        {
            foreach(MarketingResult item in requestList)
            {
                _marketingResultRepository.Add(item);
                if(item.CustomerId != null)
                {
                    if(item.ContactId != null)
                    {
                        Contact _contact = _contactRepository.GetAll().Where(x => x.Id == item.ContactId).First();
                        _contact.Name = item.ContactName;
                        _contact.Phone = item.Phone;
                        _contact.Email = item.Email;
                    }
                    else
                    {
                        Contact _contact = new Contact()
                        {
                            CustomerId = item.CustomerId,
                            Name = item.ContactName,
                            Phone = item.Phone,
                            Email = item.Email
                        };
                        _contactRepository.Add(_contact);
                    }
                }
                else
                {
                    if(item.ContactId.HasValue)
                    {
                        Customer _insertedCustomer = new Customer()
                        {
                            IsLead = true,
                            Name = item.CustomerName,
                            Address = item.Address
                        };
                        _customerRepository.Add(_insertedCustomer);
                        _unitOfWork.Commit();
                        Contact _insertedContact = new Contact()
                        {
                            CustomerId = _insertedCustomer.Id,
                            Name = item.ContactName,
                            Phone = item.Phone,
                            Email = item.Email
                        };
                    }
                }
                _unitOfWork.Commit();
            }
        }
    }

    public interface IMarketingResultService
    {
        void CreateMarketingResults(List<MarketingResult> requestList);
    }
}
