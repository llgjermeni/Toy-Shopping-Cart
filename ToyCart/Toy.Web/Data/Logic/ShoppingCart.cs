using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using ToyApp.Data.Data;

namespace ToyApp.Web.Data.Logic
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ShoppingCart(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        public void AddToCart(Toy toy, int amount)
        {
            var shoppingCartItem = _applicationDbContext
                .ShoppingCartItems.SingleOrDefault(
                s => s.Toy.ToyID == toy.ToyID && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem==null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Toy = toy,
                    Amount = 1
                };
                _applicationDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _applicationDbContext.SaveChanges();
        }

        public int RemoveFromCart(Toy toy)
        {
            var shoppingCartItem =
                                _applicationDbContext.ShoppingCartItems.SingleOrDefault(
                                    s => s.Toy.ToyID == toy.ToyID && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _applicationDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _applicationDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _applicationDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Toy)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _applicationDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _applicationDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _applicationDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _applicationDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Toy.UnitPrice * c.Amount).Sum();
            return (int)total;
        }

    }
}
