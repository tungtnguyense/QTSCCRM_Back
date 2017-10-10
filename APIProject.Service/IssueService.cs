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
    public class IssueService : IIssueService
    {

        private readonly IIssueRepository _issueRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string DraftingStageName = "Drafting";
        private readonly string OpenStageName = "Opening";
        public IssueService(IIssueRepository _issueRepository, IUnitOfWork _unitOfWork)
        {
            this._issueRepository = _issueRepository;
            this._unitOfWork = _unitOfWork;
        }

        public void CreateIssue(Issue issue, bool isFinished)
        {
            _issueRepository.Add(issue);
            issue.CreatedDate = DateTime.Today.Date;
            issue.Stage = DraftingStageName;

            if (isFinished)
            {
                issue.OpenById = issue.CreatedById;
                issue.OpenDate = issue.CreatedDate;
                issue.Stage = OpenStageName;
            }

            _unitOfWork.Commit();
        }

        public bool IsIssueExist(int id)
        {
            return _issueRepository.GetById(id) != null;
        }
    }

    public interface IIssueService
    {
        void CreateIssue(Issue issue, bool isFinished);
        bool IsIssueExist(int id);
    }
}
