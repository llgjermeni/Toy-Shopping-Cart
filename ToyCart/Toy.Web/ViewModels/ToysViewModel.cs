using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyApp.Data.Data;

namespace ToyApp.Web.ViewModels
{
    public class ToysViewModel
    { 
        public IEnumerable<Toy> Toys { get; set; }
        public string CurrentCategory { get; set; }
    }
}
