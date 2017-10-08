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
    public class StaffService:IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IStaffRepository staffRepository, IUnitOfWork unitOfWork)
        {
            this._staffRepository = staffRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool CheckTakenUsername(string username)
        {
            Staff _staff = _staffRepository.GetByUsername(username);
            return (_staff != null);
        }

        public void CreateStaff(Staff staff)
        {
            _staffRepository.Add(staff);
            _unitOfWork.Commit();
        }

        public void EditStaff(Staff staff)
        {
            _staffRepository.Update(staff);
            _unitOfWork.Commit();
        }

        public bool CheckStaffExist(int staffId)
        {
            return _staffRepository.GetById(staffId) != null;
        }
    }

    public interface IStaffService
    {
        void CreateStaff(Staff staff);
        void EditStaff(Staff staff);
        bool CheckTakenUsername(string username);
        bool CheckStaffExist(int staffId);
    }
}
