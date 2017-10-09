using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Data
{
    public class ProjectSeedData : DropCreateDatabaseIfModelChanges<APIProjectEntities>
    {
        protected override void Seed(APIProjectEntities context)
        {
            Stack<MarketingStage> stackList = new Stack<MarketingStage>();
            stackList.Push(new MarketingStage { Name = "Drafting", IsInitial = true });
            stackList.Push(new MarketingStage { Name = "Validating" });
            stackList.Push(new MarketingStage { Name = "Approving" });
            stackList.Push(new MarketingStage { Name = "Preparing" });
            stackList.Push(new MarketingStage { Name = "Executing" });
            stackList.Push(new MarketingStage { Name = "Finished" });

            InsertStage(context, stackList, null);
            IEnumerable<Staff> staffList = MockDataStaffs();
            context.Staffs.AddRange(staffList);

            context.Commit();
        }

        private void InsertStage(APIProjectEntities context, Stack<MarketingStage> stack, MarketingStage oldOne)
        {
            if (stack.Count != 0)
            {
                MarketingStage newOne = stack.Pop();
                if (newOne != null)
                {
                    if (oldOne != null)
                    {
                        newOne.NextStageId = oldOne.Id;
                    }
                    context.MarketingStages.Add(newOne);
                    context.Commit();
                    //recursive
                    InsertStage(context, stack, newOne);
                }
            }
        }

        private List<Staff> MockDataStaffs()
        {
            List<Staff> _list = new List<Staff>()
            {
                new Staff()
                {
                    FirstName = "Tung",
                    MiddleName ="Thanh",
                    LastName="Nguyen",
                    Username="tungnt",
                    Password="123456",
                    Phone="999-888-777",
                    Email="tungnt@gmail.com"
                },
                new Staff()
                {
                    FirstName = "A",
                    MiddleName ="B",
                    LastName="C",
                    Username="acb",
                    Password="123456",
                    Phone="888-888-777",
                    Email="acb@gmail.com"
                },
                new Staff()
                {
                    FirstName = "Quan",
                    MiddleName ="Huy",
                    LastName="Vu",
                    Username="quanvh",
                    Password="123456",
                    Phone="888-888-888",
                    Email="quanvh@gmail.com"
                }
            };
            return _list;
        }

        private List<Customer> MockDataCustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Name = "Cong ty A",
                    EstablishedDate = DateTime.Today.Date,
                    TaxCode = "111111111111",
                    IsLead = true,
                    Address = "ABC Street"
                },
                new Customer()
                {
                    Name = "Cong ty B",
                    EstablishedDate = DateTime.Today.Date,
                    TaxCode = "222222222222",
                    IsLead = false,
                    CustomerType = "Inside",
                    Address = "BCD Street"
                }
            };
        }




    }
}
