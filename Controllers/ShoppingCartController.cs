using DyreInternatApp.SharedModels.Models;
using DyreInternatApp.DAL.Repositories;
using DyreInternatApp.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DyreInternatApp.BL.Services;

using AutoMapper;

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
            return View(await _shoppingCartService.GetShoppingCart());
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
