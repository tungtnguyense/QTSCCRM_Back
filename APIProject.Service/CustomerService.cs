using APIProject.Data.Infrastructure;
using APIProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIProject.Model.Models;

namespace APIProject.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository _customerRepository,
            IUnitOfWork _unitOfWork)
        {
            this._customerRepository = _customerRepository;
            this._unitOfWork = _unitOfWork;
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
            _unitOfWork.Commit();
        }

        public void EditLead(Customer customer)
        {
            Customer foundCustomer =_customerRepository.GetById(customer.Id);
            foundCustomer.Name = customer.Name;
            foundCustomer.EstablishedDate = customer.EstablishedDate;
            foundCustomer.TaxCode = customer.TaxCode;
            foundCustomer.Address = customer.Address;
            _unitOfWork.Commit();
        }

        public void EditCustomer(Customer customer)
        {
            Customer foundCustomer = _customerRepository.GetById(customer.Id);
            foundCustomer.CustomerType = customer.CustomerType;
            _unitOfWork.Commit();
        }
        
    }

    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        void EditLead(Customer customer);
        void EditCustomer(Customer customer);
    }
}