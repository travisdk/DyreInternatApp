using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using DyreInternatApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DyreInternatApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IAnimalRepository animalRepository, IShoppingCart shoppingCart)
        {
            _animalRepository = animalRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items  = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            ShoppingCartViewModel scVM = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
                      
            return View(scVM);
        }

        public RedirectToActionResult AddToShoppingCart(int animalId)
        {
            var selectedAnimal = _animalRepository.GetAnimalById(animalId);
            if (selectedAnimal != null)
            {
                _shoppingCart.AddToCart(selectedAnimal);

            }

           return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int animalId)
        {
            var selectedAnimal = _animalRepository.GetAnimalById(animalId);
            if (selectedAnimal!=null)
            {
                _shoppingCart.RemoveFromCart(selectedAnimal);
            }

            return RedirectToAction("Index");

        }
    }                                                                       
}
