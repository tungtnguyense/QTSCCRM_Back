using APIProject.Data.Infrastructure;
using APIProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(ICustomerRepository _customerRepository,
            IUnitOfWork _unitOfWork)
        {
            this._customerRepository = _customerRepository;
            this._unitOfWork = _unitOfWork;
        }
    }

    public interface ICustomerService
    {

    }
}
