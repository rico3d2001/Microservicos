namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = string.Empty;
        public List<ShoppinCarItem> items { get; set; } = new();
        public ShoppingCart()
        {
            
        }

        public ShoppingCart(string userName)
        {
             userName = userName ?? string.Empty;
        }

        public decimal TotalPrice 
        {
            get 
            {
                decimal totalPrice = 0;
                foreach (var item in items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            } 
            
        }
    }
}
