using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyApp.Data.Data;
using ToyApp.Web.Data;
using ToyApp.Web.Data.Interfaces;
using ToyApp.Web.Data.Logic;
using ToyApp.Web.ViewModels;

namespace ToyApp.Web.Controllers
{
    public class ToysController: Controller
    {
        private readonly IToyRepository _toyRepository;
        private ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;

        public ToysController(IToyRepository toyRepository,
            ICategoryRepository categoryRepository, ApplicationDbContext context)
        {
            _toyRepository = toyRepository;
            _categoryRepository = categoryRepository;
            _context = context;
        }

        public IActionResult Index(string category)
        {
            IEnumerable<Toy> toys;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                toys = _toyRepository.Toys.OrderBy(t => t.ToyID);
                currentCategory = "All toys";
            }
            else
            {
                toys = _toyRepository.Toys.Where(t => t.Category
                     .CategoryName == category).OrderBy(t => t.ToyID);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(
                        c => c.CategoryName == category).CategoryName;
            }

            return View(new ToysViewModel
            {
                Toys = toys,
                CurrentCategory = currentCategory
            });
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Toy> toys;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                toys = _toyRepository.Toys.OrderBy(t => t.ToyID);
            }
            else
            {
                toys = _toyRepository.Toys.Where(t => t.ToyName.ToLower()
                  .Contains(_searchString.ToLower()));
            }
            return View("~/Views/Toys/Index.cshtml",
                new ToysViewModel
                {
                    Toys = toys,
                    CurrentCategory = "All toys"
                });
        }

       
        public IActionResult Details(int id)
        {
            var model = _toyRepository.GetToyById(id);

            if (model==null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
