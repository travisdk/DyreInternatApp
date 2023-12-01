

using DyreInternatApp.Domain.Models;
namespace DyreInternatApp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(List<ShoppingCartItem> shoppingCartItems , decimal shoppingCartTotal)
        {
            ShoppingCartItems = shoppingCartItems;
            ShoppingCartTotal = shoppingCartTotal;
        }
        public List<ShoppingCartItem> ShoppingCartItems { get; }
        public decimal ShoppingCartTotal { get; }
    }
}
