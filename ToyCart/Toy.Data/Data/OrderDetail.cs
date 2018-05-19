using System;
using System.Collections.Generic;
using System.Text;

namespace ToyApp.Data.Data
{
  public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Toy Toy { get; set; }
        public virtual Order Order { get; set; }
    }
}
