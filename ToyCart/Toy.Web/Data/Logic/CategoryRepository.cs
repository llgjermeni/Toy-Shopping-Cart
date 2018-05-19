using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyApp.Data.Data;
using ToyApp.Web.Data.Interfaces;

namespace ToyApp.Web.Data.Logic
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Category> Categories => _applicationDbContext.Categories;
    }
}
