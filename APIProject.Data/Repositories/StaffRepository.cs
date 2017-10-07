using APIProject.Data.Infrastructure;
using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Data.Repositories
{
    public class StaffRepository: RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Staff GetByUsername(string username)
        {

            return DbContext.Staffs.Where(x => x.Username == username).FirstOrDefault();
        }
    }
    public interface IStaffRepository: IRepository<Staff>
    {
        Staff GetByUsername(string username);
    }
}
