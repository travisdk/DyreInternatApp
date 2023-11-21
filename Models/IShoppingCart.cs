using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DyreInternatApp.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Animal animal);
        void RemoveFromCart(Animal animal);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set ; }

    }
}
