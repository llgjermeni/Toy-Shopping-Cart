namespace ToyApp.Data.Data
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Toy Toy { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
