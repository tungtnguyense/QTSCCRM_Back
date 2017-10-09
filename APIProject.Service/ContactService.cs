using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIProject.Model.Models;
using APIProject.Data.Repositories;
using APIProject.Data.Infrastructure;

namespace APIProject.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository _contactRepository, IUnitOfWork _unitOfWork)
        {
            this._contactRepository = _contactRepository;
            this._unitOfWork = _unitOfWork;
        }

        public void CreateContact(Contact contact)
        {
            _contactRepository.Add(contact);
            _unitOfWork.Commit();

            if (contact.IsMain)
            {
                SetMainContact(contact);
            }
        }

        private void SetMainContact(Contact mainContact)
        {
            IEnumerable<Contact> _list = _contactRepository.GetAll().Where(x => x.CustomerId == mainContact.CustomerId);
            foreach(Contact item in _list)
            {
                item.IsMain = false;
            }
            mainContact.IsMain = true;
            _unitOfWork.Commit();
        }

        public bool IsContactExist(int contactID)
        {
            return _contactRepository.GetById(contactID) != null;
        }
    }

    public interface IContactService
    {
        void CreateContact(Contact contact);
        bool IsContactExist(int contactID);
    }
}
