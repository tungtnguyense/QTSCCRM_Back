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
            GetCategories().ForEach(c => context.Categories.Add(c));
            context.Commit();
        }
        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "Food",
                    isDelete = false,
                },
                new Category {
                    Name = "Drink",
                    isDelete = false,
                },
                new Category {
                    Name = "Snack",
                    isDelete = false,
                }
            };
        }
    }
}
