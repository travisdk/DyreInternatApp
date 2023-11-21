namespace DyreInternatApp.Models
{
    public class ShoppingCartItem
    {  
        public int ShoppingCartItemId { get; set; }
        public Animal Animal { get; set; } = default!;
        // quantity ?? - Not for now - Unique animals only

        public string? ShoppingCartId { get; set; }
    }
}