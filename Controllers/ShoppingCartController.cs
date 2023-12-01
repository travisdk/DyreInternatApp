using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DyreInternatApp.BL.Services;
using Microsoft.AspNetCore.Http.Features;
using DyreInternatApp.ViewModels;


namespace DyreInternatApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(ICartService shoppingCartService, IMapper mapper)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }
        public async Task< IActionResult> Index()
        {
            var (items, total) = await _shoppingCartService.GetShoppingCart();

            return View(new ShoppingCartViewModel(items, total));   
        }
        public async Task<RedirectToActionResult> AddToShoppingCart(int animalId)
        {
            await _shoppingCartService.AddToCart(animalId);
            return RedirectToAction("Index");
        }
        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int animalId)
        {
            await _shoppingCartService.RemoveFromCart(animalId);
            return RedirectToAction("Index");

        }
    }
}
