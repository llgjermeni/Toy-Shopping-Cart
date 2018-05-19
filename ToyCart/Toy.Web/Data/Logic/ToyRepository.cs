using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyApp.Data.Data;
using ToyApp.Web.Data.Interfaces;

namespace ToyApp.Web.Data.Logic
{
    public class ToyRepository : IToyRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ToyRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Toy> Toys
        {
            get
            {
                return _applicationDbContext.Toys.Include(c => c.Category);
            }
        }

        public Toy GetToyById(int id)
        {
            return _applicationDbContext.Toys.FirstOrDefault(t => t.ToyID == id);
        }

        public IEnumerable<Toy> GetToys()
        {
            return _applicationDbContext.Toys.OrderBy(p=>p.ToyName);
        }
    }
}
