using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyApp.Data.Data;
using ToyApp.Web.Data.Interfaces;

namespace ToyApp.Web.Data.Logic
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext applicationDbContext,
            ShoppingCart shoppingCart)
        {
            _applicationDbContext = applicationDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _applicationDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Toy.ToyID,
                    OrderId = order.OrderId,
                    Price = (decimal)shoppingCartItem.Toy.UnitPrice
                };

                _applicationDbContext.OrderDetails.Add(orderDetail);
            }

            _applicationDbContext.SaveChanges();
        }

        
    }
}
