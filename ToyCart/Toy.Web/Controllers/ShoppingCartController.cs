using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ToyApp.Web.Data.Interfaces;
using ToyApp.Web.Data.Logic;
using ToyApp.Web.ViewModels;

namespace ToyApp.Web.Controllers
{
    [Authorize]
    public class ShoppingCartController: Controller
    {
        private readonly IToyRepository _toyRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IToyRepository toyRepository,
            ShoppingCart shoppingCart)
        {
            _toyRepository = toyRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int toyId)
        {
            var selectedToy = _toyRepository.Toys.FirstOrDefault(
                t => t.ToyID == toyId);

            if (selectedToy != null)
            {
                _shoppingCart.AddToCart(selectedToy, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedToy = _toyRepository.Toys.FirstOrDefault(
                t => t.ToyID == pieId);

            if (selectedToy != null)
            {
                _shoppingCart.RemoveFromCart(selectedToy);
            }
            return RedirectToAction("Index");
        }
    }
}
