using APIProject.Data.Infrastructure;
using APIProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Service
{
    public class SalesCategoryService : ISalesCategoryService
    {
        private readonly ISalesCategoryRepository _salesCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SalesCategoryService(ISalesCategoryRepository _salesCategoryRepository, IUnitOfWork _unitOfWork)
        {
            this._salesCategoryRepository = _salesCategoryRepository;
            this._unitOfWork = _unitOfWork;
        }

        public bool IsCategoryExist(int categoryId)
        {
            return _salesCategoryRepository.GetById(categoryId) != null;
        }
    }

    public interface ISalesCategoryService
    {
        bool IsCategoryExist(int categoryId);
    }
}
