using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyApp.Data.Data;

namespace ToyApp.Web.Data.Interfaces
{
    public interface IToyRepository
    {
        IEnumerable<Toy> Toys { get; }
        IEnumerable<Toy> GetToys();
        Toy GetToyById(int id);
    }
}
