using Microsoft.EntityFrameworkCore;

namespace DyreInternatApp.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string? ShoppingCartId { get; set; } 

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetService<IHttpContextAccessor>()?.HttpContext?.Session;
            AppDbContext appDbContext = services.GetService<AppDbContext>() ?? throw new Exception("Error initializing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(appDbContext)
            {
                ShoppingCartId = cartId,
            };
        }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public void AddToCart(Animal animal)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Animal.AnimalId == animal.AnimalId
             && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null) // not already added
            {
                shoppingCartItem = new ShoppingCartItem
                {

                    Animal = animal,
                    ShoppingCartId = this.ShoppingCartId,
                };
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
                _appDbContext.SaveChanges();
            }

        }

        public void ClearCart() { 
            var cartItems = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _appDbContext.ShoppingCartItems.Include(sci => sci.Animal).ThenInclude(a => a.Race).Where(s=>s.ShoppingCartId  == ShoppingCartId)
              .ToList();   
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).
                 Select(s=>s.Animal.Price).Sum();
            return total;
        }

        public void RemoveFromCart(Animal animal)
        {
            var cartItem = _appDbContext.ShoppingCartItems.Where(s=>s.ShoppingCartId == ShoppingCartId &&
              s.Animal.AnimalId == animal.AnimalId).FirstOrDefault();
            if (cartItem != null)
            {
                _appDbContext.ShoppingCartItems.Remove(cartItem);
                _appDbContext.SaveChanges();
                
            }
        }
    }
}
