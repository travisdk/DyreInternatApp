using DyreInternatApp.BL.Services;
using DyreInternatApp.SharedModels.Models;
using DyreInternatApp.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DyreInternatApp.Controllers
{

    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderController(IOrderService orderService, ICartService cartService, UserManager<ApplicationUser> userManager) {
            _cartService = cartService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Checkout()
        {
     

            var cartVM =  await _cartService.GetShoppingCart();

            var orderVM = new OrderVM();
            orderVM.CustomerId = _userManager.GetUserId(User);

            return View(orderVM);
        }



        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderVM orderVM)
        {
            if (ModelState.IsValid)
            {
                _orderService.Add(newOrder);

            }

            return View(orderVM);
        }
    }
}
